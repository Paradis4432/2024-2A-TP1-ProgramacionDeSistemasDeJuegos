using Scenes.Gameplay.Strategies;

namespace Scenes.Gameplay.Structures.Wrappers {
    public interface IWrapper {
        
        IHealth Unwrap();
    }
}