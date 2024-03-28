using Card;
using QuizSystem;
using UI;

namespace LevelSystem
{
    public class LevelFactory
    {
        private readonly CardsCreator cardsCreator;
        private readonly QuizController quizController;
        private readonly UIFactory uiFactory;
        private readonly ObjectPool pool;

        public LevelFactory(CardsCreator cardsCreator, QuizController quizController, UIFactory uiFactory, ObjectPool pool)
        {
            this.cardsCreator = cardsCreator;
            this.quizController = quizController;
            this.uiFactory = uiFactory;
            this.pool = pool;
        }

        public void CreateLevel(int cardCount)
        {
            pool.ReturnAllObjects();
            var grid = uiFactory.SetupGrid();
            var correctCard = cardsCreator.CreateCards(cardCount, grid.transform);
            quizController.Initialize(correctCard);
        }
    }
}
