﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine.Events;
using UnityEngine;
using Arcomage.Unity.NetworkScene.Requests;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class PreparePanelView : View
    {
        [Tooltip("Событие, вызываемое при установлении соединения с игрой")]
        public UnityEvent ConnectedEvent;

        [Tooltip("Объект, активирующийся при неудачном соединении с игровым веб-сервером")]
        public GameObject FailureConnectObject;

        public void OnEnable()
        {
            Bind(Scene.Mediator.Send(new ConnectGameRequest(), CancellationToken.None))
                .OnSuccess(t => ConnectedEvent.Invoke())
                .OnFailure(t => OnConnectGameFailure());
        }

        private void OnConnectGameFailure()
        {
            gameObject.SetActive(false);
            FailureConnectObject.SetActive(true);
        }
    }
}
