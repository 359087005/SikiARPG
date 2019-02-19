
using PENet;
using PEProtocol;

/// <summary>
/// 网络回话连接
/// </summary>
public class ServerSession : PESession<GameMsg>
{
    protected override void OnConnected()
    {
        PETool.LogMsg("CLient Connect");
        SendMsg(new GameMsg { text = "欢迎连接" });
    }

    protected override void OnDisConnected()
    {
        PETool.LogMsg("CLient DisConnect");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PETool.LogMsg("CLient ReciveMsg:" + msg.text);
        SendMsg(new GameMsg { text = "Service Res: " + msg.text});
    }
}

