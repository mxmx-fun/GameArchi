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

        protected BNode preConditionNode;
        public BNode PreConditionNode => preConditionNode;

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

        public virtual void OnEnter()
        {
            if (PreConditionNode != null)
            {
                var conditionNode = preConditionNode as BNodeCondition;
                if (!conditionNode.Evaluate())
                {
                    nodeState = BNodeState.Failure;
                    return;
                }
            }
            nodeState = BNodeState.Running;
        }

        public virtual BNodeState OnExit()
        {
            return BNodeState.None;
        }

        public virtual BNodeState OnExecute()
        {
            return BNodeState.Success;
        }

        public void SetPreConditionNode(BNode node)
        {
            preConditionNode = node;
        }

    }
}