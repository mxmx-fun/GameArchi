namespace GameArchi.AISystem.FSM
{

    public interface IFSM
    {

        IFSMState CurrentState { get; }
        
        IFSMState GetCurrentState();

        void ChangeState(int stateID);

        void Reset();

        void Tick(float dt);
    }

}

