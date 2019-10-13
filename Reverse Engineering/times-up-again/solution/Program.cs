using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Data;
using Jace;

namespace solve {
    public static class Program {
        public static void Main() {
            Console.WriteLine("Hello");
            CalculationEngine calc = new CalculationEngine();
            
            ProcessStartInfo info = new ProcessStartInfo();
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.FileName = "times-up-again";
            
            while (true) {
                try {
                    Process process = new Process();
                    process.StartInfo = info;
                    process.Start();
                    
                    string solution = ((long)calc.Calculate(process.StandardOutput.ReadLine().Substring(11))).ToString();

                    process.StandardInput.WriteLine(solution);
                    Console.WriteLine(process.StandardOutput.ReadLine());
                    string check = process.StandardOutput.ReadLine();
                    if (!check.Contains("Nope")) {
                        Console.WriteLine(check);
                        Console.WriteLine(process.StandardOutput.ReadLine());
                        break;
                    }
                    
                    process.Close();
                    Console.WriteLine(solution);
                    
                } catch {
                    Console.WriteLine("fail");
                }

                
            }
            
        }
    }
}