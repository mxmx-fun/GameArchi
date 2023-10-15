namespace GameArchi.AI.BehaviourTree
{
    public class BNodeSelector : BNode
    {
        int index;

        public BNodeSelector()
        {
            nodeType = BNodeType.Composite;
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
                return BNodeState.Failure;
            }

            var node = Children[index];
            var state = node.OnExecute(input);

            if (state == BNodeState.Success)
            {
                OnExit();
                return BNodeState.Success;
            }

            if (state == BNodeState.Failure)
            {
                index++;
            }
            return BNodeState.Running;
        }
    }
}