using Enemy;
using Enemy.SmallSpider;
using UnityEngine;

namespace StateMachine.EnemyState.SmallSpider
{
    public class EnemySmallSpiderMoveState : EnemySmallSpiderState
    {
        private float _timer;


        public EnemySmallSpiderMoveState(EnemySmallSpiderController smallSpiderController) : base(smallSpiderController)
        {
            SmallSpiderController = smallSpiderController;
            _timer = 0;
        }

        public override void Enter()
        {
            Debug.Log("EnemySmallSpiderMoveState Enter");
        }

        public override void Update()
        {
            //3초후 IdleState로 전환
            _timer += Time.deltaTime;
            if(_timer > 3f)
                SmallSpiderController.StateMachine.Transition(SmallSpiderController.StateMachine.SmallSpiderIdleState);
          
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
            _timer = 0;
            SmallSpiderController.IsDamaged = false;
        }
    }
}
