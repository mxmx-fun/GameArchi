namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BNActionPatrol : BNodeAction
    {
        public BNActionPatrol() : base()
        {
            nodeName = "巡逻";
        }

        public override BNodeState OnExecute()
        {
            UnityEngine.Debug.Log("巡逻中");
            return BNodeState.Success;
        }
    }
}