using System;
using System.Collections.Generic;

namespace _5 {
    class Program {

        static void Main(string[] args) {


            List<string> boardingPass = new List<string>();

            parsearString(leerArchivo("input.txt"), boardingPass);

            ///////PARTE 1
            //int highestID = 0;

            // foreach (string bp in boardingPass) {
            //     if (bp.Length > 0) {

            //         int row = Convert.ToByte(bp.Substring(0, 7).Replace("B", "1").Replace("F", "0"), 2);
            //         int seat = Convert.ToByte(bp.Substring(7, 3).Replace("R", "1").Replace("L", "0"), 2); ;

            //         int id = row * 8 + seat;
            //         highestID = Math.Max(highestID, id);
                    
            //     }
            // }

            //Console.WriteLine("Highest ID: " + highestID);

            //////PARTE 2
            HashSet<int> notValidatedBP = new HashSet<int>(0b1111111);

            for (int i = 1; i < 0b1111111111; i++) {
                notValidatedBP.Add(i);
            }

            foreach (string bp in boardingPass) {
                if (bp.Length > 0) {
                    
                    int row = Convert.ToByte(bp.Substring(0, 7).Replace("B", "1").Replace("F", "0"), 2);
                    int seat = Convert.ToByte(bp.Substring(7, 3).Replace("R", "1").Replace("L", "0"), 2);

                    int bpByte = (row << 3) + seat;
                    notValidatedBP.Remove(bpByte);

                }
            }

            foreach (int candidate in notValidatedBP) {

                if (!notValidatedBP.Contains(candidate - 1) && !notValidatedBP.Contains(candidate + 1)) {
                    int row = candidate >> 3;
                    int seat = candidate & 0b00000111;
                    Console.WriteLine("Mi ID: " + (row * 8 + seat));
                }

            }

        }

        public static void parsearString(string texto, List<string> passports) {

            string[] lineas = texto.Split("\n");

            passports.AddRange(lineas);

        }

        public static string leerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
    }
}
