/*
求 1+2+...+n ，要求不能使用乘除法、for、while、if、else、switch、case等关键字及条件判断语句（A?B:C）。
*/

/*
不让用乘除,不让用for while if else switch case
首先想到递归,递归需要有终止条件,
可以利用&&的特性,左边为false,来屏蔽掉右边的代码,来实现终止功能.
*/

public class Solution {
    public int SumNums(int n) {
        bool flag = n > 0 && (n += SumNums(n - 1)) > 0;
        return n;
    }
}