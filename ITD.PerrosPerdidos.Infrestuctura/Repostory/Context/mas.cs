using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace ITD.PerrosPerdidos.Infrestuctura
    {
        public interface ISimulacionContextRepository
        {
            Task<SimulacionContext> GetContextAsync(int id);
            Task<IEnumerable<SimulacionContext>> GetAllContextsAsync();
            Task AddContextAsync(SimulacionContext context);
            Task UpdateContextAsync(SimulacionContext context);
            Task DeleteContextAsync(int id);
        }

        public class SimulacionContextRepository : ISimulacionContextRepository
        {
           
        }

        public class SimulacionContext
        {
          
        }
    }

}
