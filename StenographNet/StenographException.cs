using System;

namespace StenographNet
{
    [Serializable]
    public class StenographException : Exception
    {
        public StenographException(string message) : base(message)
        {
        }
    }
}