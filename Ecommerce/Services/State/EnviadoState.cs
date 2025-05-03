using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Objetcs.Models;
using Ecommerce.Services.State;

namespace Ecommerce.domains.state
{
    public class EnviadoState : PedidoState
    {
        private Pedido pedido;
        public EnviadoState(Pedido pedido)
        {
            this.pedido = pedido;
        }
        void PedidoState.CancelarPedido()
        {
            throw new Exception("Operação não suportada, pedido já foi enviado");
        }
        void PedidoState.DespacharPedido()
        {
            throw new Exception("Operação não suportada, pedido já foi enviado");
        }
        void PedidoState.SucessoAoPagar()
        {
            throw new Exception("Operação não suportada, pedido já foi enviado");
        }
    }
}
