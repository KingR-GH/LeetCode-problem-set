//给定一个整数数组 A，返回其中元素之和可被 K 整除的（连续、非空）子数组的数目。


/*
利用前缀和,只要统计前缀和之差可被K整除的子数组的个数即可,

根据同余定理，两个前缀和a和b,若满足a-b能够被K整除，那么整数a与b对模K同余,
于是可以根据同余的前缀和的数量,得到可被K整除的子数组数。
*/

public class Solution {
    Dictionary<int, int> dic = new Dictionary<int, int>();
    public int SubarraysDivByK(int[] A, int K)
    {
        int[] B = new int[A.Length+1];
        int temp = 0;
        B[0] = 0;
        dic.Add(0, 1);
        for (int i = 0; i < A.Length; i++)
        {
            B[i + 1] = B[i] + A[i];
            temp = B[i + 1] % K;
            if (temp < 0)
            {
                temp += K;
            }
            if (dic.ContainsKey(temp))
            {
                dic[temp]++;
            }
            else
            {
                dic.Add(temp, 1);
            }
        }
        int result = 0;
        foreach (var item in dic)
        {
            result += item.Value * (item.Value - 1) / 2;
        }
        return result;
    }
}