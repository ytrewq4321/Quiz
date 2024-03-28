using System;
using Card;

namespace UserInput
{
    public class UserInput
    {
        public Action<CardView> OnClicked;
        private bool canInput;

        public void Click(CardView cardView)
        {
            if(canInput)
                OnClicked?.Invoke(cardView);
        }

        public void SetInput(bool value)
        {
            canInput = value;
        }
    }
}