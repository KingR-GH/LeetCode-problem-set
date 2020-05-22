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
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    //用于存储中序遍历序列数据的字典,key为序列的数值,value为数值对应的索引
    public Dictionary<int, int> dicInoder = new Dictionary<int, int>();

    
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        int preorderLeft, inorderLeft ,treeLength;

        preorderLeft = 0;   //当前树的先序遍历序列的左边界索引
        inorderLeft = 0;    //当前树的中序遍历序列的左边界索引
        treeLength = preorder.Length;   //当前树的长度

        //创建字典存储中序遍历序列的数据
        for (int i = 0; i < treeLength; ++i)
        {
            dicInoder.Add(inorder[i], i);
        }
        //用于检索中序遍历序列中分隔左右子树的索引


        return CreateTree(preorder, preorderLeft, inorderLeft, treeLength);
    }

    /// <summary>
    /// 创建树(递归程序)
    /// </summary>
    /// <param name="preorder">先序遍历序列</param>
    /// <param name="preorderLeft">先序遍历序列内用来构造树的区间的左边界索引</param>
    /// <param name="inorderLeft">中序遍历序列内用来构造树的区间的左边界索引</param>
    /// <param name="treeLength">子树的长度</param>
    /// <returns></returns>
    public TreeNode CreateTree(int[] preorder, int preorderLeft, int inorderLeft, int treeLength)
    {
        //树的长度不足1返回空树
        if (treeLength < 1)
        {
            return null;
        }

        int val = preorder[preorderLeft];   //获取先序遍历区间左边界的值
        int centerIndex = dicInoder[val];   //通过val在字典中查找中序遍历序列中分隔左右子树的索引
        int treeLengthLeft = centerIndex - inorderLeft; //左子树的长度
        int treeLengthRight = treeLength - treeLengthLeft - 1;  //右子树的长度

        //节点的值
        TreeNode treeNode = new TreeNode(val);  
        //创建左子树
        treeNode.left = CreateTree(preorder, preorderLeft + 1, inorderLeft, treeLengthLeft);
        //创建右子树
        treeNode.right = CreateTree(preorder,preorderLeft+treeLengthLeft+1, centerIndex + 1, treeLengthRight);

        return treeNode;
    }
}