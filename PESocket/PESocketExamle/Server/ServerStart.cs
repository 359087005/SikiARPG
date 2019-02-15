using PENet;
using Protocal;

namespace Server
{
    public class ServerStart
    {
        static void Main(string[] arg)
        {
            PESocket<ServerSession, NetMsg> server = new PESocket<ServerSession, NetMsg>();

            server.StartAsServer(IPCfg.srvIP,IPCfg.srvPort);
            while (true)
            {

            }
        }
       
    }
}
