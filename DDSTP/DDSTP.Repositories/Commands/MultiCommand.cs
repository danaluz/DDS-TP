using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Repositories.Commands
{
    public class MultiCommand : ICommand
    {
        private readonly IEnumerable<ICommand> _commands;

        public MultiCommand(params ICommand[] commands)
        {
            if (_commands == null)
                throw new Exception("You must attach at least one command to execute.");

            _commands = commands;
        }

        public string Name {
            get { return string.Join(",", _commands.Select(x => x.Name).ToList()); }
        }

        public void Do()
        {
            foreach (var command in _commands)
            {
                command.Do();
            }
        }
    }
}
