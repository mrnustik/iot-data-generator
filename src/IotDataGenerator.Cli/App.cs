using System.Collections.Generic;
using System.Threading.Tasks;
using IotDataGenerator.Core.Configuration;
using IotDataGenerator.Core.Devices;
using IotDataGenerator.Core.Generators;
using IotDataGenerator.Core.Senders;
using IotDataGenerator.Core.Variable;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TransportType = Microsoft.Azure.Devices.Client.TransportType;

namespace IotDataGenerator.Cli
{
    public class App
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;
        private IDeviceManager deviceManager;
        private IDeviceClientFactory deviceClientFactory;

        public App(IConfiguration configuration, ILogger logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public void Initialize()
        {
            var registryManager =
                RegistryManager.CreateFromConnectionString(configuration[ConfigurationKeys.IotHubConnectionString]);
            deviceManager = new DeviceManager(registryManager);
            deviceClientFactory = new DeviceClientFactory(configuration);
        }

        public async Task Run()
        {
            Initialize();
            var variables = new List<IVariable<double>>
            {
                new DoubleVariable("TemperatureInside", new DoubleGenerator(20.0, 25.0)),
                new DoubleVariable("TemperatureOutside", new DoubleGenerator(17.0, 40.0))
            };

            var device = await deviceManager.GetOrCreateDevice("HomeSensor");
            var deviceClient = deviceClientFactory.CreateDeviceClient(device, TransportType.Http1);

            var sender = new VariableDataSender(logger, variables, deviceClient, 1000);
            sender.StartSending();
        }
    }
}
