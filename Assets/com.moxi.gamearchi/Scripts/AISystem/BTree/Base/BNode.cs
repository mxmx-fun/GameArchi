using System.Collections.Generic;

namespace GameArchi.AI.BehaviourTree
{

    public class BNode
    {
        protected string nodeName;
        public string NodeName => nodeName;

        protected BNodeType nodeType;
        public BNodeType NodeType => nodeType;

        protected List<BNode> children;
        public List<BNode> Children => children;

        protected BNodeCondition preConditionNode;
        public BNodeCondition PreConditionNode => preConditionNode;

        protected BNodeState nodeState;
        public BNodeState NodeState => nodeState;



        public BNode()
        {
            children = new List<BNode>();
            nodeState = BNodeState.None;
        }

        public void AddChild(BNode node)
        {
            children.Add(node);
        }

        public void RemoveChild(BNode node)
        {
            children.Remove(node);
        }

        public void ClearChildren()
        {
            children.Clear();
        }

        public void InsertChildren(BNode preNode, BNode insertNode)
        {
            int index = children.IndexOf(preNode);
            if (index >= 0)
            {
                children.Insert(index, insertNode);
            }
        }

        public virtual void OnEnter(BInput input)
        {
            if (PreConditionNode != null)
            {
                if (!PreConditionNode.Evaluate(input))
                {
                    nodeState = BNodeState.Failure;
                    return;
                }
            }
            nodeState = BNodeState.Running;
        }

        public virtual void OnExit()
        {
            nodeState = BNodeState.None;
        }

        public virtual BNodeState OnExecute(BInput input)
        {
            return BNodeState.Success;
        }

        public void SetPreConditionNode(BNodeCondition node)
        {
            preConditionNode = node;
        }

    }
}