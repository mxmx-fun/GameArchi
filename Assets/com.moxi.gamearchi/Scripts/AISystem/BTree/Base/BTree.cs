using System.Collections.Generic;

namespace GameArchi.AI.BehaviourTree
{
    public class BTree
    {
        BNode root;
        public BNode Root => root;
        public void SetRoot(BNode value) => root = value;

        BNode currentNode;
        public BNode CurrentNode => currentNode;

        public BInput input;

        public BTree()
        {
            input = new BInput();
            currentNode = root;
        }

        public void OnExecute()
        {
            if (root == null) return;
            currentNode.OnExecute();
        }
    }
}