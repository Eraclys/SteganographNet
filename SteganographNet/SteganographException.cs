using System;

namespace SteganographNet
{
    [Serializable]
    public class SteganographException : Exception
    {
        public SteganographException(string message) : base(message)
        {
        }
    }
}