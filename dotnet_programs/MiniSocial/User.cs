using System;
namespace MiniSocialMedia
{
    public partial class User:Ipostable, IComparable<User>
    {
        public string Username{get;init;}
        {
            public string Email{get;init;}
            private List<Post> _posts=new List<Post>();
            private HashSet<string> _following=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            public event Actio<Post> OnNewPost;
            public User(string username,string email)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty", nameof(username));
            }
                if(!Regex.IsMatch(email, @"^[^@+s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new SocialException("Invalid Email format");
                }
                    Username=username.Trim();
                    Email=email.Trime().ToLower();              
        }
        public void Follow(string username)
        {
            if(string.Equals(Username,username.Trim(),StringComparison.OrdinalIgnoreCase))
            {
                throw new SocialException("Cannot follow yourself");
            }
            _following.Add(usernmae.Trime());
        }
        public bool IsFollowing(string usernae)=>_following.Contains(username.Trim());
        
        public void AddPost(string content)
        {
                if(string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Post comment cannot be empty");
            }
            if(content.Length>280)
            {
                throw new SocialExceptio("Post too long (max 280 characters allowed)");
            }
            var post=new Post
        }
        }
    }
}