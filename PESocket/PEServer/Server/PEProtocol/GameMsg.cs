using PENet;
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
    }
    [Serializable]
    public class ReqLogin
    {
        public string account;
        public string password;
    }

    public enum CMD
    {
        NONE = 0,

        ReqLogin = 101,
        RspLogin = 102
    }

    public class ServerConfig
    {
        public const string serverIP = "127.0.0.1";
        public const int serverPort = 17666;
    }
}
