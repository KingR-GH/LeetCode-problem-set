/*
给定一个整数 n，求以 1 ... n 为节点组成的二叉搜索树有多少种？
*/

/*
当左右子树的节点数确定时,树的种类数 = 左子树的种类数*右子树的种类数
左右子树的节点数有多种情况,所以将各种情况下的结果求和即可得答案
F(节点数) = ΣF(左子树节点数) * F(右子树节点数)

动态规划
F(0) = 0;　　(后面参与乘法计算时F(0) = 1)
F(1) = 1;
F(2) = F(0)*F(1) + F(1)*F(0);
F(3) = F(0)*F(2) + F(1)*F(1) +F(2)*F(0);
......
F(n) = F(0) * F(n-1) + F(1) * F(n-2) + ......+ F(n-1) * F(0);
*/
public class Solution {
    public int NumTrees(int n) {
        if(n == 0){return 0;}
        int[] array = new int[n+1];
        array[0] = 1;
        array[1] = 1;
        for(int i = 2; i <= n; i++){
            int temp = 0;
            for(int j = 0; j < i; j++ ){
                temp += array[j]*array[i-1-j];
            }
            array[i]=temp;
        }
        return array[n];
    }
}