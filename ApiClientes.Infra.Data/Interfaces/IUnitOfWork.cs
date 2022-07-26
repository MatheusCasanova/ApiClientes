using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        #region Métodos para controle de transição

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Métodos pra acesso ao repositórios

        public IClienteRepository ClienteRepository { get; }

        #endregion
    }
}
