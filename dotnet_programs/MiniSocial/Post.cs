using System;
namespace MiniSocialMedia
{
    public class Post
    {
        public User Author{get;init;}
        public string Content{get;init;}
        public DateTime CreatedAt{get;set;}=DateTime.UtcNow;
        public Post(user author, string content)
        {
            Author=author?? throw new ArgumentNullException(nameof(author));
            Content=content;
            public override string ToString()
        {
            var sb=new System.Text.StringBuilder();
            sb.AppendLine($"{Author} {CreatedAt:MMM dd HH:mm }");
            sb.AppendLine(Content);
            var hashtags=Regex.Matches(Content, @"#\w+");
            if(hastags.Count>0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(",", hashtags.Cast<Match>().Select(m =>m.Value));
            }
            returnn sb.ToString()>TrimEnd();
        }
        }
    }
    
    
    public class Repository<T> where T:class

{
    private readonly List<T> _items=new List<T>();
    public void Add(T item)=> _items.Add(item);
    public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
    public T Find(Predicate<T> match)=> _items.Find(match);
}
}