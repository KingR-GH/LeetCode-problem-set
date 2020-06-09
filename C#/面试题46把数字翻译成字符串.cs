/*
给定一个数字，我们按照如下规则把它翻译为字符串：
0 翻译成 “a” ，1 翻译成 “b”，……，11 翻译成 “l”，……，25 翻译成 “z”。
一个数字可能有多个翻译。请编程实现一个函数，用来计算一个数字有多少种不同的翻译方法。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/ba-shu-zi-fan-yi-cheng-zi-fu-chuan-lcof
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/

/*
先将数字转换成字符串,
dp[i]代表,索引从0开始到i,所有字母翻译成字符串的种类数,

dp[0] = 1;
dp[1] = dp[0] + g(1)　　　　//g(1)代表,索引0和1的两个数字是否能构成一个字母,如果是返回1,不是返回0
dp[2] = dp[1] + dp[0]*g(2)　//g(2)代表,索引1和2的两个数字是否能构成一个字母,如果是返回1,不是返回0
....
dp[i] = dp[i-1] + dp[i-2]*g(i)　　////g(i)代表,索引i-1和i的两个数字是否能构成一个字母,如果是返回1,不是返回0

遍历字符串,从dp[0]开始依次求到dp[n-1](n为字符串长度),便得出答案
*/

public class Solution {
    public int TranslateNum(int num) {
        string s = num.ToString();
        int n = s.Length;
        if(n<2){
            return 1;
        }
        int[] dp = new int[n];

        dp[0] = 1;
        dp[1] = dp[0]+MyFunc(1,s);
        for(int i = 2;i<n;i++){
            dp[i] = dp[i-1] + dp[i-2]*MyFunc(i,s);
        }
        return dp[n-1];
    }

    public int MyFunc(int i,string s){
        if(s[i-1]=='1'||s[i-1]=='2'&&s[i]<'6'){
            return 1;
        }
        else{
            return 0;
        }
    }
}