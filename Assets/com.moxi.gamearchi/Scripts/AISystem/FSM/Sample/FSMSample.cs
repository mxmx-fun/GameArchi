using UnityEngine;

namespace GameArchi.AISystem.FSM.Sample
{
    public class FSMSample : MonoBehaviour
    {
        RGYFSM rgyFSM;

        public void Awake()
        {
            rgyFSM = new RGYFSM();
        }

        public void Update()
        {
            rgyFSM.Tick(Time.deltaTime);
        }
    }
}