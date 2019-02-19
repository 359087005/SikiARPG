
/// <summary>
/// 服务器初始化
/// </summary>
public class ServerRoot
{
    private static ServerRoot instance = null;
    public static ServerRoot Instance
    {
        get
        {
            if (instance == null)
                instance = new ServerRoot();
            return instance;
        }
        
    }

    public void Init()
    {
        //数据层 TODO

        //服务层
        NetServer.Instance.Init();

        //业务系统层
        LoginSystem.Instance.Init();

    }
}


