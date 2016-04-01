using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIDemo.ExampleClasses
{
    public class SingletonDependencyExample : ISingletonDependencyExample
    {
        public Guid ID { get; set; }

        public SingletonDependencyExample()
        {
            ID = Guid.NewGuid();
        }
    }
}
