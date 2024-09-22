using Enemy.SmallSpider;
using StateMachine.BaseClass;

namespace StateMachine.EnemyState.SmallSpider
{
    public class EnemySmallSpiderStateMachine : BaseStateMachine
    { 
        protected override BaseState CurrentState { get; set; }

        public readonly EnemySmallSpiderIdleState SmallSpiderIdleState;
        public readonly EnemySmallSpiderMoveState SmallSpiderMoveState;
        
        public EnemySmallSpiderStateMachine(EnemySmallSpiderController smallSpiderController)
        {
            SmallSpiderIdleState = new EnemySmallSpiderIdleState(smallSpiderController);
            SmallSpiderMoveState = new EnemySmallSpiderMoveState(smallSpiderController);
        }
    }
}
