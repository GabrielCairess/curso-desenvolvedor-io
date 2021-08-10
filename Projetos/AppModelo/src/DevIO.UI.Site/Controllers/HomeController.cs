using DevIO.UI.Site.Data;
using DevIO.UI.Site.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public OperacaoService OperacaoService { get; }
        public OperacaoService OperacaoService2 { get; }

        public HomeController(IPedidoRepository pedidoRepository, OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            _pedidoRepository = pedidoRepository;
            OperacaoService = operacaoService;
            OperacaoService2 = operacaoService2;
        }

        public string Index()
        {
            var pedido = _pedidoRepository.ObterPedido();

            return "Primeira Instância: " + Environment.NewLine +
                OperacaoService.Transiente.OperacaoId + Environment.NewLine +
                OperacaoService.Scopped.OperacaoId + Environment.NewLine +
                OperacaoService.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Segunda Instância: " + Environment.NewLine +
                OperacaoService2.Transiente.OperacaoId + Environment.NewLine +
                OperacaoService2.Scopped.OperacaoId + Environment.NewLine +
                OperacaoService2.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService2.SingletonInstance.OperacaoId + Environment.NewLine;
        }
    }
}
