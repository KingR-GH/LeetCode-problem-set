/*
根据每日 气温 列表，请重新生成一个列表，对应位置的输出是需要再等待多久温度才会升高超过该日的天数。如果之后都不会升高，请在该位置用 0 来代替。
例如，给定一个列表 temperatures = [73, 74, 75, 71, 69, 72, 76, 73]，你的输出应该是 [1, 1, 4, 2, 1, 1, 0, 0]。
提示：气温 列表长度的范围是 [1, 30000]。每个气温的值的均为华氏度，都是在 [30, 100] 范围内的整数。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/daily-temperatures
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/


/*
利用栈解决.
按索引遍历{
　　如果栈为空,将索引入栈,
　　如果栈不空,判断,当前索引对应的温度是否比栈顶索引对应的温度高,{
　　　　如果高则出栈,并计算索引差,所得结果存入返回数组对应的索引上,然后返回上一步重新比较栈顶元素和当前元素的大小
　　　　如果低则入栈。
　　}
}
*/

public class Solution {
    public int[] DailyTemperatures(int[] T) {
        int[] ret = new int[T.Length];
        Stack<int> stack = new Stack<int>();

        for(int i = 0; i < T.Length; i++){
            while(stack.Count != 0 && T[stack.Peek()]<T[i]){
                int temp = stack.Pop();
                ret[temp] = i-temp;
            }
            stack.Push(i);
        }

        return ret;
    }
}