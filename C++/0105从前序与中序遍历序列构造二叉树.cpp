//��Ŀ:����һ������ǰ�������������������������

/*
��������е�һ��Ԫ�ص�ֵ�������ĸ�,

���ǿ���ͨ����ֵ������������������ڶ�Ӧ������

�����͵õ������������������,���������ĳ��ȡ� �Լ������������������

��������������У������������ĳ���,���Ի��������������������Լ������������������

�������ǵõ���������������������������, �Լ���������������������������

��Ҫ��������������Ҫ��������������������������������������
�����������˸�������Ҫ��������������������
�������Ѿ��õ����������������������������������ͻع�����ĿҪ�󣺴�ǰ�������������й����������
�������ǿ����õݹ�ʵ�ָ����⡣

ֻ��Ҫ�ҵ���Ҫ���������ĳ���,�Լ�������������������������߽������,
�Ϳ��������Ϲ��ɵݹ鹹������
*/

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Solution {
public:
    unordered_map<int, int> map;

    TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) {
        int preorderLeft, inorderLeft, treeLength;
        preorderLeft = 0;
        inorderLeft = 0;
        treeLength = preorder.size();

        for (int i = 0; i < treeLength; ++i) {
            map[inorder[i]] = i;
        }
        
        return CreateTree(preorder, preorderLeft, inorderLeft, treeLength);
    }


    TreeNode* CreateTree(vector<int>& preorder, int preorderLeft, int inorderLeft, int treeLength) {
        if (treeLength < 1) {
            return NULL;
        }

        int val = preorder[preorderLeft];
        TreeNode* treeNode = new TreeNode(val);
        int centerIndex = map[val];
        int leftTreeLength = centerIndex - inorderLeft;
        int rightTreeLength = treeLength - leftTreeLength - 1;

        treeNode->left = CreateTree(preorder, preorderLeft + 1, inorderLeft, leftTreeLength);
        treeNode->right = CreateTree(preorder, preorderLeft + leftTreeLength + 1, centerIndex + 1, rightTreeLength);

        return treeNode;
    }
};