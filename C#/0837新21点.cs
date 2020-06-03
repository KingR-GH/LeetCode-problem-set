/*
爱丽丝参与一个大致基于纸牌游戏 “21点” 规则的游戏，描述如下：
爱丽丝以 0 分开始，并在她的得分少于 K 分时抽取数字。 抽取时，她从 [1, W] 的范围中随机获得一个整数作为分数进行累计，其中 W 是整数。 每次抽取都是独立的，其结果具有相同的概率。
当爱丽丝获得不少于 K 分时，她就停止抽取数字。 爱丽丝的分数不超过 N 的概率是多少？

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/new-21-game
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/


/*
题意: 从0点数开始,等可能加上1到W之间的某一数值,如果点数小于等于K,继续抽牌,一旦点数大于K则停止抽牌,并判断点数是否超过N，没超过N就获胜。本题求获胜的概率

整局游戏所有可能出现的点数范围是 0 到 W+K-1,可以用长度为W+K的数组res存储处于各点数时游戏获胜的概率

其中,点数从K到W+K-1之间时,获胜的概率是100%,
点数处于从W+K-1到N是,获胜的概率是0,
点数为n时获胜的概率是: res[n] = res[n+1]/w + res[n+2]/w + ....... res[n+w]/w

求res[n-1]时,不必计算每一个后续值,可以用res[n-1] = res[n] + res[n]/w - res[n+w]/w求
*/

public class Solution {
    public double New21Game(int N, int K, int W) {
        double[] res = new double[W + K];
        double window = 0;

        for (int i = K + W - 1; i >= K; i--) 
        {
            if (i > N)
            {
                res[i] = 0;
            }
            else
            {
                res[i] = 1;
            }
            window += res[i];
        }

        for(int i = K - 1; i >= 0; i--)
        {
            res[i] = window / W;
            window = window + res[i] - res[i + W];
        }

        return res[0];
    }
}