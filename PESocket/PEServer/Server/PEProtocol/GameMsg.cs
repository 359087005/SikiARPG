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
        public string text;
    }

    public class ServiceConfig
    {
        public const string serviceIP = "127.0.0.1";
        public const int servicePort = 17666;
    }
}
