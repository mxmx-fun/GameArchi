namespace GameArchi.Utils {

    public static class ArrayExtension {

        public static void Debug(this int[] array) {
            string str = "IntArray Element:";
            for (int i = 0; i < array.Length; i++) {
                str += array[i] + " ";
            }
            UnityEngine.Debug.Log(str);
        }

        public static void Debug(this string[] array) {
            string str = "StringArray Element:";
            for (int i = 0; i < array.Length; i++) {
                str += array[i] + " ";
            }
            UnityEngine.Debug.Log(str);
        }

        public static void Debug(this float[] array) {
            string str = "FloatArray Element:";
            for (int i = 0; i < array.Length; i++) {
                str += array[i] + " ";
            }
            UnityEngine.Debug.Log(str);
        }
    }
}