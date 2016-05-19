using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Dominio.Interfaces.Especificacoes
{
    public interface ISpecification<in TEntity>
    {
         bool IsSatisfiedBy(TEntity entity);
    }
}
