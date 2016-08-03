using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DDSTP.Repositories.Commands
{
    public interface ICommand
    {
        string Name { get; }
        void Do();
    }
}
