using Game;
using UI;
using VContainer.Unity;

public class EntryPoint : IStartable
{
    private readonly GameFactory gameFactory;
    private readonly GameMachine gameMachine;
    private readonly UIFactory uiFactory;

    public EntryPoint(GameFactory gameFactory, GameMachine gameMachine)
    {
        this.gameFactory = gameFactory;
        this.gameMachine = gameMachine;
    }

    void IStartable.Start()
    {
        gameFactory.CreateGame();
        gameMachine.StartGame();
    }
}
