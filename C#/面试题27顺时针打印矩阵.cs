/*
输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字。
*/

/*
模拟打印路径,
设置通过枚举表示索引运动方向,
每次运动时根据运动方向判断下一个位置,
改变方向的条件是,下一步会运动到边界,或者运动到已经去过的位置,(可以把已经去过的位置赋值为特殊值,方便判断),
如果连续改变两次方向则代表打印路径结束。
*/

public class Solution {

    public enum Direction{
        right,
        down,
        left,
        up
    };
    
    public int[] SpiralOrder(int[][] matrix) {
        Direction dir = Direction.right;
        int height = matrix.Length;
        if(height == 0){
            return new int[]{};
        }
        int width = matrix[0].Length;

        int[] ret = new int[height * width];
        int index = 0;
        int i = 0;
        int j = 0;

        ret[index++] = matrix[i][j];
        matrix[i][j] = int.MinValue;

        bool isFinish = false;
        do{
            switch(dir){
                case Direction.right:{
                    if(j+1 == width || matrix[i][j+1] == int.MinValue){
                        if(i+1 == height || matrix[i+1][j] == int.MinValue){
                            isFinish = true;
                            break;
                        }
                        dir = Direction.down;
                        i++;
                    }
                    else{
                        j++;
                    }
                    break;
                }
                case Direction.down:{
                    if(i+1 == height || matrix[i+1][j] == int.MinValue){
                        if(j - 1 == -1 || matrix[i][j - 1] == int.MinValue){
                            isFinish = true;
                            break;
                        }
                        dir = Direction.left;
                        j--;
                    }
                    else{
                        i++;
                    }
                    break;
                }
                case Direction.left:{
                    if(j - 1 == -1 || matrix[i][j - 1] == int.MinValue){
                        if(i - 1 == -1 || matrix[i - 1][j] == int.MinValue){
                            isFinish = true;
                            break;
                        }
                        dir = Direction.up;
                        i--;
                    }
                    else{
                        j--;
                    }
                    break;
                }
                case Direction.up:{
                    if(i - 1 == -1 || matrix[i - 1][j] == int.MinValue){
                        if(j + 1 == height || matrix[i][j + 1] == int.MinValue){
                            isFinish = true;
                            break;
                        }
                        dir = Direction.right;
                        j++;
                    }
                    else{
                        i--;
                    }
                    break;
                }
            }
            if(index == ret.Length){
                break;
            }
            else{
                ret[index++] = matrix[i][j];
                matrix[i][j] = int.MinValue;
            }

        }while(!isFinish);

        return ret;
    }
}