/****************************************************
    文件：LoginWind.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 17:29:10
	功能：登录窗口
*****************************************************/

using PEProtocol;
using UnityEngine;
using UnityEngine.UI;

public class LoginWindow : GameUIRoot
{
    public InputField accText;
    public InputField pwdText;
    public Button enterGame;
    public Button notice;

    protected override void InitWindow()
    {
        base.InitWindow();
        if (PlayerPrefs.HasKey("Account") && PlayerPrefs.HasKey("PassWord"))
        {
            accText.text = PlayerPrefs.GetString("Account");
            pwdText.text = PlayerPrefs.GetString("PassWord");
        }
        else
        {
            accText.text = "";
            pwdText.text = "";
        }
    }
    
    //点击登录
    public void BtnLoginEnter()
    {
        audioService.PlayUIAudio(Constants.uiLoginBtn);

        string account = accText.text;
        string passWord = pwdText.text;

        if (account != "" && passWord != "")
        {
            // 更新本地的存储
            PlayerPrefs.SetString("Account",account);
            PlayerPrefs.SetString("PassWord", passWord);

            //todo发送网络消息 请求登录
            GameMsg msg = new GameMsg
            {
                cmd = (int)CMD.ReqLogin,
               reqLogin = new ReqLogin
               {
                   account = account,
                   password = passWord
               }
            };
            netService.SendMsg(msg);
        }
        else
        {
            GameRoot.AddTips("账号密码为空");
        }
    }

    public void BtnNotice()
    {
        audioService.PlayUIAudio(Constants.btnEffect);

        GameRoot.AddTips("功能模块开发中...");
    }
}