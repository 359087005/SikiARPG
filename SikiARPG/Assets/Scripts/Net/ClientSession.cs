


using UnityEngine;
using PEProtocol;

//客户端网络回话
public class ClientSession : PENet.PESession<GameMsg>
{
	protected override void OnConnected()
	{
		Debug.Log("Server Connect");
	}

	protected override void OnDisConnected()
	{
		Debug.Log("Server DisConnect");
	}
	
	protected override void OnReceiveMsg(GameMsg msg)
	{
		Debug.Log("Server Receive:" + msg.text);
	}
}