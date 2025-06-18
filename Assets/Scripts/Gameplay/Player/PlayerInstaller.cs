using Zenject;

namespace Gameplay.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInput>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        }
    }
}
