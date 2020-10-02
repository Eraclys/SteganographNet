using StenographNet.Common;

namespace StenographNet
{
    public interface IStenographer<T>
    {
        long CalculateBitCapacity(T target);
        T Embed(T target, BitReader bitReader);
        void Extract(T target, BitWriter bitWriter);
    }
}
