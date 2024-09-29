using Player;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(PlayerController playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void Enter()
        {
            PlayerController.ChangeColor(Color.green);
        }
        public override void Update()
        {
            PlayerController.playerMovement.MoveCharacter();
            
            if(PlayerController.playerInput.MoveInput == Vector2.zero) 
                PlayerController.StateMachine.Transition(PlayerController.StateMachine.IdleState);
            
        }

        public override void FixedUpdate()
        {
            PlayerController.playerMovement.CalculateNextFixedPosition(PlayerController.playerInput.MoveInput);
        }

        public override void Exit()
        {
        }
    }
}
