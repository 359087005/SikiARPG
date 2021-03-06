﻿/****************************************************
    文件：LoginSystem.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:49:49
	功能：登录系统
*****************************************************/

using PEProtocol;
using UnityEngine;

public class LoginSystem : SystemRoot
{
    public static LoginSystem instance = null;
    public LoginWindow loginWindow;
    public CreatWindow creatWindow;

    public override void Init()
    {
        base.Init();
        instance = this;
        PECommon.Log("LoginInit...");
    }

    public void EnterLogin()
    {
        //异步加载登录场景
        resService.AsyncLoadScene(Constants.SceneLogin, () =>
         {
             loginWindow.SetWindowState();
             AudioService.instance.PlayBGAudio(Constants.BGLogin);
         });
    }

    public void Response(GameMsg msg)
    {
        //提示
        GameRoot.AddTips("登录成功");

        GameRoot.instance.SetPlayData(msg.rspLogin);
        if (msg.rspLogin.playerData.name == "")
        {
            //打开面板
            creatWindow.SetWindowState();
        }
        else
        {
            //进入主城 todo
        }
        //关闭面板
        loginWindow.SetWindowState(false);
    }
}