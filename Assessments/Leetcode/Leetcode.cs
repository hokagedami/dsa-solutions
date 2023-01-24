using System.Collections;

namespace Assessments.Leetcode;

public static class Leetcode
{
    public static bool ContainsDuplicateSolutionOne(int[] numbers)
    {
        var uniques = new Hashtable();
        foreach (var number in numbers)
        {
            if (uniques.ContainsKey(number))
                return true;
            uniques.Add(number, 1);
        }
        return false;
    }

    public static bool ContainsDuplicateSolutionTwo(int[] numbers)
    {
        var uniques = new HashSet<int>();
        return numbers.Select(number => uniques.Add(number)).Any(alreadyAdded => !alreadyAdded);
    }
    
    public static int MaximumProductSubArray(int[] nums)
    {
        var result = 1;
        var currentProduct = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            currentProduct *= nums[i];
            result = Math.Max(result, currentProduct);
        }
        return result;
    }
    
    public static int MaximumSubArray(int[] nums)
    {
        var result = nums[0];
        var currentSum = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (currentSum < 0) currentSum = 0;
            currentSum += nums[i];
            result = Math.Max(result, currentSum);
        }
        return result;
    }
    
    public static int[] ProductOfArrayExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        // product of members to the left
        var product = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = product;
            product *= nums[i];
        }
        // product of members to the right
        product = 1;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= product;
            product *= nums[i];
        }
        return result;
    }
    
    public static int StockBestTimeSolutionOne(int[] prices)
    {
        var maxProfit = 0;
        var minProfit = prices[0];
        for (var i = 0; i < prices.Length - 1; i++)
        {
            var currentPrice = prices[i];
            if (currentPrice < minProfit)
                minProfit = currentPrice;
            else
            {
                var currentProfit = currentPrice - maxProfit;
                if (currentProfit > maxProfit)
                    maxProfit = currentProfit;
            }
        }
        return maxProfit;
    }
    
    public static int StockBestTimeSolutionTwo(int[] prices)
    {
        var maxProfit = 0;
        int start = 0, end = 1;
        while (end < prices.Length)
        {
            var currentPrice = prices[start];
            var possibleSellPrice = prices[end];
            var profit = possibleSellPrice - currentPrice;
            if (Math.Sign(profit) == -1)
                start = end;
            maxProfit = Math.Max(maxProfit, profit);
            end++;
        }
        return maxProfit;
    }
    
    public static int[] TwoSums(int[] numbers, int target)
    {
        var numberHashTable = new Hashtable();
        for (var i = 0; i < numbers.Length; i++)
        {
            var difference = target - numbers[i];
            if (numberHashTable.ContainsKey(difference))
            {
                var savedIndex = Convert.ToInt32(numberHashTable[difference]);
                return new[] { savedIndex, i };
            }
            numberHashTable.Add(numbers[i], i);
        }
        return Array.Empty<int>();
    }

    public static int SearchInRotatedSortedArray(int[] nums, int target)
    {
        var start = 0;
        var end = nums.Length - 1;

        while (start <= end)
        {
            if (nums[start] == target)
                return start;
            
            if (nums[end] == target)
                return end;
            
            if (nums[start] != target)
                start++;
            
            if (nums[end] != target)
                end--;
        }
        return -1;
    }

    public static int FindMinimumInRotatedSortedArray(int[] nums)
    {
        int start = 0, end = nums.Length - 1;
        var midPoint = nums.Length / 2;
        var min = nums[0];
        while (start <= end)
        {
            if (nums[start] < nums[end])
                return Math.Min(min, nums[start]);

            midPoint = (start + end) / 2;
            min = Math.Min(min, nums[midPoint]);
            if (nums[midPoint] >= nums[start])
                start = midPoint + 1;
            else
                end = midPoint - 1;
        }
        return midPoint;
    }

    public static int Fib(int n)
    {
        switch (n)
        {
            case 0:
                return n;
            case 1:
            case 2:
                return 1;
            default:
                int n1 = 1, n2 = 1;
                for (var i = 2; i < n; i++)
                {
                    var sum = n1 + n2;
                    n1 = n2;
                    n2 = sum;
                }
                return n2;
        }
    }
}