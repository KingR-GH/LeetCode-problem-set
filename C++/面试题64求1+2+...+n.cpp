/*
�� 1+2+...+n ��Ҫ����ʹ�ó˳�����for��while��if��else��switch��case�ȹؼ��ּ������ж���䣨A?B:C����
*/

/*
�����ó˳�,������for while if else switch case
�����뵽�ݹ�,�ݹ���Ҫ����ֹ����,
��������&&������,���Ϊfalse,�����ε��ұߵĴ���,��ʵ����ֹ����.
*/


class Solution {
public:
    int sumNums(int n) {
        n && (n+=sumNums(n-1))>0;
        return n;
    }
};