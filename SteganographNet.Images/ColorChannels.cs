using System;

namespace SteganographNet.Images
{
    [Flags]
    public enum ColorChannels
    {
        R = 1,
        G = 2,
        B = 4,
        All = R | G | B,
        None = 0
    }
}