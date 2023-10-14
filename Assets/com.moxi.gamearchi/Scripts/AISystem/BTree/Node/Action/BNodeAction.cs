namespace GameArchi.AI.BehaviourTree
{
    public class BNodeAction : BNode
    {
        public BNodeAction()
        {
            nodeType = BNodeType.Action;
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override BNodeState OnExit()
        {
            return base.OnExit();
        }

        public override BNodeState OnExecute()
        {
            return base.OnExecute();
        }
    }
}