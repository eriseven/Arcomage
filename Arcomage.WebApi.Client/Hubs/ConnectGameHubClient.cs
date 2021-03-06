﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.WebApi.Client.Hubs
{
    /// <summary>
    /// Клиент хаба подключения к сетевой игре
    /// </summary>
    public class ConnectGameHubClient : ApplicationHubClient
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ConnectkGameHubClient"/>
        /// </summary>
        /// <param name="hubConnectionFactory">Фабрика для создания подключению к хабу</param>
        public ConnectGameHubClient(IHubConnectionFactory hubConnectionFactory)
            : base(hubConnectionFactory, "ConnectGameHub")
        {
            
        }

        /// <summary>
        /// Вызов серверного метода "Подключиться к игре"
        /// </summary>
        /// <returns>Задача, представляющая вызов серверного метода</returns>
        public Task Connect()
        {
            return Invoke("Connect");
        }
        
        /// <summary>
        /// Вызов серверного метода "Отключиться от игры"
        /// </summary>
        /// <returns>Задача, представляющая вызов серверного метода</returns>
        public Task Disconnect()
        {
            return Invoke("Disconnect");
        }

        /// <summary>
        /// Серверное событие хаба "Подключение к игре произведено"
        /// </summary>
        public event Action<Guid> OnConnected
        {
            add { AddSubscription(value, HubProxy.On("Connected", value)); }
            remove { RemoveSubscription(value); }
        }

        /// <summary>
        /// Серверное событие хаба "Отключение от игры произведено"
        /// </summary>
        public event Action<Guid> OnDisconnected
        {
            add { AddSubscription(value, HubProxy.On("Disconnected", value)); }
            remove { RemoveSubscription(value); }
        }
    }
}
