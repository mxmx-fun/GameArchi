namespace GameArchi.AI.BehaviourTree
{
    public class BTree
    {
        BNode root;
        public BNode Root => root;
        public void SetRoot(BNode value) => root = value;

        public BInput input;

        public BTree()
        {
            input = new BInput();
        }

        public void OnEnter()
        {
            if (root != null)
            {
                root.OnEnter();
            }
        }

        public BNodeState OnExecute()
        {
            if (root != null)
            {
                return root.OnExecute();
            }
            return BNodeState.None;
        }
    }
}