using IotDataGenerator.Core.Configuration;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Configuration;
using TransportType = Microsoft.Azure.Devices.Client.TransportType;

namespace IotDataGenerator.Core.Devices
{
    class DeviceClientFactory : IDeviceClientFactory
    {

        private readonly IConfiguration configuration;

        public DeviceClientFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DeviceClient CreateDeviceClient(Device device, TransportType transportType)
        {
            return DeviceClient.Create(configuration[ConfigurationKeys.IotHubUri], new DeviceAuthenticationWithRegistrySymmetricKey(device.Id, device.Authentication.SymmetricKey.PrimaryKey), transportType);
        }
    }
}