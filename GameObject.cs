using System;
using System.Reflection;
using System.Collections.Generic;


namespace Client
{
    public class GameObject
    {
        bool isActive;
        public bool IsActive => isActive;
        Dictionary<Type, Component> coms;
        Dictionary<Component, Action[]> comsEvents;

        public GameObject()
        {
            coms = new Dictionary<Type, Component>();
            comsEvents = new Dictionary<Component, Action[]>();
        }

        public void AddComponent<T>()
        {
            Type comType = typeof(T);
            Component obj = (Component)Activator.CreateInstance(comType);
            if (!coms.TryAdd(comType, obj))
            {
                Console.WriteLine("该组件已存在");
                return;
            }
            Action[] actions = new Action[2];

            MethodInfo awakeMethod = comType.GetMethod("Awake", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (awakeMethod != null)
            {
                awakeMethod.Invoke(obj, null);
            }

            MethodInfo startMethod = comType.GetMethod("Start", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (startMethod != null)
            {
                Action start = (Action)Delegate.CreateDelegate(typeof(Action), obj, startMethod, false);
                Client.StartEvnet += start;
            }

            MethodInfo fixedUpdateMethod = comType.GetMethod("FixedUpdate", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fixedUpdateMethod != null)
            {
                Action fixedUpdate = (Action)Delegate.CreateDelegate(typeof(Action), obj, fixedUpdateMethod, false);
                Client.FixedUpdateEvent += fixedUpdate;
                actions[0] = fixedUpdate;
            }

            MethodInfo updateMethod = comType.GetMethod("Update", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (updateMethod != null)
            {
                Action update = (Action)Delegate.CreateDelegate(typeof(Action), obj, updateMethod, false);
                Client.UpdateEvent += update;
                actions[1] = update;
            }

            comsEvents.Add(obj, actions);

            obj.gameObject = this;
        }

        public void RemoveComponent<T>()
        {
            if (coms.TryGetValue(typeof(T), out Component com))
            {
                Action[] actions = comsEvents[com];
                Client.FixedUpdateEvent -= actions[0];
                Client.UpdateEvent -= actions[1];

                coms.Remove(typeof(T));
            }
        }

        // public static GameObject Instantiate(GameObject obj)
        // {

        // }
    }
}