using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaNumero_Metodos
{
    class Program
    {
        // Declaração de variáveis globais
        static int[] numeros = new int[100]; // instanciamos a matriz de 1 dimensão (vetor) com 100 células

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                opcao = Menu(); // chamada de um método de um tipo função
                Distribuidor(opcao); // chamada de um método do tipo procedimento
                      
                Console.Write("\nPressione qualquer tecla para prosseguir este programa...");
                Console.ReadKey();
            } while (opcao != 9);
        } // fim do método main

        static int Menu() // detalhamento da função Menu
        {
            int escolha; 
            Console.Clear();
            Console.WriteLine("Projeto Lista Números");
            Console.WriteLine("\nMenu de opções:");
            Console.WriteLine("1. Lista números pares");
            Console.WriteLine("2. Lista números impares");
            Console.WriteLine("3. Lista números múltiplos");
            Console.WriteLine("4. Lista números aleatórios");
            Console.WriteLine("5. Lista palpite para Megasena");
            Console.WriteLine("6. Testa tipo de número");
            Console.WriteLine("7. Lista de números primos");
            Console.WriteLine("8. Lista últimos números listados");
            Console.WriteLine("9. Encerrar programa");
            Console.Write("\nDigite o número da opção desejada: ");
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || (escolha > 8 && escolha != 9))  // consistência da escolha aceitável
            {
                Console.Write("A opção deve ser um número (inteiro) e entre 1 e 9! Digite novamente: ");
            }
            return escolha;
            } // fim do método Menu

        static void Distribuidor(int tarefa) // detalhamento do procedimento distribuidor
        {
            switch (tarefa)
            {

                case 1:
                    GeraPares(); // Chamada do método do tipo procedimento
                    break;


                case 2:
                    GeraImpares(); // Chamada do método do tipo procedimento                    
                        break;

                case 3:
                    GeraMultiplos(); // Chamada do método do tipo procedimento
                    break;

                case 4:
                    GeraAleatorio(); // Chamada do método do tipo procedimento
                    break;

                case 5:
                    Console.WriteLine("\nLista palpite para megasena");
                    break;

                case 6:
                    TestaNumero(); // Chamada de método do tipo procedimento
                    break;

                case 7:
                    ListaPrimo(); // Chamada do método do tipo procedimento
                    break;
                
                case 8:
                    ListaUltimaLista(); // Chamada do método do tipo procedimento
                    break;

                case 9:
                    Console.WriteLine("\nEncerrando programa...");
                    break;
                    
            } // fim do switch
        } // fim do procedimento Distribuidor

        static void Listador(int num, int posicao)  // Detalhamento do método Listador
        {
            numeros[posicao - 1] = num; // armazenando o vetor o número que será listado
            if (posicao % 10 != 0)
                Console.Write("{0, 3}  ", num);
            else
                Console.Write("{0, 3}\n", num);
        } // fim do procedimento Listador

        static void GeraPares() // Detalhamento do método do tipo procedimento
        {
            int cont;
            Console.WriteLine("\nLista de números pares:\n");
            for (cont = 1; cont <= 100; cont++)
            {
                Listador(cont * 2, cont);  // chamada de um método do tipo procedimento
            }
        } // Fim do procedimento GeraPares

        static void GeraImpares() // Detalhamento do método do tipo procedimento
        {
            int cont;
            Console.WriteLine("\nLista números impares:\n");
            cont = 1;
            while (cont <= 100)
            {
                Listador(cont * 2 - 1, cont);
                cont++;
            }
        } // Fim do procedimento GeraImpares

        static void GeraMultiplos() // Detalhamento do método do tipo procedimento
        {
            int cont, mult;
            Console.Write("\nDeseja múltiplos de qual número inteiro: ");
            while (!int.TryParse(Console.ReadLine(), out mult)) 
            {
                Console.Write("O digito é de um número não inteiro! Digite novamente: ");
            }
            Console.WriteLine("\nLista números múltiplos:\n");
            cont = 1;
            do
            {
                Listador(cont * mult, cont);
                cont++;
            } while (cont <= 100);
        } // Fim do procedimento GeraMultiplos

        static void TestaNumero() // Detalhamento do método do tipo procedimento
        {
            int num, div;
            Console.Write("Informe o número a ser testado: ");
            while (!int.TryParse(Console.ReadLine(), out num) || num < 1)
                Console.Write("Deve ser número inteiro maior que 0! Digite novamente: ");

            if (TestaPar(num) == 0)
                Console.WriteLine("\nO número {0} é par!", num);
            else
                Console.WriteLine("\nO número {0} é ímpar!", num);

            div = TestaPrimo(num);
            if (div == num)
                Console.WriteLine("\nO número {0} é primo!", num);
            else
                Console.WriteLine("\nO número {0} não é primo, pois é divisível por {1}.", num, div);
        } // fim do procedimento TestaNumero

        static int TestaPar (int num)
        {
            return num % 2;
        } // fim da função TestaPar

        static int TestaPrimo (int num) // Detalhamento da função
        {
            int div;
            if (num == 1) return 1;
            for (div = 2; div < num; div++)
                if (num % div == 0) break;
            return div;
        } // fim da função TestaPrimo

        static void GeraAleatorio() // Detalhamento do método do tipo procedimento
        {
            int cont;
            Random aleat = new Random(); // instanciamento de objeto aleatório
            Console.WriteLine("\nLista de números aleatórios:\n");
            for (cont = 1; cont <= 100; cont++)
            {            
                Listador(aleat.Next(1, 101), cont);  // chamada de um método do tipo procedimento
            }
        } // Fim do procedimento GeraAleatorio

        static void ListaPrimo() // Detalhamento do método do tipo procedimento
        {
            Console.WriteLine("\nLista de números primos:\n");
            int num, pos = 1;
            for (num = 2; num < 5000; num++)
                if(TestaPrimo(num) == num)
                {
                    Listador(num, pos);
                    pos++;
                    if (pos > 100) break;
                }
        } // Fim do procedimento ListaPrimo

        static void ListaUltimaLista() // Detalhamento de método do tipo procedimento
        {
            int i; // Declaração do ponteiro para nosso vetor, além de contador para o posicionamento
            Console.WriteLine("\nLista dos últimos listados:\n");
            for (i = 0; i < 100; i++)
                Listador(numeros[i], i + 1);
        } // Fim do método ListaUltimaLista
    }
}