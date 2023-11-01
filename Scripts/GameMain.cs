namespace Client.Scripts
{
    public class GameMain : Component
    {
        
        int fixedUpdateTimes = 0;
        int updateTimes = 0;

        void Awake()
        {
            Console.WriteLine("Awake Function Call");
        }
        void Start()
        {
            Console.WriteLine("Start Function Call");
        }
        void FixedUpdate()
        {
            fixedUpdateTimes++;
            Console.WriteLine("FixedUpdate Function Call:" + fixedUpdateTimes);
        }
        void Update()
        {
            updateTimes++;
            Console.WriteLine("Update Function Call:" + updateTimes);
            if(updateTimes == 100) {
                gameObject.RemoveComponent<GameMain>();
            }
        }
    }
}