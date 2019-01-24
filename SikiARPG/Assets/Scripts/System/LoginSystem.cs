/****************************************************
    文件：LoginSystem.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:49:49
	功能：登录系统
*****************************************************/

using UnityEngine;

public class LoginSystem : MonoBehaviour 
{
    public static LoginSystem instance = null;
    public LoginWindow lw;

    public void InitLogIn()
    {
        instance = this;
        Debug.Log("LoginInit...");
    }

    public void EnterLogin()
    {
        //异步加载登录场景
        ResService.instance.AsyncLoadScene(Constants.SceneLogin,()=>
        {
            lw.gameObject.SetActive(true);
            lw.InitLoginWindow();
        });
    }
}