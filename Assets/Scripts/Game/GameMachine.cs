using System;
using System.Collections.Generic;

namespace Game
{
    public class GameMachine : IDisposable
    {
        private readonly List<object> listeners=new List<object>();

        public void StartGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is IStartGameListener starGameListener)
                {
                    starGameListener.OnStartGame();
                }
            }
        }

        public void FinishGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is IFinishGameListener finishGameListener)
                {
                    finishGameListener.OnFinishGame();
                }
            }
        }
    
        public void RestartGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is IRestartGameListener restartGameListener)
                {
                    restartGameListener.OnRestartGame();
                }
            }
        }
    
        public void AddListener(object listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(object listener)
        {
            listeners.Remove(listener);
        }

        public void Dispose()
        {
            listeners.Clear();
        }
    }
}