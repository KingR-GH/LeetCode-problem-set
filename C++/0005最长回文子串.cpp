//����һ���ַ��� s���ҵ� s ����Ļ����Ӵ�������Լ��� s ����󳤶�Ϊ 1000��

/*
�����㷨

��ȡÿһ���Ӵ� �ж��Ƿ�Ϊ���Ĵ� ���������Ļ����Ӵ���



������չ

�����Ĵ�������ַ���ͬ����ɾȥ�����ַ���ʣ�µ��ַ�����Ϊ���Ĵ���

���ǿ��Է����������ַ����е�ĳһλ�ַ�c(��ĳ��λ���ڵ���ͬ�ַ���cc)��

����������ַ���ͬ����������������չ��ֱ�������ַ���ͬ������������c(��cc)Ϊ���ĵĻ����ִ���

��ÿһλ��������������,��ɻ�ȡ��Ļ����Ӵ���*/


class Solution {
public:
    string longestPalindrome(string s) {
        if (s.size() < 2) {
            return s;
        }
        string result = "";
        int max = 0;
        int start = 0;
        for (int i = 0; i < s.size(); ++i) {
            int length1 = CentralExpansion(s, i, 0);
            if (length1 > max) {
                max = length1;
                start = i - (max - 1) / 2;
            }
            if (i < s.size() - 1 && s[i] == s[i + 1]) {
                int length2 = CentralExpansion(s, i, 1);
                if (length2 > max) {
                    max = length2;
                    start = i - (max - 1) / 2;
                }
            }
        }
        result = s.substr(start, max);
        return result;
    }

    int CentralExpansion(string s, int center, int plus) {
        int result = 1 + plus;
        int left = center - 1;
        int right = center + 1 + plus;
        while (left >= 0 && right < s.size()) {
            if (s[left--] == s[right++]) {
                result += 2;
            }
            else {
                break;
            }
        }
        return result;
    }
};