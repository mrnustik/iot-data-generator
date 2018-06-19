using System;
using System.Collections.Generic;
using System.Text;
using IotDataGenerator.Core.Generators;

namespace IotDataGenerator.Core.Variable
{
    public interface IVariable<out T>
    {
        string Name { get; }
        IValueGenerator<T> Generator { get; }
    }
}
