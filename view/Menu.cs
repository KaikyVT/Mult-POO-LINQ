using Multiplicacao.controller;
using NPOI.HSSF.Record;

namespace Multiplicacao.view;

public class Menu
{
    const int RESPOSTA_MINIMA = 1;
    const int RESPOSTA_MAXIMA = 16;
    public static void Iniciar()
    {
        bool querSair = false;
        while (!querSair)
        {
            int resposta = 0;
            do
            {
                Console.Clear();
                try
                {
                    Console.Write($"Olá, multiplicador😺! Qual exercício deseja verificar [de 1 a {RESPOSTA_MAXIMA}]?\n> ");
                    resposta = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Digite um número, não uma baboseira 😾");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (!(resposta >= RESPOSTA_MINIMA && resposta <= RESPOSTA_MAXIMA));
            PedidoControle.ChamaExercicio(resposta);
            int continua = 2;
            do
            {
                Console.Write("\nDeseja ver outro exercício?\n[1 = sim😺 ||| 0 = não😿]\n> ");
                try
                {
                    continua = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Digite um número, não uma baboseira 😾");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (continua != 0 && continua != 1);
            if (continua == 0)
            {
                querSair = true;
            }
        }
    }
}