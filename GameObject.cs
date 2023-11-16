namespace Client;
using System;
using System.Reflection;
using System.Collections.Generic;


public class GameObject
{
    bool isActive;
    public bool IsActive => isActive;
    List<Type> comsList;
    Dictionary<Type, Component> comsDic;
    HashSet<Component> comsStartEvents;
    HashSet<Component> comsUpdateEvents;
    HashSet<Component> comsFixedUpdateEvents;

    public GameObject()
    {
        comsList = new List<Type>();
        comsDic = new Dictionary<Type, Component>();
        comsStartEvents = new HashSet<Component>();
        comsUpdateEvents = new HashSet<Component>();
        comsFixedUpdateEvents = new HashSet<Component>();
    }

    public void Start(){
        if(comsStartEvents.Count == 0){
            return;
        }
        foreach(var com in comsList){

        }
    }

    public void Update(float dt){

    }

    public void FixedUpdate(float dt){

    }

    // public void AddComponent<T>()
    // {
    //     Type comType = typeof(T);
    //     Component obj = (Component)Activator.CreateInstance(comType);
    //     if (!comsDic.TryAdd(comType, obj))
    //     {
    //         Console.WriteLine("该组件已存在");
    //         return;
    //     }
    //     Action[] actions = new Action[2];

    //     MethodInfo awakeMethod = comType.GetMethod("Awake", BindingFlags.Public);
    //     if (awakeMethod != null)
    //     {
    //         awakeMethod.Invoke(obj, null);
    //     }

    //     MethodInfo startMethod = comType.GetMethod("Start", BindingFlags.Public);
    //     if (startMethod != null)
    //     {
    //         Action start = (Action)Delegate.CreateDelegate(typeof(Action), obj, startMethod, false);
    //         Client.StartEvnet += start;
    //     }

    //     MethodInfo fixedUpdateMethod = comType.GetMethod("FixedUpdate", BindingFlags.Public);
    //     if (fixedUpdateMethod != null)
    //     {
    //         Action fixedUpdate = (Action)Delegate.CreateDelegate(typeof(Action), obj, fixedUpdateMethod, false);
    //         Client.FixedUpdateEvent += fixedUpdate;
    //         actions[0] = fixedUpdate;
    //     }

    //     MethodInfo updateMethod = comType.GetMethod("Update", BindingFlags.Public);
    //     if (updateMethod != null)
    //     {
    //         Action update = (Action)Delegate.CreateDelegate(typeof(Action), obj, updateMethod, false);
    //         Client.UpdateEvent += update;
    //         actions[1] = update;
    //     }

    //     comsEvents.Add(obj, actions);

    //     obj.gameObject = this;
    // }

    // public void RemoveComponent<T>()
    // {
    //     if (comsDic.TryGetValue(typeof(T), out Component com))
    //     {
    //         Action[] actions = comsEvents[com];
    //         Client.FixedUpdateEvent -= actions[0];
    //         Client.UpdateEvent -= actions[1];

    //         comsDic.Remove(typeof(T));
    //     }
    // }

    // public static GameObject Instantiate(GameObject obj)
    // {

    // }
}