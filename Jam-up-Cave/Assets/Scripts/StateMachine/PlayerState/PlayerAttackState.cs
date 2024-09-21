using Cysharp.Threading.Tasks;
using Player;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerAttackState : PlayerState
    {
        public PlayerAttackState(PlayerManager playerManager) : base(playerManager)
        {
            PlayerManager = playerManager;
        }

        public override void Enter()
        {
            PlayerManager.ChangeColor(Color.red);
        }

        public override void Update()
        {
            if(PlayerManager.playerInput.MoveInput != Vector2.zero) 
                PlayerManager.StateMachine.Transition(PlayerManager.StateMachine.MoveState);
            
            
            var closestEnemy = PlayerManager.playerDetector.GetClosestEnemy();

            if (closestEnemy == null)
                PlayerManager.StateMachine.Transition(PlayerManager.StateMachine.IdleState);
            else
                PlayerManager.playerAttack.Attack(closestEnemy);
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
