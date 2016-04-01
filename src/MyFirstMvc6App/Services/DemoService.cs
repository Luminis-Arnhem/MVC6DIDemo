using DIDemo.ExampleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIDemo.Services
{
    public class DemoService : IDemoService
    {
        private ITransientDependencyExample _transientDependencyExample;
        private IScopedDependencyExample _scopedDependencyExample;
        private ISingletonDependencyExample _singletonDependencyExample;
        private IInstanceDependencyExample _instanceDependencyExample;
        public DemoService(ITransientDependencyExample transientDependencyExample,
                           IScopedDependencyExample scopedDependencyExample,
                           ISingletonDependencyExample singletonDependencyExample,
                           IInstanceDependencyExample instanceDependencyExample)
        {
            _transientDependencyExample = transientDependencyExample;
            _scopedDependencyExample = scopedDependencyExample;
            _singletonDependencyExample = singletonDependencyExample;
            _instanceDependencyExample = instanceDependencyExample;
        }
        public string GetIDFromTransientDependency()
        {
            return _transientDependencyExample.ID.ToString();
        }
        public string GetIDFromScopedDependency()
        {
            return _scopedDependencyExample.ID.ToString();
        }
        public string GetIDFromSingletonDependency()
        {
            return _singletonDependencyExample.ID.ToString();
        }
        public string GetIDFromInstanceDependency()
        {
            return _instanceDependencyExample.ID.ToString();
        }
    }
}
