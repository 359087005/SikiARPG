/****************************************************
    文件：ResService.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:50:1
	功能：网络服务
*****************************************************/

using UnityEngine;
using PENet;
using PEProtocol;

public class NetService: MonoBehaviour 
{
    public static ResService instance = null;

	PESocket<ClientSession,GameMsg> client = null;

    public void InitNetService()
    { 
        instance = this;
	
	client = new PESocket<ClientSession,GameMsg>();
	client.StartAsClient(ServerConfig.serverIP,ServerConfig.serverPort);

	client.SetLog(true,(string msg,int lv) =>{
	switch(lv)
	{
		case 0:
		msg = "Log:" + msg;
		Debug.Log(msg);
		break;

		case 1:
		msg = "Warn:" + msg;
		Debug..LogWarning(msg);
		break;

		case 2:
		msg = "Error:" + msg;
		Debug.LogError(msg);
		break;		

		case 3:
		msg = "Info:" + msg;
		Debug.Log(msg); 
		break;	
	}
	});

        Debug.Log("NetService Init...");
    }

 
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			client.session.SendMsg(new GameMsg{text = "Hello"});
		}
	}

}