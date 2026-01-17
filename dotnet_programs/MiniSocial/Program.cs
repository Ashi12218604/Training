using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MiniSocialMedia
{
    public class Program
    {
        static Repository<User> _users = new();
        static User? _currentUser = null;
        static readonly string _dataFile = "social-data.json";

        public static void Main()
        {
            Console.Title = "MiniSocial - Console Edition";
            Console.WriteLine("=== MiniSocial ===");
            LoadData();

            while (true)
            {
                try
                {
                    if (_currentUser == null) ShowLoginMenu();
                    else ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    ConsoleColorWrite(ConsoleColor.Red, "Error: " + ex.Message);
                    if (ex.InnerException != null) Console.WriteLine(ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error!!");
                    Console.WriteLine(ex);
                }
                // Console.WriteLine("Press any key to continue...");
                // Console.ReadKey(true);
                // Console.Clear();
                // Console.WriteLine("=== MiniSocial ===");
            }
        }

        static void ShowLoginMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            var choice = Console.ReadLine();
            if (choice == "1") Register();
            else if (choice == "2") Login();
            else if (choice == "9") { SaveData(); Environment.Exit(0); }
            else Console.WriteLine("Invalid choice");
        }

        static void Register()
        {
            Console.Write("Username: ");
            var u = Console.ReadLine();
            Console.Write("Email: ");
            var e = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(u) || string.IsNullOrWhiteSpace(e))
                throw new SocialException("Username and email required");
            if (_users.Find(x => string.Equals(x.Username, u.Trim(), StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");
            var user = new User(u, e);
            _users.Add(user);
            Console.WriteLine("Welcome " + user);
        }

        static void Login()
        {
            Console.Write("Username: ");
            var u = Console.ReadLine();
            var user = _users.Find(x => string.Equals(x.Username, u, StringComparison.OrdinalIgnoreCase));
            if (user == null) throw new SocialException("User not found");
            _currentUser = user;
            Console.WriteLine("Logged in as " + user + "!");
            _currentUser.OnNewPost += p =>
            {
                var text = p.Content.Length > 40 ? p.Content.Substring(0, 40) + "..." : p.Content;
                Console.WriteLine("[New Post] " + p.Author + " : " + p.Content);
            };
        }

        private static void ShowMainMenu()
        {
            if (_currentUser == null) return;

            Console.WriteLine("Logged in as " + _currentUser.GetDisplayName());
            Console.WriteLine("1. Post message");
            Console.WriteLine("2. View my posts");
            Console.WriteLine("3. View timeline");
            Console.WriteLine("4. Follow user");
            Console.WriteLine("5. List users");
            Console.WriteLine("6. Logout");
            Console.WriteLine("0. Exit and save");
            var choice = Console.ReadLine();
            if (choice == "1") PostMessage();
            else if (choice == "2") ViewPosts();
            else if (choice == "3") ShowTimeline();
            else if (choice == "4") FollowUser();
            else if (choice == "5") ListUsers();
            else if (choice == "6") { _currentUser = null; SaveData(); }
            else if (choice == "0") { SaveData(); Environment.Exit(0); }
            else Console.WriteLine("Invalid choice");
        }

        static void PostMessage()
        {
            if (_currentUser == null) return;
            Console.WriteLine("Write your post (max 280 characters, empty to cancel):");
            var content = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Post cancelled");
                return;
            }
            _currentUser.AddPost(content);
            Console.WriteLine("Post published successfully");
        }

        static void ViewPosts()
        {
            if (_currentUser == null) return;
            Console.WriteLine("=== My Posts ===");
            ShowPosts(_currentUser.GetPosts());
        }

        static void ShowTimeline()
        {
            if (_currentUser == null) return;
            var timeline = new List<Post>();
            timeline.AddRange(_currentUser.GetPosts());

            foreach (var u in _currentUser.GetFollowingNames())
            {
                var user = _users.Find(x => string.Equals(x.Username, u, StringComparison.OrdinalIgnoreCase));
                if (user != null) timeline.AddRange(user.GetPosts());
            }

            timeline.Sort((a, b) => b.CreatedAt.CompareTo(a.CreatedAt));
            Console.WriteLine("=== Your Timeline ===");
            ShowPosts(timeline);
        }

        private static void ShowPosts(IEnumerable<Post> posts)
        {
            int count = 0;
            foreach (var post in posts)
            {
                if (count == 20) break;
                Console.WriteLine(post.ToString());
                Console.WriteLine(post.CreatedAt.FormatTimeAgo());
                Console.WriteLine("--------------------------------");
                count++;
            }
            if (count == 0) Console.WriteLine("No posts yet.");
        }

        static void FollowUser()
        {
            if (_currentUser == null) return;
            Console.Write("Enter username to follow: ");
            var name = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Cancelled.");
                return;
            }
            var user = _users.Find(x => string.Equals(x.Username, name, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            try { _currentUser.Follow(name); }
            catch (SocialException ex) { Console.WriteLine(ex.Message); return; }
            Console.WriteLine("Now following @" + name);
        }

        static void ListUsers()
        {
            Console.WriteLine("Registered users:");
            var users = _users.GetAll().OrderBy(u => u.Username, StringComparer.OrdinalIgnoreCase);
            foreach (var u in users)
            {
                Console.WriteLine("@" + u.Username.PadRight(20) + " " + u.Email);
            }
        }

        static void SaveData()
        {
            try
            {
                var data = _users.GetAll().Select(u => new
                {
                    Username = u.Username,
                    Email = u.Email,
                    Following = u.GetFollowingNames().ToList(),
                    Posts = u.GetPosts().Select(p => new { p.Content, p.CreatedAt }).ToList()
                });
                var json = System.Text.Json.JsonSerializer.Serialize(data, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_dataFile, json);
                Console.WriteLine("Data saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save data.");
                Console.WriteLine(ex);
            }
        }

        static void LoadData()
        {
            try
            {
                if (!File.Exists(_dataFile)) return;
                var json = File.ReadAllText(_dataFile);
                if (string.IsNullOrWhiteSpace(json)) return;
                var data = System.Text.Json.JsonSerializer.Deserialize<List<dynamic>>(json);
                Console.WriteLine("Data loaded (simulation - add proper logic).");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load data.");
                Console.WriteLine(ex);
            }
        }

        private static void ConsoleColorWrite(ConsoleColor color, string text)
        {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = c;
        }
    }
}
