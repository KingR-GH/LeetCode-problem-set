using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "leetcodeisgreat";
            Console.WriteLine(Solution.FindTheLongestSubstring(s));
            Console.ReadLine();
        }
    }
    /*对于字符串的第i位,存储从第0位开始到第i位的 a\e\i\o\u的出现次数的奇偶信息(以下简称奇偶信息) 0代表字符出现偶数次,1代表出现奇数次。
     * 对于a,e,i,o,u五个字符的出现次数的奇偶信息,整合成一个五位二进制数字,该数字的每位都对应一个字符的奇偶信息,
     * 
     * 奇偶信息从(00000)B到(11111)B,共有32种。 
     * 于是设立一个长度为32的数组，对每一位字符串获取它的奇偶信息作为数组的脚标,存储的信息是字符串当前的位数.
     * 
     * 对于所有满足aeiou为偶数(以下简称满足条件)的子串,串首和串尾对应的奇偶信息是一致的,
     * 遍历字符串时,对于上述的数组来说,如果某一数组的元素(脚标对应一种奇偶信息)若已经存储了信息,
     * 说明这种奇偶状态之前出现过,于是当前位置脚标和之前状态对应的脚标之间的子串满足的条件,记录该子串的长度,
     * 遍历字符串的过程中出现长度更大的满足条件的子串,就更新信息,最后输出最大长度.
     */
    public static class Solution
    {
        static public int FindTheLongestSubstring(string s)
        {
            int result = 0;
            int[] vowelInfo = new int[32];
            for(int i = 0; i < vowelInfo.Length; i++)
            {
                vowelInfo[i] = -1;
            }
            int infoIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'a':
                        {
                            infoIndex ^= 1;
                            break;
                        }
                    case 'e':
                        {
                            infoIndex ^= 2;
                            break;
                        }
                    case 'i':
                        {
                            infoIndex ^= 4;
                            break;
                        }
                    case 'o':
                        {
                            infoIndex ^= 8;
                            break;
                        }
                    case 'u':
                        {
                            infoIndex ^= 16;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }//更新第i位的奇偶信息
                if (vowelInfo[infoIndex] == -1)
                {
                    vowelInfo[infoIndex] = i;
                }
                else if(i - vowelInfo[infoIndex] > result)
                {
                    result = i - vowelInfo[infoIndex];
                }
            }
            return result;
        }
    }
}