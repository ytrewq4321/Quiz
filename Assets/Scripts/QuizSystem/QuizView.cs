using DG.Tweening;
using TMPro;
using UnityEngine;

namespace QuizSystem
{
    public class QuizView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI quizText;

        public void SetText(string text)
        {
            quizText.text = "Find "+text;
        }

        public void ShowQuizText()
        {
            quizText.DOFade(1, 1f);
        }

        public void HideQuizText()
        {
            quizText.DOFade(0, 0);
        }
    }
}
