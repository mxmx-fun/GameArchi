using System.Runtime.InteropServices;

namespace BufferIO.Content
{
    [StructLayout(LayoutKind.Explicit)]
    public struct FloatContent
    {
        [FieldOffset(0)]
        public float FloatValue;

        [FieldOffset(0)]
        public int IntValue;
    }

}
