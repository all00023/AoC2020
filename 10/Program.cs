using System;
using System.Collections.Generic;

namespace _10 {
    class Program {

        static void Main(string[] args) {

            List<int> inputJolts = new List<int>();
            ParsearString(LeerArchivo("input.txt"), inputJolts);

            inputJolts.Add(0);
            inputJolts.Sort();
            inputJolts.Add(inputJolts[inputJolts.Count - 1] + 3);

            //////PARTE 1
            int cont1 = 0;
            int cont2 = 0;
            int cont3 = 0;

            for (int i = 0; i < inputJolts.Count - 1; i++) {
                if (inputJolts[i + 1] - inputJolts[i] == 1) cont1++;
                if (inputJolts[i + 1] - inputJolts[i] == 2) cont2++;
                if (inputJolts[i + 1] - inputJolts[i] == 3) cont3++;
            }

            Console.WriteLine("First number found: " + cont1  * cont3);

            ///////PARTE 2
            List<long> contadores = new List<long> { 1 };
            
            for (int i = 1; i < inputJolts.Count; i++) {
                long contLocal = 0;

                for (int j = 1; j <= 3 && i - j >= 0; j++) {

                    if (inputJolts[i] - inputJolts[i-j] <= 3)
                        contLocal += contadores[i-j];
                }

                contadores.Add(contLocal);
            }

            Console.WriteLine("Second number found: " + contadores[contadores.Count - 1]);

        }


        public static void ParsearString(string texto,List<int> inputJolts) {

            string[] lineas = texto.Split("\n");

            foreach (string linea in lineas) {
                if (linea.Length > 0) {
                    inputJolts.Add(int.Parse(linea));
                }
            }
        }

        public static string LeerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
        
    }
}
