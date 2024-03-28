using System;
using LevelSystem;
using QuizSystem;
using RestartSystem;
using UI;

namespace Game
{
    public class GameFactory : IDisposable
    {
        private readonly QuizController quizController;
        private readonly UIFactory uiFactory;
        private readonly LevelController levelController;
        private readonly GameMachine gameMachine;
        private readonly RestartController restartController;

        public GameFactory(
            QuizController quizController,
            UIFactory uiFactory,
            LevelController levelController,
            GameMachine gameMachine,
            RestartController restartController)
        {
            this.quizController = quizController;
            this.uiFactory = uiFactory;
            this.levelController = levelController;
            this.gameMachine = gameMachine;
            this.restartController = restartController;
        }

        public void CreateGame()
        {
            uiFactory.CreateGrid();

            gameMachine.AddListener(levelController);
            gameMachine.AddListener(restartController);
            gameMachine.AddListener(quizController);

            levelController.GameFinished += gameMachine.FinishGame;
            restartController.StartGame += gameMachine.StartGame;
            restartController.AddListener(gameMachine.RestartGame);
        
            quizController.OnCorrectAnswer += levelController.NextLevel;
        }

        public void Dispose()
        {
            quizController.OnCorrectAnswer -= levelController.NextLevel;
            levelController.GameFinished -= gameMachine.FinishGame;
        }
    }
}
