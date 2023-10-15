namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BNActionAttack : BNodeAction
    {
        public BNActionAttack() : base()
        {
            nodeName = "攻击";
        }

        public override BNodeState OnExecute(BInput input)
        {
            UnityEngine.Debug.Log("攻击！");
            return BNodeState.Success;
        }
    }
}