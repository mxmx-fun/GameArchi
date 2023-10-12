namespace GameArchi.AISystem.FSM.Sample
{
    public class RGYYellowLightState : IFSMState
    {

        IFSM owner;
        IFSM IFSMState.Owner => owner;

        int stateID;
        int IFSMState.StateID => stateID;

        LifeCycle state;
        LifeCycle IFSMState.State => state;


        float duration = 0;
        float maxDuration = 2;

        public RGYYellowLightState(IFSM manager)
        {
            this.owner = manager;
            stateID = (int)RGYLightType.Yellow;
        }

        void IFSMState.OnEnter()
        {
            state = LifeCycle.Enter;
            duration = 0;
            UnityEngine.Debug.Log("Yellow Light OnEnter");
            state = LifeCycle.Tick;
        }

        void IFSMState.OnExit()
        {
            state = LifeCycle.Exit;
            duration = 0;
            UnityEngine.Debug.Log("Yellow Light Exit");
        }

        void IFSMState.OnTick(float dt)
        {
            if (state != LifeCycle.Tick) return;
            
            if (duration < maxDuration)
            {
                duration += dt;
                UnityEngine.Debug.Log("Yellow Light OnTick");
                return;
            }
            else
            {
                owner.ChangeState((int)RGYLightType.Red);
            }
        }
    }
}