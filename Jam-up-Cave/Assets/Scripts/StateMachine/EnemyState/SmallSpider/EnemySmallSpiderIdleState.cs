using Enemy;
using Enemy.BaseClass;
using Enemy.SmallSpider;
using UnityEngine;

namespace StateMachine.EnemyState.SmallSpider
{
    public class EnemySmallSpiderIdleState : EnemySmallSpiderState
    {
        public EnemySmallSpiderIdleState(EnemySmallSpiderController smallSpiderController) : base(smallSpiderController)
        {
            SmallSpiderController = smallSpiderController;
        }

        public override void Enter()
        {
            Debug.Log("EnemySmallSpiderIdleState Enter");
        }

        public override void Update()
        {
            //Damage를 받으면 HitState로 전환
            if (SmallSpiderController.IsDamaged)
            {
                SmallSpiderController.StateMachine.Transition(SmallSpiderController.StateMachine.SmallSpiderMoveState);
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
