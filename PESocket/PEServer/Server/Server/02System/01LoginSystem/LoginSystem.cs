using PENet;
using PEProtocol;

public class LoginSystem
{
    private static LoginSystem instance = null;
    public static LoginSystem Instance
    {
        get
        {
            if (instance == null)
                instance = new LoginSystem();
            return instance;
        }
    }

    CacheService cacheService = null;

    public void Init()
    {
        cacheService = CacheService.Instance;
        PECommon.Log("登录系统初始化完成...");
    }
    /// <summary>
    /// 登录请求
    /// </summary>
    /// <param name="msg"></param>
    public void ReqLogin(PackMsg pack)
    {
        ReqLogin req = pack.gameMsg.reqLogin;
        //当前账号是否上线
        //已经上线  返回错误提示
        //未上线 
        //账号是否存在
        //存在  检测密码
        //不存在 创建默认账号密码（应该是存入数据库之类的）
        //回应客户端
        GameMsg msg =  new GameMsg
        {
            cmd = (int)CMD.RspLogin,
        };
        //当前账号是否上线
        if (cacheService.isAccountOnLine(req.account))
        {
            //已经上线  返回错误提示
            msg.err = (int)ErrorCode.AccIsOnLine;
        }
        else
        {
            //未上线 
            PlayerData _playdata = cacheService.GetPlayData(req.account,req.password);
            //账号是否存在
            if (_playdata == null)
            {
                //为空 说明密码错误
                msg.err = (int)ErrorCode.PassError;
            }
            else
            {
                msg.rspLogin = new RspLogin
                {
                    playerData = _playdata
                };
            }
            //缓存账号数据
            cacheService.CachePlayerInfo(req.account,pack.serverSession, _playdata);
        }
        //回应客户端
        pack.serverSession.SendMsg(msg);
    }
}

