using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(Player.Player player) : base(player)
        {
            Player = player;
        }

        public override void Enter()
        {
            Debug.Log("Move State");  
        }
        public override void Update()
        {
            if(Mathf.Abs(Player.CharacterController.velocity.x) <= 0 &&
               Mathf.Abs(Player.CharacterController.velocity.z) <= 0) {
                Player.StateMachine.Transition(Player.StateMachine.IdleState);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Move State");
        }
    }
}
