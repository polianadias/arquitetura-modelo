using ArquiteturaModelo.Dominio.Entidades.Especificacao.Produtos;
using ArquiteturaModelo.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Dominio.Entidades.Validacao.Produtos
{
    public class ProdutoEstaConsistenteValidation : Validation<Produto>
    {
        public ProdutoEstaConsistenteValidation()
        {
            AddRule(new ValidationRule<Produto>(new ProdutoDescricaoNaoPodeSerNuloOuEmBrancoSpecification(), "A Descrição do Produto não pode ser nula ou em branco."));
        }
    }
}
