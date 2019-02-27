using MySql.Data.MySqlClient;


public class DataBaseManager
{
    private static DataBaseManager instance = null;
    public static DataBaseManager Instance
    {
        get
        {
            if (instance == null)
                instance = new DataBaseManager();
            return instance;
        }
    }
     MySqlConnection conn = null;
    public void Init()
    {
        conn = new MySqlConnection("server = localhost;User Id = root;password =;Database = ARPG;Charset = utf8");
        //PECommon.Log("数据库连接完成...");
    }
    public PlayerData QueryPlayerData(string acc, string password)
    {
        PlayerData pd = null;
        //TODO
        return pd;
    }
}

