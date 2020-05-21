//给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

/*
暴力算法

截取每一个子串 判断是否为回文串 输出其中最长的回文子串。



中心扩展

若回文串两侧的字符相同，则删去两侧字符后剩下的字符串仍为回文串。

我们可以反过来，对字符串中的某一位字符c(或某两位相邻的相同字符串cc)，

如果其两侧字符相同，则让它向两侧扩展，直到两侧字符不同，最后便获得了以c(或cc)为中心的回文字串。

对每一位都进行上述操作,便可获取最长的回文子串。*/


public class Solution {
    public string LongestPalindrome(string s)
    {
        if (s.Length < 2)
        {
            return s;
        }
        string result = "";
        int max = 0;
        int start = 0;
        //cbbd
        for (int i = 0; i < s.Length; i++)
        {
            int length1 = OneCentralExpansion(s, i);
            if (length1 > max)
            {
                max = length1;
                start = i - (max - 1) / 2;
            }
            if (i < s.Length - 1 && s[i] == s[i+1])
            {
                int length2 = TwoCentralExpansion(s, i);

                if (length2 > max)
                {
                    max = length2;
                    start = i - (max - 1) / 2;
                }
            }
        }
        result = s.Substring(start, max);
        return result;
    }

    /// <summary>
    /// 单字符扩展
    /// </summary>
    /// <param name="s">原字符串</param>
    /// <param name="center">子串中心字符的索引</param>
    /// <returns>回文子串长度</returns>
    public int OneCentralExpansion(string s,int center)
    {
        int result = 1;
        int left = center - 1;
        int right = center + 1;
        while (left >= 0 && right < s.Length)
        {
            if (s[left--] == s[right++])
            {
                result += 2;
            }
            else
            {
                break;
            }
        }
        return result;
    }

    /// <summary>
    /// 双字符扩展
    /// </summary>
    /// <param name="s">原字符串</param>
    /// <param name="center">子串中心字符串的第一个字符的索引</param>
    /// <returns>回文子串长度</returns>
    public int TwoCentralExpansion(string s, int center)
    {
        int result = 1 +1;
        int left = center - 1;
        int right = center + 1  +1;
        while (left >= 0 && right < s.Length)
        {
            if (s[left--] == s[right++])
            {
                result += 2;
            }
            else
            {
                break;
            }
        }
        return result;
    }
}