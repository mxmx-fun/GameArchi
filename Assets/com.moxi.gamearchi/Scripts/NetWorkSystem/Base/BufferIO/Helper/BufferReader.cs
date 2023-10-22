using System;
using System.Text;
using BufferIO.Content;

namespace BufferIO.Helper
{
    public class BufferReader
    {
        public static UInt32 ReadUInt32(byte[] des, ref int index)
        {
            uint res = 0;
            for (int i = 0; i < 4; i++)
            {
                res += (UInt32)des[index++] << i * 8;
            }
            return res;
        }

        public static Int32 ReadInt32(byte[] des, ref int index)
        {
            return (Int32)ReadUInt32(des, ref index);
        }

        public static byte ReadUInt8(byte[] des, ref int index)
        {
            return des[index++];
        }

        public static bool ReadBool(byte[] des, ref int index)
        {
            byte value = ReadUInt8(des, ref index);
            return value > 0;
        }

        public static sbyte ReadSbyte(byte[] des, ref int index)
        {
            return (sbyte)des[index++];
        }

        public static short ReadInt16(byte[] des, ref int index)
        {
            short value = 0;
            for (int i = 0; i < 2; i++)
            {
                value += (short)(des[index++] << i * 8);
            }
            return value;
        }

        public static float ReadSingle(byte[] des, ref int index)
        {
            int value = ReadInt32(des, ref index);
            FloatContent content = new FloatContent();
            content.IntValue = value;
            return content.FloatValue;
        }

        public static double ReadDouble(byte[] des, ref int index)
        {
            long value = ReadInt64(des, ref index);
            DoubleContent content = new DoubleContent();
            content.LongValue = value;
            return content.DoubleValue;
        }

        public static long ReadInt64(byte[] des, ref int index)
        {
            long value = 0;
            for (int i = 0; i < 8; i++)
            {
                value += (long)des[index++] << i * 8;
            }
            return value;
        }

        public static char ReadChar(byte[] des, ref int index)
        {
            return (char)ReadUInt8(des, ref index);
        }

        public static char[] ReadCharArray(byte[] des, ref int index)
        {
            short count = ReadInt16(des, ref index);
            char[] content = new char[count];
            for (int i = 0; i < count; i++)
            {
                content[i] = ReadChar(des, ref index);
            }
            return content;
        }

        public static string ReadUTF8String(byte[] des, ref int index)
        {
            int count = ReadInt32(des, ref index);
            string content = Encoding.UTF8.GetString(des, index, count);
            index += count;
            return content;
        }

        public static int[] ReadIntArray(byte[]des,ref int index){
            short count = ReadInt16(des,ref index);
            int[] value = new int [count];
            for (int i = 0; i < count; i++)
            {
                value[i] = ReadInt32(des,ref index);
            }            
            return value;
        }

        public static bool[] ReadBoolArray(byte[]des,ref int index)
        {
            short count = ReadInt16(des,ref index);
            bool[] value = new bool[count];
            for (int i = 0; i < count; i++)
            {
                value[i] = ReadBool(des,ref index);
            }
            return value;
        }

        public static short[] ReadShortArray(byte[]des,ref int index)
        {
            short count = ReadInt16(des,ref index);
            short[]value = new short[count];
            for (int i = 0; i < count; i++)
            {
                value[i] = ReadInt16(des,ref index);
            }
            return value;
        }

        public static byte[] ReadByteArray(byte[]des,ref int index)
        {
            short count = ReadInt16(des,ref index);
            byte[]value = new byte[count];
            for (int i = 0; i < count; i++)
            {
                value[i] = ReadUInt8(des,ref index);
            }
            return value;
        }

        public static float[] ReadSingleArray(byte[]des,ref int index)
        {
            short count = ReadInt16(des,ref index);
            float[]value = new float[count];
            for (int i = 0; i < count; i++)
            {
                value[i] = ReadSingle(des,ref index);
            }
            return value;
        }

        public static long[] ReadLongArray(byte[]des,ref int index)
        {
            short count = ReadInt16(des,ref index);
            long[]value = new long[count];
            for (int i = 0; i < count; i++)
            {
                value[i] = ReadInt64(des,ref index);
            }
            return value;
        }

        public static double[] ReadDoubleArray(byte[]des,ref int index)
        {
            short count = ReadInt16(des,ref index);
            double[]value = new double[count];
            for (int i = 0; i < count; i++)
            {
                value[i]= ReadDouble(des,ref index);
            }
            return value;
        }

        public static string[] ReadUTF8StringArray(byte[]des,ref int index)
        {
            short count = ReadInt16(des,ref index);
            string[] value = new string[count];
            for (int i = 0; i < count; i++)
            {
                value[i] = ReadUTF8String(des,ref index);
            }
            return value;
        }
    }
}