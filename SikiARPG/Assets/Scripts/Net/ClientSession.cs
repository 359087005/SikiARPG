using UnityEngine;
using PEProtocol;
using PENet;

//�ͻ�������ػ�
public class ClientSession : PESession<GameMsg>
{
	protected override void OnConnected()
	{
        GameRoot.AddTips("��������¼�ɹ�...");
		PECommon.Log("Server Connect");
	}

	protected override void OnDisConnected()
	{
        GameRoot.AddTips("�������Ͽ�����...");
        PECommon.Log("Server DisConnect");
	}

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("Receive Msg:" + ((CMD)msg.cmd).ToString());
    }
}