namespace GameArchi.AI.BehaviourTree
{
    public class BNodeSelector : BNode
    {
        int index;

        public BNodeSelector()
        {
            nodeType = BNodeType.Composite;
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
                return BNodeState.Failure;
            }

            var node = Children[index];
            var state = node.OnExecute();

            if (state == BNodeState.Success)
            {
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