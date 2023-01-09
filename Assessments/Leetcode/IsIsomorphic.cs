namespace Assessments.Leetcode
{
    public static class IsIsomorphic
    {
        public static bool Solution(string s, string t)
        {
            if(s.Length != t.Length) return false;

            var tracker = new Dictionary<char, char>();
            for (var i = 0; i < s.Length; i++)
            {
                if(tracker.TryGetValue(s[i], out var value))
                {
                    if (value != t[i]) return false;
                }
                else
                {
                    if (tracker.ContainsValue(t[i])) return false;
                    tracker.Add(s[i], t[i]);
                }
            }
            return true;
        }
    }
}
