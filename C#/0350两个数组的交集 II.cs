/*
给定两个数组，编写一个函数来计算它们的交集。
*/

/*
将短数组元素以及出现的次数存到字典中(元素->键,出现次数->值),
遍历长数组的元素,如果该元素在字典中的个数大于0,则将字典中以该元素为键的值减1.并把元素存到结果数组中.
*/
public class Solution
{
    Dictionary<int, int> dic = new Dictionary<int, int>();

    public int[] Intersect(int[] nums1, int[] nums2)
    {
        int[] res = null;

        if(nums1.Length > nums2.Length)
        {
            res = MyFunc(nums2, nums1);
        }
        else
        {
            res = MyFunc(nums1, nums2);
        }

        return res;
    }

    public int[] MyFunc(int[] nums1, int[] nums2)
    {
        List<int> res = new List<int>();
        foreach (var item in nums1)
        {
            if (dic.ContainsKey(item))
            {
                dic[item]++;
            }
            else
            {
                dic.Add(item, 1);
            }
        }
        foreach (var item in nums2)
        {
            if (dic.ContainsKey(item))
            {
                if (dic[item] > 0)
                {
                    res.Add(item);
                    dic[item]--;
                }
            }
            
        }
        return res.ToArray();
    }
}