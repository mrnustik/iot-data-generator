namespace IotDataGenerator.Core.Senders
{
    interface IDataSender
    {
        void StartSending();
        void StopSending();
    }
}
