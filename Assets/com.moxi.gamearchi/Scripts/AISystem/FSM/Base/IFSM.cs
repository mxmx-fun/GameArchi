namespace GameArchi.AISystem.FSM
{

    public interface IFSM
    {

        FSMState State { get; }        

        void ChangeState(int stateID);

        void Reset();

        void Tick(float dt);
    }

}

