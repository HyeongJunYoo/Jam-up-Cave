using Enemy.Units.SmallSpider;
using UnityEngine;

namespace StateMachine.EnemyState.SmallSpider
{
    public class SmallSpiderIdleState : EnemyState<EnemySmallSpiderController>
    {
        public SmallSpiderIdleState(EnemySmallSpiderController smallSpiderController) : base(smallSpiderController)
        {
            Controller = smallSpiderController;
        }

        public override void Enter()
        {
            Debug.Log("EnemySmallSpiderIdleState Enter");
        }

        public override void Update()
        {
            //Damage를 받으면 HitState로 전환
            if (Controller.damaged.IsDamaged)
            {
                Controller.StateMachine.Transition(Controller.StateMachine.SmallSpiderMoveState);
            }
        }

        public override void FixedUpdate()
        {
        }

        public override void Exit()
        {
        }
    }
}
