using Cysharp.Threading.Tasks;
using Player;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerAttackState : PlayerState
    {
        public PlayerAttackState(PlayerController playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void Enter()
        {
            PlayerController.ChangeColor(Color.red);
        }

        public override void Update()
        {
            if(PlayerController.playerInput.MoveInput != Vector2.zero) 
                PlayerController.StateMachine.Transition(PlayerController.StateMachine.MoveState);
            
            
            var closestEnemy = PlayerController.playerDetector.GetClosestEnemy();

            if (closestEnemy == null)
                PlayerController.StateMachine.Transition(PlayerController.StateMachine.IdleState);
            else
                PlayerController.playerAttack.Attack(closestEnemy);
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
