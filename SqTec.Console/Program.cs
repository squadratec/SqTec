using SqTec.Spec.IoC;
using SqTec.Spec.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqTec.Console
{
    /// <summary>
    /// Classe Program - Não deve ser alterada
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = IoC.ObterContainer())
            {
                container.ObterInstancia<Sistema>().Executar();
            }
        }
    }
}