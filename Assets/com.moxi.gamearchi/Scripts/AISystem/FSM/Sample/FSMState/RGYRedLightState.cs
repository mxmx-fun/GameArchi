namespace GameArchi.AISystem.FSM.Sample
{
    public class RGYRedLightState : FSMState
    {

        float duration = 0;
        float maxDuration = 4;

        public RGYRedLightState(FSM ownner): base(ownner)
        {
            stateID = (int)RGYLightType.Red;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            duration = 0;
            UnityEngine.Debug.Log("Red Light OnEnter");
            state = LifeCycle.Tick;
        }

        public override void OnExit()
        {
            base.OnExit();
            duration = 0;
            UnityEngine.Debug.Log("Red Light Exit");
        }

        public override void OnTick(float dt)
        {
            base.OnTick(dt);
            
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