namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BNConditionDistance : BNodeCondition
    {
        BInput input;

        float triggerDistance;

        public BNConditionDistance() : base()
        {
            nodeName = "距离判断";
        }

        public void SetCondition(float distance) {
            triggerDistance= distance;
        }

        public override bool Evaluate()
        {
            var distance = (input as BInputDistance).Distance;
            return distance <= triggerDistance;
        }

    }
}