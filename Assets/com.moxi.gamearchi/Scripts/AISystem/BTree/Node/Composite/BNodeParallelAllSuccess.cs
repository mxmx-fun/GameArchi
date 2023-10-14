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

        public override void OnEnter()
        {
            index = 0;
            tasks = new List<Task<BNodeState>>();
            IsCompleted = false;
            base.OnEnter();
        }

        public override BNodeState OnExecute()
        {
            _AsyncExecute();
            if (nodeState == BNodeState.Success)
            {
                nodeState = BNodeState.None;
                return BNodeState.Success;
            }

            nodeState = BNodeState.None;
            return BNodeState.Failure;
        }

        async void _AsyncExecute()
        {

            for (; index < children.Count; index++)
            {
                Task<BNodeState> task = Task.Run(() =>
                {
                    return children[index].OnExecute();
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