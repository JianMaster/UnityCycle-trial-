namespace Client.Scripts
{
    public class GameMain : Component
    {
        
        int fixedUpdateTimes = 0;
        int updateTimes = 0;

        public override void Awake()
        {
            Console.WriteLine("Awake Function Call");
        }
        public override void Start()
        {
            Console.WriteLine("Start Function Call");
        }
        public override void FixedUpdate(float dt)
        {
            fixedUpdateTimes++;
            Console.WriteLine("FixedUpdate Function Call:" + fixedUpdateTimes);
        }
        public override void Update(float dt)
        {
            updateTimes++;
            Console.WriteLine("Update Function Call:" + updateTimes);
            if(updateTimes == 100) {
                // gameObject.RemoveComponent<GameMain>();
            }
        }
    }
}