//题目:根据一棵树的前序遍历与中序遍历构造二叉树。

/*
先序遍历中第一个元素的值就是树的根,

我们可以通过该值检索到根在中序遍历内对应的索引

这样就得到了左子树的中序遍历,和左子树的长度。 以及右子树的中序遍历。

在先序遍历序列中，根据左子树的长度,可以获得左子树的先序遍历，以及右子树的先序遍历。

这样我们得到了左子树的先序遍历和中序遍历, 以及右子树的先序遍历和中序遍历。

想要构建树，我们需要三样东西，根，构建左子树，构建右子树。
现在我们有了根，还需要构建左子树和右子树。
而我们已经得到了左子树的先序遍历和中序遍历，这样就回归了题目要求：从前序和中序遍历序列构造二叉树。
于是我们可以用递归实现该问题。

只需要找到需要构建的树的长度,以及树在先序和中序遍历序列中左边界的索引,
就可以用以上规律递归构建树。
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