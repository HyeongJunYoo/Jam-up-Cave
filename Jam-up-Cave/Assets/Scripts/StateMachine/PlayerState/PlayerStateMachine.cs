using Player;
using StateMachine.BaseClass;

namespace StateMachine.PlayerState
{
    public class PlayerStateMachine : BaseStateMachine
    {
        public BaseState CurrentState { get; private set; }

        public readonly PlayerIdleState IdleState;
        public readonly PlayerMoveState MoveState;
        public readonly PlayerAttackState AttackState;
    
        public PlayerStateMachine(PlayerManager playerManager)
        {
            IdleState = new PlayerIdleState(playerManager);
            MoveState = new PlayerMoveState(playerManager);
            AttackState = new PlayerAttackState(playerManager);
        }
    
        public override void Initialize()
        {
            CurrentState = IdleState;
            CurrentState.Enter();
        }

        public override void Transition(BaseState nexState)
        {
            CurrentState.Exit();
            CurrentState = nexState;
            nexState.Enter();
        }

        public override void Update()
        {
            CurrentState?.Update();
        }
        
        public override void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }
    }
}
