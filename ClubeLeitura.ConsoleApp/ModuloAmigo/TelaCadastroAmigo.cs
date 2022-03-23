using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaCadastroAmigo
    {
        public int numeroAmigo; //controlar o numero de amigos cadastradas
        public Notificador notificador; //reponsavel pelas mensagens pro usuario
        public RepositorioAmigo repositorioAmigo;
        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite S para sair");

            Console.WriteLine();
            Console.Write("Opcao selecionada: ");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo novoAmigo = ObterAmigo();

            repositorioAmigo.Inserir(novoAmigo);

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", "Sucesso");
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            bool temAmigosCadastrados = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo cadastrado para poder editar", "Atencao");
                return;
            }

            int idAmigo = ObterNumeroAmigo();

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(idAmigo, amigoAtualizado);

            notificador.ApresentarMensagem("Amigo editado com sucesso", "Sucesso");
        }

        public int ObterNumeroAmigo()
        {
            int idAmigo;
            bool idAmigoEncontrado;

            do
            {
                Console.Write("Digite o ID do amigo que deseja: ");
                idAmigo = Convert.ToInt32(Console.ReadLine());

                idAmigoEncontrado = repositorioAmigo.VerificarIdAmigoExiste(idAmigo);

                if (idAmigoEncontrado)
                {
                    Console.WriteLine();
                }
                else
                {
                    notificador.ApresentarMensagem("ID do amigo nao encontrado, digite novamente", "Atencao");
                }

            } while (idAmigoEncontrado == false);

            return idAmigo;
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temAmigosCadastrados = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhum amigo encontrado para excluir.", "Atencao");
                return;
            }

            int idAmigo = ObterNumeroAmigo();

            repositorioAmigo.Excluir(idAmigo);

            notificador.ApresentarMensagem("Amigo excluido com sucesso", "Sucesso");
        }

        public bool VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            Amigo[] amigos = repositorioAmigo.SelecionarTodos();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigo amigo = amigos[i];

                Console.WriteLine("ID: " + amigo.id);
                Console.WriteLine("Nome: " + amigo.nome);
                Console.WriteLine("Nome do Responsavel: " + amigo.nomeResponsavel);
                Console.WriteLine("Endereco: " + amigo.endereco);
                Console.WriteLine("Telefone: " + amigo.telefone);

                Console.WriteLine();
            }

            return true;
        }

        public Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o endereco: ");
            string endereco = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nome = nome;
            amigo.nomeResponsavel = nomeResponsavel;
            amigo.endereco = endereco;
            amigo.telefone = telefone;

            return amigo;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
    }
}
