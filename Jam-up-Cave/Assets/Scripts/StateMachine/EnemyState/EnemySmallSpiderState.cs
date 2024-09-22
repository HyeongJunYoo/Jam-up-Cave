using Enemy;
using Enemy.BaseClass;
using Enemy.SmallSpider;
using StateMachine.BaseClass;

namespace StateMachine.EnemyState
{
    public abstract class EnemySmallSpiderState : BaseState
    {
        protected EnemySmallSpiderController SmallSpiderController;
        
        protected EnemySmallSpiderState(EnemySmallSpiderController smallSpiderController)
        {
            SmallSpiderController = smallSpiderController;
        }
    }
}
