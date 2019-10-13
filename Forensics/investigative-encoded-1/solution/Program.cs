using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace investigative_encoded_1 {
    class Program {
        public static byte[] secret = {0xB8, 0xEA, 0x8E, 0xBA, 0x3A, 0x88, 0xAE, 0x8E, 0xE8, 0xAA, 0x28, 0xBB, 0xB8, 0xEB, 0x8B, 0xA8, 0xEE, 0x3A, 0x3B, 0xB8, 0xBB, 0xA3, 0xBA, 0xE2, 0xE8, 0xA8, 0xE2, 0xB8, 0xAB, 0x8B, 0xB8, 0xEA ,0xE3, 0xAE, 0xE3, 0xBA, 0x80};

        public static int[] matrix = { 0x00000008, 0x00000000, 0x0000000c, 0x00000008, 0x0000000e, 0x00000014, 0x0000000a, 0x00000022, 0x00000004, 0x0000002c, 0x0000000c, 0x00000030, 0x0000000c, 0x0000003c, 0x0000000a, 0x00000048, 0x00000006, 0x00000052, 0x00000010, 0x00000058, 0x0000000c, 0x00000068, 0x0000000c, 0x00000074, 0x0000000a, 0x00000080, 0x00000008, 0x0000008a, 0x0000000e, 0x00000092, 0x0000000e, 0x000000a0, 0x00000010, 0x000000ae, 0x0000000a, 0x000000be, 0x00000008, 0x000000c8, 0x00000006, 0x000000d0, 0x0000000a, 0x000000d6, 0x0000000c, 0x000000e0, 0x0000000c, 0x000000ec, 0x0000000e, 0x000000f8, 0x00000010, 0x00000106, 0x0000000e, 0x00000116, 0x00000004, 0x00000124 };

        public static byte[] output = { 0x8E, 0x8E, 0xBA, 0x3B, 0xB8, 0xEA, 0x23, 0xA8, 0xA8, 0xB8, 0xBB, 0x8A, 0x2E, 0x3A, 0x8E, 0xEE, 0x22, 0xEE, 0xE3, 0xBA, 0x00 };

        public static void Main() {
            Console.WriteLine("hacc in progress");
            string flag = "";
            IEnumerable<bool> bitsEnum = output.SelectMany(x => getBits(x));
            while (true) {
                if (!bitsEnum.Any())
                    break;
                Tuple<char, int> res = bruteForce(bitsEnum);
                if (res == null) break;
                flag += res.Item1;
                bitsEnum = bitsEnum.Skip(res.Item2);
            }

            Console.WriteLine("Flag: " + flag);
        }

        public static Tuple<char, int> bruteForce(IEnumerable<bool> bits) {
            int pos = 0;

            bool[] bitarr = bits.ToArray();

            // brute force matrix lookup
            char iMc = ' ';
            for (int i = 0; i < matrix.Length / 2; i++) {
                int iM = matrix[(i * 2) + 1]; // + 1 due to interweaved data
                iMc = (char)(byte)(i + 0x61);

                if (iMc == '{')
                    iMc = ' ';

                int iM2 = matrix[i * 2] + iM;

                //Console.WriteLine("iM: " + iM + " | iMC: " + iMc + " | iM2: " + iM2);
                while (iM < iM2) {
                    //Console.WriteLine(getValue((byte) iM) + " " + bitarr[pos]);
                    if (getValue((byte)iM) != bitarr[pos]) {
                        pos = 0;
                        //Console.WriteLine("break!");
                        break;
                    }
                    iM++;
                    pos++;
                }

                if (pos > 0)
                    break;
            }

            if (pos > 0)
                return new Tuple<char, int>(iMc, pos);
            else
                return null;
        }

        public static bool getValue(byte b) {
            return Convert.ToBoolean((secret[b / 8] >> (7 - b % 8) & 1));
        }

        public static bool[] getBits(byte b) {
            bool[] bits = new bool[8];
            for (int j = 0; j < 8; j++) {
                byte bit = (byte)(b & 1);

                bits[j] = Convert.ToBoolean(bit);

                b /= 2; // shift bits
            }
            return bits.Reverse().ToArray();
        }
    }
}