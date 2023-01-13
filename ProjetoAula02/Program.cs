using ProjetoAula02.Entities;
using ProjetoAula02.Repositories;

namespace ProjetoAula02
{
    public class Program
    {
        /// <summary>
        /// Método para execução da class
        /// </summary>
        /// <param name="args">Parametros de entrada</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("\n *** Cadastro de Funcionários *** \n");

            var funcionario = new Funcionario();
            funcionario.Funcao = new Funcao();

            try
            {
                funcionario.Id = Guid.NewGuid();
                funcionario.Funcao.Id = Guid.NewGuid();

                Console.Write("Informe o nome do funcionário..: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("Informe o CPF..................: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("Informe a matrícula............: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("Informe a data de admissão.....: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.Write("Informe a descrição da função..: ");
                funcionario.Funcao.Descricao = Console.ReadLine();

                Console.WriteLine("\nDados do Funcionário:");
                Console.WriteLine($"\tID.............: {funcionario.Id}");
                Console.WriteLine($"\tNome...........: {funcionario.Nome}");
                Console.WriteLine($"\tCPF............: {funcionario.Cpf}");
                Console.WriteLine($"\tMatrícula......: {funcionario.Matricula}");
                Console.WriteLine($"\tData admissão..: {funcionario.DataAdmissao}");
                Console.WriteLine($"\tID função......: {funcionario.Funcao.Id}");
                Console.WriteLine($"\tDesc função....: {funcionario.Funcao.Descricao}");

                Console.Write("\nEscolha (1)JSON ou (2)XML.....:");
                var opcao = int.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                
                switch(opcao)
                {
                    case 1:
                        funcionarioRepository.ExportarJson(funcionario);
                        Console.WriteLine("\nArquivo JSON gravado com sucesso!");
                        break;
                    case 2:
                        funcionarioRepository.ExportarXml(funcionario);
                        Console.WriteLine("\nArquivo XML gravado com sucesso!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro de validação:");
                Console.WriteLine(e.Message);

                Console.Write("\nDeseja tentar novamente? (S/N)..:");
                var opcao = Console.ReadLine();
                if (opcao.Equals("S",StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Main(args);
                }
                else
                {
                    Console.WriteLine("\nFim");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao executar o programa:");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}