using System;
using System.Collections.Generic;

namespace Client
{
    public class Client
    {
        Timer timer;

        float frameTime;
        float fixedUpdateExcuteTime;
        float maximumFixedUpdateTimes;
        List<GameObject> objList;
        Dictionary<GameObject, int> objDic;
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
                Update(timer.DeltaTime);
                FixedUpdate(timer.DeltaTime);
                Console.WriteLine("当前CurFrameTime：" + timer.CurFrameTime);
                while (timer.CurFrameTime < frameTime) { }
                timer.Record();
                Console.WriteLine("当前deltatime：" + timer.DeltaTime);
            }
        }

        void Start()
        {
            foreach (var obj in objList)
            {
                obj.Start();
            }
        }

        void FixedUpdate(float dt)
        {
            fixedUpdateExcuteTime = dt;
            if (fixedUpdateExcuteTime > GlobalConfig.MAXIMUM_ALLOWED_TIMESTEP)
            {
                float newFDT = fixedUpdateExcuteTime / maximumFixedUpdateTimes;
                timer.SetFixedDeltaTime(newFDT);
            }
            for (; fixedUpdateExcuteTime > timer.FixedDeltaTime; fixedUpdateExcuteTime -= timer.FixedDeltaTime)
            {
                foreach (var obj in objList)
                {
                    obj.FixedUpdate(fixedUpdateExcuteTime);
                }
            }
            timer.SetFixedDeltaTime(GlobalConfig.FIXED_DELTA_TIME);
        }

        void Update(float dt)
        {
            foreach (var obj in objList)
            {
                obj.Update(dt);
            }
        }

    }
}