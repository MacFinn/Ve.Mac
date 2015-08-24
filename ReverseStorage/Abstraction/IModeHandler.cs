using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage
{
    public interface IModeHandler
    {
        void OrchestrateMode(UserMode mode, string word);
    }
}
