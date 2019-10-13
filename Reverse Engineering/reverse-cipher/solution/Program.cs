using System;

namespace reverse_cipher_solver {
    class Program {
        static void Main(string[] args) {
            string ciphertext = "picoCTF{w1{1wq83k055j5f}";
            char[] plaintext = "picoCTF{w1{1wq83k055j5f}".ToCharArray();

            for (int i = 0x16; i >=8; i--) {
                char newchar = ciphertext[i];

                if ((i & 1) == 0) {
                    plaintext[i] = (char) (newchar - 5);
                } else {
                    plaintext[i] = (char) (newchar + 2);
                }
            }

            Console.WriteLine("Flag: " + new String(plaintext));
        }
    }
}
