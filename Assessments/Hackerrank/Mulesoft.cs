using System.Text;

namespace Assessments.Hackerrank;

public static class Mulesoft
{
    public static string CompressedString(string message)
    {
        Console.WriteLine(message);
        if (message.Length <= 1) return message;
        var result = new StringBuilder();
        var count = 1;
        for (var i = 1; i < message.Length; i++)
        {
            var current = message[i];
            var previous = message[i - 1];
            if (current == previous)
                count++;
            else
            {
                result.Append(previous);
                if (count > 1)
                    result.Append(count);
                count = 1;
            }
        }

        result.Append(message[^1]);
        if (count > 1)
            result.Append(count);
        return result.ToString();
    }
    
    public static int PalindromeSubstringCount(string s)
    {
        return CountPalSeq(s, 0, s.Length - 1, new int[s.Length, s.Length]);
    }

    private static bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end])
                return false;
            ++start;
            --end;
        }
        return true;
    }

    private static int ExtendPalindrome(string s, int left, int right)
    {
        var result = 0;
        while (left >= 0 && right < s.Length)
        {
            if(s[left] != s[right]) break;
            left--;
            right++;
            result++;
        }
        return result;
    }
    
    private static int CountPalSeq(string s, int start, int end, int[,] dp)
    {
        if(start == end) return 1;
        if(start > end) return 0;
        if(dp[start, end] != 0) return dp[start, end] ;
        
        int result;
        if(s[start] == s[end])
        {
            int left = start, right = end;
            while(s[++left] != s[start]);
            while(s[--right] != s[start]);
                 
            if(left > right) result = CountPalSeq(s, start + 1, end - 1, dp) * 2 + 2;  
            else if(left == right) result = CountPalSeq(s, start + 1, end - 1, dp) * 2 + 1;  
            else result = CountPalSeq(s, start + 1, end - 1, dp) * 2 - 
                          CountPalSeq(s, left + 1, right - 1, dp); 
        }
        else result = CountPalSeq(s, start + 1, end, dp) + 
                      CountPalSeq(s, start, end - 1, dp) - 
                      CountPalSeq(s, start + 1, end - 1, dp);
        
        return dp[start, end]  = result < 0 ? result + 1_000_000_007 : result % 1_000_000_007;
    }
}