using SteganographNet.Common;

namespace SteganographNet
{
    public interface ISteganographer<T> where T : class
    {
        long CalculateBitCapacity(T target);
        bool Embed(T target, BitReader bitReader);
        bool Extract(T target, BitWriter bitWriter);
    }

    public interface IRefSteganographer<T> where T : struct
    {
        long CalculateBitCapacity(T target);
        bool Embed(ref T target, BitReader bitReader);
        bool Extract(T target, BitWriter bitWriter);
    }
}
