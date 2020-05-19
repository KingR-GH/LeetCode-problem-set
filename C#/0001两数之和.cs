using System;
using System.Collections.Generic;
//给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
//你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Specialized;
using System.Data;
using System.Collections;

namespace CSharpTest
{

    class Program
    {

        static void Main(string[] args)
        {
        }

        static public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], i);
                }
            }
            for(int i = 0; i < nums.Length; i++)
            {
                int n = target - nums[i];
                if (dic.ContainsKey(n) && dic[n] != i)
                {
                    return new int[2] { dic[n], i };
                }
            }
            return null;
        }
    }


}


