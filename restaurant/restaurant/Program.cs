using System;
using System.Collections.Generic;
using System.IO;

namespace restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            LerCSV();
            Console.ReadLine();
            
        }

        static void LerCSV()
        {
            var linhas = File.ReadAllLines("D:\\DocumentosDeProgramacao\\Programacao\\back\\c#\\restaurante-horario2\\restaurant-hours.csv");
            var list = new System.Collections.Generic.List<Estabelecimentos>();
            foreach(var linha in linhas)
            {
                var values = linha.Split(',');
                var Estabelecimentos = new Estabelecimentos()
                {
                    Nome = values[0],
                    OpenTime = values[1],
                    CloseTime = values[2]
                };
                list.Add(Estabelecimentos);
            }
            list.ForEach(x => Console.WriteLine($"{x.Nome} \nAberto às {x.OpenTime} horas até às {x.CloseTime} horas\n\n"));


            Console.WriteLine("Digite um horário: ");
            DateTime hora = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"A hora que vc digitou foi {hora}");
            foreach(var estabelecimento in Estabelecimentos)
            {
                if(hora < DateTime.Parse(estabelecimento[2])){
                    Console.WriteLine($"O restaurante aberto nesse horário é {estabelecimento[0]}");
                }
            }
        }
    }

    public class Estabelecimentos
    {
        public string Nome { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime{ get; set;} 
    }
}
