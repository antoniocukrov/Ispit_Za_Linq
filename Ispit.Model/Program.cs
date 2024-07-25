using System;
using System.Collections.Generic;
using System.Linq;

namespace Ispit.Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Proizvod> ListaProizvoda = new List<Proizvod>
            {
                new Proizvod { ProizvodID = 1, Naziv = "Cokolada - za kuhanje" },
                new Proizvod { ProizvodID = 2, Naziv = "Lino Lada – Gold" },
                new Proizvod { ProizvodID = 3, Naziv = "Papir za pecenje" },
                new Proizvod { ProizvodID = 4, Naziv = "Brasno – psenicno" },
                new Proizvod { ProizvodID = 5, Naziv = "Secer – standard" }
            };

            List<Racun> ListaRacuna = new List<Racun>
            {
                new Racun { BrojRacuna = 100, ProizvodID = 3, Kolicina = 800 },
                new Racun { BrojRacuna = 101, ProizvodID = 2, Kolicina = 650 },
                new Racun { BrojRacuna = 102, ProizvodID = 3, Kolicina = 900 },
                new Racun { BrojRacuna = 103, ProizvodID = 4, Kolicina = 700 },
                new Racun { BrojRacuna = 104, ProizvodID = 3, Kolicina = 900 },
                new Racun { BrojRacuna = 105, ProizvodID = 4, Kolicina = 650 },
                new Racun { BrojRacuna = 106, ProizvodID = 1, Kolicina = 458 }
            };

            Console.WriteLine("Ovdje je popis proizvoda:\n ============================================================");
            foreach (var proizvod in ListaProizvoda)
            {
                Console.WriteLine($"ProizvodID: {proizvod.ProizvodID}, Naziv: {proizvod.Naziv}");
            }

            Console.WriteLine();
            Console.WriteLine("Ovdje je popis racuna:\n ============================================================");

            foreach (var racun in ListaRacuna)
            {
                Console.WriteLine($"BrojRacuna: {racun.BrojRacuna}, ProizvodID: {racun.ProizvodID}, Kolicina: {racun.Kolicina}");
            }

            Console.WriteLine();
            Console.WriteLine("Poredana lista proizvoda uzlazno na temelju naziva proizvoda:\n ============================================================");

           var SortiraniProizvodi = ListaProizvoda.OrderBy(p => p.Naziv).ToList();

            foreach (var proizvod in SortiraniProizvodi)
            {
                Console.WriteLine($"ProizvodID: {proizvod.ProizvodID}, Naziv: {proizvod.Naziv}");
            }

            Console.WriteLine();


            var ListaSpojenihPodataka = from racun in ListaRacuna
                                        join proizvod in ListaProizvoda
                                        on racun.ProizvodID equals proizvod.ProizvodID
                                        orderby racun.ProizvodID
                                        select new
                                        {
                                            proizvod.ProizvodID,
                                            proizvod.Naziv,
                                            racun.Kolicina
                                        };

            Console.WriteLine("Evo popisa nakon pridruživanja:\n");
            Console.WriteLine("ID proizvoda   Naziv proizvoda               Kupljena količina");
            Console.WriteLine("=============================================================");

            foreach (var item in ListaSpojenihPodataka)
            {
                Console.WriteLine($"{item.ProizvodID,-14} {item.Naziv,-28}  {item.Kolicina}");
            }

            Console.ReadLine();
        }
    }
}
