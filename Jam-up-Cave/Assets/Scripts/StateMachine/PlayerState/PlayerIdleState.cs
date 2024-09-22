using Player;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerController playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void Enter()
        {
            PlayerController.ChangeColor(Color.white);
        }

        public override void Update()
        {
            if(PlayerController.playerInput.MoveInput != Vector2.zero) 
                PlayerController.StateMachine.Transition(PlayerController.StateMachine.MoveState);
            
            if(PlayerController.playerDetector.IsEnemyDetected())
                PlayerController.StateMachine.Transition(PlayerController.StateMachine.AttackState);
            
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
        }
    }
}
