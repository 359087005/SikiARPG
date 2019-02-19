using PENet;

public class LoginSystem
{
    private static LoginSystem instance = null;
    public static LoginSystem Instance
    {
        get
        {
            if (instance == null)
                instance = new LoginSystem();
            return instance;
        }
    }

    public void Init()
    {
        PECommon.Log("登录系统初始化完成...");
    }
}

