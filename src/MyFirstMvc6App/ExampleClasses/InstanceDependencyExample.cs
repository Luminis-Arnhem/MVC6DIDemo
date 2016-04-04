using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIDemo.ExampleClasses
{
    public class InstanceDependencyExample : IInstanceDependencyExample
    {
        public Guid ID { get; set; }
        public InstanceDependencyExample()
        {
            ID = Guid.NewGuid();
        }
    }
}
