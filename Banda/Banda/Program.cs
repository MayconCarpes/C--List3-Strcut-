using System;
class Program
{
    struct TipoBanda
    {
        public string nome;
        public string genero;
        public int integrants;
        public int ranking;

    }//fim struct
    static void addBanda(List<TipoBanda> lista)
    {

        TipoBanda novaBanda = new TipoBanda();//declarando uma variavel do TipoBanda
        Console.Write("Nome da banda: ");
        novaBanda.nome = Console.ReadLine();
        Console.Write("Genero da banda: ");
        novaBanda.genero = Console.ReadLine();
        Console.Write("Intergrantes:");
        novaBanda.integrants = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ranking:");
        novaBanda.ranking = Convert.ToInt32(Console.ReadLine());
        lista.Add(novaBanda);
    }//fim da funcao

    static void ListaBandas(List<TipoBanda> lista)
    {
        int qtd = lista.Count();//conta quantos item bandas tem retorna  a ultima adicionada 
        for (int i = 0; i < qtd; i++)
        {
            Console.WriteLine("\t***Dados da banda***");
            Console.WriteLine("Nome:" + lista[i].nome);
            Console.WriteLine("Genero:" + lista[i].genero);
            Console.WriteLine("Integrantes:" + lista[i].integrants);//
            Console.WriteLine("Raking:" + lista[i].ranking);
        }   
    }


    static void ListaRanking(List<TipoBanda> lista, int idRanking)
    {
        int qtd = lista.Count();//conta quantos item bandas tem retorna  a ultima adicionada 
        for (int i = 0; i < qtd; i++)
        {

            if (lista[i].ranking == idRanking)
            {
                Console.WriteLine("\t***Dados da banda***");
                Console.WriteLine("Nome:" + lista[i].nome);
                Console.WriteLine("Genero:" + lista[i].genero);
                Console.WriteLine("Integrantes:" + lista[i].integrants);//
                Console.WriteLine("Raking:" + lista[i].ranking);
            }//fim else
        }
    }

    static void BuscarNome(List<TipoBanda> lista, string nomeBusca)
    {
        int qtd = lista.Count();//conta quantos item bandas tem retorna  a ultima adicionada 
        for (int i = 0; i < qtd; i++)
        {

            if (lista[i].nome.ToUpper().Contains(nomeBusca.ToUpper() ) )
            {
                Console.WriteLine("\t***Dados da banda***");
                Console.WriteLine("Nome:" + lista[i].nome);
                Console.WriteLine("Genero:" + lista[i].genero);
                Console.WriteLine("Integrantes:" + lista[i].integrants);//
                Console.WriteLine("Raking:" + lista[i].ranking);
                
            }//fim else
        }//fim do for
    }//

    static void buscarGenero(List<TipoBanda> lista, string GeneroBusca)
    {
        int qtd = lista.Count();//conta quantos item bandas tem retorna  a ultima adicionada 
        for (int i = 0; i < qtd; i++)
        {

            if (lista[i].genero.ToUpper().Contains(GeneroBusca.ToUpper()))
            {
                Console.WriteLine("\t***Dados da banda***");
                Console.WriteLine("Nome:" + lista[i].nome);
                Console.WriteLine("Genero:" + lista[i].genero);
                Console.WriteLine("Integrantes:" + lista[i].integrants);//
                Console.WriteLine("Raking:" + lista[i].ranking);

            }//fim else
        }//fim do for
    }//

