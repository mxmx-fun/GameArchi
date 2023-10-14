using System.Collections.Generic;

namespace GameArchi.AISystem.FSM
{

    public class FSM : IFSM
    {
        protected FSMState state;
        public FSMState State => state;

        protected Dictionary<int, FSMState> states;

        public FSM()
        {
            states = new Dictionary<int, FSMState>();
        }

        public virtual void ChangeState(int stateID)
        {
            state?.OnExit();

            if (states.ContainsKey(stateID))
            {
                state = states[stateID];
                state.OnEnter();
            }

        }

        public virtual void Reset()
        {
            state = null;
        }

        public virtual void Tick(float dt)
        {
            state?.OnTick(dt);
        }
    }

}

