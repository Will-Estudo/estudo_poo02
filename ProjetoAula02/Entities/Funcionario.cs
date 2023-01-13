using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    /// <summary>
    /// Classe de modelo de dados para a entidade Funcionário
    /// </summary>
    public class Funcionario
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private string _matricula;
        private DateTime _dataAdmissao;
        private Funcao _funcao;

        /// <summary>
        /// Método para encapsulamento do atributo _id
        /// </summary>
        public Guid Id
        {
            get => _id;
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("Por favor, informe um ID válido.");

                _id = value;
            }
        }

        /// <summary>
        /// Método para encapsulamento do atributo _nome
        /// </summary>
        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe o nome do funcionário");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um nome válido.");

                _nome = value;
            }
        }

        /// <summary>
        /// Método para encapsulamento do atributo _cpf
        /// </summary>
        public string Cpf
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe o CPF do funcionário");

                var regex = new Regex("^[0-9]{11}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um CPF com somente 11 dígitos numéricos.");

                _cpf = value;
            }
        }

        /// <summary>
        /// Método para encapsulamento do atributo _matricula
        /// </summary>
        public string Matricula
        {
            get => _matricula;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe a matrícula do funcionário");

                var regex = new Regex("^[A-Z0-9]{6,10}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe uma matrícula válida.");

                _matricula = value;
            }
        }

        /// <summary>
        /// Método para encapsulamento do atributo _dataAdmissao
        /// </summary>
        public DateTime DataAdmissao
        {
            get => _dataAdmissao;
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("Por favor, informe a data de admissão do funcionário.");

                _dataAdmissao = value;
            }
        }

        /// <summary>
        /// Método para encapsulamento do atributo _funcao
        /// </summary>
        public Funcao Funcao
        {
            get => _funcao;
            set { _funcao = value; }
        }
    }
}
