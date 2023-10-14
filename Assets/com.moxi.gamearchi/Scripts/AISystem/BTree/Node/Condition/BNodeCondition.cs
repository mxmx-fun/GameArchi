namespace GameArchi.AI.BehaviourTree
{
    public class BNodeCondition : BNode
    {
        public BNodeCondition()
        {
            nodeType = BNodeType.Condition;
        }

        public BNodeState Evaluate(BInput input)
        {
            return BNodeState.Success;
        }
    }
}