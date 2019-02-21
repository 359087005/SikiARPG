/****************************************************
    �ļ���ResService.cs
	���ߣ�ICE
    ����: 359087005@qq.com
    ���ڣ�2019/1/24 14:50:1
	���ܣ��������
*****************************************************/

using UnityEngine;
using PENet;
using PEProtocol;
using System.Collections.Generic;

public class NetService : MonoBehaviour
{
    public static NetService instance = null;

    PESocket<ClientSession, GameMsg> client = null;

    private Queue<GameMsg> msgQueue = new Queue<GameMsg>();

    public static readonly string lockObj = "lock";


    public void InitNetService()
    {
        instance = this;

        client = new PESocket<ClientSession, GameMsg>();
        client.StartAsClient(ServerConfig.serverIP, ServerConfig.serverPort);

        client.SetLog(true, (string msg, int lv) =>
        {
            switch (lv)
            {
                case 0:
                    msg = "Log:" + msg;
                    Debug.Log(msg);
                    break;

                case 1:
                    msg = "Warn:" + msg;
                    Debug.LogWarning(msg);
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

        PECommon.Log("NetService Init...");
    }

    /// <summary>
    /// ��Ϣ��ӵ�����
    /// </summary>
    /// <param name="msg"></param>
    public void AddMsgQueue(GameMsg msg)
    {
        lock (lockObj)
        {
            msgQueue.Enqueue(msg);
        }
    }


    /// <summary>
    /// ������Ϣ
    /// </summary>
    /// <param name="msg"></param>
    public void SendMsg(GameMsg msg)
    {
        if (client.session != null)
        {
            client.session.SendMsg(msg);
        }
        else
        {
            GameRoot.AddTips("����������ʧ�ܣ���������...");
            InitNetService();
        }
    }


    private void Update()
    {
        if (msgQueue.Count > 0)
        {
          GameMsg msg =  msgQueue.Dequeue();
            HandOut(msg);
        }
    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    /// <param name="msg"></param>
    private void HandOut(GameMsg msg)
    {
        //�ж���Ϣ�Ƿ�������
        if (msg.err != (int)ErrorCode.None)
        {
            switch ((ErrorCode)msg.err)
            {
                case ErrorCode.AccIsOnLine:
                    GameRoot.AddTips("�˺�������");
                    break;
                case ErrorCode.PassError:
                    GameRoot.AddTips("�������");
                    break;
            }
            return;
        }
        switch ((CMD)msg.cmd)
        {
            case CMD.RspLogin:
                LoginSystem.instance.Response(msg);
                break;
        }
    }
}