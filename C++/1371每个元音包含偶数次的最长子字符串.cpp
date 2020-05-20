//����һ���ַ��� s �����㷵��������������������ַ����ĳ��ȣ�ÿ��Ԫ����ĸ���� 'a'��'e'��'i'��'o'��'u' �������ַ����ж�ǡ�ó�����ż���Ρ�;
//����C#
#include <string>
using namespace std;

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
//aabbccaaeeffgg
//12222234444444