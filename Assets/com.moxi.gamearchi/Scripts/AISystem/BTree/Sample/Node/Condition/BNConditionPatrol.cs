namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BNConditionPatrol : BNodeCondition
    {
        float triggerDistance;

        public BNConditionPatrol() : base()
        {
            nodeName = "巡逻判断";
        }


        public void SetCondition(float distance) {
            triggerDistance= distance;
        }

        public override bool Evaluate(BInput input)
        {
            var distance = (input as BInputDistance).Distance;
            return distance > triggerDistance;
        }

    }
}