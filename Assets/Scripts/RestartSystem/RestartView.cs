using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RestartSystem
{
    public class RestartView : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Image backGroundImage;
        
        public void AddListener(UnityAction action)
        {
            restartButton.onClick.AddListener(action);
        }
    
        public void RemoveListener(UnityAction action)
        {
            restartButton.onClick.RemoveListener(action);
        }
    
        public void OnStartGame()
        {
            backGroundImage.DOFade(0, 0);
            backGroundImage.gameObject.SetActive(false);
        }

        public void OnFinishGame()
        {
            restartButton.gameObject.SetActive(true);
            backGroundImage.gameObject.SetActive(true);
            backGroundImage.DOFade(0.5f, 0.5f);
        }

        public void OnRestartGame()
        {
            restartButton.gameObject.SetActive(false);
            backGroundImage.DOFade(1, 1f);
        }
    
        private void OnDestroy()
        {
            restartButton.onClick.RemoveAllListeners();
        }
    }
}
