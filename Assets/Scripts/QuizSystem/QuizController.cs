using System;
using System.Collections;
using Card;
using Game;
using UnityEngine;
using Utils;

namespace QuizSystem
{
    public class QuizController : IStartGameListener, IFinishGameListener
    {
        public Action OnCorrectAnswer;
    
        private readonly UserInput.UserInput userInput;
        private readonly CoroutineRunner coroutineRunner;
        private readonly QuizView quizView;
        private CardData correctCard;

        public QuizController(UserInput.UserInput userInput, CoroutineRunner coroutineRunner, QuizView quizView)
        {
            this.userInput = userInput;
            this.coroutineRunner = coroutineRunner;
            this.quizView = quizView;
            userInput.OnClicked += CheckAnswer;
        }
    
        public void Initialize(CardData correctCard)
        {
            this.correctCard = correctCard;
            userInput.SetInput(true);
            quizView.SetText(this.correctCard.Name);
        }

        private void CheckAnswer(CardView cardView)
        {
            if (cardView.GetName() == correctCard.Name)
            {
                userInput.SetInput(false);
                coroutineRunner.StartCoroutine(WaitCoroutine(OnCorrectAnswer));
                cardView.BounceCard();
                cardView.PlayParticles();

            }
            else
            {
                cardView.ShakeCard();
            }
        }

        private IEnumerator WaitCoroutine(Action action)
        {
            yield return new WaitForSeconds(1.8f);
            action?.Invoke();
        }

        public void OnStartGame()
        {
            quizView.ShowQuizText();
        }

        public void OnFinishGame()
        {
            quizView.HideQuizText();
        }
    }
}