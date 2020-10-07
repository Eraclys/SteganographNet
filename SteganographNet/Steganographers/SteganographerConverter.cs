namespace SteganographNet.Steganographers
{
    public class SteganographerConverter<TInput, TOutput> : ISteganographer<TInput> 
        where TInput : class 
        where TOutput : class, TInput
    {
        readonly ISteganographer<TOutput> _innerSteganographer;

        public SteganographerConverter(
            ISteganographer<TOutput> innerSteganographer)
        {
            _innerSteganographer = innerSteganographer;
        }

        public long CalculateBitCapacity(TInput target)
        {
            return _innerSteganographer.CalculateBitCapacity((TOutput) target);
        }

        public bool Embed(TInput target, BitReader bitReader)
        {
            return _innerSteganographer.Embed((TOutput)target, bitReader);
        }

        public bool Extract(TInput target, BitWriter bitWriter)
        {
            return _innerSteganographer.Extract((TOutput)target, bitWriter);
        }
    }
}