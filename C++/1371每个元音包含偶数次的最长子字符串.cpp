//����һ���ַ��� s �����㷵��������������������ַ����ĳ��ȣ�ÿ��Ԫ����ĸ���� 'a'��'e'��'i'��'o'��'u' �������ַ����ж�ǡ�ó�����ż���Ρ�;

/*
����: ÿ��Ԫ����ĸ,'a','e','i','o','u',�����ַ����ж�ǡ�ó�����ż����
 
��ǰ׺���д洢ĳ��Ԫ����ĸ���ִ�������ż��, 
��ĳһ���������ǰ׺����ͬ,��������ĸ�ڶ�Ӧ�������ڳ��ֵĴ���Ϊż����(����-���� = ż��,ż��-ż��=ż��)��
ͬ��,��ǰ׺���д洢��������Ԫ����ĸ���ִ�������ż��,��ô��������ǰ׺����ͬ������,�ڲ�Ԫ����ĸ���ִ�����Ϊż���Ρ�
 
��δ洢����Ԫ����ĸ���ִ�������ż����Ϣ�����¼����Ϣ����
���ڵ�����ĸ����Ϣ������1��0��ʾ,,1�������������,0�������ż���Σ�
ͬ���������е�5��Ԫ�������ǿ��԰����ǵ���Ϣ��ϳ�һ��5λ2������,ȡֵ��Χ��(00000)2��(11111)2,��ʮ���Ƶ�0��31��
 
��ʱ�������ַ������ڼ�¼ǰ׺�͵���Ϣ��ͬʱ����Ҫ������Ϣ�Ƿ��Ѿ����ֹ���������ֹ��������������ֵ�Ĳ�ֵ�õ������������Ӵ��ĳ��ȣ�
��������Ϻ󼴿ɵõ�����������������Ӵ��ĳ��ȡ�
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