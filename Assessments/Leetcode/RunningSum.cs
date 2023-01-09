using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments.Leetcode
{
    public static class RunningSum
    {
        public static int[] Solution(int[] nums)
        {
            var result = new int[nums.Length];
            var runningSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                runningSum+= nums[i];
                result[i] = runningSum;
            }            
            return result;
        }
    }
}
