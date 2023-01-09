namespace Assessments.Leetcode
{
    public static class LongestPalindrome
    {
        public static int Solution(string s)
        {
            if (s.Length <= 1) return s.Length;
            var characters = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (characters.ContainsKey(c)) characters[c]++;
                else
                    characters.Add(c, 1);
            }
            var count = characters.Keys.Select(cx => characters[cx] / 2).Select(charCount => (charCount * 2)).Sum();
            return count < s.Length ? count + 1 : count;
        }
    }
}