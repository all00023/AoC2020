using System;
using System.Collections.Generic;

namespace _3 {
    class Program {

        static void Main(string[] args) {

            List<List<bool>> mapa = new List<List<bool>>();
            List<Tuple<int, int>> movimientos = new List<Tuple<int, int>>();
            long treesMult = 1;

            movimientos.Add(new Tuple<int, int>(1, 1));
            movimientos.Add(new Tuple<int, int>(3, 1));
            movimientos.Add(new Tuple<int, int>(5, 1));
            movimientos.Add(new Tuple<int, int>(7, 1));
            movimientos.Add(new Tuple<int, int>(1, 2));

            parsearString(leerArchivo("input.txt"), mapa);

            int borde = mapa[0].Count;

            foreach (Tuple<int, int> m in movimientos) {
                long trees = 0;
                int cX = 0;
                int cY = 0;

                while (cY < mapa.Count) {
                    cX = (cX + m.Item1) % borde;
                    cY += m.Item2;

                    if (cY < mapa.Count && mapa[cY][cX])
                        trees++;

                }
                if (trees != 0)
                    treesMult *= trees;

                Console.WriteLine("Trees: " + trees);

            }

            Console.WriteLine("TreesMult: " + treesMult);

        }

        public static void parsearString(string texto, List<List<bool>> mapa) {

            string[] lineas = texto.Split("\n");

            for (int i = 0; i < lineas.Length; i++) {
                string linea = lineas[i];

                if (linea.Length > 0) {
                    mapa.Add(new List<bool>());

                    foreach (char c in linea.ToCharArray()) {
                        mapa[i].Add(c == '#');
                    }
                }
            }
        }

        public static string leerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
    }
}
