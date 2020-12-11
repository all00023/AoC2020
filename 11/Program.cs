using System;
using System.Collections.Generic;

namespace _11 {

    enum seatStatus { nop, free, occupied }

    class Program {

        static void Main(string[] args) {

            List<List<seatStatus>> seats = new List<List<seatStatus>>();


            parsearString(leerArchivo("input.txt"), seats);

            /////////PARTE 1
            List<List<seatStatus>> seatsNext = new List<List<seatStatus>>();
            int occupiedTotal = 0;
            int changes = 0;
            int loops = 0;

            for (int i = 0; i < seats.Count; i++) {
                List<seatStatus> currentRow = new List<seatStatus>();
                for (int j = 0; j < seats[i].Count; j++) {
                    currentRow.Add(seats[i][j]);
                }
                seatsNext.Add(currentRow);
            }

            do {
                changes = 0;
                loops++;

                for (int i = 0; i < seats.Count; i++) {
                    for (int j = 0; j < seats[i].Count; j++) {
                        if (seats[i][j] == seatStatus.free || seats[i][j] == seatStatus.occupied) {
                            int occupied = 0;

                            for (int k = -1; k <= 1; k++)
                                for (int l = -1; l <= 1; l++)
                                    if (!(k == 0 && l == 0) &&
                                    i + k >= 0 && i + k < seats.Count &&
                                    j + l >= 0 && j + l < seats[i].Count &&
                                    seats[i + k][j + l] == seatStatus.occupied)
                                        occupied++;


                            if (seats[i][j] == seatStatus.free) {
                                if (occupied == 0) {
                                    seatsNext[i][j] = seatStatus.occupied;
                                    changes++;
                                } else {
                                    seatsNext[i][j] = seatStatus.free;
                                }

                            } else if (seats[i][j] == seatStatus.occupied) {
                                if (occupied >= 4) {
                                    seatsNext[i][j] = seatStatus.free;
                                    changes++;
                                } else {
                                    seatsNext[i][j] = seatStatus.occupied;
                                }
                            }
                        }
                    }
                }

                //Swapping status of seats
                List<List<seatStatus>> seatsAux = seatsNext;
                seatsNext = seats;
                seats = seatsAux;

            } while (changes > 0);

            for (int i = 0; i < seats.Count; i++)
                for (int j = 0; j < seats[i].Count; j++)
                    if (seats[i][j] == seatStatus.occupied)
                        occupiedTotal++;

            // for (int i = 0; i < seats.Count; i++) {
            //     for (int j = 0; j < seats[i].Count; j++)
            //         Console.Write(seats[i][j] == seatStatus.free ? 'L' : seats[i][j] == seatStatus.nop ? '.' : '#');
            //     Console.WriteLine();
            // }


            Console.WriteLine("Accumulator 1: " + occupiedTotal);
            Console.WriteLine("Loops 1: " + loops);


            ///////PARTE 2
            seats = new List<List<seatStatus>>();
            parsearString(leerArchivo("input.txt"), seats);
            seatsNext = new List<List<seatStatus>>();
            occupiedTotal = 0;
            changes = 0;
            loops = 0;

            for (int i = 0; i < seats.Count; i++) {
                List<seatStatus> currentRow = new List<seatStatus>();
                for (int j = 0; j < seats[i].Count; j++) {
                    currentRow.Add(seats[i][j]);
                }
                seatsNext.Add(currentRow);
            }

            do {
                changes = 0;
                loops++;

                for (int i = 0; i < seats.Count; i++) {
                    for (int j = 0; j < seats[i].Count; j++) {
                        if (seats[i][j] == seatStatus.free || seats[i][j] == seatStatus.occupied) {

                            int occupied = numberOfoccupiedSeatInLineOfSight(seats, i, j);

                            if (seats[i][j] == seatStatus.free) {
                                if (occupied == 0) {
                                    seatsNext[i][j] = seatStatus.occupied;
                                    changes++;
                                } else {
                                    seatsNext[i][j] = seatStatus.free;
                                }

                            } else if (seats[i][j] == seatStatus.occupied) {
                                if (occupied >= 5) {
                                    seatsNext[i][j] = seatStatus.free;
                                    changes++;
                                } else {
                                    seatsNext[i][j] = seatStatus.occupied;
                                }
                            }
                        }
                    }
                }

                //Swapping status of seats
                List<List<seatStatus>> seatsAux = seatsNext;
                seatsNext = seats;
                seats = seatsAux;

            } while (changes > 0);

            for (int i = 0; i < seats.Count; i++)
                for (int j = 0; j < seats[i].Count; j++)
                    if (seats[i][j] == seatStatus.occupied)
                        occupiedTotal++;

            // for (int i = 0; i < seats.Count; i++) {
            //     for (int j = 0; j < seats[i].Count; j++)
            //         Console.Write(seats[i][j] == seatStatus.free ? 'L' : seats[i][j] == seatStatus.nop ? '.' : '#');
            //     Console.WriteLine();
            // }


            Console.WriteLine("Accumulator 2: " + occupiedTotal);
            Console.WriteLine("Loops 2: " + loops);

        }

