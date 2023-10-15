namespace GameArchi.AI.BehaviourTree
{
    public class BNodeCondition : BNode
    {
        public BNodeCondition()
        {
            nodeType = BNodeType.Condition;
        }

        public bool Evaluate()
        {
            return true;
        }

    }
}