using Player;
using StateMachine.BaseClass;

namespace StateMachine.PlayerState
{
    public abstract class PlayerState : BaseState
    {
        protected PlayerController PlayerController;
    
        protected PlayerState(PlayerController playerController)
        {
            PlayerController = playerController;
        }
    }
}
