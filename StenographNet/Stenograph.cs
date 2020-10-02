using System;

namespace StenographNet
{
    public class Stenograph<T> where T : class
    {
        public T Value { get; }
        public IStenographer<T> Strategy { get; }

        public Stenograph(T value, IStenographer<T> strategy)
        {
            Strategy = strategy;
            Value = value;
        }
    }

    public class DisposableStenograph<T> : Stenograph<T>, IDisposable where T : class, IDisposable
    {
        public DisposableStenograph(T value, IStenographer<T> strategy) : base(value, strategy)
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

    public static class Stenograph
    {
        public static Stenograph<T> Create<T>(T value, IStenographer<T> strategy) where T : class
        {
            return new Stenograph<T>(value, strategy);
        }

        public static DisposableStenograph<T> CreateDisposable<T>(T value, IStenographer<T> strategy) where T : class, IDisposable
        {
            return new DisposableStenograph<T>(value, strategy);
        }
    }
}