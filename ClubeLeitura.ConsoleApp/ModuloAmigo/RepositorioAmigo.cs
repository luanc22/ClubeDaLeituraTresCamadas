using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;

        public void Inserir(Amigo amigo)
        {
            amigo.id = ++numeroAmigo;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;
        }

        public void Editar(int numeroSelecioando, Amigo amigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == numeroSelecioando)
                {
                    amigo.id = numeroSelecioando;
                    amigos[i] = amigo;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == numeroSelecionado)
                {
                    amigos[i] = null;
                    break;
                }
            }
        }

        public bool VerificarIdAmigoExiste(int numeroAmigo)
        {
            bool idAmigoEncontrado = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].id == numeroAmigo)
                {
                    idAmigoEncontrado = true;
                    break;
                }
            }

            return idAmigoEncontrado;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

        public Amigo[] SelecionarTodos()
        {
            int quantidadeAmigos = ObterQtdAmigos();

            Amigo[] caixasInseridas = new Amigo[quantidadeAmigos];
            int j = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    caixasInseridas[j] = amigos[i];
                    j++;
                }
            }

            return caixasInseridas;
        }

        public int ObterQtdAmigos()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                    numeroAmigos++;
            }

            return numeroAmigos;
        }
    }

}

