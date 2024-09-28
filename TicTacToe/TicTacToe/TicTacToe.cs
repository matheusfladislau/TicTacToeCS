namespace TicTacToe;

public class TicTacToe
{
    static string? p1;
    static string? p2;
    static bool FinalizouGanhou = false;
    static string?[,] tictactoe = new string?[3, 3];

    public static void Main()
    {
        bool primeiroJogador = true;
        EscolherSimbolo();
        PopularMatriz();
        do
        {
            Console.Clear();
            PrintarMatriz();
            Jogada(primeiroJogador);
            primeiroJogador = !primeiroJogador;
        } while (!Ganhou(!primeiroJogador) && !Velha());

        if (FinalizouGanhou)
        {
            Console.WriteLine("O jogador {0} venceu!", (!primeiroJogador) ? p1 : p2);
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Deu velha.");
        Console.ReadKey();
        return;
    }

    private static bool Ganhou(bool primeiroJogador)
    {
        string? jogadorChecar = (primeiroJogador) ? p1 : p2;

        for (int i = 0; i < 3; i++)
        {
            if (tictactoe[i, 0] == jogadorChecar &&
                tictactoe[i, 1] == jogadorChecar &&
                tictactoe[i, 2] == jogadorChecar)
            {
                FinalizouGanhou = true;
                return FinalizouGanhou;
            }

            if (tictactoe[0, i] == jogadorChecar &&
                tictactoe[1, i] == jogadorChecar &&
                tictactoe[2, i] == jogadorChecar)
            {
                FinalizouGanhou = true;
                return FinalizouGanhou;
            }
        }

        if (tictactoe[0, 0] == jogadorChecar &&
            tictactoe[1, 1] == jogadorChecar &&
            tictactoe[2, 2] == jogadorChecar)
        {
            FinalizouGanhou = true;
            return FinalizouGanhou;
        }

        if (tictactoe[2, 0] == jogadorChecar &&
            tictactoe[1, 1] == jogadorChecar &&
            tictactoe[0, 2] == jogadorChecar)
        {
            FinalizouGanhou = true;
            return FinalizouGanhou;
        }
        FinalizouGanhou = false;
        return FinalizouGanhou;
    }

    private static bool Velha()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tictactoe[i,j]! != "X" && tictactoe[i,j]! != "O")
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static void PopularMatriz()
    {
        int somarCasa = 0;
        for (int i = 0; i < 3; i++)
        {
            tictactoe[i, 0] = (somarCasa + i + 1).ToString();
            tictactoe[i, 1] = (somarCasa + i + 2).ToString();
            tictactoe[i, 2] = (somarCasa + i + 3).ToString();
            somarCasa += 2;
        }
    }

    private static void Jogada(bool primeiroJogador)
    {
        Console.WriteLine((primeiroJogador ? "Primeiro jogador: {0}" : "Segundo jogador: {1}") + ". Faça sua jogada!", p1, p2);
        Console.WriteLine("Escolha um número disponível.");

        string num = Console.ReadLine()!;
        bool icExiste = ChecarNumero(num, primeiroJogador);
        while (!icExiste)
        {
            Console.WriteLine("Escolha um número disponível!");
            num = Console.ReadLine()!;
            icExiste = ChecarNumero(num, primeiroJogador);
        }
    }

    private static bool ChecarNumero(string num, bool primeiroJogador)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tictactoe[i,j]!.Equals(num))
                {
                    SubstituirNumero(i,j,num,primeiroJogador);
                    return true;
                }
            }
        }
        return false;
    }

    private static void SubstituirNumero(int i, int j, string num, bool primeiroJogador)
    {
        tictactoe[i, j] = (primeiroJogador) ? p1 : p2;
    }

    private static void PrintarMatriz()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("{0}|{1}|{2}", tictactoe[i, 0], 
                                             tictactoe[i, 1], 
                                             tictactoe[i, 2]);
            if (i < 2)
            {
                Console.WriteLine("=====");
            }
        }
    }

    private static void EscolherSimbolo()
    {
        Console.WriteLine("Jogador 1: X ou O?");
        p1 = Console.ReadLine()!;

        while (p1 != "X" && p1 != "O")
        {
            Console.WriteLine("Escreva X ou O");
            p1 = Console.ReadLine()!;
        }
        p2 = (p1 == "X") ? "O" : "X";

        Console.WriteLine("Jogador 1 = {0}, Jogador 2 = {1}", p1, p2);
        Console.ReadKey();
    }
}
