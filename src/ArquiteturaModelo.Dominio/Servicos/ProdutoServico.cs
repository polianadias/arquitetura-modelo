using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum;
using ArquiteturaModelo.Dominio.Interfaces.Servicos;
using ArquiteturaModelo.Dominio.Servicos.Comum;

namespace ArquiteturaModelo.Dominio.Servicos
{
    public class ProdutoServico : Servico<Produto>, IProdutoServico
    {
        public ProdutoServico(IProdutoRepositorio repositorio)
            : base(repositorio)
        {
        }
    }
}
