﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Models.About;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class ConnectPanelView : View
    {
        [Tooltip("Объект, активирующийся при удачном соединении с игровым веб-сервером")]
        public GameObject SuccessObject;

        [Tooltip("Объект, активирующийся при неудачном соединении с игровым веб-сервером")]
        public GameObject FailureConnectObject;

        [Tooltip("Объект, активирующийся при несоответствующей версии клиента и игрового веб-сервера")]
        public GameObject FailureVersionObject;

        public void Initialize(AboutClient aboutClient)
        {
            var getVersionTask = aboutClient.GetVersion();

            StartCoroutine(GetVersionCoroutine(getVersionTask));
        }

        public void OnBackButtonClickHandler()
        {
            SceneManager.LoadScene("MenuScene");
        }

        private IEnumerator GetVersionCoroutine(Task<VersionModel> task)
        {
            while (!task.IsCompleted)
                yield return null;

            gameObject.SetActive(false);
            
            SuccessObject.SetActive(task.Status == TaskStatus.RanToCompletion && task.Result.Version == 0);

            FailureConnectObject.SetActive(task.Status == TaskStatus.Faulted);
            FailureVersionObject.SetActive(task.Status == TaskStatus.RanToCompletion && task.Result.Version != 0);
        }
    }
}