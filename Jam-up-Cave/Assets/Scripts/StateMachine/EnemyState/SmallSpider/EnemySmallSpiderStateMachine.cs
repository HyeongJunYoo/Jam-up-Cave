using Enemy.Units.SmallSpider;
using StateMachine.BaseClass;

namespace StateMachine.EnemyState.SmallSpider
{
    public class EnemySmallSpiderStateMachine : BaseStateMachine
    {
        protected override BaseState CurrentState { get; set; }
        
        public readonly SmallSpiderIdleState SmallSpiderIdleState;
        public readonly SmallSpiderMoveState SmallSpiderMoveState;
        
        public EnemySmallSpiderStateMachine(EnemySmallSpiderController enemySmallSpiderController)
        {
            SmallSpiderIdleState = new SmallSpiderIdleState(enemySmallSpiderController);
            SmallSpiderMoveState = new SmallSpiderMoveState(enemySmallSpiderController);
        }
    }
}
