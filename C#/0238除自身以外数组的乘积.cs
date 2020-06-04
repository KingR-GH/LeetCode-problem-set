/*
给你一个长度为 n 的整数数组 nums，其中 n > 1，返回输出数组 output ，其中 output[i] 等于 nums 中除 nums[i] 之外其余各元素的乘积。
来源：力扣（LeetCode）

链接：https://leetcode-cn.com/problems/product-of-array-except-self
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/


/*
如果不限制使用除法,
res[n] = nums[0] * nums[1] * .....* nums[nums.Lenght-1] / nums[n];
由于限制除法
res[n] = nums[0] * nums[1] *....* nums[n-1] * nums[n+1] * num[n+2] * ......* nums[nums.Lenght-1];
可以用两个数组分别存储n取不同值时 nums[0] * nums[1] *....* nums[n-1]  和 nums[n+1] * num[n+2] * ......* nums[nums.Lenght-1] 这两组信息
即，从左向右的累乘结果，以及从右向左的累乘结果。
求res[n]时,则用 left[n-1] * right[n+1]即可得。
另外需要考虑n处于最左端和最右端时的边界情况。
*/
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] l = new int[nums.Length];
        int[] r = new int[nums.Length];

        l[0] = nums[0];
        r[nums.Length-1] = nums[nums.Length-1]; 

        for(int i = 1; i < nums.Length; i++){
            l[i] = l[i-1]*nums[i];
        }
        for(int i = nums.Length - 2; i >=0 ; i--){
            r[i] = r[i+1]*nums[i];
        }
        nums[0] = r[1];
        nums[nums.Length-1] = l[nums.Length-2];
        for(int i = 1; i < nums.Length-1; i++){
            nums[i] = l[i-1] * r[i+1];
        }

        return nums;
    }
}