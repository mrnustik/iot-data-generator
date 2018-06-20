using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IotDataGenerator.Core.Variable;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IotDataGenerator.Core.Senders
{
    public class VariableDataSender : IDataSender
    {
        private readonly ILogger logger;
        private readonly IEnumerable<IVariable<double>> variables;
        private readonly DeviceClient client;
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly int delay;

        public VariableDataSender(ILogger logger, IEnumerable<IVariable<double>> variables, DeviceClient client, int delay)
        {
            this.logger = logger;
            this.variables = variables;
            this.client = client;
            this.delay = delay;
        }
        
        public void StartSending()
        {
            Task.Run(async () => await Send(cancellationTokenSource.Token));
        }

        public async Task Send(CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
            {
                var data = GenerateData();
                var encodedData = EncodeData(data);
                await SendData(encodedData);
                await Task.Delay(delay);
            }
        }

        public void StopSending()
        {
            cancellationTokenSource.Cancel();
        }

        private async Task SendData(byte[] encodedData)
        {
            var message = new Message(encodedData);
            await client.SendEventAsync(message);
            logger.LogInformation("Data sent");
        }

        private byte[] EncodeData(object data)
        { 
            var serializedObject = JsonConvert.SerializeObject(data);
            logger.LogInformation($"Sending data: {serializedObject}");
            return Encoding.ASCII.GetBytes(serializedObject);
        }

        private Dictionary<string, double> GenerateData()
        {
            var data = new Dictionary<string, double>();
            foreach (var variable in variables)
            {
                var key = variable.Name;
                var value = variable.Generator.NextValue();
                logger.LogInformation($"Generated value {value} of variable {key}.");
                data.Add(key, value);
            }

            return data;
        }
    }
}