using System;

namespace DIO.series
{
    class Program
    {
       static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaousuario = ObterOpcaoUsuario();     

            while (opcaousuario.ToUpper() != "X")
            {
                switch (opcaousuario)
                {   
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        IncluirSerie();
                        break;
                    case "3":
                        AlterarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;    
                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }

        }

        private static void ListarSerie(){

            Console.WriteLine("Lista de Series");

            var lista = repositorio.Lista();       

            if (lista.Count == 0){

              Console.WriteLine("Nnhuma serie cadastrada");
              return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}",serie.retornaId(), serie.retornaTitulo());
            }

        }
        private static void IncluirSerie(){

            Console.Write("Incluindo serie");
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetValues(typeof(Genero)));
            }
            Console.WriteLine("Digite o numero do genero");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie");
            string entradaTitulo = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o ano de inicio da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie");
            String entradaDescricao = Console.ReadLine().ToUpper();

            Serie serie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,titulo: entradaTitulo,Descricao: entradaDescricao, ano: entradaAno);

            repositorio.Insere(serie);

        }

        private static void AlterarSerie(){
            
            Console.Write("Alterando a serie");
            
            Console.WriteLine("Digite o numero do ID da serie");
            int entradaID = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetValues(typeof(Genero)));
            }
            Console.WriteLine("Digite o numero do genero");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie");
            string entradaTitulo = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o ano de inicio da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie");
            String entradaDescricao = Console.ReadLine().ToUpper();

            Serie atualizaserie = new Serie(id: entradaID,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    Descricao: entradaDescricao, 
                                    ano: entradaAno);

            repositorio.Atualiza(entradaID,atualizaserie);

        }

        private static void ExcluirSerie(){

            Console.Write("Excluindo a serie");
            
            Console.WriteLine("Digite o numero do ID da serie que deseja excluir");
            int entradaID = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja realmente excluir a serie? S/N");
            string respostaExclusao = Console.ReadLine().ToUpper();

            if (respostaExclusao.Equals("S")){
                repositorio.Exclui(entradaID);
            } else{
                Console.WriteLine("Registro não excluido");
            }
        }

        private static void VisualizarSerie(){
            
            Console.Write("Mostrando a serie...");
            
            Console.WriteLine("Digite o numero do ID da serie que deseja visualizar");
            int entradaID = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorID(entradaID);

            Console.WriteLine(serie);
        }



        private static string ObterOpcaoUsuario(){

            Console.WriteLine("Ola. Bem vindo ao programa de Series");
            Console.WriteLine("Infomre a opção desejada");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Cadastrar Series");
            Console.WriteLine("3 - Atualizar Series");
            Console.WriteLine("4 - Excluir Series");
            Console.WriteLine("5 - Visualizar Series");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;

        }
    }
}
