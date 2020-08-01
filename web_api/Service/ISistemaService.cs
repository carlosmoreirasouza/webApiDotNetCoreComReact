using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Service
{
    public interface ISistemaServices
    {
        IEnumerable<Sistemas> GetListaSistemas();
        Sistemas GetSistema(int id);
        void AddSistema(Sistemas item);
        void UpdateSistema(Sistemas item);
        void DeleteSistema(int id);
        bool sistemaExiste(Sistemas Id);

    }
}
