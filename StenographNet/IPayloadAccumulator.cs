namespace StenographNet
{
    public interface IPayloadAccumulator
    {
        bool OnNext(byte value);
        void OnCompleted();
    }
}