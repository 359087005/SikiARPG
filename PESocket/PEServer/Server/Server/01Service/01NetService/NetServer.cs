
using PENet;
using PEProtocol;

/// <summary>
/// 网络服务
/// </summary>
public class NetServer 
{
    private static NetServer instance = null;
    public static NetServer Instance
    {
        get
        {
            if (instance == null)
                instance = new NetServer();
            return instance;
        }

    }

    public void Init()
    {
        PESocket<ServerSession, GameMsg> server = new PESocket<ServerSession, GameMsg>();
        server.StartAsServer(ServiceConfig.serviceIP,ServiceConfig.servicePort);

        PETool.LogMsg("网络部分初始化完成...");
    }
}

