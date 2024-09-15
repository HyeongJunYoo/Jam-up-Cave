using StateMachine.BaseClass;

namespace StateMachine.PlayerState
{
    public abstract class PlayerState : BaseState
    {
        protected Player Player;
    
        protected PlayerState(Player player)
        {
            Player = player;
        }
    }
}
