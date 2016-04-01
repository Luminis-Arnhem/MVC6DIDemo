using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIDemo.ExampleClasses
{
    public class TransientDependencyExample : ITransientDependencyExample
    {
        public Guid ID { get; set; }

        public TransientDependencyExample()
        {
            ID = Guid.NewGuid();
        }
    }
}
