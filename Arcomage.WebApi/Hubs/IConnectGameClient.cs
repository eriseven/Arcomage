﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.WebApi.Hubs
{
    public interface IConnectGameClient
    {
        void Connected(Guid gameId);

        void Disconnected(Guid gameId);
    }
}
