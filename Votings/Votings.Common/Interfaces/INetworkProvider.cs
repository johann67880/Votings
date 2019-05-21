using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Common.Interfaces
{
    public interface INetworkProvider
    {
        bool IsConnectedToWifi();
    }
}
