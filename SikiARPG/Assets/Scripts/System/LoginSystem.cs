/****************************************************
    文件：LoginSystem.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:49:49
	功能：登录系统
*****************************************************/

using UnityEngine;

public class LoginSystem : SystemRoot
{
    public static LoginSystem instance = null;
    public LoginWindow loginWindow;

    public override void Init()
    {
        base.Init();
        instance = this;
        Debug.Log("LoginInit...");
    }

    public void EnterLogin()
    {
        //异步加载登录场景
        resService.AsyncLoadScene(Constants.SceneLogin, () =>
         {
             loginWindow.SetWindowState();
             AudioService.instance.PlayBGAudio(Constants.BGLogin);
             GameRoot.AddTips("111");
             GameRoot.AddTips("222");
             GameRoot.AddTips("333");
         });
    }
}