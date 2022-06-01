using System;

namespace Estudo.Threads
{
    public class Principal
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Escolher opção para rodar:\n1 - Rodar sequencial\n2 - Rodar paralelo\n3 - Rodar distribuído e paralelo\nEscolha: ");
            string choosed = Console.ReadLine();
            string[] args_user;
            string path;
            switch(choosed)
            {
                case "1":
                    Console.WriteLine("Será tentado encontrar de forma sequencial o arquivo: Arquivo_teste.txt que se encontra dentro deste projeto. Por favor, digite agora o valor referente ao PATH de onde a busca será iniciada:\nPATH: ");
                    path = Console.ReadLine();
                    args_user = new string[] {$"path={path}", "file=Arquivo_teste.txt"};
                    FindFiller.Busca(args_user);
                    break;
                case "2":
                    Console.WriteLine("Será tentado encontrar de forma paralela o arquivo: Arquivo_teste.txt que se encontra dentro deste projeto. Por favor, digite agora o valor referente ao PATH de onde a busca será iniciada:\nPATH: ");
                    path = Console.ReadLine();
                    args_user = new string[] {$"path={path}", "file=Arquivo_teste.txt"};
                    FindFiller.Busca(args_user, useThreadSearch: false);
                    break;
                case "3":
                    Console.WriteLine("Será tentado encontrar de forma paralela e distribuída o arquivo: Arquivo_teste.txt que se encontra dentro deste projeto. Por favor, inicie o programa SocketClient no Python e em seguida passe o valor do path por lá.");
                    SocketServerConnection.Run();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}