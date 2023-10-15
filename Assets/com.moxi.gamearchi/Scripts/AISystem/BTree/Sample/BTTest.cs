using UnityEngine;

namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BTTest : MonoBehaviour
    {
        BTreeMonster tree;
        BInputDistance input;

        private void Start()
        {
            tree = new BTreeMonster();
            tree.Init();

            input = new BInputDistance(10);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                input.Distance = 5;
            }
            if (Input.GetKey(KeyCode.S))
            {
                input.Distance = 10;
            }
            tree?.OnExecute(input);
        }
    }
}