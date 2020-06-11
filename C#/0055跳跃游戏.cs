/*
给定一个非负整数数组，你最初位于数组的第一个位置。
数组中的每个元素代表你在该位置可以跳跃的最大长度。
判断你是否能够到达最后一个位置。
*/


/*
贪心算法
从起点开始遍历直到所能到达的最远位置,
过程中更新所能到达的最远索引,如果能到达的最远索引大于终点则返回真,否则为假
*/

public class Solution {
    public bool CanJump(int[] nums) {
        int maxIndex = nums[0];
        int tempLength;
        for(int i = 0; i <= maxIndex; i++){
            tempLength = nums[i];
            if( i + tempLength > maxIndex){
                maxIndex = i + tempLength;
            }
            if(maxIndex >= nums.Length - 1){
                return true;
            }
        }
        return false;
    }
}