using StateMachine.BaseClass;

namespace StateMachine.PlayerState
{
    public abstract class PlayerState : BaseState
    {
        protected Player.Player Player;
    
        protected PlayerState(Player.Player player)
        {
            Player = player;
        }
    }
}
