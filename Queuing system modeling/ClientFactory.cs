using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queuing_system_modeling
{
    public abstract class ClientFactory
    {
        public abstract Client CreateClient(int[] idQueuingSystem, int[] needVisiting);
    }

    public class CleverClientFactory : ClientFactory
    {
        public override Client CreateClient(int[] idQueuingSystem, int[] needVisiting)
        {
            return new CleverClient(idQueuingSystem, needVisiting);
        }
    }

    public class StupidClientFactory : ClientFactory
    {
        public override Client CreateClient(int[] idQueuingSystem, int[] needVisiting)
        {
            return new StupidClient(idQueuingSystem, needVisiting);
        }
    }
}
