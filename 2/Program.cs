using System;
using System.Collections.Generic;

namespace _2 {
    class Program {
        static void Main(string[] args) {

            List<Tuple<int, int>> limites = new List<Tuple<int, int>>();
            List<char> letra = new List<char>();
            List<string> contraseña = new List<string>();
            int passValidas = 0;

            parsearString(leerArchivo("input.txt"), limites, letra, contraseña);
            /////Parte 1
            // for (int i = 0; i < limites.Count; i++) {

            //     char[] pass = contraseña[i].ToCharArray();
            //     int contador = 0;

            //     for (int j = 0; j < pass.Length; j++)
            //         if (pass[j] == letra[i])
            //             contador++;

            //     if (contador >= limites[i].Item1 && contador <= limites[i].Item2)
            //         passValidas++;

            // }

            for (int i = 0; i < limites.Count; i++) {

                int contador = 0;
                char[] pass = contraseña[i].ToCharArray();

                if (contraseña[i][limites[i].Item1 - 1] == letra[i])
                    contador++;
                if (contraseña[i][limites[i].Item2 - 1] == letra[i])
                    contador++;

                if (contador == 1)
                    passValidas++;
            }


            Console.WriteLine("Pass correctas: " + passValidas);

        }

        public static void parsearString(string texto, List<Tuple<int, int>> limites, List<char> letra, List<string> contraseña) {

            string[] lineas = texto.Split("\n");

            foreach (string linea in lineas) {
                if (linea.Length > 0) {

                    string[] cortes = linea.Split(" ");

                    if (cortes.Length == 3) {

                        string[] corte = cortes[0].Split("-");
                        limites.Add(new Tuple<int, int>(int.Parse(corte[0]), int.Parse(corte[1])));

                        letra.Add(cortes[1].Substring(0, 1).ToCharArray()[0]);

                        contraseña.Add(cortes[2]);

                    }
                }
            }
        }

        public static string leerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
    }
}
