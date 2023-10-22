using System;
using System.Text;
using BufferIO.Content;

namespace BufferIO.Helper
{
    public static class BufferWriter
    {
        public static void WriteUInt64(byte[] des, ulong data, ref int index)
        {
            for (int i = 0; i < 8; i++)
            {
                des[index++] = (byte)(data >> i * 8);
            }
        }

        public static void WriteInt64(byte[] des, long data, ref int index)
        {
            WriteUInt64(des, (ulong)data, ref index);
        }

        public static void WriteUInt32(byte[] des, uint data, ref int index)
        {
            for (int i = 0; i < 4; i++)
            {
                des[index++] = (byte)(data >> i * 8);
            }
        }

        public static void WriteInt32(byte[] des, int data, ref int index)
        {
            WriteUInt32(des, (uint)data, ref index);
        }

        public static void WriteUInt16(byte[] des, UInt16 data, ref int index)
        {
            byte[] value = new byte[2];
            for (int i = 0; i < 2; i++)
            {
                des[index++] = (byte)(data >> i * 8);
            }
        }

        public static void WriteInt16(byte[] des, short data, ref int index)
        {
            WriteUInt16(des, (ushort)data, ref index);
        }

        public static void WriteInt8(byte[] des, sbyte data, ref int index)
        {
            WriteUInt8(des, (byte)data, ref index);
        }

        public static void WriteUInt8(byte[] des, byte data, ref int index)
        {
            des[index++] = data;
        }

        public static void WriteChar(byte[] des, char data, ref int index)
        {
            WriteUInt8(des, (byte)data, ref index);
        }

        public static void WriteBool(byte[] des, bool data, ref int index)
        {
            byte value = data ? (byte)1 : (byte)0;
            WriteUInt8(des, value, ref index);
        }

        public static void WriteShort(byte[] des, short data, ref int index)
        {
            for (int i = 0; i < 2; i++)
            {
                des[index++] = (byte)(data >> i * 8);
            }
        }

        public static void WriteByte(byte[] des, byte data, ref int index)
        {
            des[index++] = data;
        }

        public static void WriteSbyte(byte[] des, sbyte data, ref int index)
        {
            WriteByte(des, (byte)data, ref index);
        }

        public static void WriteSingle(byte[] des, float data, ref int index)
        {
            FloatContent content = new FloatContent();
            content.FloatValue = data;
            WriteInt32(des, content.IntValue, ref index);
        }

        public static void WriteDouble(byte[] des, double data, ref int index)
        {
            DoubleContent content = new DoubleContent();
            content.DoubleValue = data;
            WriteInt64(des, content.LongValue, ref index);
        }

        public static void WriteUTF8String(byte[] des, string data, ref int index)
        {
            byte[] content = Encoding.UTF8.GetBytes(data);
            int count = content.Length;
            WriteInt32(des, count, ref index);
            Buffer.BlockCopy(content, 0, des, index, count);
            index += count;
        }

        public static void WriteCharArr(byte[] des, char[] data, ref int index)
        {
            short count = (short)data.Length;
            WriteInt16(des, count, ref index);
            foreach (var value in data)
            {
                WriteChar(des, value, ref index);
            }
        }

        public static void WriteIntArr(byte[] des, int[] data, ref int index)
        {
            short count = (short)data.Length;
            WriteInt16(des,count,ref index);
            for (int i = 0; i < count; i++)
            {
                WriteInt32(des,data[i],ref index);
            }
        }

        public static void WriteBoolArr(byte[]des ,bool[] data, ref int index)
        {
            short count = (short)data.Length;
            WriteInt16(des,count,ref index);
            for (int i = 0; i < count; i++)
            {
                WriteBool(des,data[i],ref index);
            }
        }

        public static void WriteShortArr(byte[]des,short[] data,ref int index)
        {
            short count = (short)data.Length;
            WriteInt16(des,count,ref index);
            for (int i = 0; i < count; i++)
            {
                WriteShort(des,data[i],ref index);    
            }
        }

        public static void WriteByteArr(byte[]des,byte[]data,ref int index)
        {
            short count = (short)data.Length;
            WriteInt16(des,count,ref index);
            for (int i = 0; i < count; i++)
            {
                WriteByte(des,data[i],ref index);
            }
        }

        public static void WriteSingleArr(byte[]des,float[]data,ref int index)
        {
            short count = (short)data.Length;
            WriteShort(des,count,ref index);
            for (int i = 0; i < count; i++)
            {
                WriteSingle(des,data[i],ref index);
            }
        }

        public static void WriteLongArr(byte[]des,long[]data,ref int index)
        {
            short count = (short)data.Length;
            WriteShort(des,count,ref index);
            for (int i = 0; i < count; i++)
            {
                WriteInt64(des,data[i],ref index);
            }
        }

        public static void WriteDoubleArr(byte[]des,double[]data,ref int index)
        {
            short count = (short)data.Length;
            WriteShort(des,count,ref index);
            for (int i = 0; i < count; i++)
            {
                WriteDouble(des,data[i],ref index);
            }
        }

        public static void WriteUTF8StringArr(byte[]des,string[]data,ref int index)
        {
            short count = (short)data.Length;
            WriteShort(des,count,ref index);
            for (int i = 0; i < count; i++)
            {
                WriteUTF8String(des,data[i],ref index);
            }
        }
        
    }

}
