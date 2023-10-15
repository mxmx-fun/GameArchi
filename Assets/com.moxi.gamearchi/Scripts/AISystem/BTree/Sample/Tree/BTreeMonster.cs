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
            BNodeSequence sequenceAttack = new BNSequenceAttack();

            BNodeCondition conditionAttack = new BNConditionDistance();
            var conditionNode = (conditionAttack as BNConditionDistance);
            conditionNode.SetCondition(5);

            BNodeAction actionPatrol = new BNActionPatrol();
            BNodeAction actionAttack = new BNActionAttack();


            SetRoot(selectorMonster);
            selectorMonster.AddChild(sequenceAttack);
            selectorMonster.AddChild(actionPatrol);

            sequenceAttack.SetPreConditionNode(conditionAttack);
            sequenceAttack.AddChild(actionAttack);
        }
    }
}