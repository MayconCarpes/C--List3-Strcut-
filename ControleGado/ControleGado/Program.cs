using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    struct DataNascimento
    {
        public int Mes;
        public int Ano;
    }

    struct Gado
    {
        public int Codigo;
        public double ProducaoLeite; // por semana
        public double ConsumoAlimento; // por semana
        public DataNascimento Nascimento;
        public char Abate; // S/N
    }

    static void GerarDados(List<Gado> lista)
    {
        Random random = new Random();
        int codigo = 0;

        for (int i = 0; i < 100; i++)
        {
            Gado gado = new Gado();
            gado.Codigo = ++codigo;
            gado.ProducaoLeite = random.Next(30, 100);
            gado.ConsumoAlimento = random.Next(15, 50);
            gado.Nascimento.Mes = random.Next(1, 13);
            gado.Nascimento.Ano = random.Next(2016, 2023);
            if (2023 - gado.Nascimento.Ano > 5 || gado.ProducaoLeite < 40)
            {
                gado.Abate = 'S';
            }
            else
            {
                gado.Abate = 'N';
            }
            lista.Add(gado);
        }
    }

    static void TotalLeite(List<Gado> lista)
    {
        int qtd = lista.Count;
        double leiteSemanal = 0;

        for (int i = 0; i < qtd; i++)
        {
            leiteSemanal += lista[i].ProducaoLeite;
        }
        Console.WriteLine("Total de leite produzido por semana: " + leiteSemanal.ToString("F1") + "L");
    }

    static void TotalAlimento(List<Gado> lista)
    {
        int qtd = lista.Count;
        double totalAlimento = 0;

        foreach (Gado gado in lista)
        {
            totalAlimento += gado.ConsumoAlimento;
        }
        Console.WriteLine("Total de alimento consumido por semana: " + totalAlimento.ToString("F1") + "KG");
    }

    static void ListaAnimaisAbate(List<Gado> lista)
    {
        int qtd = lista.Count;

        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].Abate == 'S')
            {
                Console.WriteLine($"Código animal: {lista[i].Codigo}");
            }
        }
    }

    static void SalvarDados(List<Gado> lista, string nomeArquivo)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (Gado gado in lista)
            {
                writer.WriteLine($"{gado.Codigo},{gado.ProducaoLeite},{gado.ConsumoAlimento},{gado.Nascimento.Mes},{gado.Nascimento.Ano},{gado.Abate}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void CarregarDados(List<Gado> lista, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            lista.Clear();

            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                Gado gado = new Gado
                {
                    Codigo = int.Parse(campos[0]),
                    ProducaoLeite = double.Parse(campos[1]),
                    ConsumoAlimento = double.Parse(campos[2]),
                    Nascimento = new DataNascimento { Mes = int.Parse(campos[3]), Ano = int.Parse(campos[4]) },
                    Abate = char.Parse(campos[5]),
                };
                lista.Add(gado);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static int MenuPrincipal()
    {
        Console.WriteLine("Menu Principal");
        Console.WriteLine("1 - Total de leite produzido por semana");
        Console.WriteLine("2 - Total de alimento consumido por semana");
        Console.WriteLine("3 - Listar animais para abate");
        Console.WriteLine("4 - Salvar dados em arquivo");
        Console.WriteLine("5 - Carregar dados do arquivo");
        Console.WriteLine("0 - Sair");
        Console.Write("Digite a opção desejada: ");

        int opcao = int.Parse(Console.ReadLine());
        return opcao;
    }

    static void Main()
    {
        List<Gado> listaGado = new List<Gado>();

        GerarDados(listaGado);

        int opcao;

        do
        {
            opcao = MenuPrincipal();

            switch (opcao)
            {
                case 1:
                    TotalLeite(listaGado);
                    break;
                case 2:
                    TotalAlimento(listaGado);
                    break;
                case 3:
                    ListaAnimaisAbate(listaGado);
                    break;
                case 4:
                    SalvarDados(listaGado, "dados.txt");
                    break;
                case 5:
                    CarregarDados(listaGado, "dados.txt");
                    break;
                case 0:
                    Console.WriteLine("Saindo");
                    break;
                default:
                    Console.WriteLine("ERRO: Opção Inválida");
                    break;
            }

            Console.ReadKey();
            Console.Clear();

        } while (opcao != 0);
    }
}
