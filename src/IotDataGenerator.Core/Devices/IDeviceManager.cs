using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Devices;

namespace IotDataGenerator.Core.Devices
{
    interface IDeviceManager
    {
        Device CreateDevice(string name);
        Device GetDevice(string name);
        Device GetOrCreateDevice(string name);
    }
}
