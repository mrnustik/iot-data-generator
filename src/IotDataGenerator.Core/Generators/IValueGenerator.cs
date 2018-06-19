using System.Collections.Generic;
using System.Text;

namespace IotDataGenerator.Core.Generators
{
    interface IValueGenerator<out T>
    {
        void Initialize();
        T NextValue();
    }
}
