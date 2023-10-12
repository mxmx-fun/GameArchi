namespace GameArchi.AISystem.FSM
{
    public class FSMState : IFSMState
    {

        protected FSM owner;
        public FSM Owner => owner;

        protected int stateID;
        public int StateID => stateID;

        protected LifeCycle state;
        public LifeCycle State => state;

        public FSMState(FSM owner)
        {
            this.owner = owner;
        }

        public virtual void OnEnter()
        {
            state = LifeCycle.Enter;
        }

        public virtual void OnExit()
        {
            state = LifeCycle.Exit;
        }

        public virtual void OnTick(float dt)
        {
            if (state != LifeCycle.Tick) return;
        }
    }
}