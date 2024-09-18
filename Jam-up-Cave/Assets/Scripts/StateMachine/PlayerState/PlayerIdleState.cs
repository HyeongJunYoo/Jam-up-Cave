using Player;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerManager playerManager) : base(playerManager)
        {
            PlayerManager = playerManager;
        }

        public override void Enter()
        {
            PlayerManager.ChangeColor(Color.white);
        }

        public override void Update()
        {
            if(PlayerManager.playerInput.MoveInput != Vector2.zero) 
                PlayerManager.StateMachine.Transition(PlayerManager.StateMachine.MoveState);
            
            if(PlayerManager.playerDetector.IsEnemyDetected())
                PlayerManager.StateMachine.Transition(PlayerManager.StateMachine.AttackState);
            
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
        }
    }
}
