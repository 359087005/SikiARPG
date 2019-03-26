using MySql.Data.MySqlClient;
using PEProtocol;
using System;

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
        conn.Open();
        //QueryPlayerData("aaa","bbb");
        PECommon.Log("数据库初始化完成...");
    }
    public PlayerData QueryPlayerData(string acc, string password)
    {
        PlayerData pd = null;
        MySqlDataReader reader = null;
        bool isNew = true;
        try
        {
            MySqlCommand cmd = new MySqlCommand("select * from playerdata where account = @account", conn);
            //通过账号获取数据库数据 与密码作比较
            cmd.Parameters.AddWithValue("account", acc);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                isNew = false;
                string pass = reader.GetString("password");
                if (pass.Equals(password))
                {
                    pd = new PlayerData
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        lv = reader.GetInt32("lv"),
                        exp = reader.GetInt32("exp"),
                        power = reader.GetInt32("power"),
                        coin = reader.GetInt32("coin"),
                        diamond = reader.GetInt32("diamond")
                    };
                }
            }

        }
        catch (Exception e)
        {
            PECommon.Log("Query PlayerData By Acount Error:" + e, LogType.Error);
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
            if (isNew)
            {
                //不存在账号数据 创建新的默认账号数据 并返回
                pd = new PlayerData
                {
                    id =-1,
                    name = "",
                    lv = 1,
                    exp = 0,
                    power = 100,
                    coin = 1000,
                    diamond = 500
                };
                pd.id = InsertNewPlayerData(acc,password,pd);
            }
        }
        
        return pd;
    }


    /// <summary>
    /// 创建新的玩家数据 返回主键
    /// </summary>
    /// <param name="acc"></param>
    /// <param name="pass"></param>
    /// <param name="pd"></param>
    /// <returns></returns>
    private int InsertNewPlayerData(string acc, string pass, PlayerData pd)
    {
        int id = -1;
        try
        {
            MySqlCommand cmd = new MySqlCommand("insert into playerdata set account = @account,password = @password, name = @name,lv = @lv,exp = @exp,power = @power,coin = @coin,diamond = @diamond", conn);
            cmd.Parameters.AddWithValue("account",acc);
            cmd.Parameters.AddWithValue("password",pass);
            cmd.Parameters.AddWithValue("name",pd.name);
            cmd.Parameters.AddWithValue("lv",pd.lv);
            cmd.Parameters.AddWithValue("exp",pd.exp);
            cmd.Parameters.AddWithValue("power",pd.power);
            cmd.Parameters.AddWithValue("coin",pd.coin);
            cmd.Parameters.AddWithValue("diamond",pd.diamond);

            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;
        }
        catch (Exception e)
        {
            PECommon.Log("Insert playerData Error:" + e, LogType.Error);
        }

        return id;
    }
}

