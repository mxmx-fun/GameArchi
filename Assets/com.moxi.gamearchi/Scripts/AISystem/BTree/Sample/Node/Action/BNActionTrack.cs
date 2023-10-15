namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BNActionTrack : BNodeAction
    {
        float time = 0;
        float CDTime = 1;
        public BNActionTrack() : base()
        {
            nodeName = "追击";
        }

        public override BNodeState OnExecute(BInput input)
        {
            if(time < CDTime)
            {
                time += UnityEngine.Time.deltaTime;
            }else {
                time = 0;
                (input as BInputDistance).Distance -= 1;
            }
            UnityEngine.Debug.Log("追击中");
            return BNodeState.Success;
        }
    }
}