using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments.Leetcode
{
    public static class PivotIndex
    {
        public static int Solution(int[] nums)
        {
            var leftSum = 0;
            var rightSum = nums.Sum();

            for (var i = 0; i < nums.Length; i++)
            {
                if (leftSum == rightSum - nums[i]) return i;
                leftSum += nums[i];
                rightSum -= nums[i];
            }
            return -1;
        }
    }
}
