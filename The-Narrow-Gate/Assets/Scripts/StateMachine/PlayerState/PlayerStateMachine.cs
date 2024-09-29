using Player;
using StateMachine.BaseClass;

namespace StateMachine.PlayerState
{
    public class PlayerStateMachine : BaseStateMachine
    {
        protected override BaseState CurrentState { get; set; }
        
        public readonly PlayerIdleState IdleState;
        public readonly PlayerMoveState MoveState;
        public readonly PlayerAttackState AttackState;
        
        public PlayerStateMachine(PlayerController playerController)
        {
            IdleState = new PlayerIdleState(playerController);
            MoveState = new PlayerMoveState(playerController);
            AttackState = new PlayerAttackState(playerController);
        }
    }
}
