using SqTec.Spec.IoC;
using SqTec.Spec.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqTec.Console
{
    public static class IoC
    {
        public static Container ObterContainer()
        {
            var container = Container.Inicializar();

            // Registre suas dependências aqui...

            //container.Registrar<IClienteService, ...>();
            //container.Registrar<ILogService, ...>();
            //container.Registrar<IExibicaoService, ...>();
            //container.Registrar<IPremiacaoService, ...>();
            //container.Registrar<IConfigService, ...>();
            container.Registrar<Sistema>();

            return container;
        }
    }
}
