using System.Runtime.InteropServices;

namespace BufferIO.Content
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DoubleContent
    {
        [FieldOffset(0)]
        public double DoubleValue;
        [FieldOffset(0)]
        public long LongValue;
    }
}
