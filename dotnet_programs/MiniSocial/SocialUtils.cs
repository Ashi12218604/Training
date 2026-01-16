using System;

namespace MiniSocialMedia
{
    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime time)
        {
            var diff = DateTime.UtcNow - time;
            if (diff.TotalMinutes < 1) return "just now";
            if (diff.TotalMinutes < 60) return ((int)diff.TotalMinutes) + " min ago";
            if (diff.TotalHours < 24) return ((int)diff.TotalHours) + " h ago";
            return time.ToString("MMM dd");
        }
    }
}
