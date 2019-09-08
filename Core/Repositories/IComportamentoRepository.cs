using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteFullStackPleno.Core.Entities;

namespace TesteFullStackPleno.Core.Repositories
{
    public interface IComportamentoRepository
    {
        void Add(Comportamento comportamento);
    }
}
