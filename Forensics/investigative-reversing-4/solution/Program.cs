using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace investigative_reversing_4 {
    class Program {
        static string flag = ""; 
        static void Main(string[] args) {
            Console.WriteLine("hacc in progress");

            for(int i = 5; i > 0; i--) {
                Console.Write("File " + i + "... ");
                decodeDataInFile(i);
                Console.WriteLine("Done.");
            }

            Console.WriteLine(flag);
        }

        static void decodeDataInFile(int fileNum) {
            byte[] file = File.ReadAllBytes("item0" + fileNum + "_cp.bmp");

            file = file.Skip(2019).ToArray();

            for (int j = 0; j < 50; j++) {
                if (j % 5 > 0) {
                    //do nothing, its a fake byte
                    file = file.Skip(1).ToArray();
                } else {
                    flag += (char)GetLsbByte(file.Take(8).ToArray());
                    file = file.Skip(8).ToArray();
                }
            }
        }

        static byte GetLsbByte(byte[] bytes) {
            string bits = "";
            for (int n = 7; n >= 0; n--) {
                if ((bytes[n] & 1) == 1) {
                    bits += 1;
                } else {
                    bits += 0;
                }
            }
            return Convert.ToByte(bits, 2);
        }
    }
}
