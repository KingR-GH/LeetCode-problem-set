//题目：给定一个非空字符串s,最多删除一个字符。判断能否成为回文字符串。


//判断回文串,可使用头尾双指针。因为回文串满足以下条件，若回文串两侧的字符相同，则删去两侧字符后剩下的字符串仍为回文串。

//本题的特殊要求是，最多可以删除一个字符，所以双指针向中间行进的过程中可以有一次删除相异字符的机会，
//因为头尾指针的两个字符不同，所以可以删掉头字符，或者删掉尾字符，
//分别判断两种情况下的字符串是否为回文串即可。
class Solution {
public:
    bool validPalindrome(string s) {
        int left = 0;
        int right = s.length() - 1;
        while(left < right){
            if(s[left] == s[right]){
                left++;
                right--;
            }
            else{
                return isPalindrome(s,left,right-1)||isPalindrome(s,left+1,right);
            }
        }
        return true;
    }
    
	bool isPalindrome(string s,int left,int right){
		while(left < right){
			if(s[left++]!=s[right--]){
				return false;
			}
		}
        return true;
    }
};