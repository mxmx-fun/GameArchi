using System.Collections.Generic;

namespace GameArchi.AI.BehaviourTree
{

    public class BNode
    {
        protected BNodeState nodeName;
        public BNodeState NodeName => nodeName;

        protected BNodeType nodeType;
        public BNodeType NodeType => nodeType;

        protected List<BNode> children;
        public List<BNode> Children => children;


        protected BNodeState nodeState;
        public BNodeState NodeState => nodeState;


        public BNode()
        {
            children = new List<BNode>();
            nodeState = BNodeState.None;
        }

        public virtual void OnEnter()
        {
            nodeState = BNodeState.Running;
        }

        public virtual BNodeState OnExit()
        {
            return BNodeState.Success;
        }

        public virtual BNodeState OnExecute()
        {
            return BNodeState.Success;
        }

        public BNodeState GetNodeState()
        {
            return nodeState;
        }

    }
}