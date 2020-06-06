/*
给定一个未排序的整数数组，找出最长连续序列的长度。
要求算法的时间复杂度为 O(n)。
*/

/*
找到连续数字集合的起点,然后对数字进行加1操作,直到该数字不存在与数组中为止,然后判断该连续数字集合的长度是否为最长
可以利用哈希表查找数字是否存在,减少时间复杂度.
*/

public class Solution {
    List<int> list = new List<int>();    
    public int LongestConsecutive(int[] nums) {
        
        for(int i = 0; i < nums.Length; i++){
            if(!list.Contains(nums[i])){
                list.Add(nums[i]);
            }
        }

        int max = 0;
        int num = 0;
        int length = 0;

        foreach(int i in list){
            num = i;
            length = 1;
            if(!list.Contains(num-1)){
                while(list.Contains(num+1)){
                    num++;
                    length++;
                }
            }
            max = Math.Max(length,max);
        }

        return max;
    }
}

