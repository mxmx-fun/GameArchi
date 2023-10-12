namespace GameArchi.AISystem.FSM
{
    public enum LifeCycle
    {
        Enter,
        Tick,
        Exit,
    }

    public interface IFSMState
    {
        FSM Owner { get; }
        LifeCycle State { get; }

        int StateID { get; }

        void OnEnter();
        void OnTick(float dt);
        void OnExit();
    }
}