namespace GameArchi.AI.BehaviourTree
{
    public class BNodeCondition : BNode
    {
        public BNodeCondition()
        {
            nodeType = BNodeType.Condition;
        }

        public virtual bool Evaluate(BInput input)
        {
            return true;
        }

    }
}