using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client
{
    public class Component
    {
        public GameObject gameObject{ get; set; }
        public virtual void Awake() { Console.WriteLine("Component Awake"); }
        public virtual void Start() { }
        public virtual void Update(float dt) { }
        public virtual void FixedUpdate(float dt) { }
    }
}