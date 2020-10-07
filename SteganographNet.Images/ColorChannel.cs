using System;

namespace SteganographNet.Images
{
    [Flags]
    public enum ColorChannel
    {
        R = 1,
        G = 2,
        B = 4,
        All = R | G | B
    }
}