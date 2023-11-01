using System;

namespace Client
{
    public class Client
    {
        static event Action startAction;
        public static Action StartEvnet { get => startAction; set => startAction = value; }
        static event Action fixedUpdateAction;
        public static Action FixedUpdateEvent { get => fixedUpdateAction; set => fixedUpdateAction = value; }
        static event Action updateAction;
        public static Action UpdateEvent{ get => updateAction; set => updateAction = value; }

        Timer timer;

        float frameTime;
        float fixedUpdateExcuteTime;
        float maximumFixedUpdateTimes;
        public Client(int frame)
        {
            frameTime = 1f / frame;
            maximumFixedUpdateTimes = GlobalConfig.MAXIMUM_ALLOWED_TIMESTEP / GlobalConfig.FIXED_DELTA_TIME;
            timer = new Timer();

        }

        public void StartGame()
        {
            timer.Start();
            while (true)
            {
                Start();
                FixedUpdate(Timer.DeltaTime);
                Update(Timer.DeltaTime);
                Console.WriteLine("当前CurFrameTime："+ timer.CurFrameTime);
                while (timer.CurFrameTime < frameTime) { }
                timer.Record();
                Console.WriteLine("当前deltatime："+ Timer.DeltaTime);
            }
        }

        void Start()
        {
            StartEvnet?.Invoke();
            startAction = null;
        }

        void FixedUpdate(float dt)
        {
            fixedUpdateExcuteTime += dt;
            if (fixedUpdateExcuteTime > GlobalConfig.MAXIMUM_ALLOWED_TIMESTEP)
            {
                float newFDT = fixedUpdateExcuteTime / maximumFixedUpdateTimes;
                timer.SetFixedDeltaTime(newFDT);
            }
            for (; fixedUpdateExcuteTime > Timer.FixedDeltaTime; fixedUpdateExcuteTime -= Timer.FixedDeltaTime)
            {
                FixedUpdateEvent?.Invoke();
            }
            timer.SetFixedDeltaTime(GlobalConfig.FIXED_DELTA_TIME);
        }

        void Update(float dt)
        {
            UpdateEvent?.Invoke();
        }

    }
}