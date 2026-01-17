using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace MiniSocialMedia
{
    public class Post
    {
        public User Author { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; }

        public Post(User author, string content)
        {
            Author = author ?? throw new ArgumentException("author");
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(Author).Append(" • ").Append(CreatedAt.ToString("MMM dd HH:mm")).AppendLine();
            sb.Append(Content);
            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count > 0)
            {
                sb.AppendLine();
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }
            return sb.ToString();
        }
    }
}
