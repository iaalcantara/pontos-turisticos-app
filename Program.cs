using System;

namespace pontos_turisticos_app
{
    class Program
    {
        static PontosRepositorio repositorio = new PontosRepositorio();
        static void Main(string[] args)
        {
            string userOption = ReceiveUserOption();

            while (userOption.ToUpper() != "0")
            {
                switch (userOption)
                {
                    case "1":
                    ListarPontos();
                    break;
                    case "2":
                    CadastrarPontos();
                    break;
                    case "3":
                    AtualizarPontos();
                    break;
                    case "4":
                    ExcluirPontos();
                    break;
                    case "5":
                    VisualizarPontos();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                userOption = ReceiveUserOption();
            }

            Console.WriteLine("Obrigada pela visita!");
        }
        //Listar pontos turísticos
        private static void ListarPontos()
        {
            Console.WriteLine("Listar Pontos Turísticos");

            var lista = repositorio.List();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não achamos nenhum ponto turístico cadastrado!");
                return;
            }

            foreach (var pontos in lista)
            {
                var excluido = pontos.retornaDeleted();
                Console.WriteLine("#ID {0}: - {1}", pontos.retornaId(), pontos.retornaNome(), excluido ? "Ponto turístico já foi excluído" : "");
            }
        }

        //Cadastrar pontos turísticos
        private static void CadastrarPontos()
        {
            Console.WriteLine("Cadastrar  novo ponto turístico");

            foreach (int i in Enum.GetValues(typeof(City)))
            {
                Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(City), i));
            }

            Console.WriteLine("Digite o número da cidade desejada: ");
            int entradaCity = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do ponto turístico: ");
            string entradaName = Console.ReadLine();

            Console.WriteLine("Digite o endereço do ponto turístico: ");
            string entradaAddress = Console.ReadLine();

            Console.WriteLine("Digite o dia da semana e horário de funcionamento do ponto turístico: ");
            string entradaOperation = Console.ReadLine();

            Console.WriteLine("Digite o preço do ponto turístico: ");
            string entradaPrice = Console.ReadLine();

            Console.WriteLine("Adicione uma descrição ao ponto turístico: ");
            string entradaDescription = Console.ReadLine();

            Pontos novoPonto = new Pontos(id: repositorio.NextId(),
            city: (City)entradaCity,
            name: entradaName,
            address: entradaAddress,
            operation: entradaOperation,
            price: entradaPrice,
            description: entradaDescription);

            repositorio.Insert(novoPonto);

        }

        // Visualizar pontos turísticos

        private static void VisualizarPontos()
        {
            Console.Write("Digite o id do ponto turístico: ");
            int idPontos = int.Parse(Console.ReadLine());

            var pontos = repositorio.ReturnById(idPontos);

            Console.WriteLine(pontos);
        }

        //Atualizar pontos turísticos

        private static void AtualizarPontos()
        {
            Console.WriteLine("Digite o id do ponto turístico que deseja atualizar: ");
            int idPontos = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(City)))
            {
                Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(City), i));
            }
            Console.WriteLine("Digite o número da cidade desejada: ");
            int entradaCity = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do ponto turístico: ");
            string entradaName = Console.ReadLine();

            Console.WriteLine("Digite o endereço do ponto turístico: ");
            string entradaAddress = Console.ReadLine();

            Console.WriteLine("Digite o dia da semana e horário de funcionamento do ponto turístico: ");
            string entradaOperation = Console.ReadLine();

            Console.WriteLine("Digite o preço do ponto turístico: ");
            string entradaPrice = Console.ReadLine();

            Console.WriteLine("Adicione uma descrição ao ponto turístico: ");
            string entradaDescription = Console.ReadLine();

            Pontos atualizarPonto = new Pontos(id: idPontos,
            city: (City)entradaCity,
            name: entradaName,
            address: entradaAddress,
            operation: entradaOperation,
            price: entradaPrice,
            description: entradaDescription);

            repositorio.Update(idPontos, atualizarPonto);

        }

        // Excluir pontos turísticos

        public static void ExcluirPontos()
        {
            Console.Write("Digite o id do ponto turístico que deseja excluir: ");
            int idPontos = int.Parse(Console.ReadLine());

            repositorio.Delete(idPontos);
        }

        

        private static string ReceiveUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Conheça os Pontos Turísticos de Pernambuco");
            Console.WriteLine("Escolha o opçao abaixo: ");

            Console.WriteLine("1 - Listar Pontos Turísticos");
            Console.WriteLine("2 - Inserir novos Pontos Turísticos");
            Console.WriteLine("3 - Atualizar Pontos Turísticos");
            Console.WriteLine("4 - Excluir Pontos Turísticos");
            Console.WriteLine("5 - Visualizar Pontos Turísticos");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper(); 
            Console.WriteLine();
            return userOption;
        }
    }
}
