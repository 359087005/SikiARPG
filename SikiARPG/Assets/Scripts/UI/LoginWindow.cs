/****************************************************
    文件：LoginWind.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 17:29:10
	功能：登录窗口
*****************************************************/

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
        if (PlayerPrefs.HasKey("Account") && PlayerPrefs.HasKey("Password"))
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
    //TODO 更新本地的存储
}