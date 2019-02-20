
using System.Collections.Generic;
/// <summary>
/// 缓存层
/// </summary>
public class CacheService
{
    private static CacheService instance = null;
    public static CacheService Instance
    {
        get
        {
            if (instance == null)
                instance = new CacheService();
            return instance;
        }
    }

    public void Init()
    {
        PECommon.Log("数据缓存初始化完成...");
    }
    public Dictionary<string, ServerSession> accDict = new Dictionary<string, ServerSession>();

    public bool isAccountOnLine(string acc)
    {
        return accDict.ContainsKey(acc);
    }
}

