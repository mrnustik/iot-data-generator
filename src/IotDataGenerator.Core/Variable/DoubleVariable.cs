using IotDataGenerator.Core.Generators;

namespace IotDataGenerator.Core.Variable
{
    public class DoubleVariable : IVariable<double>
    {
        public string Name { get; }
        public IValueGenerator<double> Generator { get; }

        public DoubleVariable(string name, IValueGenerator<double> generator)
        {
            Name = name;
            Generator = generator;
        }
    }
}