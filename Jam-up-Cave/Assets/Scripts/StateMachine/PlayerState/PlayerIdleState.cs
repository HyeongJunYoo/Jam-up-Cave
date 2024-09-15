using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(Player.Player player) : base(player)
        {
            Player = player;
        }

        public override void Enter()
        {
            Debug.Log("Idle State");
        }

        public override void Update()
        {
            if(Mathf.Abs(Player.CharacterController.velocity.x) > 0.001f ||
               Mathf.Abs(Player.CharacterController.velocity.z) > 0.001f) {
                Player.StateMachine.Transition(Player.StateMachine.MoveState);
            }
        }
    
        public override void Exit()
        {
            Debug.Log("Exit Idle State");
        }
    }
}
