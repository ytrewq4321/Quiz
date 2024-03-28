using System;
using Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer;

namespace Card
{
    public class CardView : MonoBehaviour, IPointerClickHandler, IStartGameListener
    {
        [SerializeField] private Image image;
        [SerializeField] private CardEffects cardEffects;
        public Action<CardView> OnSelectedCard;

        private UserInput.UserInput userInput;
        private string cardName;

        [Inject]
        public void Construct(UserInput.UserInput userInput)
        {
            this.userInput = userInput;
        }
        
        public void Initialize(string name, Sprite sprite, Vector3 rotation)
        {
            image.sprite = sprite;
            cardName = name;
            image.SetNativeSize();

            image.rectTransform.eulerAngles = rotation;
        }

        public string GetName()
        {
            return cardName;
        }

        public void ShakeCard()
        {
            cardEffects.Shake();
        }

        public void BounceCard()
        {
            cardEffects.Bounce();
        }

        public void PlayParticles()
        {
            cardEffects.PlayParticles();
        }

        public void OnPointerClick(PointerEventData eventData)
        { 
            userInput.Click(this);
        }

        public void OnStartGame()
        {
            cardEffects.Bounce();
        }
    }
}