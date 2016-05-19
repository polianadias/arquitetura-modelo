using ArquiteturaModelo.Dominio.Entidades;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Infra.Contexto.Mapeamento
{
    public class ProdutoMapper : ClassMapper<Produto>
    {
        public ProdutoMapper()
        {
            Table("PRODUTO");

            Map(p => p.ProdutoId).Column("ID_PRODUTO").Key(KeyType.Identity);
            Map(p => p.Descricao).Column("DESCRICAO_PRODUTO");
        }

    }
}
