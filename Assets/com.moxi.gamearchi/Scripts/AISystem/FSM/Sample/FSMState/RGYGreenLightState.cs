namespace GameArchi.AISystem.FSM.Sample
{
    public class RGYGreenLightState : FSMState
    {

        float duration = 0;
        float maxDuration = 5;

        public RGYGreenLightState(FSM ownner) : base(ownner)
        {
            stateID = (int)RGYLightType.Green;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            duration = 0;
            UnityEngine.Debug.Log("Green Light OnEnter");
            state = LifeCycle.Tick;
        }

        public override void OnExit()
        {
            base.OnExit();
            duration = 0;
            UnityEngine.Debug.Log("Green Light Exit");
        }

        public override void OnTick(float dt)
        {
            base.OnTick(dt);

            if (duration < maxDuration)
            {
                duration += dt;
                UnityEngine.Debug.Log("Green Light OnTick");
                return;
            }
            else
            {
                owner.ChangeState((int)RGYLightType.Yellow);
            }
        }
    }
}