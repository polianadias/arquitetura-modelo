using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Infra.Repositorio.Dapper.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArquiteturaModelo.Infra.Contexto.Interfaces;

namespace ArquiteturaModelo.Infra.Repositorio.Dapper
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(IDapperContexto context)
            : base(context)
        {
        }
    }
}
