using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MiniSocialMedia
{
    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
        {
            if (user == null) return Enumerable.Empty<string>();
            var field = typeof(User).GetField("_following", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null) return Enumerable.Empty<string>();
            var value = field.GetValue(user) as IEnumerable<string>;
            return value ?? Enumerable.Empty<string>();
        }
    }
}
