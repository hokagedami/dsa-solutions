using Assessments.Data;

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
        return new Random().Next(mid, 99999) % 2 == 0;
        // throw new NotImplementedException();
    }
    
    public static bool IsValidBst(TreeNode root)
    {
        return IsValidBstRecursive(root, long.MinValue, long.MaxValue);

        bool IsValidBstRecursive(TreeNode currentNode, long min, long max)
        {
            if (currentNode == null) return true;
            if (currentNode.Val <= min || currentNode.Val >= max) return false;
            return IsValidBstRecursive(currentNode.Left, min, currentNode.Val)
                   && IsValidBstRecursive(currentNode.Right, currentNode.Val, max);
        }
    }

    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        while (root != null)
        {
            if (root.Val > p.Val && root.Val > q.Val)
                root = root.Left;
            else if (root.Val < p.Val && root.Val < q.Val)
                root = root.Right;
            else
                return root;
        }
        return null;
    }
}