//题目：给定一个非空字符串s,最多删除一个字符。判断能否成为回文字符串。


//判断回文串,可使用头尾双指针。因为回文串满足以下条件，若回文串两侧的字符相同，则删去两侧字符后剩下的字符串仍为回文串。

//本题的特殊要求是，最多可以删除一个字符，所以双指针向中间行进的过程中可以有一次删除相异字符的机会，
//因为头尾指针的两个字符不同，所以可以删掉头字符，或者删掉尾字符，
//分别判断两种情况下的字符串是否为回文串即可。


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