using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace IotDataGenerator.Core.Devices
{
    interface IDeviceManager
    {
        Task<Device> CreateDevice(string name);
        Task<Device> GetDevice(string name);
        Task<Device> GetOrCreateDevice(string name);
    }
}
