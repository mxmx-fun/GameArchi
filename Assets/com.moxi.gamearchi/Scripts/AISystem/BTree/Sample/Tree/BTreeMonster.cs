namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BTreeMonster : BTree
    {
        public BTreeMonster() : base()
        {
            treeName = "怪物AI行为树";
        }

        public override void Init()
        {
            BNodeSelector selectorMonster = new BNSelectorMonster();
            BNodeSelector selectorPatrol = new BNSelectorPatrol();
            BNodeSelector selectorAttack = new BNSelectorAttack();

            BNodeSequence sequenceAttack = new BNSequenceAttack();

            BNodeCondition conditionPatrol = new BNConditionPatrol();
            var conditionNode = (conditionPatrol as BNConditionPatrol);
            conditionNode.SetCondition(5);

            BNodeCondition conditionAttack = new BNConditionAttack();
            var conditionTrackNode = (conditionAttack as BNConditionAttack);
            conditionTrackNode.SetCondition(3);

            BNodeAction actionPatrol = new BNActionPatrol();
            BNodeAction actionAttack = new BNActionAttack();
            BNodeAction actionTrack = new BNActionTrack();

            //第一层
            SetRoot(selectorMonster);

            //第二层
            selectorMonster.AddChild(selectorPatrol);
            selectorPatrol.SetPreConditionNode(conditionPatrol);

            selectorMonster.AddChild(selectorAttack);

            //第三层
            selectorPatrol.AddChild(actionPatrol);
            selectorAttack.AddChild(sequenceAttack);
            sequenceAttack.SetPreConditionNode(conditionAttack);
            selectorAttack.AddChild(actionTrack);

            //第四层
            sequenceAttack.AddChild(actionAttack);
        }
    }
}