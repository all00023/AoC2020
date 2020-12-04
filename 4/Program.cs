using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _4 {
    class Program {

        static void Main(string[] args) {

            int validPassports = 0;
            List<string> passports = new List<string>();
            HashSet<string> parameters = new HashSet<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };

            parsearString(leerArchivo("input.txt"), passports);

            /////PARTE 1//////

            // foreach (string passport in passports) {

            //     HashSet<string> paramsCopy = new HashSet<string>(parameters);
            //     string[] mapKeyValue = passport.Replace("\n", " ").Split(" ");

            //     foreach (string keyValue in mapKeyValue) {
            //         string[] tuple = keyValue.Split(":");

            //         if (tuple.Length == 2) 
            //             paramsCopy.Remove(tuple[0]);


            //     }

            //     if (paramsCopy.Count == 0 || (paramsCopy.Count == 1 && paramsCopy.Contains("cid")))
            //         validPassports++;
            // }

            HashSet<string> eyeColors = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            Regex rHex = new Regex(@"^[A-Fa-f0-9]*$");
            Regex rPid = new Regex(@"^[0-9]*$");

            foreach (string passport in passports) {

                HashSet<string> paramsCopy = new HashSet<string>(parameters);
                string[] mapKeyValue = passport.Replace("\n", " ").Split(" ");

                foreach (string keyValue in mapKeyValue) {
                    string[] tuple = keyValue.Split(":");

                    if (tuple.Length == 2) {
                        string value = tuple[1];

                        switch (tuple[0]) {

                            case "byr":
                                int yearByr = int.Parse(value);

                                if (yearByr >= 1920 && yearByr <= 2002)
                                    paramsCopy.Remove("byr");

                                break;

                            case "iyr":
                                int yearIyr = int.Parse(value);

                                if (yearIyr >= 2010 && yearIyr <= 2020)
                                    paramsCopy.Remove("iyr");

                                break;

                            case "eyr":
                                int yearEyr = int.Parse(value);

                                if (yearEyr >= 2020 && yearEyr <= 2030)
                                    paramsCopy.Remove("eyr");

                                break;

                            case "hgt":
                                int index;

                                if ((index = value.IndexOf("cm")) != -1) {
                                    int hgt = int.Parse(value.Substring(0, index));

                                    if (hgt >= 150 && hgt <= 193)
                                        paramsCopy.Remove("hgt");

                                } else if ((index = value.IndexOf("in")) != -1) {
                                    int hgt = int.Parse(value.Substring(0, index));

                                    if (hgt >= 59 && hgt <= 76)
                                        paramsCopy.Remove("hgt");

                                }

                                break;

                            case "hcl":
                                if (value.Length == 7 && value[0] == '#')
                                    if (rHex.IsMatch(value.Substring(1, 6)))
                                        paramsCopy.Remove("hcl");

                                break;

                            case "ecl":
                                if (eyeColors.Contains(value))
                                        paramsCopy.Remove("ecl");

                                break;

                            case "pid":
                                if (value.Length == 9)
                                    if (rPid.IsMatch(value))
                                        paramsCopy.Remove("pid");

                                break;
                        }


                    }

                }

                if (paramsCopy.Count == 0 || (paramsCopy.Count == 1 && paramsCopy.Contains("cid")))
                    validPassports++;
            }


            Console.WriteLine("Valid passports: " + validPassports);

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
