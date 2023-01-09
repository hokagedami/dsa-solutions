namespace Assessments.Leetcode
{
    public static class IsSubsequence
    {
        public static bool Solution(string s, string t)
        {
            var counter = 0;
            foreach (var ch in t)
            {
                if (counter == s.Length) return true;
                if (s[counter] == ch) counter++;
            }
            return counter == s.Length;
        }
    }
}