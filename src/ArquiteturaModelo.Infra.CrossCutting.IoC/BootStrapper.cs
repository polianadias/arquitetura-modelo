using ArquiteturaModelo.Aplicacao;
using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Dominio.Interfaces.Servicos;
using ArquiteturaModelo.Dominio.Servicos;
using ArquiteturaModelo.Infra.Contexto;
using ArquiteturaModelo.Infra.Contexto.Interfaces;
using ArquiteturaModelo.Infra.Repositorio.Dapper;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void Register(Container container)
        {
            container.Register<IProdutoAppServico, ProdutoAppServico>(Lifestyle.Scoped);
            container.Register<IProdutoServico, ProdutoServico>(Lifestyle.Scoped);
            container.Register<IProdutoRepositorio, ProdutoRepositorio>(Lifestyle.Scoped);
            container.Register<IDapperContexto, DapperContexto>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

        }
    }
}
