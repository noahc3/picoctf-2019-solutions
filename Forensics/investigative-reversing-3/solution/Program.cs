using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace investigative_reversing_3_solver {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("hacc in progress");

            byte[] encoded = File.ReadAllBytes("encoded.bmp").Skip(0x2d3).ToArray();

            byte[] bytes = new byte[100];

            for (int i = 0; i < 100; i++) {
                if ((i & 1) == 0) {
                    byte b = GetLsbByte(encoded.Take(8).ToArray());
                    encoded = encoded.Skip(8).ToArray();
                    bytes[i / 2] = b;
                } else {
                    encoded = encoded.Skip(1).ToArray();
                }
            }

            foreach(byte b in bytes) {
                Console.Write((char)b);
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
