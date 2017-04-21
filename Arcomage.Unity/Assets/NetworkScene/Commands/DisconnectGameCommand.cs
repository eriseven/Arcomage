﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Controllers;

namespace Arcomage.Unity.NetworkScene.Commands
{
    public class DisconnectGameCommand : Command<object>
    {
        private readonly ConnectGameControllerClient connectGameControllerClient;

        public DisconnectGameCommand(ConnectGameControllerClient connectGameControllerClient)
        {
            this.connectGameControllerClient = connectGameControllerClient;
        }

        public override Task Execute(object state)
        {
            return connectGameControllerClient.Disconnect();
        }
    }
}
