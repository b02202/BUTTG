using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TTG1
{
    class RPC
    {
        Socket s = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
        IPAddress ipAddress = IPAddress.Parse(Tivo.curTivoIP);
        IPEndPoint ipe = new IPEndPoint(ipAddress.Address, 11000);
    }
}
