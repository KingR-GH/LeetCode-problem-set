//给你一个字符串 s ，请你返回满足以下条件的最长子字符串的长度：每个元音字母，即 'a'，'e'，'i'，'o'，'u' ，在子字符串中都恰好出现了偶数次。;

/*
条件: 每个元音字母,'a','e','i','o','u',在子字符串中都恰好出现了偶数次
 
在前缀和中存储某个元音字母出现次数的奇偶性, 
若某一区间两侧的前缀和相同,则代表该字母在对应的区间内出现的次数为偶数次(奇数-奇数 = 偶数,偶数-偶数=偶数)。
同理,若前缀和中存储的是所有元音字母出现次数的奇偶性,那么对于两侧前缀和相同的区间,内部元音字母出现次数都为偶数次。
 
如何存储所有元音字母出现次数的奇偶性信息（以下简称信息）？
对于单个字母的信息可以用1或0表示,,1代表出现奇数次,0代表出现偶数次，
同理，对于题中的5个元音，我们可以把它们的信息组合成一个5位2进制数,取值范围是(00000)2到(11111)2,即十进制的0到31。
 
此时，遍历字符串，在记录前缀和的信息的同时，还要检测该信息是否已经出现过，如果出现过则计算两次索引值的差值得到满足条件的子串的长度，
最后遍历完毕后即可得到的满足条件的最大子串的长度。
*/



class Solution {
public:
    int findTheLongestSubstring(string s) {
        int result = 0;
        int vowelInfo = 0;
		int stringIndexOfInfo[32];
		for (int i = 0; i < sizeof(stringIndexOfInfo)/sizeof(int); ++i) {
			stringIndexOfInfo[i] = -2;
		}
		stringIndexOfInfo[0] = -1;
		for (int i = 0; i < s.size(); i++) {
			switch (s[i]){
			case 'a': {
				vowelInfo ^= 1;
				break;
			}
			case 'e': {
				vowelInfo ^= 2;
				break;
			}
			case 'i': {
				vowelInfo ^= 4;
				break;
			}
			case 'o': {
				vowelInfo ^= 8;
				break;
			}
			case 'u': {
				vowelInfo ^= 16;
				break;
			}
			default:
				break;
			}
			if (stringIndexOfInfo[vowelInfo] == -2) {
				stringIndexOfInfo[vowelInfo] = i;
			}
			else  if (i - stringIndexOfInfo[vowelInfo] > result) {
				result = i - stringIndexOfInfo[vowelInfo];
			}
		}
		return result;
    }
};