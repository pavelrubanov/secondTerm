using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWT_
{
    struct BWT_String
    {
        public string str;
        public int end;
    }
    internal class BWT
    {
        public static BWT_String Encode(string str)
        {
            string original_str = str;
            int n = str.Length;
            string[] arr = new string[n];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = Shift_str(str);
                str = Shift_str(str);
            }
            Array.Sort(arr);
            BWT_String result = new BWT_String();
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == original_str) result.end = i + 1;
                result.str += arr[i][n - 1];
            }
            return result;
        }
        public static string Decode(BWT_String encoded_str)
        {
            int n = encoded_str.str.Length;
            string str = encoded_str.str;
            string[] arr = new string[n];
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                    arr[i] = str[i] + arr[i];
                Array.Sort(arr);
            }
            return (arr[encoded_str.end - 1]);
        }
        private static string Shift_str(string str)
        {
            return (str[str.Length - 1] + str).Substring(0, str.Length);
        }
    }
}
