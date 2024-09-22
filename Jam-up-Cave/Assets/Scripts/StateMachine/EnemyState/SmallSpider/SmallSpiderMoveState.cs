using Enemy;
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
            _timer = 0;
        }

        public override void Enter()
        {
            Debug.Log("EnemySmallSpiderMoveState Enter");
        }

        public override void Update()
        {
            //3초후 IdleState로 전환
            Controller.movement.Flee();
            
            _timer += Time.deltaTime;
            if(_timer > 3f)
                Controller.StateMachine.Transition(Controller.StateMachine.SmallSpiderIdleState);
          
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
            _timer = 0;
            Controller.damaged.IsDamaged = false;
        }
    }
}
