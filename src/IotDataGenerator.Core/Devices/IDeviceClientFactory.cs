using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using TransportType = Microsoft.Azure.Devices.Client.TransportType;

namespace IotDataGenerator.Core.Devices
{
    public interface IDeviceClientFactory
    {
        DeviceClient CreateDeviceClient(Device device, TransportType transportType);
    }
}