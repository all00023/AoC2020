using System;
using System.Linq;
using System.Collections.Generic;

namespace _8 {

    enum instruction { nop, acc, jmp }

    class Program { 

        static void Main(string[] args) {

            List<Tuple<instruction, int>> instructions = new List<Tuple<instruction, int>>();
            int acc = 0;

            parsearString(leerArchivo("input.txt"), instructions);

            List<bool> instructionConsumed = new List<bool>(instructions.Count);
            instructionConsumed.AddRange(Enumerable.Repeat(false, instructions.Count));

            // int currInst = 0;

            // while (!instructionConsumed[currInst]) {

            //     instructionConsumed[currInst] = true;

            //     switch (instructions[currInst].Item1) {

            //         case instruction.acc:
            //             acc += instructions[currInst].Item2;
            //             currInst++;
            //             break;

            //         case instruction.jmp:
            //             currInst += instructions[currInst].Item2;
            //             break;

            //         default:
            //             currInst++;
            //             break;
            //     }
            // }

            HashSet<int> nopAndJmp = new HashSet<int>();
            for (int i = 0; i < instructions.Count; i++)
                if (!(instructions[i].Item1 == instruction.acc))
                    nopAndJmp.Add(i);

            foreach (int changeInst in nopAndJmp) {
                Tuple<instruction, int> auxTuple = instructions[changeInst];
                Tuple<instruction, int> newTuple = new Tuple<instruction, int>(
                    instructions[changeInst].Item1 == instruction.nop ? instruction.jmp : instruction.nop,
                    instructions[changeInst].Item2);
                instructions[changeInst] = newTuple;

                int currInst = 0;
                acc = 0;

                for (int i = 0; i < instructionConsumed.Count; i++)
                    instructionConsumed[i] = false;

                while (currInst < instructions.Count && !instructionConsumed[currInst]) {

                    instructionConsumed[currInst] = true;

                    switch (instructions[currInst].Item1) {

                        case instruction.acc:
                            acc += instructions[currInst].Item2;
                            currInst++;
                            break;

                        case instruction.jmp:
                            currInst += instructions[currInst].Item2;
                            break;

                        default:
                            currInst++;
                            break;
                    }
                }

                instructions[changeInst] = auxTuple;

                if (currInst == instructions.Count)
                    break;

            }


            Console.WriteLine("Accumulator: " + acc);

        }

        public static void parsearString(string texto, List<Tuple<instruction, int>> instructions) {

            string[] lineas = texto.Split("\n");

            foreach (string linea in lineas) {

                if (linea.Length > 0) {
                    string[] inst = linea.Split(" ");
                    Tuple<instruction, int> tupla = new Tuple<instruction, int>((instruction)Enum.Parse(typeof(instruction), inst[0]), int.Parse(inst[1]));
                    instructions.Add(tupla);
                }
            }
        }

        public static string leerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
    }
}
