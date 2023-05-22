using Services.Transitions;
using Signals;
using Systems.CommandSystem;
using Systems.CommandSystem.Payloads;
using UnityEngine;
using Zenject;

namespace MainComponents.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour, IGameplayEntryPoint
    {
        [SerializeField] private GameplayView gameplayView;
        [SerializeField] private Transform viewSpawnPoint;
        [SerializeField] private Canvas _canvas;

        [Inject]
        public void Construct(ICommandDispatcher commandDispatcher,
            ISceneTransitionService sceneTransitionService, DiContainer container)
        {
            commandDispatcher.Dispatch<SetupGameplaySignal>(new SetupGameplayPayload(gameplayView, sceneTransitionService, viewSpawnPoint, _canvas, container));
        }

        public void Dispose()
        {
                   
        }
    }
}