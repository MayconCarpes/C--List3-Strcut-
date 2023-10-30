using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Programa
{
    struct Emprestimo
    {
        public DateTime Data;
        public string NomePessoa;
        public char Emprestado;
    }

    struct Jogo
    {
        public string Titulo;
        public string Console;
        public int Ano;
        public int Ranking;
        public Emprestimo EstadoEmprestimo;
    }

    static void AdicionarJogo(List<Jogo> listaJogos)
    {
        Jogo novoJogo = new Jogo();
        Console.WriteLine("Digite o Título do Jogo: ");
        novoJogo.Titulo = Console.ReadLine();
        Console.WriteLine("Digite o Modelo de Console: ");
        novoJogo.Console = Console.ReadLine();
        Console.WriteLine("Digite o Ano do Jogo: ");
        novoJogo.Ano = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o Ranking do Jogo: ");
        novoJogo.Ranking = int.Parse(Console.ReadLine());
        Emprestimo emprestimo = new Emprestimo();
        novoJogo.EstadoEmprestimo.Emprestado = 'N';
        listaJogos.Add(novoJogo);
    }

    static void ListarJogos(List<Jogo> listaJogos)
    {
        int qtd = listaJogos.Count;
        Console.WriteLine("Lista de Jogos: ");
        for (int i = 0; i < qtd; i++)
        {
            Console.WriteLine($"Título do Jogo: {listaJogos[i].Titulo}");
            Console.WriteLine($"Modelo de Console: {listaJogos[i].Console}");
            Console.WriteLine($"Ano do Jogo: {listaJogos[i].Ano}");
            Console.WriteLine($"Ranking do Jogo: {listaJogos[i].Ranking}");
            Console.WriteLine($"Emprestado: {listaJogos[i].EstadoEmprestimo.Emprestado}");
            if (listaJogos[i].EstadoEmprestimo.Emprestado == 'S')
            {
                Console.WriteLine($"Data de Empréstimo: {listaJogos[i].EstadoEmprestimo.Data}");
                Console.WriteLine($"Nome da Pessoa: {listaJogos[i].EstadoEmprestimo.NomePessoa}");
            }
        }
    }

    static void BuscarPorTitulo(List<Jogo> listaJogos, string titulo)
    {
        int qtd = listaJogos.Count();

        for (int i = 0; i < qtd; i++)
        {
            if (listaJogos[i].Titulo.ToUpper().Equals(titulo.ToUpper()))
            {
                Console.WriteLine($"Título do Jogo: {listaJogos[i].Titulo}");
                Console.WriteLine($"Modelo de Console: {listaJogos[i].Console}");
                Console.WriteLine($"Ano do Jogo: {listaJogos[i].Ano}");
                Console.WriteLine($"Ranking do Jogo: {listaJogos[i].Ranking}");
                Console.WriteLine($"Emprestado: {listaJogos[i].EstadoEmprestimo.Emprestado}");
                if (listaJogos[i].EstadoEmprestimo.Emprestado == 'S')
                {
                    Console.WriteLine($"Data de Empréstimo: {listaJogos[i].EstadoEmprestimo.Data}");
                    Console.WriteLine($"Nome da Pessoa: {listaJogos[i].EstadoEmprestimo.NomePessoa}");
                }
            }
        }
    }

    static void RealizarEmprestimo(List<Jogo> listaJogos, string titulo)
    {
        int qtd = listaJogos.Count();

        for (int i = 0; i < qtd; i++)
        {
            if (listaJogos[i].Titulo.ToUpper().Equals(titulo.ToUpper()))
            {
                if (listaJogos[i].EstadoEmprestimo.Emprestado == 'S')
                {
                    Console.WriteLine("Jogo já está emprestado!");
                }
                else
                {
                    Jogo jogoAtualizado = listaJogos[i];
                    jogoAtualizado.EstadoEmprestimo.Data = DateTime.Now;
                    Console.WriteLine("Digite o nome da pessoa que está pegando o jogo:");
                    jogoAtualizado.EstadoEmprestimo.NomePessoa = Console.ReadLine();
                    jogoAtualizado.EstadoEmprestimo.Emprestado = 'S';
                    listaJogos[i] = jogoAtualizado;
                }
            }
        }
    }

    static void DevolverJogo(List<Jogo> listaJogos, string titulo)
    {
        int qtd = listaJogos.Count();

        for (int i = 0; i < qtd; i++)
        {
            if (listaJogos[i].Titulo.ToUpper().Equals(titulo.ToUpper()))
            {
                if (listaJogos[i].EstadoEmprestimo.Emprestado == 'N')
                {
                    Console.WriteLine("Jogo não está emprestado!");
                }
                else
                {
                    Jogo jogoAtualizado = listaJogos[i];
                    jogoAtualizado.EstadoEmprestimo.Data = DateTime.MinValue;
                    jogoAtualizado.EstadoEmprestimo.NomePessoa = "";
                    jogoAtualizado.EstadoEmprestimo.Emprestado = 'N';
                    listaJogos[i] = jogoAtualizado;
                }
            }
        }
    }

    static void ListarEmprestados(List<Jogo> listaJogos)
    {
        int qtd = listaJogos.Count();

        for (int i = 0; i < qtd; i++)
        {
            if (listaJogos[i].EstadoEmprestimo.Emprestado == 'S')
            {
                Console.WriteLine($"Título do Jogo: {listaJogos[i].Titulo}");
                Console.WriteLine($"Modelo de Console: {listaJogos[i].Console}");
                Console.WriteLine($"Ano do Jogo: {listaJogos[i].Ano}");
                Console.WriteLine($"Ranking do Jogo: {listaJogos[i].Ranking}");
                Console.WriteLine($"Data de Empréstimo: {listaJogos[i].EstadoEmprestimo.Data}");
                Console.WriteLine($"Nome da Pessoa: {listaJogos[i].EstadoEmprestimo.NomePessoa}");
            }
        }
    }

    static void SalvarDados(List<Jogo> listaJogos, string nomeArquivo)
    {
        using (StreamWriter escritor = new StreamWriter(nomeArquivo))
        {
            foreach (Jogo jogo in listaJogos)
            {
                escritor.WriteLine($"{jogo.Titulo},{jogo.Console},{jogo.Ano},{jogo.Ranking},{jogo.EstadoEmprestimo.Data},{jogo.EstadoEmprestimo.NomePessoa},{jogo.EstadoEmprestimo.Emprestado}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static int MenuPrincipal()
    {
        Console.WriteLine("Menu Principal");
        Console.WriteLine("1 - Adicionar Jogo");
        Console.WriteLine("2 - Listar Jogos");
        Console.WriteLine("3 - Buscar por Título");
        Console.WriteLine("4 - Realizar Empréstimo de um Jogo");
        Console.WriteLine("5 - Devolver Jogo Emprestado");
        Console.WriteLine("6 - Listar Jogos Emprestados");
        Console.WriteLine("0 - Sair");
        int opcao = int.Parse(Console.ReadLine());
        return opcao;
    }

    static void Main()
    {
        List<Jogo> listaJogos = new List<Jogo>();
        int opcao;

        do
        {
            opcao = MenuPrincipal();

            switch (opcao)
            {
                case 1:
                    AdicionarJogo(listaJogos);
                    break;
                case 2:
                    ListarJogos(listaJogos);
                    break;
                case 3:
                    Console.WriteLine("Digite o Título do jogo que deseja procurar: ");
                    string tituloBusca = Console.ReadLine();
                    BuscarPorTitulo(listaJogos, tituloBusca);
                    break;
                case 4:
                    Console.WriteLine("Digite o Título do Jogo: ");
                    string titulo = Console.ReadLine();
                    RealizarEmprestimo(listaJogos, titulo);
                    break;
                case 5:
                    Console.WriteLine("Digite o Título do Jogo: ");
                    titulo = Console.ReadLine();
                    DevolverJogo(listaJogos, titulo);
                    break;
                case 6:
                    ListarEmprestados(listaJogos);
                    break;
                case 0:
                    Console.WriteLine("Saindo");
                    SalvarDados(listaJogos, "dados.txt");
                    break;
                default:
                    Console.WriteLine("ERRO: Opção Inválida.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        } while (opcao != 0);
    }
}
