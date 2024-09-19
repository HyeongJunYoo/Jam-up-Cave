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
            
            
            if(PlayerManager.playerDetector.IsEnemyDetected() == false)
                PlayerManager.StateMachine.Transition(PlayerManager.StateMachine.IdleState);
            
            PlayerManager.playerAttack.Attack();
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
