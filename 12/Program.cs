using System;
using System.Collections.Generic;

namespace _12 {
    class Program {

        static void Main(string[] args) {

            List<Tuple<char, int>> directions = new List<Tuple<char, int>>();
            ParsearString(LeerArchivo("input.txt"), directions);

            int coordX = 0;
            int coordY = 0;
            int facingDirection = 1;

            //////PARTE 1
            foreach (Tuple<char, int> instr in directions) {

                switch (instr.Item1) {

                    case 'N':
                        coordX += instr.Item2;
                        break;

                    case 'S':
                        coordX -= instr.Item2;
                        break;

                    case 'E':
                        coordY += instr.Item2;
                        break;

                    case 'W':
                        coordY -= instr.Item2;
                        break;

                    case 'L':
                        facingDirection = (facingDirection + 16 - (instr.Item2 / 90)) % 4;
                        break;

                    case 'R':
                        facingDirection = (facingDirection + (instr.Item2 / 90)) % 4;
                        break;

                    case 'F':
                        if (facingDirection == 0) coordX += instr.Item2;
                        if (facingDirection == 1) coordY += instr.Item2;
                        if (facingDirection == 2) coordX -= instr.Item2;
                        if (facingDirection == 3) coordY -= instr.Item2;
                        break;
                }
            }

            Console.WriteLine("First distance found: " + coordX + " + " + coordY + " = " + (Math.Abs(coordX) + Math.Abs(coordY)));

            /////////Parte 2
            int shipX = 0;
            int shipY = 0;
            int wayX = 1;
            int wayY = 10;

            foreach (Tuple<char, int> instr in directions) {

                switch (instr.Item1) {

                    case 'N':
                        wayX += instr.Item2;
                        break;

                    case 'S':
                        wayX -= instr.Item2;
                        break;

                    case 'E':
                        wayY += instr.Item2;
                        break;

                    case 'W':
                        wayY -= instr.Item2;
                        break;

                    case 'L':
                        for (int i = 0; i < instr.Item2 / 90; i++) {
                            int aux = wayX;
                            wayX = wayY;
                            wayY = aux;
                            wayY = -wayY;
                        }
                        break;

                    case 'R':
                        for (int i = 0; i < instr.Item2 / 90; i++) {
                            int aux = wayX;
                            wayX = wayY;
                            wayY = aux;
                            wayX = -wayX;
                        }
                        break;

                    case 'F':
                        shipX += wayX * instr.Item2;
                        shipY += wayY * instr.Item2;
                        break;
                }
            }

            Console.WriteLine("Second distance found: " + shipX + " + " + shipY + " = " + (Math.Abs(shipX) + Math.Abs(shipY)));

        }


        public static void ParsearString(string texto, List<Tuple<char, int>> directions) {

            string[] lineas = texto.Split("\n");

            foreach (string linea in lineas)
                if (linea.Length > 0)
                    directions.Add(new Tuple<char, int>(linea[0], int.Parse(linea.Substring(1))));

        }

        public static string LeerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }

    }
}
