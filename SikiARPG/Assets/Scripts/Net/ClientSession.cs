using UnityEngine;
using PEProtocol;
using PENet;

//客户端网络回话
public class ClientSession : PESession<GameMsg>
{
	protected override void OnConnected()
	{
		PECommon.Log("Server Connect");
	}

	protected override void OnDisConnected()
	{
		PECommon.Log("Server DisConnect");
	}

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("Receive Msg:");
    }
}