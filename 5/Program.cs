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
            //         int row = 0;
            //         int seat = 0;

            //         foreach (char c in bp.Substring(0, 7)) {
            //             row += c == 'B' ? 1 : 0;
            //             row = row << 1;
            //         }
            //         row = row >> 1;

            //         foreach (char c in bp.Substring(7, 3)) {
            //             seat += c == 'R' ? 1 : 0;
            //             seat = seat << 1;
            //         }
            //         seat = seat >> 1;

            //         int id = row * 8 + seat;
            //         highestID = Math.Max(highestID, id);

            //     }
            // }

            //Console.WriteLine("Highest ID: " + highestID);

            //////PARTE 2
            HashSet<int> validatedBP = new HashSet<int>();
            HashSet<int> notValidatedBP = new HashSet<int>();

            for (int i = 1; i < 0b1111111111; i++) {
                notValidatedBP.Add(i);
            }

            foreach (string bp in boardingPass) {
                if (bp.Length > 0) {
                    int row = 0;
                    int seat = 0;

                    foreach (char c in bp.Substring(0, 7)) {
                        row += c == 'B' ? 1 : 0;
                        row = row << 1;
                    }
                    row = row >> 1;

                    foreach (char c in bp.Substring(7, 3)) {
                        seat += c == 'R' ? 1 : 0;
                        seat = seat << 1;
                    }
                    seat = seat >> 1;

                    int bpByte = (row << 3) + seat;
                    validatedBP.Add(bpByte);
                    notValidatedBP.Remove(bpByte);

                }
            }

            foreach (int candidate in notValidatedBP) {

                if (validatedBP.Contains(candidate - 1) && validatedBP.Contains(candidate + 1)) {
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