    static void AlterarDados(List<TipoBanda> lista, string nomeBusca)
    {
        int qtd = lista.Count();//conta quantos item bandas tem retorna  a ultima adicionada 
        bool flag = false;
        for (int i = 0; i < qtd; i++)
        {

            if (lista[i].nome.ToUpper().Equals(nomeBusca.ToUpper()))
            {
                flag = true;
                TipoBanda novaBanda = new TipoBanda();//declarando uma variavel do TipoBanda
                Console.Write("NOVO Nome da banda: ");
                novaBanda.nome = Console.ReadLine();
                Console.Write("NOVO Genero da banda: ");
                novaBanda.genero = Console.ReadLine();
                Console.Write("NOVOS Intergrantes:");
                novaBanda.integrants = Convert.ToInt32(Console.ReadLine());
                Console.Write("NOVO Ranking:");
                novaBanda.ranking = Convert.ToInt32(Console.ReadLine());

                lista[i] = novaBanda;

            }//fim else
        }//fim do for
        if (!flag) //flag==true
            Console.WriteLine("Banda não encontrada :(");
        


    }//alterar dados
    static void removerBanda(List<TipoBanda> lista, string nomeBusca)
    {
        int qtd = lista.Count();//conta quantos item bandas tem retorna  a ultima adicionada 
        bool flag = false;
        int decisao;

        for (int i = 0; i < qtd; i++)
        {

            if (lista[i].nome.ToUpper().Equals(nomeBusca.ToUpper()))
            {
                Console.Write($"Tem certeza que deseja remover a banda? {nomeBusca}?[S/N]");
                char resp;
                resp = Convert.ToChar(Console.ReadLine());
                if (resp == 's' || resp == 'S')
                {
                    Console.Write($"Banda {nomeBusca} removida");
                    lista.RemoveAt(i);
                    
                    break;
                }
                else
                {
                    Console.WriteLine(" Operação Cancelada...");
                }
            }
            
                

            //fim else
        }//fim do for
       



    }//alterar dados

static  int somaIntegrantes(List<TipoBanda> lista)
    {
        int qtd = lista.Count();
        int soma = 0;
        // percorrer o vetor - lista - e somar todo integrantes
        for (int i = 0; i < qtd; i++)
        {
            soma += lista[i].integrants;

        }
            return soma;
    }

    static void SalvarDados(List<TipoBanda> bandas, string nomeArquivo)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (TipoBanda banda in bandas)
            {
                writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrants},{banda.ranking}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }


    static void CarregarDados(List<TipoBanda> bandas, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                TipoBanda banda = new TipoBanda
                {
                    nome = campos[0],
                    genero = campos[1],
                    integrants = int.Parse(campos[2]),
                    ranking = int.Parse(campos[3])
                };
                bandas.Add(banda);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static int menu(){
        Console.WriteLine("***Sistema de Cadastro Banda**");
        Console.WriteLine("1-Adicionar banda");
        Console.WriteLine("2-Listar");
        Console.WriteLine("3-Filtrar por ranking");
        Console.WriteLine("4-buscar por nome");
        Console.WriteLine("5-buscar por genero");
        Console.WriteLine("6-Alterar ");
        Console.WriteLine("7-remove");
        Console.WriteLine("8-soma todos integrantes");
        Console.WriteLine("0-sair");
        Console.WriteLine("Entre com uma opção: ");
        int op = Convert.ToInt32(Console.ReadLine());  
        return op;
    }
        static void Main()
        {
            List<TipoBanda> listadeBandas = new List<TipoBanda>();

        int op;
        CarregarDados(listadeBandas, "                                         .txt");
        do
        {
            op = menu();

            switch (op)
            {
                case 1:
                    addBanda(listadeBandas);
                    break;
                case 2:
                    ListaBandas(listadeBandas);
                    break;
                case 3:
                    Console.WriteLine("Ranking para filtro:");
                    int idRanking = Convert.ToInt32(Console.ReadLine());
                    ListaRanking(listadeBandas, idRanking);

                    break;
                case 4:
                    Console.WriteLine("Nome para busca:");
                    string nomeBusca = Console.ReadLine();
                    BuscarNome(listadeBandas, nomeBusca);

                    break;
                case 5:
                    Console.WriteLine("Genero para busca:");
                    string GeneroBusca = Console.ReadLine();
                    buscarGenero(listadeBandas, GeneroBusca);

                    break;
                case 6:
                    Console.WriteLine("Busca nome banda alteracao:");
                     nomeBusca = Console.ReadLine();
                    AlterarDados(listadeBandas, nomeBusca);

                    break;
                case 7:
                    Console.WriteLine("Nome banda para remover:");
                    nomeBusca = Console.ReadLine();
                    removerBanda(listadeBandas, nomeBusca);

                    break;
                case 8:

                    Console.WriteLine("Nome banda para remover: "+somaIntegrantes(listadeBandas)); 
                    
                   

                    break;
                case 0: 
                    Console.WriteLine("Saindo...");
                    SalvarDados(listadeBandas, "dadosBandas.txt");
                    break;
            }// fim switch
            Console.ReadKey();//pausa
            Console.Clear();//limpa
        } while (op != 0); //fim while
            
         


            Console.ReadLine();//pause antes de fechar
        }

    }
