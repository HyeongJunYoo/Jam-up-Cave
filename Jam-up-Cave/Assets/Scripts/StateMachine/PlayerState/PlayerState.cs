using Player;
using StateMachine.BaseClass;

namespace StateMachine.PlayerState
{
    public abstract class PlayerState : BaseState
    {
        protected PlayerManager PlayerManager;
    
        protected PlayerState(PlayerManager playerManager)
        {
            PlayerManager = playerManager;
        }
    }
}
