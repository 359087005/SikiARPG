using PENet;
using Protocal;

namespace Server
{
    public class ServerSession : PENet.PESession<NetMsg>
    {

        protected override void OnConnected()
        {
            PETool.LogMsg("CLient Connect");
        }

        protected override void OnDisConnected()
        {
            PETool.LogMsg("CLient DisConnect");
        }

        protected override void OnReciveMsg(NetMsg msg)
        {
            PETool.LogMsg("CLient ReciveMsg");
        }
    }
}
