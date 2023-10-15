namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BNConditionDistance : BNodeCondition
    {
        float triggerDistance;

        public BNConditionDistance() : base()
        {
            nodeName = "距离判断";
        }


        public void SetCondition(float distance) {
            triggerDistance= distance;
        }

        public override bool Evaluate(BInput input)
        {
            var distance = (input as BInputDistance).Distance;
            UnityEngine.Debug.Log($"距离判断:{distance}");
            return distance <= triggerDistance;
        }

    }
}