using System;
using MySql.Data.MySqlClient;


class Program
{
    static MySqlConnection conn = null;

    static void Main(string[] args)
    {
        conn = new MySqlConnection("server = localhost;User Id = root;password =;Database = mystudysql;Charset = utf8");
        conn.Open();

        //增
        //Add();

        //删
        Delete();

        //改
        Update();

        //查
        //Query();

        Console.ReadKey();
        conn.Close();
    }

    static void Add()
    {
        MySqlCommand cmd = new MySqlCommand("insert into userinfo set name = 'aaa',age=12",conn);
        cmd.ExecuteNonQuery();
        int id = (int)cmd.LastInsertedId;

        Console.WriteLine("add id = {0}", id);
    }

    static void Delete()
    {
        MySqlCommand cmd = new MySqlCommand("delete from  userinfo  where id = 1", conn);
        cmd.ExecuteNonQuery();

        Console.WriteLine("delete done");
    }

    static void Update()
    {

        //MySqlCommand cmd = new MySqlCommand("update  userinfo set name = 'bbb',age=12 where id = 1", conn);
        MySqlCommand cmd = new MySqlCommand("update  userinfo set name = @name',age=@age where id =@id", conn);
        cmd.Parameters.AddWithValue("name","ccc");
        cmd.Parameters.AddWithValue("age",11);
        cmd.Parameters.AddWithValue("id",2);
    }

    static void Query()
    {
        MySqlCommand cmd = new MySqlCommand("select * from userinfo where name ='bing' ", conn);
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            string name = reader.GetString("name");
            int age = reader.GetInt32("age");

            Console.WriteLine("id:{0};name:{1};age:{2}", id, name, age);
        }
        
    }
}

