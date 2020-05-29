//你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，
//如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。
//给定一个代表每个房屋存放金额的非负整数数组，计算你 不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。

/*
按照数组顺序偷,将每个房子累计可能偷到的最大值记录下来,
到第0个房子累计偷到的最大值Value[0] = nums[0]
到第1个房子累计偷到的最大值Value[1] = Max( Value[0],nums[1])
到第2个房子累计偷到的最大值Value[2] = Max( Value[1], Value[0]+nums[2])
到第3个房子累计偷到的最大值Value[3] = Max( Value[2], Value[1]+nums[3])
......

到第i个房子累计偷到的最大值Value[i] = Max( Value[i-1], Value[i-2]+nums[i])

Value数组可以不声明,因为Value[i-1],Value[i-2]的值可以用2个变量动态保存,减少空间复杂度
*/

public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if(n==0){return 0;}
        if(n==1){return nums[0];}

        int nonExcept = nums[0];
        int except = Math.Max(nums[1],nonExcept);
        for(int i = 2; i < n; i++){
            int temp = except;
            except = Math.Max(except,nonExcept+nums[i]);
            nonExcept = temp;
        }
        return except;
    }
}