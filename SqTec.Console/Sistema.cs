using SqTec.Spec;
using SqTec.Spec.Dtos;
using SqTec.Spec.Entities;
using SqTec.Spec.Exceptions;
using SqTec.Spec.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqTec.Console
{
    /// <summary>
    /// Classe da execução principal - Não deve ser alterada
    /// </summary>
    public class Sistema
    {
        private readonly IClienteService _clienteService;
        private readonly IConfigService _configService;
        private readonly ILogService _logService;
        private readonly IExibicaoService _exibicaoService;
        private readonly IPremiacaoService _premiacaoService;

        public Sistema(IClienteService clienteService,
            IConfigService configService,
            ILogService logService,
            IExibicaoService exibicaoService,
            IPremiacaoService premiacaoService)
        {
            _clienteService = clienteService;
            _configService = configService;
            _logService = logService;
            _exibicaoService = exibicaoService;
            _premiacaoService = premiacaoService;
        }

        public void Executar()
        {
            try
            {
                var caminhoTxt = _configService.ObterConfiguracao<string>(Consts.CaminhoArquivoClientes);
                var clientes = _clienteService.ObterClientesDeTxt(caminhoTxt);

                ProcessarClientes(clientes);

                var clientesExibicao = ObterClientesExibicao(_clienteService.Listar());
                var regioesExibicao = _exibicaoService.AgruparClientesExibicaoPorRegiao(clientesExibicao);

                _exibicaoService.ExibirClientes(clientesExibicao);
                System.Console.WriteLine();
                _exibicaoService.ExibirSumarizadoPorRegiao(regioesExibicao);
            }
            catch (Exception ex)
            {
                _logService.Log(ex);
                System.Console.WriteLine(Consts.MensagemErroPadrao);
            }

            System.Console.ReadLine();
        }

        private void ProcessarClientes(IEnumerable<ICliente> clientes)
        {
            try
            {
                _clienteService.BeginTransaction();

                clientes.ToList().ForEach(cliente =>
                {
                    if (_clienteService.ObterPorId(cliente.IdentificadorERP) == null)
                        _clienteService.Inserir(cliente);
                    else
                        _clienteService.Atualizar(cliente);
                });

                _clienteService.Commit();
            }
            catch (Exception)
            {
                _clienteService.Rollback();
                throw;
            }
        }

        private IEnumerable<ClienteExibicao> ObterClientesExibicao(IEnumerable<ICliente> clientes)
        {
            return clientes.Select(cliente =>
            {
                return new ClienteExibicao(
                    cliente.Nome,
                    cliente.Regiao,
                    _clienteService.CalcularIdade(cliente),
                    _premiacaoService.CalcularMedalhasOuro(cliente),
                    _premiacaoService.CalcularMedalhasPrata(cliente),
                    _premiacaoService.CalcularMedalhasBronze(cliente),
                    _premiacaoService.CalcularDesconto(cliente));
            });
        }
    }
}
