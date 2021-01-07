using System;

namespace jogoDaVelha
{
    class Program
    {
        public static int GerarNumerosAleatorios(int inicio, int fim)
        {
            Random random = new Random();

            return random.Next(inicio, fim);
        }

        public static int GerarXEYAleatorios(int x, int y, int vazio)
        {
            var numeroAleatorio = GerarNumerosAleatorios(0, 3);

            if (numeroAleatorio == 0)
            {
                return vazio;
            }

            return numeroAleatorio == 1 ? x : y;
        }

        public static int[][] GerarJogoDaVelhaAleatorio(int x, int y, int vazio)
        {
            int[][] matriz = new int[3][];

            for (int i = 0; i < matriz.Length; i++)
            {
                matriz[i] = new int[3];

                for (int j = 0; j < matriz.Length; j++)
                {
                    matriz[i][j] = GerarXEYAleatorios(x, y, vazio);
                }
            }

            return matriz;
        }

        public static void PrintarJogoDaVelha(int[][] matriz)
        {
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    System.Console.Write(matriz[i][j]);

                    if (j != (matriz[i].Length - 1))
                    {
                        System.Console.Write(" - ");
                    }
                    else
                    {
                        System.Console.Write("\n");
                    }
                }
            }
        }

        static int VerResultado(int[][] matriz, int x, int y, int vazio)
        {
            var listaDePossiveisVitorias = new int[][][] {
                //linhas
                new int[3][] { new int[] {0, 0}, new int[] {0, 1}, new int[] {0, 2}},
                new int[3][] { new int[] {1, 0}, new int[] {1, 1}, new int[] {1, 2}},
                new int[3][] { new int[] {2, 0}, new int[] {2, 1}, new int[] {2, 2}},

                //colunas
                new int[3][] { new int[] {0, 0}, new int[] {1, 0}, new int[] {2, 0}},
                new int[3][] { new int[] {0, 1}, new int[] {1, 1}, new int[] {2, 1}},
                new int[3][] { new int[] {0, 2}, new int[] {1, 2}, new int[] {2, 2}},
                
                //cortes
                new int[3][] { new int[] {0, 0}, new int[] {1, 1}, new int[] {2, 2}},
                new int[3][] { new int[] {0, 2}, new int[] {1, 1}, new int[] {2, 0}},
            };

            foreach (var item in listaDePossiveisVitorias)
            {
                if (
                    matriz[item[0][0]][item[0][1]] == x && matriz[item[1][0]][item[1][1]] == x && matriz[item[2][0]][item[2][1]] == x ||
                    matriz[item[0][0]][item[0][1]] == y && matriz[item[1][0]][item[1][1]] == y && matriz[item[2][0]][item[2][1]] == y
                )
                {
                    return HOUVE_GANHADOR;
                }
            }

            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    if (matriz[i][j] == vazio)
                    {
                        return NAO_TERMINOU;
                    }
                }
            }

            return NAO_HOUVE_GANHADOR;
        }
        static int VALOR_CAMPO_X = 1;
        static int VALOR_CAMPO_Y = 10;
        static int VALOR_CAMPO_VAZIO = 0;
        static int NAO_TERMINOU = 0;
        static int HOUVE_GANHADOR = 1;
        static int NAO_HOUVE_GANHADOR = 2;

        static void Main(string[] args)
        {
            var jogoDaVelha = GerarJogoDaVelhaAleatorio(VALOR_CAMPO_X, VALOR_CAMPO_Y, VALOR_CAMPO_VAZIO);
            PrintarJogoDaVelha(jogoDaVelha);

            System.Console.WriteLine();
            System.Console.WriteLine($"Resultado: {VerResultado(jogoDaVelha, VALOR_CAMPO_X, VALOR_CAMPO_Y, VALOR_CAMPO_VAZIO)}");
            System.Console.WriteLine();
        }
    }
}
