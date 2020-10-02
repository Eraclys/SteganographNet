namespace StenographNet.Common
{
    public interface IPayloadWriter
    {
        void Write(byte target, byte bitsToKeep);
    }
}