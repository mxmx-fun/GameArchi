namespace GameArchi.AI.BehaviourTree
{
    public class BNodeSequence : BNode
    {
        int index;

        public BNodeSequence()
        {
            nodeType = BNodeType.Decorator;
        }

        public override void OnEnter(BInput input)
        {
            index = 0;
            base.OnEnter(input);
        }

        public override BNodeState OnExecute(BInput input)
        {
            if (nodeState == BNodeState.None)
            {
                OnEnter(input);
                if (nodeState == BNodeState.Failure)
                {
                    OnExit();
                    return BNodeState.Failure;
                }
                return nodeState;
            }

            if (index >= Children.Count)
            {
                OnExit();
                return BNodeState.Success;
            }

            var node = Children[index];
            var state = node.OnExecute(input);

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