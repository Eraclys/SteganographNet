using StenographNet.Common;

namespace StenographNet
{
    public interface IStenographer<T>
    {
        long CalculateBitCapacity(T target);
        T Embed(T target, IPayloadReader payloadReader);
        void Extract(T target, IPayloadWriter payloadWriter);
    }
}
