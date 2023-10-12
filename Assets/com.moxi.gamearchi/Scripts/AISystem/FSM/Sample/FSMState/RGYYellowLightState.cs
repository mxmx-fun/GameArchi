namespace GameArchi.AISystem.FSM.Sample
{
    public class RGYYellowLightState : FSMState
    {
        float duration = 0;
        float maxDuration = 2;

        public RGYYellowLightState(FSM ownner):base(ownner)
        {
            stateID = (int)RGYLightType.Yellow;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            duration = 0;
            UnityEngine.Debug.Log("Yellow Light OnEnter");
            state = LifeCycle.Tick;
        }

        public override void OnExit()
        {
            base.OnExit();
            duration = 0;
            UnityEngine.Debug.Log("Yellow Light Exit");
        }

        public override void OnTick(float dt)
        {
            base.OnTick(dt);
            
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