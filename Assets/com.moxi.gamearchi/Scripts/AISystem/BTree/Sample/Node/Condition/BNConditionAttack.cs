namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BNConditionAttack : BNodeCondition
    {
        float triggerDistance;

        public BNConditionAttack() : base()
        {
            nodeName = "攻击判断";
        }


        public void SetCondition(float distance) {
            triggerDistance= distance;
        }

        public override bool Evaluate(BInput input)
        {
            var distance = (input as BInputDistance).Distance;
            return distance <= triggerDistance;
        }

    }
}