using System;

namespace SteganographNet
{
    public class Steganograph<T> where T : class
    {
        public T Value { get; }
        public ISteganographer<T> Strategy { get; }

        public Steganograph(T value, ISteganographer<T> strategy)
        {
            Strategy = strategy;
            Value = value;
        }
    }

    public class DisposableSteganograph<T> : Steganograph<T>, IDisposable where T : class, IDisposable
    {
        public DisposableSteganograph(T value, ISteganographer<T> strategy) : base(value, strategy)
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Value?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public static class Steganograph
    {
        public static Steganograph<T> Create<T>(T value, ISteganographer<T> strategy) where T : class
        {
            return new Steganograph<T>(value, strategy);
        }

        public static DisposableSteganograph<T> CreateDisposable<T>(T value, ISteganographer<T> strategy) where T : class, IDisposable
        {
            return new DisposableSteganograph<T>(value, strategy);
        }
    }
}