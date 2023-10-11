using System.Collections.Generic;

namespace GameArchi.AISystem.FSM.Sample
{
    public class RGYFSM : IFSM
    {
        IFSMState curState;
        IFSMState IFSM.CurrentState => curState;

        Dictionary<int, IFSMState> states;

        IFSMState redLightState;
        IFSMState greenLightState;
        IFSMState yellowLightState;

        public RGYFSM()
        {
            redLightState = new RGYRedLightState(this);
            greenLightState = new RGYGreenLightState(this);
            yellowLightState = new RGYYellowLightState(this);

            states = new Dictionary<int, IFSMState>();
            states.Add(redLightState.StateID, redLightState);
            states.Add(greenLightState.StateID, greenLightState);
            states.Add(yellowLightState.StateID, yellowLightState);
        }

        void IFSM.ChangeState(int stateID)
        {
            if(curState != null) curState.OnExit();
            
            if(states.ContainsKey(stateID)) {
                curState = states[stateID];
                curState.OnEnter();
            }
        }

        IFSMState IFSM.GetCurrentState()
        {
            return curState;
        }

        void IFSM.Reset()
        {
            curState = null;
        }

        void IFSM.Tick(float dt)
        {
            if(curState == null) return;
            curState.OnTick(dt);
        }


    }
}