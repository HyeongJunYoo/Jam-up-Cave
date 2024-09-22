namespace StateMachine.BaseClass
{
    public abstract class BaseStateMachine{
        
        protected abstract BaseState CurrentState { get; set; }
        
        public void Initialize(BaseState initialState)
        {
            CurrentState = initialState;
            CurrentState.Enter();
        }
        
        public void Transition(BaseState nexState)
        {
            CurrentState.Exit();
            CurrentState = nexState;
            nexState.Enter();
        }

        public void Update()
        {
            CurrentState?.Update();
        }

        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }
    }
}
