using UnityEngine;
using PEProtocol;
using PENet;

//客户端网络回话
public class ClientSession : PESession<GameMsg>
{
	protected override void OnConnected()
	{
        GameRoot.AddTips("服务器登录成功...");
		PECommon.Log("Server Connect");
	}

	protected override void OnDisConnected()
	{
        GameRoot.AddTips("服务器断开连接...");
        PECommon.Log("Server DisConnect");
	}

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("Receive Msg:" + ((CMD)msg.cmd).ToString());
    }
}