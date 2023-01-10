namespace Assessments.Leetcode;

public static class BinarySearch
{
    public static int Solution(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] == target) return mid;
            left = target > nums[mid] ? mid + 1 : left;
            right = target > nums[mid] ? right : mid - 1;
        }
        return -1;
    }
    
    public static int FirstBadVersionSolution(int n)
    {
        var left = 1;
        var right = n;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (IsBadVersion(mid))
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }

    private static bool IsBadVersion(int mid)
    {
        throw new NotImplementedException();
    }
}