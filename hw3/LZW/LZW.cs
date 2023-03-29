using System;

namespace LZW
{
    public class LZW
    {
        public static void Main()
        {
            byte[] file = File.ReadAllBytes("C:\\Users\\Настя\\source\\repos\\spbu\\secondTerm\\hw3\\LZW\\test.txt");
            Console.WriteLine(file.Length);

            
            File.WriteAllBytes("C:\\Users\\Настя\\source\\repos\\spbu\\secondTerm\\hw3\\LZW\\testf.zipped", file);

        }
        public static byte[] 
    }

}
