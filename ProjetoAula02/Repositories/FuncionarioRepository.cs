using Newtonsoft.Json;
using ProjetoAula02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoAula02.Repositories
{
    /// <summary>
    /// Classe para gravação dos dados de funcionários em arquivos
    /// </summary>
    public class FuncionarioRepository
    {
        /// <summary>
        /// Método para gravar dados dos funcionários em JSON
        /// </summary>
        public void ExportarJson(Funcionario funcionario)
        {
            var json = JsonConvert.SerializeObject(funcionario, Formatting.Indented);

            using (var streamWriter = new StreamWriter($"C:\\Willian\\Aula 2\\funcionario_{funcionario.Id}.json"))
            {
                streamWriter.WriteLine(json);
            }
        }

        /// <summary>
        /// Método para gravar dados dos funcionários em XML
        /// </summary>
        public void ExportarXml(Funcionario funcionario)
        {
            var xml = new XmlSerializer(typeof(Funcionario));

            using (var streamWriter = new StreamWriter($"C:\\Willian\\Aula 2\\funcionario_{funcionario.Id}.xml"))
            {
                xml.Serialize(streamWriter, funcionario);
            }
        }
    }
}
