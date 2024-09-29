
using StateMachine.BaseClass;

namespace StateMachine.EnemyState.SmallSpider
{
    public abstract class EnemyState<TController> : BaseState where TController : class
    {
        protected TController Controller;

        protected EnemyState(TController controller)
        {
            Controller = controller;
        }
    }
}
