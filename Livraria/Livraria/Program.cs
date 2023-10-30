using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Programa
{
    struct DadosLivros
    {
        public string Titulo;
        public string Autor;
        public int Ano;
        public int Prateleira;
    }

    static void AdicionarLivro(List<DadosLivros> listaLivros)
    {
        DadosLivros livro = new DadosLivros();
        Console.WriteLine("Digite o Título do Livro: ");
        livro.Titulo = Console.ReadLine();
        Console.WriteLine("Digite o Nome do Autor: ");
        livro.Autor = Console.ReadLine();
        Console.WriteLine("Digite o Ano do Livro: ");
        livro.Ano = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a Prateleira do Livro: ");
        livro.Prateleira = int.Parse(Console.ReadLine());
        listaLivros.Add(livro);
    }

    static void BuscarPorTitulo(List<DadosLivros> listaLivros, string titulo)
    {
        int quantidade = listaLivros.Count();
        bool encontrado = false;

        for (int i = 0; i < quantidade; i++)
        {
            if (listaLivros[i].Titulo.ToUpper().Contains(titulo.ToUpper()))
            {
                encontrado = true;
                Console.WriteLine($"Título do Livro: {listaLivros[i].Titulo}");
                Console.WriteLine($"Prateleira do Livro: {listaLivros[i].Prateleira}");
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    static void ListarLivros(List<DadosLivros> listaLivros)
    {
        int quantidade = listaLivros.Count();

        for (int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"Título do Livro: {listaLivros[i].Titulo}");
            Console.WriteLine($"Autor do Livro: {listaLivros[i].Autor}");
            Console.WriteLine($"Ano do Livro: {listaLivros[i].Ano}");
            Console.WriteLine($"Prateleira do Livro: {listaLivros[i].Prateleira}");
            Console.WriteLine("\n");
        }
    }

    static void ListarPorAno(List<DadosLivros> listaLivros, int ano)
    {
        int quantidade = listaLivros.Count();
        Console.WriteLine($"Livros mais novos que {ano}:");
        for (int i = 0; i < quantidade; i++)
        {
            if (listaLivros[i].Ano > ano)
            {
                Console.WriteLine($"Título do Livro: {listaLivros[i].Titulo}");
                Console.WriteLine($"Autor do Livro: {listaLivros[i].Autor}");
                Console.WriteLine($"Ano do Livro: {listaLivros[i].Ano}");
                Console.WriteLine($"Prateleira do Livro: {listaLivros[i].Prateleira}");
            }
            Console.WriteLine("\n");
        }
    }

    static int Menu()
    {
        Console.WriteLine("**Menu**");
        Console.WriteLine("1 - Adicionar Livro");
        Console.WriteLine("2 - Buscar Livro");
        Console.WriteLine("3 - Listar Livros");
        Console.WriteLine("4 - Listar Livros mais Novos");
        Console.WriteLine("0 - Sair");

        Console.Write("Digite: ");
        int opcao = int.Parse(Console.ReadLine());
        return opcao;
    }

    static void SalvarDados(List<DadosLivros> listaLivros, string nomeArquivo)
    {
        using (StreamWriter escritor = new StreamWriter(nomeArquivo))
        {
            foreach (DadosLivros livro in listaLivros)
            {
                escritor.WriteLine($"{livro.Titulo},{livro.Autor},{livro.Ano},{livro.Prateleira}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void CarregarDados(List<DadosLivros> listaLivros, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                DadosLivros livro = new DadosLivros
                {
                    Titulo = campos[0],
                    Autor = campos[1],
                    Ano = int.Parse(campos[2]),
                    Prateleira = int.Parse(campos[3])
                };
                listaLivros.Add(livro);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static void Main()
    {
        List<DadosLivros> listaDadosLivros = new List<DadosLivros>();
        int opcao;

        do
        {
            opcao = Menu();

            switch (opcao)
            {
                case 1:
                    AdicionarLivro(listaDadosLivros);
                    break;
                case 2:
                    Console.WriteLine("Digite o Título do Livro que deseja buscar: ");
                    string titulo = Console.ReadLine();
                    BuscarPorTitulo(listaDadosLivros, titulo);
                    break;
                case 3:
                    ListarLivros(listaDadosLivros);
                    break;
                case 4:
                    Console.WriteLine("Digite o ano para filtrar: ");
                    int ano = int.Parse(Console.ReadLine());
                    ListarPorAno(listaDadosLivros, ano);
                    break;
                case 0:
                    SalvarDados(listaDadosLivros, "dados.txt");
                    break;
                default:
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        } while (opcao != 0);
    }
}
