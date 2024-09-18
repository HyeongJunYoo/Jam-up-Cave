using Player;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(PlayerManager playerManager) : base(playerManager)
        {
            PlayerManager = playerManager;
        }

        public override void Enter()
        {
            PlayerManager.ChangeColor(Color.green);
        }
        public override void Update()
        {
            PlayerManager.playerMovement.MoveCharacter();
            
            if(PlayerManager.playerInput.MoveInput == Vector2.zero) 
                PlayerManager.StateMachine.Transition(PlayerManager.StateMachine.IdleState);
            
        }

        public override void FixedUpdate()
        {
            PlayerManager.playerMovement.CalculateNextFixedPosition(PlayerManager.playerInput.MoveInput);
        }

        public override void Exit()
        {
        }
    }
}
