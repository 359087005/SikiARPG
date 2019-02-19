
using PENet;
using PEProtocol;

/// <summary>
/// 网络回话连接
/// </summary>
public class ServerSession : PESession<GameMsg>
{
    protected override void OnConnected()
    {
        PECommon.Log("CLient Connect");
    }

    protected override void OnDisConnected()
    {
        PECommon.Log("CLient DisConnect");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("CLient ReciveMsg:" + ((CMD)msg.cmd).ToString());
    }
}

