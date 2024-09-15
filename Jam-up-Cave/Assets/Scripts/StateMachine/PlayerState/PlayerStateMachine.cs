using StateMachine.BaseClass;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerStateMachine : BaseStateMachine
    {
        public BaseState CurrentState { get; private set; }

        public readonly PlayerIdleState IdleState;
        public readonly PlayerMoveState MoveState;
    
        public PlayerStateMachine(Player.Player player)
        {
            IdleState = new PlayerIdleState(player);
            MoveState = new PlayerMoveState(player);
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
    }
}
