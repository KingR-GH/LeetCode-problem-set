//给定一个非空字符串 s，最多删除一个字符。判断是否能成为回文字符串。
public class Solution {
     public bool ValidPalindrome(string s)
    {
        if (s.Length < 2) return true;
        int i = 0;
        int j = s.Length - 1;
        while( i < j)
        {
            if(s[i] != s[j])
            {
                return IsPalindrome(s, i+1, j) || IsPalindrome(s, i, j-1);
            }
            ++i;
            --j;
        }
        return true;
    }
    public bool IsPalindrome(string s, int i ,int j)
    {
        while (i < j)
        {
            if (s[i++] != s[j--])
            {
                return false;
            }
        }
        return true;
    }
}