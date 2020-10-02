using StenographNet.Common;

namespace StenographNet
{
    public interface IStenographer<T> where T : class
    {
        long CalculateBitCapacity(T target);
        void Embed(T target, BitReader bitReader);
        void Extract(T target, BitWriter bitWriter);
    }

    public interface IRefStenographer<T> where T : struct
    {
        long CalculateBitCapacity(T target);
        void Embed(ref T target, BitReader bitReader);
        void Extract(T target, BitWriter bitWriter);
    }
}
