using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Card
{
    public class CardsCreator
    {
        private readonly CardFactory cardFactory;

        private Dictionary<string, List<CardData>> cardDataBundlesDictionary;
        private Dictionary<string, List<CardData>> availableAnswerCardsDictionary;
        private List<CardData> currentCardBundle;
        private List<CardData> cardToCreate;
        private CardData currentAvailableCard;

        
        public CardsCreator(List<CardBundleData> cardDataBundles, CardFactory cardFactory)
        {
            this.cardFactory = cardFactory;

            availableAnswerCardsDictionary = new Dictionary<string, List<CardData>>();
            cardDataBundlesDictionary = new Dictionary<string, List<CardData>>();
            currentCardBundle = new List<CardData>();
            cardToCreate = new List<CardData>();

            foreach (var cardDataBundle in cardDataBundles)
            {
                availableAnswerCardsDictionary.Add(cardDataBundle.BundleName,new List<CardData>(cardDataBundle.CardData));
                cardDataBundlesDictionary.Add(cardDataBundle.BundleName,new List<CardData>(cardDataBundle.CardData));
            }
        }

        public CardData CreateCards(int cardsCount, Transform parrent)
        {
            if (availableAnswerCardsDictionary.Count == 0)
            {
                Debug.Log("Game Over");
                return new CardData();
            }
            
            var bundleName = ChooseRandomCardBundle();
            ChooseCorrectCard(bundleName);
            ChooseRandomCards(cardsCount);
            GenerateCards( cardsCount, parrent);

            return currentAvailableCard;
        }

        private void  GenerateCards(int cardsCount, Transform parrent)
        {
            for (int i = 0; i < cardsCount; i++)
            {
                CardView cardView = cardFactory.CreateCard();
                cardView.transform.SetParent(parrent);

                var randomIndex = Random.Range(0, cardToCreate.Count);
                var currentCardData = cardToCreate[randomIndex];
                
                cardView.Initialize(currentCardData.Name,currentCardData.Sprite,currentCardData.Rotation);
                
                cardToCreate.Remove(currentCardData);
            }
            cardToCreate.Clear();
        }

        private void ChooseRandomCards(int cardsCount)
        {
            for (int i = 1; i < cardsCount; i++)
            {
                var randomIndex = Random.Range(0, currentCardBundle.Count);
                var currentCartData = currentCardBundle[randomIndex];
                cardToCreate.Add(currentCartData);
            }
        }

        private string ChooseRandomCardBundle()
        {
            string[] keys = new string[cardDataBundlesDictionary.Count];
            cardDataBundlesDictionary.Keys.CopyTo(keys, 0);
            string randomKey = keys[Random.Range(0,keys.Length)];
            currentCardBundle =  new List<CardData>(cardDataBundlesDictionary[randomKey]);
            return randomKey;
        }
        
        private void ChooseCorrectCard(string bundleName)
        {
            var availableCards = availableAnswerCardsDictionary[bundleName];
            var availableCardIndex = Random.Range(0, availableCards.Count());
            currentAvailableCard = availableCards[availableCardIndex];

            cardToCreate.Add(currentAvailableCard);
            availableCards.RemoveAt(availableCardIndex);

            if (availableCards.Count() == 0)
            {
                availableAnswerCardsDictionary.Remove(bundleName);
                cardDataBundlesDictionary.Remove(bundleName);
            }
            
            currentCardBundle.Remove(currentAvailableCard);
        }
    }
}