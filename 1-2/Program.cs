using System;
using System.Collections.Generic;

namespace _2
{
    class Program
    {
        static void Main(string[] args)        {
            
            List<int> numeros = parsearString(leerArchivo("input.txt"));
            
            for(int i = 0; i < numeros.Count - 2; i++){
                for(int j = i + 1 ; j< numeros.Count ; j++){

                    if(numeros[i] + numeros[j] - 1 <= 2020){

                        for(int k = j + 1; k < numeros.Count ; k++){

                            if(numeros[i] + numeros[j] + numeros[k] == 2020){
                                Console.WriteLine(numeros[i] + " * " + numeros[j] + " * " + numeros[k] + " = "  + (numeros[i] * numeros[j] * numeros[k]));
                                return;
                            }
                        }
                    }
                }
            }
        }

        public static List<int> parsearString (string texto){

            string[] lineas = texto.Split("\n");
            List<int> numeros = new List<int>();

            foreach (string linea in lineas){
                if(linea.Length > 0)
                    numeros.Add(int.Parse(linea));
            }

            return numeros;

        }

        public static string leerArchivo(string archivo){

           return System.IO.File.ReadAllText (archivo);

        }   
    }
}
