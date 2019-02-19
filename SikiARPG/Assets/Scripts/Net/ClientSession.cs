


using UnityEngine;
using PEProtocol;

//�ͻ�������ػ�
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