using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace investigating_reversing_2 {
    static class Program {
        static void Main(string[] args) {
            Console.WriteLine("hacc in progress");

            byte[] encoded = File.ReadAllBytes("encoded.bmp").Skip(0x7D0).ToArray();
            string bits = "";

            for(int img_byte_index = 0; img_byte_index < (0x32 * 0x8); img_byte_index += 8) {
                for (int n = 7; n >= 0; n--) {
                    if((encoded[img_byte_index + n] & 1) == 1) {
                        bits += 1;
                    } else {
                        bits += 0;
                    }
                }
            }

            string flag = "";

            for (int img_byte_index = 0; img_byte_index < (0x32 * 0x8); img_byte_index += 8) {
                flag += (char)(Convert.ToByte(bits.Substring(img_byte_index, 8), 2) + 5);
            }

            Console.WriteLine(flag);
        }
    }
}
