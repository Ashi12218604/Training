using System;

namespace LibrarySystem
{
    public enum UserRole { Admin, Librarian, Member }
    public enum ItemStatus { Available, Borrowed, Reserved, Lost }

    namespace Items
    {
        public abstract class LibraryItem
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int ItemID { get; set; }
            public abstract void DisplayDetails();
            public abstract double CalculateLateFee(int days);
        }

        public interface IReservable
        {
            void Reserve();
        }

        public interface INotifiable
        {
            void Notify(string message);
        }

        public class Book : LibraryItem, IReservable, INotifiable
        {
            void IReservable.Reserve() => Console.WriteLine("Book reserved successfully.");
            void INotifiable.Notify(string message) => Console.WriteLine($"Notification message sent: {message}");

            public override void DisplayDetails()
            {
                Console.WriteLine("Item Type: Book");
                Console.WriteLine($"Title: {Title}, Author: {Author}, ID: {ItemID}");
            }

            public override double CalculateLateFee(int days) => days * 1.0;
        }

        public class Magazine : LibraryItem
        {
            public override void DisplayDetails()
            {
                Console.WriteLine("Item Type: Magazine");
                Console.WriteLine($"Title: {Title}, Author: {Author}, ID: {ItemID}");
            }

            public override double CalculateLateFee(int days) => days * 0.5;
        }

        public class eBook : LibraryItem
        {
            public override void DisplayDetails()
            {
                Console.WriteLine("Item Type: eBook");
                Console.WriteLine($"Title: {Title}, Author: {Author}, ID: {ItemID}");
            }

            public override double CalculateLateFee(int days) => 0;

            public void Download() => Console.WriteLine("eBook downloaded successfully.");
        }
    }

    namespace Users
    {
        public class Member
        {
            public string Name { get; set; }
            public UserRole Role { get; set; }

            public void SendRoleBasedNotification()
            {
                if (Role == UserRole.Admin)
                    Console.WriteLine("Admin system alert: System maintenance scheduled.");
                else
                    Console.WriteLine("Member borrowing update: Your borrowed item is due tomorrow.");
            }
        }
    }

    public partial class LibraryAnalytics { public static int TotalBorrowed { get; set; } }
    public partial class LibraryAnalytics 
    { 
        public static void ShowAnalytics() => Console.WriteLine($"Total Items Borrowed: {TotalBorrowed}");
    }
}