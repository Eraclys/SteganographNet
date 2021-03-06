﻿namespace SteganographNet
{
    public interface ISteganographer<T> where T : class
    {
        long CalculateBitCapacity(T target);
        bool Embed(T target, BitReader bitReader);
        bool Extract(T target, BitWriter bitWriter);
    }
}
