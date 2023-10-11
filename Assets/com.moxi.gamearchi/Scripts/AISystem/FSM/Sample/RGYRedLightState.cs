namespace GameArchi.AISystem.FSM.Sample
{
    public class RGYRedLightState : IFSMState
    {

        IFSM owner;
        IFSM IFSMState.Owner => owner;

        int stateID;
        int IFSMState.StateID => stateID;

        LifeCycle state;
        LifeCycle IFSMState.State => state;


        float duration = 0;
        float maxDuration = 4;

        public RGYRedLightState(IFSM manager)
        {
            this.owner = manager;
            stateID = (int)RGYLightType.Red;
        }

        void IFSMState.OnEnter()
        {
            state = LifeCycle.Enter;
            duration = 0;
            UnityEngine.Debug.Log("Red Light OnEnter");
            state = LifeCycle.Tick;
        }

        void IFSMState.OnExit()
        {
            state = LifeCycle.Exit;
            duration = 0;
            UnityEngine.Debug.Log("Red Light Exit");
        }

        void IFSMState.OnTick(float dt)
        {
            if (state != LifeCycle.Tick) return;
            
            if (duration < maxDuration)
            {
                duration += dt;
                UnityEngine.Debug.Log("Red Light OnTick");
                return;
            }
            else
            {
                owner.ChangeState((int)RGYLightType.Green);
            }
        }
    }
}