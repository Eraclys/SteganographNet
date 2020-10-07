namespace SteganographNet
{
    public interface IRefSteganographer<T> where T : struct
    {
        long CalculateBitCapacity(T target);
        bool Embed(ref T target, BitReader bitReader);
        bool Extract(T target, BitWriter bitWriter);
    }
}