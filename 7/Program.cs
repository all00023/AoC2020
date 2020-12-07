using System;
using System.Collections.Generic;

namespace _7 {
    class Program {

        static void Main(string[] args) {


            Dictionary<string, Dictionary<string, int>> rules = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> rulesInverse = new Dictionary<string, Dictionary<string, int>>();

            parsearString(leerArchivo("input.txt"), rules, rulesInverse);

            List<string> processing = new List<string> { "shiny gold" };

            ////////PARTE 1
            //HashSet<string> accepted = new HashSet<string>();

            // for (int i = 0; i < processing.Count; i++)
            //     foreach (string key in rulesInverse[processing[i]].Keys)
            //         processing.Add(key);


            // foreach (string color in processing) 
            //     accepted.Add(color);

            //Console.WriteLine("Combinations: " + (accepted.Count - 1));


            ////////PARTE 2
            for (int i = 0; i < processing.Count; i++)
                foreach (string key in rules[processing[i]].Keys)
                    for (int j = 0; j < rules[processing[i]][key]; j++)
                        processing.Add(key);

            Console.WriteLine("Combinations: " + (processing.Count - 1));

        }

        public static void parsearString(string texto, Dictionary<string, Dictionary<string, int>> rules, Dictionary<string, Dictionary<string, int>> rulesInverse) {

            string[] lineas = texto.Split("\n");

            foreach (string linea in lineas) {
                if (linea.Length > 0) {

                    string[] rule = linea.Split(" contain ");

                    string mainColor = rule[0].Remove(rule[0].Length - 5);
                    rules.Add(mainColor, new Dictionary<string, int>());

                    if (!rulesInverse.ContainsKey(mainColor))
                        rulesInverse.Add(mainColor, new Dictionary<string, int>());

                    if (rule[1] != "no other bags.") {
                        string rule2 = rule[1].Remove(rule[1].Length - 1);
                        string[] subRules = rule2.Split(", ");

                        foreach (string subRule in subRules) {
                            int capacity = int.Parse(subRule.Split(" ")[0]);
                            string subColor;

                            if (subRule.EndsWith("bags"))
                                subColor = subRule.Remove(0, 2).Remove(subRule.Length - 5 - 2);
                            else
                                subColor = subRule.Remove(0, 2).Remove(subRule.Length - 4 - 2);

                            rules[mainColor].Add(subColor, capacity);

                            if (!rulesInverse.ContainsKey(subColor))
                                rulesInverse.Add(subColor, new Dictionary<string, int>());

                            rulesInverse[subColor].Add(mainColor, capacity);

                        }
                    }
                }
            }

            // //Comprobacion
            // foreach (string mainColor in rules.Keys) {

            //     Console.Write(mainColor);

            //     foreach (string subColor in rules[mainColor].Keys) {
            //         Console.Write(" | " + rules[mainColor][subColor] + " " + subColor);
            //     }

            //     Console.WriteLine();
            // }
        }

        public static string leerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
    }
}
