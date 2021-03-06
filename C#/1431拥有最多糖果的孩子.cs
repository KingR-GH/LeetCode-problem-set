﻿/*给你一个数组 candies 和一个整数 extraCandies ，其中 candies[i] 代表第 i 个孩子拥有的糖果数目。
对每一个孩子，检查是否存在一种方案，将额外的 extraCandies 个糖果分配给孩子们之后，此孩子有 最多 的糖果。
注意，允许有多个孩子同时拥有 最多 的糖果数目。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/kids-with-the-greatest-number-of-candies
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/

/*
贪心算法,找到最大值,用最大值减去额外糖果数量,小于这个结果的不可能获得最多糖果
*/
public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        List<bool> ret = new List<bool>();
        int max = 0;
        for(int i = 0; i < candies.Length; i++){
            if(max < candies[i]){max = candies[i];}
        }
        for(int i = 0; i < candies.Length; i++){
            ret.Add((max - extraCandies) <= candies[i]);
        }
        return ret;
    }
}