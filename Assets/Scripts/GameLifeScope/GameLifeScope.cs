using System.Collections.Generic;
using Card;
using Game;
using Grid;
using LevelSystem;
using QuizSystem;
using RestartSystem;
using UI;
using UnityEngine;
using Utils;
using VContainer;
using VContainer.Unity;

namespace GameLifeScope
{
    public class GameLifeScope : LifetimeScope
    {
        [SerializeField] private CardView cardPrefab;
        [SerializeField] private GridModel gridModel;
        [SerializeField] private GridView grid;
        [SerializeField] private LevelsData levelsData;
        [SerializeField] private List<CardBundleData> cardModelsCollection;
        [SerializeField] private CoroutineRunner coroutineRunnerPrefab;
    
    
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterCoroutineRunner(builder);
            RegisterGameMachine(builder);
            RegisterRestartController(builder);
            RegisterRestartView(builder);
            RegisterQuizView(builder);
            RegisterUIRoot(builder);

            builder.RegisterComponent<GridView>(grid);
            
            RegisterUIFactory(builder);
            RegisterLevelFactory(builder);
            RegisterUserInput(builder);
            RegisterQuizController(builder);
            RegisterObjectPool(builder);
            RegisterCardFactory(builder);
            RegisterCardCreator(builder);
            RegisterLevelController(builder);
            RegisterGameFactory(builder);
            RegisterEntyPoint(builder);
        }

        private static void RegisterUIRoot(IContainerBuilder builder) => builder.RegisterComponentInHierarchy<UIRoot>();

        private static void RegisterEntyPoint(IContainerBuilder builder) => builder.RegisterEntryPoint<EntryPoint>();

        private static void RegisterGameFactory(IContainerBuilder builder) => builder.Register<GameFactory>(Lifetime.Singleton);

        private void RegisterLevelController(IContainerBuilder builder) => builder.Register<LevelController>(Lifetime.Singleton).WithParameter(levelsData);

        private void RegisterCardCreator(IContainerBuilder builder) => builder.Register<CardsCreator>(Lifetime.Singleton).WithParameter(cardModelsCollection);

        private void RegisterCardFactory(IContainerBuilder builder) => builder.Register<CardFactory>(Lifetime.Singleton).WithParameter(cardPrefab);

        private void RegisterObjectPool(IContainerBuilder builder) => builder.Register<ObjectPool>(Lifetime.Singleton).WithParameter(cardPrefab);

        private static void RegisterQuizController(IContainerBuilder builder) => builder.Register<QuizController>(Lifetime.Singleton);

        private static void RegisterUserInput(IContainerBuilder builder) => builder.Register<UserInput.UserInput>(Lifetime.Singleton);

        private static void RegisterLevelFactory(IContainerBuilder builder) => builder.Register<LevelFactory>(Lifetime.Singleton);

        private void RegisterUIFactory(IContainerBuilder builder) => builder.Register<UIFactory>(Lifetime.Singleton).WithParameter(gridModel);

        private static void RegisterQuizView(IContainerBuilder builder) => builder.RegisterComponentInHierarchy<QuizView>();

        private static void RegisterRestartView(IContainerBuilder builder) => builder.RegisterComponentInHierarchy<RestartView>();

        private static void RegisterRestartController(IContainerBuilder builder) => builder.Register<RestartController>(Lifetime.Singleton);

        private void RegisterCoroutineRunner(IContainerBuilder builder)
        {
            var coroutineRunner = Instantiate(coroutineRunnerPrefab).GetComponent<CoroutineRunner>();
            builder.RegisterComponent(coroutineRunner);
        }

        private static void RegisterGameMachine(IContainerBuilder builder) => builder.Register<GameMachine>(Lifetime.Singleton);
    }
}