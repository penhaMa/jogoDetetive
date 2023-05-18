using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoDetetive
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Suspeito> suspeitos = new List<Suspeito>
            {
                new Suspeito("Sr. Verde", "Cabelo preto"),
                new Suspeito("Sra. Rosa", "Cabelo ruivo"),
                new Suspeito("Sr. Azul", "Cabelo loiro"),
                new Suspeito("Sr. Amarelo", "Cabelo grisalho"),
                new Suspeito("Sra. Laranja", "Cabelo castanho")
            };

            Random random = new Random();
            int indiceAssassino = random.Next(0, suspeitos.Count);
            Suspeito assassino = suspeitos[indiceAssassino];

            Console.WriteLine("Bem-vindo ao jogo de detetive!");
            Console.WriteLine("Há um assassino entre os suspeitos abaixo. Você precisa descobrir quem é o assassino.");
            Console.WriteLine();

            for (int i = 0; i < suspeitos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {suspeitos[i].Nome}");
            }

            Console.WriteLine();
            Console.WriteLine("Aqui estão algumas pistas que podem te ajudar:");
            Console.WriteLine("1. O assassino tem cabelos escuros.");
            Console.WriteLine("2. O assassino estava usando um casaco preto.");
            Console.WriteLine("3. O assassino tem olhos verdes.");
            Console.WriteLine();

            int pontos = 100; // Sistema de pontos
            DateTime horaInicio = DateTime.Now; // Marca o tempo de início do jogo
            TimeSpan limiteTempo = TimeSpan.FromMinutes(5); // Limite de tempo de 5 minutos

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Digite o número do suspeito que você acha que é o assassino (ou 0 para sair):");
                int palpite = Convert.ToInt32(Console.ReadLine());

                if (palpite == 0)
                {
                    Console.WriteLine("Você saiu do jogo.");
                    break;
                }

                if (palpite >= 1 && palpite <= suspeitos.Count)
                {
                    Suspeito suspeitoPalpite = suspeitos[palpite - 1];

                    Console.WriteLine();

                    if (suspeitoPalpite == assassino)
                    {
                        Console.WriteLine("Parabéns! Você descobriu o assassino corretamente!");
                        TimeSpan tempoDecorrido = DateTime.Now - horaInicio;
                        int pontosFinais = pontos - (int)tempoDecorrido.TotalSeconds; // Cálculo dos pontos finais
                        Console.WriteLine($"Você marcou {pontosFinais} pontos.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Infelizmente você errou. O assassino não é esse suspeito.");
                        pontos -= 10; // Penalidade de pontos por palpite errado
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                }

                TimeSpan tempoDecorridoTotal = DateTime.Now - horaInicio;
                if (tempoDecorridoTotal >= limiteTempo)
                {
                    Console.WriteLine("Você excedeu o limite de tempo. O jogo acabou.");
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }

    class Suspeito
    {
        public string Nome { get; set; }
        public string Caracteristica { get; set; }

        public Suspeito(string nome, string caracteristica)
        {
            Nome = nome;
            Caracteristica = caracteristica;
        }
    }
}

    
