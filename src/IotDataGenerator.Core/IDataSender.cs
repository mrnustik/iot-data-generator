using System;
using System.Collections.Generic;
using System.Text;

namespace IotDataGenerator.Core
{
    interface IDataSender
    {
        void StartSending();
        void StopSending();
    }
}
