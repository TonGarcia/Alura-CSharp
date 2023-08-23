using System;

namespace JogoAdivinhacao
{
    class Program
    {
        string mensagemDeBoasVindas = @"
░░█ █▀█ █▀▀ █▀█   █▀▄ █▀▀   ▄▀█ █▀▄ █ █░█ █ █▄░█ █░█ ▄▀█ █▀▀ ▄▀█ █▀█
█▄█ █▄█ █▄█ █▄█   █▄▀ ██▄   █▀█ █▄▀ █ ▀▄▀ █ █░▀█ █▀█ █▀█ █▄▄ █▀█ █▄█";

        void ExibirMensagemDeBoasVindas()
        {
            Console.WriteLine(mensagemDeBoasVindas);
        }

        void JogoDeAdivinhacao()
        {
            Random random = new Random();
            int numeroSecreto = random.Next(1, 101);
            int tentativas = 0;
            int tentativasSemNumero = 0;

            Console.WriteLine("Bem-vindo ao jogo de adivinhação!");
            Console.WriteLine("Tente adivinhar o número entre 1 e 100.");

            do
            {
                Console.Write("Digite sua tentativa: ");
                string input = Console.ReadLine();
                int tentativa;

                if (int.TryParse(input, out tentativa))
                {
                    tentativas++;
                    tentativasSemNumero = 0;

                    if (tentativa < numeroSecreto)
                    {
                        Console.WriteLine("O número é maior. Tente novamente.");
                        if (numeroSecreto - tentativa <= 10)
                            Console.WriteLine("Está quente!");
                        else
                            Console.WriteLine("Está frio!");
                    }
                    else if (tentativa > numeroSecreto)
                    {
                        Console.WriteLine("O número é menor. Tente novamente.");
                        if (tentativa - numeroSecreto <= 10)
                            Console.WriteLine("Está quente!");
                        else
                            Console.WriteLine("Está frio!");
                    }
                    else
                    {
                        Console.WriteLine($"Parabéns! Você acertou o número {numeroSecreto} em {tentativas} tentativas.");
                        break;
                    }
                }
                else
                {
                    tentativasSemNumero++;

                    if (tentativasSemNumero >= 3)
                    {
                        Console.WriteLine($"Você não digitou um número 3 vezes seguidas. O número era {numeroSecreto}. Fim do jogo.");
                        break;
                    }

                    Console.WriteLine("Entrada inválida. Digite um número válido.");
                }

            } while (true);
        }

        static void Main(string[] args)
        {
            Program jogo = new Program();
            jogo.ExibirMensagemDeBoasVindas();
            jogo.JogoDeAdivinhacao();
        }
    }
}
