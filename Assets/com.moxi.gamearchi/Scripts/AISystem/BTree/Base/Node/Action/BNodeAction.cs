namespace GameArchi.AI.BehaviourTree
{
    public class BNodeAction : BNode
    {
        public BNodeAction()
        {
            nodeType = BNodeType.Action;
        }

        public override void OnEnter(BInput input)
        {
            nodeState = BNodeState.Running;
        }

        public override void OnExit()
        {
            nodeState =  BNodeState.None;
        }

        public override BNodeState OnExecute(BInput input)
        {
            return BNodeState.Success;
        }

    }
}