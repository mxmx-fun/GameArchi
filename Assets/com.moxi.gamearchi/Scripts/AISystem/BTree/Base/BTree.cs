using System.Collections.Generic;

namespace GameArchi.AI.BehaviourTree
{
    public class BTree
    {
        protected string treeName;

        BNode root;
        public BNode Root => root;

        BNode currentNode;
        public BNode CurrentNode => currentNode;

        public BInput input;

        public BTree()
        {
            input = new BInput();
        }

        public void SetRoot(BNode value)
        {
            root = value;
            currentNode = root;
        }


        public void OnExecute(BInput input)
        {
            currentNode?.OnExecute(input);
        }

        public virtual void Init() { }
    }
}