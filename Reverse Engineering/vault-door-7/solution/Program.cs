using System;

namespace VaultDoor7_Solver {
    class Program {
        static void Main(string[] args) {
            int[] vals = new int[] { 1096770097, 1952395366, 1600270708, 1601398833, 1716808014, 1734293815, 1667379558, 859191138 };
            string fin = "";
            foreach(int k in vals) {
                for (int chk = 0; chk < int.MaxValue; chk++) {
                    byte[] intBytes = BitConverter.GetBytes(chk);
                    Array.Reverse(intBytes); 
                    byte[] result = intBytes;

                    int x = result[0] << 24 | result[1] << 16 | result[2] << 8 | result[3];

                    if (x == k) {
                        fin += (char)result[0];
                        fin += (char)result[1];
                        fin += (char)result[2];
                        fin += (char)result[3];
                        break;
                    }
                }
                Console.WriteLine("Progress: " + fin);
            }
            Console.WriteLine("Solved: " + fin);
        }
    }
}