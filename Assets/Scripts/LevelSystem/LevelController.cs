using System.Linq;
using Game;
using UnityEngine.Events;

namespace LevelSystem
{
    public class LevelController : IStartGameListener
    {
        public UnityAction GameFinished;
        private readonly LevelsData levelsData;
        private readonly LevelFactory levelFactory;

        private int currentLevel;

        public LevelController(LevelsData levelsData, LevelFactory levelFactory)
        {
            this.levelFactory = levelFactory;
            this.levelsData = levelsData;
        }

        public void NextLevel()
        {
            currentLevel++;
            if (currentLevel == levelsData.LevelInfos.Count())
            {
                GameFinished?.Invoke();
                return;
            }
            
            StartLevel();
        }

        private void StartLevel()
        {
            levelFactory.CreateLevel(levelsData.LevelInfos[currentLevel].CardsCount);
        }

        public void OnStartGame()
        {
            currentLevel = 0;
            StartLevel();
        }

        public void OnFinishGame()
        {
            currentLevel = 0;
        }
    }
}