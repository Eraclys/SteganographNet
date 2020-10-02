namespace StenographNet.Common
{
    public interface IPayloadReader
    {
        byte Read(byte bitsToKeep);
        long RemainingBits { get; }
    }
}