        public static int numberOfoccupiedSeatInLineOfSight(List<List<seatStatus>> seats, int x, int y) {

            int occupied = 0;
            int i = 0;
            int j = 0;
            bool continuar = true;

            //Arriba
            continuar = true;
            for (i = 1; x - i >= 0 && continuar; i++) {
                if (seats[x - i][y] == seatStatus.free)
                    continuar = false;

                if (seats[x - i][y] == seatStatus.occupied) {
                    continuar = false;
                    occupied++;
                }
            }

            //Abajo
            continuar = true;
            for (i = 1; x + i < seats.Count && continuar; i++) {
                if (seats[x + i][y] == seatStatus.free)
                    continuar = false;

                if (seats[x + i][y] == seatStatus.occupied) {
                    continuar = false;
                    occupied++;
                }
            }

            //Izquierda
            continuar = true;
            for (j = 1; y - j >= 0 && continuar; j++) {
                if (seats[x][y - j] == seatStatus.free)
                    continuar = false;

                if (seats[x][y - j] == seatStatus.occupied) {
                    continuar = false;
                    occupied++;
                }
            }

            //Abajo
            continuar = true;
            for (j = 1; y + j < seats[x].Count && continuar; j++) {
                if (seats[x][y + j] == seatStatus.free)
                    continuar = false;

                if (seats[x][y + j] == seatStatus.occupied) {
                    continuar = false;
                    occupied++;
                }
            }

            //Arriba Izquierda
            continuar = true;
            for (i = j = 1; x - i >= 0 && y - j >= 0 && continuar; i = j = i + 1) {

                if (seats[x - i][y - j] == seatStatus.free)
                    continuar = false;

                if (seats[x - i][y - j] == seatStatus.occupied) {
                    continuar = false;
                    occupied++;
                }
            }

            //Arriba Derecha
            continuar = true;
            for (i = j = 1; x - i >= 0 && y + j < seats[x].Count && continuar; i = j = i + 1) {

                if (seats[x - i][y + j] == seatStatus.free)
                    continuar = false;

                if (seats[x - i][y + j] == seatStatus.occupied) {
                    continuar = false;
                    occupied++;
                }
            }

            //Abajo Derecha
            continuar = true;
            for (i = j = 1; x + i < seats.Count && y + j < seats[x].Count && continuar; i = j = i + 1) {

                if (seats[x + i][y + j] == seatStatus.free)
                    continuar = false;

                if (seats[x + i][y + j] == seatStatus.occupied) {
                    continuar = false;
                    occupied++;
                }
            }

            //Abajo Izquierda
            continuar = true;
            for (i = j = 1; x + i < seats.Count && y - j >= 0 && continuar; i = j = i + 1) {

                if (seats[x + i][y - j] == seatStatus.free)
                    continuar = false;

                if (seats[x + i][y - j] == seatStatus.occupied) {
                    continuar = false;
                    occupied++;
                }
            }


            return occupied;

        }

        public static void parsearString(string texto, List<List<seatStatus>> seats) {

            string[] lineas = texto.Split("\n");

            foreach (string linea in lineas) {
                if (linea.Length > 0) {
                    List<seatStatus> currentRow = new List<seatStatus>();

                    foreach (char status in linea) {
                        if (status == 'L') currentRow.Add(seatStatus.free);
                        else if (status == '#') currentRow.Add(seatStatus.occupied);
                        else currentRow.Add(seatStatus.nop);
                    }
                    seats.Add(currentRow);
                }
            }
        }

        public static string leerArchivo(string archivo) {

            return System.IO.File.ReadAllText(archivo);

        }
    }
}
