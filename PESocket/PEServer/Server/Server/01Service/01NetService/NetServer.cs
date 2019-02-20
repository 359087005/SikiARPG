
using PENet;
using PEProtocol;
using System.Collections.Generic;
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

    public Queue<PackMsg> msgQueue = new Queue<PackMsg>();
    public static readonly string lockObj = "lock";

    public void Init()
    {
        PESocket<ServerSession, GameMsg> server = new PESocket<ServerSession, GameMsg>();
        server.StartAsServer(ServerConfig.serverIP, ServerConfig.serverPort);

        PECommon.Log("网络部分初始化完成...");
    }

    public void AddMsgQueue(ServerSession serverSession,GameMsg msg)
    {
        lock (lockObj)
        {
            msgQueue.Enqueue(new PackMsg(serverSession,msg));
        }
    }

    public void Update()
    {
        if (msgQueue.Count > 0)
        {
            PECommon.Log("msgQueueCount : " + msgQueue.Count);
            PackMsg pack = msgQueue.Dequeue();
            HandOut(pack);
        }
    }

    private void HandOut(PackMsg pack)
    {
        switch ((CMD)pack.gameMsg.cmd)
        {
            case CMD.NONE:
                break;
            case CMD.ReqLogin:
                LoginSystem.Instance.ReqLogin(pack);
                break;
            case CMD.RspLogin:
                break;
        }
    }
}

public class PackMsg
{
    public ServerSession serverSession;
    public GameMsg gameMsg;

    public PackMsg(ServerSession serverSession, GameMsg gameMsg)
    {
        this.serverSession = serverSession;
        this.gameMsg = gameMsg;
    }
}

