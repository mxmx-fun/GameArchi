using System.Collections.Generic;

namespace GameArchi.AISystem.FSM.Sample
{
    public class RGYFSM : FSM
    {
        FSMState redLightState;
        FSMState greenLightState;
        FSMState yellowLightState;

        public RGYFSM():base()
        {
            redLightState = new RGYRedLightState(this);
            greenLightState = new RGYGreenLightState(this);
            yellowLightState = new RGYYellowLightState(this);

            states.Add(redLightState.StateID, redLightState);
            states.Add(greenLightState.StateID, greenLightState);
            states.Add(yellowLightState.StateID, yellowLightState);

            ChangeState((int)RGYLightType.Red);
        }

    }
}