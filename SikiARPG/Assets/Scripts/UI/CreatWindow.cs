/****************************************************
    文件：CreatWindow.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/2/14 11:43:51
	功能：人物创建面板
*****************************************************/

using PEProtocol;
using UnityEngine;
using UnityEngine.UI;

public class CreatWindow : GameUIRoot 
{
    public InputField ipt;

    protected override void InitWindow()
    {
        base.InitWindow();

        ipt.text = res.GetRdmName(false);
    }

    public void ClickRdmName()
    {
        audioService.PlayUIAudio(Constants.btnEffect);

        ipt.text = res.GetRdmName(false);
    }

    public void ClickEnterGame()
    {
        audioService.PlayUIAudio(Constants.btnEffect);
        if (ipt.text != null)
        {
            //todo
            //发送名字到服务器 进入主城
            GameMsg msg = new GameMsg
            {
                cmd = (int)CMD.ReqRename,
                reqRename = new ReqRename
                {
                    name = ipt.text
                }
            };
            netService.SendMsg(msg);
        }
        else
        {
            GameRoot.AddTips("名字不合法");
        }
    }
}