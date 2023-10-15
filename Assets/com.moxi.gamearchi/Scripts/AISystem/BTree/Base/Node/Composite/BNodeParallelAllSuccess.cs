using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameArchi.AI.BehaviourTree
{
    public class BNodeParallelAllSuccess : BNode
    {
        int index;
        BNodeState[] states;
        List<Task<BNodeState>> tasks;
        bool IsCompleted;

        public BNodeParallelAllSuccess()
        {
            nodeType = BNodeType.Composite;
        }

        public override void OnEnter(BInput input)
        {
            index = 0;
            tasks = new List<Task<BNodeState>>();
            IsCompleted = false;
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

            _AsyncExecute(input);
            if (nodeState == BNodeState.Success)
            {
                nodeState = BNodeState.None;
                return BNodeState.Success;
            }

            nodeState = BNodeState.None;
            return BNodeState.Failure;
        }

        async void _AsyncExecute(BInput input)
        {

            for (; index < children.Count; index++)
            {
                Task<BNodeState> task = Task.Run(() =>
                {
                    return children[index].OnExecute(input);
                });
                tasks.Add(task);
            }

            while (!IsCompleted)
            {
                var task = await Task.WhenAny<BNodeState>(tasks);
                var result = task.Result;
                tasks.Remove(task);

                if (result == BNodeState.Failure)
                {
                    IsCompleted = true;
                    nodeState = BNodeState.Failure;
                    if (tasks.Count > 0)
                    {
                        foreach (var t in tasks)
                        {
                            t.Dispose();
                        }
                    }
                    return;
                }

                if (tasks.Count <= 0)
                {
                    IsCompleted = true;
                    nodeState = BNodeState.Success;
                }
            }
        }
    }
}