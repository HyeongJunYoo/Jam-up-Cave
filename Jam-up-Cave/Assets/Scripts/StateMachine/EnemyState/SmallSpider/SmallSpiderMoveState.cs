using Enemy.Units.SmallSpider;
using UnityEngine;

namespace StateMachine.EnemyState.SmallSpider
{
    public class SmallSpiderMoveState : EnemyState<EnemySmallSpiderController>
    {
        private float _timer;
        
        public SmallSpiderMoveState(EnemySmallSpiderController smallSpiderController) : base(smallSpiderController)
        {
            Controller = smallSpiderController;
            RestartMoveTimer();
        }

        public override void Enter()
        {
            Debug.Log("EnemySmallSpiderMoveState Enter");
        }

        public override void Update()
        {
            Controller.movement.Move();
            
            if(IsMoveDurationComplete())
                Controller.StateMachine.Transition(Controller.StateMachine.SmallSpiderIdleState);
          
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
            RestartMoveTimer();
            Controller.damaged.IsDamaged = false;

        }
        
        private bool IsMoveDurationComplete()
        {
            _timer += Time.deltaTime;
            
            return _timer > 3f;
        }
        
        private void RestartMoveTimer()
        {
            _timer = 0;
        }
    }
}
