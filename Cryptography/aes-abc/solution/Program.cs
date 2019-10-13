using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ABCtoECB {
    class Program {
        static void Main(string[] args) {
            IEnumerable<byte> abc = File.ReadAllBytes("body.enc.ppm");
            

            List<byte> ecb = new List<byte>();
            ecb.AddRange(abc.Take(16));
            abc = abc.Skip(16);

            while (abc.Count() > 16) {
                IEnumerable<byte> prev_block = abc.Take(16);
                abc = abc.Skip(16);
                IEnumerable<byte> current_block = abc.Take(16);

                BigInteger prev_int = new BigInteger(prev_block.ToArray());
                BigInteger current_int = new BigInteger(current_block.ToArray());


                BigInteger real_int = (current_int - prev_int);
                IEnumerable<byte> real_block = real_int.ToByteArray().Take(16); //lossy but i dont care lol
                ecb.AddRange(real_block);


            }

            File.WriteAllBytes("out.enc.ppm", ecb.ToArray());
            

        }


        public static string ToHex(IEnumerable<byte> bytes) {
            return BitConverter.ToString(bytes.ToArray()).Replace("-", "");
        }


    }
}
