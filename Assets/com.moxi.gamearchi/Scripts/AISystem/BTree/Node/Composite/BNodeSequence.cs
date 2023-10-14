namespace GameArchi.AI.BehaviourTree
{
    public class BNodeSequence : BNode
    {
        int index;

        public BNodeSequence()
        {
            nodeType = BNodeType.Decorator;
        }

        public override void OnEnter()
        {
            index = 0;
            base.OnEnter();
        }

        public override BNodeState OnExecute()
        {
            if (nodeState == BNodeState.None)
            {
                OnEnter();
                return nodeState;
            }

            if (index >= Children.Count)
            {
                OnExit();
                return BNodeState.Success;
            }

            var node = Children[index];
            var state = node.OnExecute();

            if (state == BNodeState.Failure)
            {
                OnExit();
                return BNodeState.Failure;
            }

            if (state == BNodeState.Success)
            {
                index++;
            }

            return BNodeState.Running;
        }
    }
}