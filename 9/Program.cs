using System;
using System.Collections.Generic;

namespace _9 {
    class Program {

        static void Main(string[] args) {

            List<long> numbers = new List<long>();
            parsearString(leerArchivo("input.txt"), numbers);

            int pre = 25;
            bool sumFound;
            long firstWeak = 0;

            ////////PARTE 1
            for (int i = pre; i < numbers.Count && firstWeak == 0; i++) {
                sumFound = false;

                for (int j = i - pre; j < i - 1 && !sumFound; j++) {
                    for (int k = j + 1; k < i && !sumFound; k++) {

                        if (numbers[j] + numbers[k] == numbers[i]) {
                            sumFound = true;
                        }
                    }
                }

                if (sumFound == false)
                    firstWeak = numbers[i];
            }

            Console.WriteLine("First number found: " + firstWeak);

            ///////PARTE 2
            long secondWeak = 0;
            long secondWeakIndex = 0;
            bool secondFound = false;
            bool notFound = false;
            long aux;

            for (int i = 0; i < numbers.Count - 1 && secondWeakIndex == 0; i++) {
                aux = numbers[i];
                notFound = false;
                
                for (int j = i + 1; j < numbers.Count && (!secondFound || !notFound); j++) {
                    aux += numbers[j];

                    if (aux == firstWeak) {
                        secondFound = true;
                        secondWeakIndex = j;
                    }

                    if (aux > firstWeak) notFound = true;
                }

                if (secondFound) {
                    List<long> contSet = new List<long>();
                    
                    for (int k = i; k <= secondWeakIndex;k++)
                        contSet.Add(numbers[k]);

                    contSet.Sort();
                    secondWeak = contSet[0] + contSet[contSet.Count - 1];
                }
            }

            Console.WriteLine("Second number found: " + secondWeak);

        }

        public static void parsearString(string texto, List<long> numbers) {

            string[] lineas = texto.Split("\n");

            foreach (string linea in lineas) {
                if (linea.Length > 0) {
                    numbers.Add(long.Parse(linea));
                }
            }
        }

        public static string leerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
    }
}
