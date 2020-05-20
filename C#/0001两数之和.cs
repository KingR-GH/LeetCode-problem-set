//暴力算法,双循环迭代，即可找到满足条件的数组下标，时间复杂度为O(n2)。

//优化算法，可以利用哈希表（C#用字典）在第一次迭代时先存储数组的数据，
//这样第二次迭代检索数据时可以利用索引快速查找，实现了用空间换时间。

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
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
                return new int[2] { i, dic[n] };
            }
        }
        return null;
    }
}


