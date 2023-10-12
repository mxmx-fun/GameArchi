using UnityEngine;

namespace GameArchi.AISystem.FSM.Sample
{
    public class FSMSample : MonoBehaviour
    {
        IFSM rgyFSM;

        public void Awake()
        {
            rgyFSM = new RGYFSM();
            rgyFSM.ChangeState((int)RGYLightType.Red);
        }

        public void Update()
        {
            rgyFSM.Tick(Time.deltaTime);
        }
    }
}