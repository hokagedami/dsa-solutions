using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments.Leetcode
{
    public static class ProductExceptSelf
    {
        public static int[] Solution(int[] nums)
        {
            var result = new int[nums.Length];

            // prefix
            var currentProduct = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = currentProduct;
                currentProduct *= nums[i];
            }

            // postfix
            currentProduct = 1;
            for (int i = nums.Length - 1; i > -1; i--)
            {
                result[i] *= currentProduct;
                currentProduct *= nums[i];
            }

            return result;
        }
    }
}
