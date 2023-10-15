namespace GameArchi.AI.BehaviourTree.Sample
{
    public class BInputDistance : BInput
    {
        float distance;
        public float Distance {get{return distance;}set{distance = value;}}
        
        
        public BInputDistance(float distance)
        {
            this.distance = distance;
        }
    }
}