﻿using PENet;
using System;

/// <summary>
/// 网络通信协议 客户端服务端共用
/// </summary>
namespace PEProtocol
{
    [Serializable]
    public class GameMsg : PEMsg
    {
        public ReqLogin reqLogin;
        public RspLogin rspLogin;

        public ReqRename reqRename;
        public RspRename rspRename;
    }
    [Serializable]
    public class ReqLogin
    {
        public string account;
        public string password;
    }

    [Serializable]
    public class RspLogin
    {
        public PlayerData playerData;
    }

    [Serializable]
    public class ReqRename
    {
        public string name;
    }

    [Serializable]
    public class RspRename
    {
        public string name;
    }


    [Serializable]
    public class PlayerData
    {
        public int id;
        public string name;
        public int lv;
        public int exp;
        public int power;
        public int coin;
        public int diamond;
    }

    public enum ErrorCode
    {
        None = 0,
        AccIsOnLine = 1,//账号已上线
        PassError = 2,//密码错误
        NameExist = 3//名字已存在
    }

    public enum CMD
    {
        NONE = 0,

        ReqLogin = 101,
        RspLogin = 102,

        ReqRename = 103,
        RspRename = 104
    }

    public class ServerConfig
    {
        public const string serverIP = "127.0.0.1";
        public const int serverPort = 17666;
    }
}
