using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace IotDataGenerator.Core.Devices
{
    public class DeviceManager : IDeviceManager
    {
        private readonly RegistryManager registryManager;
        public DeviceManager(RegistryManager registryManager)
        {
            this.registryManager = registryManager;
        }
        
        public Task<Device> CreateDevice(string name)
        {
            return registryManager.AddDeviceAsync(new Device(name));
        }

        public Task<Device> GetDevice(string name)
        {
            return registryManager.GetDeviceAsync(name);
        }

        public Task<Device> GetOrCreateDevice(string name)
        {
            try
            {
                return CreateDevice(name);
            }
            catch (Exception)
            {
                return GetDevice(name);
            }
        }
    }
}