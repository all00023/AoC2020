using System;
using System.Collections.Generic;

namespace _6 {
    class Program {

        static void Main(string[] args) {

            List<string> groupResponses = new List<string>();
            int sum = 0;

            parsearString(leerArchivo("input.txt"), groupResponses);

            //////Part 1
            // foreach (string responses in groupResponses) {
            //     HashSet<char> responseSet = new HashSet<char>();

            //     foreach(char c in responses){
            //         if(c!='\n')
            //             responseSet.Add(c);
            //     }

            //     sum+=responseSet.Count;
            // }

            //////Part 2
            foreach (string responses in groupResponses) {
                Dictionary<char, int> responseSet = new Dictionary<char, int>();
                int members = 1;

                foreach (char c in responses) {

                    if (c != '\n') {

                        if (!responseSet.ContainsKey(c))
                            responseSet.Add(c, 1);
                        else {
                            int n = responseSet[c];
                            responseSet[c] = n + 1;
                        }

                    } else {
                        members++;
                    }
                }
                
                foreach (char key in responseSet.Keys) 
                    if (responseSet[key] == members)
                        sum++;
                
            }


            Console.WriteLine("#Responses: " + sum);


        }

        public static void parsearString(string texto, List<string> passports) {

            string[] lineas = texto.Split("\n\n");

            passports.AddRange(lineas);

        }

        public static string leerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
    }
}
