namespace GameArchi.AISystem.FSM
{
    public interface IFSMState
    {
        IFSM Owner { get; }
        LifeCycle State { get; }

        public int StateID { get; }

        public void OnEnter();
        public void OnTick(float dt);
        public void OnExit();
    }
}