using System;

namespace IotDataGenerator.Core.Generators
{
    public class DoubleGenerator : IValueGenerator<double>
    {
        private readonly Random random = new Random();

        public double MinimumValue { get; }
        public double MaximumValue { get; }

        public DoubleGenerator(double minimumValue, double maximumValue)
        {
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
        }

        public void Initialize()
        {
        }

        public double NextValue()
        {
            return random.NextDouble() * (MaximumValue - MinimumValue) + MinimumValue;
        }
    }
}