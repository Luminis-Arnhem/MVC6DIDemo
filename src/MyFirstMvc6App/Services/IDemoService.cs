using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIDemo.Services
{
    public interface IDemoService
    {
        string GetIDFromTransientDependency();
        string GetIDFromScopedDependency();
        string GetIDFromSingletonDependency();
        string GetIDFromInstanceDependency();
    }
}
