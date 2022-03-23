using System;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class Notificador
    {
        public void ApresentarMensagem(string mensagem, string tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case "Sucesso":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case "Atencao":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case "Erro":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
