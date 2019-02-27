
using PEProtocol;
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

    private DataBaseManager db = null;
    public void Init()
    {
        db = DataBaseManager.Instance;
        PECommon.Log("数据缓存初始化完成...");
    }
    //key账号  value session
    public Dictionary<string, ServerSession> accDict = new Dictionary<string, ServerSession>();
    //key session value 玩家数据
    public Dictionary<ServerSession, PlayerData> playDataDict = new Dictionary<ServerSession, PlayerData>();

    /// <summary>
    /// 账号是否上线
    /// </summary>
    /// <param name="acc"></param>
    /// <returns></returns>
    public bool isAccountOnLine(string acc)
    {
        return accDict.ContainsKey(acc);
    }
    /// <summary>
    /// 获取数据
    /// </summary>
    /// <param name="account"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public PlayerData GetPlayData(string account,string password)
    {
        PlayerData pd = db.QueryPlayerData(account,password);

        return pd;
    }
    /// <summary>
    /// 缓存玩家数据
    /// </summary>
    /// <param name="account"></param>
    /// <param name="session"></param>
    /// <param name="pd"></param>
    public void CachePlayerInfo(string account, ServerSession session, PlayerData pd)
    {
        accDict.Add(account,session);
        playDataDict.Add(session,pd);
    }
}

