/****************************************************
    文件：Tools.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/2/14 15:28:45
	功能：工具类
*****************************************************/

public class MyTools
{

    public static int RdmNum(int min, int max, System.Random rd = null)
    {
        if (rd == null)
        {
            rd = new System.Random();
        }
        int rdNum = rd.Next(min, max + 1);
        return rdNum;
    }
}