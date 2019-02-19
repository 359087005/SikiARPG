/****************************************************
    文件：GameRoot.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:35:14
	功能：游戏启动入口
*****************************************************/

using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public static GameRoot instance = null;

    public LoadingWind loadingWind;
    public DynamicWindow dynamicWindow;
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);


        Debug.Log("Game Start...");
        Init();
    }
    /// <summary>
    /// 对所有的UI面板进行初始化
    /// </summary>
    void InitAllWindow()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        dynamicWindow.SetWindowState();
    }

    void Init()
    {
        //按顺序初始化模块
        //服务模块
	NetService net = GetComponent<NetService>();
	net.InitNetService();
        ResService res = GetComponent<ResService>();
        res.InitRes();
        AudioService audio = GetComponent<AudioService>();
        audio.InitService();

        //业务系统初始化
        LoginSystem login = GetComponent<LoginSystem>();
        login.Init();

        //进入登录场景并加载相应UI
        login.EnterLogin();
    }

    public static void AddTips(string tips)
    {
        instance.dynamicWindow.AddTips(tips);
    }
}