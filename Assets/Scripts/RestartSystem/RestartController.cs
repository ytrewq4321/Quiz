using System;
using System.Collections;
using Game;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace RestartSystem
{
    public class RestartController :  IStartGameListener, IFinishGameListener, IRestartGameListener
    {
        public Action StartGame;
        
        private readonly RestartView restartView;
        private readonly CoroutineRunner coroutineRunner;

        public RestartController(RestartView restartView, CoroutineRunner coroutineRunner)
        {
            this.restartView = restartView;
            this.coroutineRunner = coroutineRunner;
        }

        public void AddListener(UnityAction unityAction)
        {
            restartView.AddListener(unityAction);
        }

        public void OnStartGame()
        {
            restartView.OnStartGame();
        }

        public void OnFinishGame()
        {
            restartView.OnFinishGame();
        }

        public void OnRestartGame()
        {
            restartView.OnRestartGame();

            coroutineRunner.StartCoroutine(WaitCoroutine());
        }

        private IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(2f);
            StartGame?.Invoke();
        }
    }
}