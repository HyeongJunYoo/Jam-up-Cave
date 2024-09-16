namespace StateMachine.BaseClass
{
    public abstract class BaseStateMachine
    {
        public abstract void Initialize();
        public abstract void Transition(BaseState nexState);
        public abstract void Update();
    }
}
