using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Proxies.ShopsProxy;

namespace DDSTP.Repositories.Commands
{
    public class CommandExecutor
    {
        public static List<ICommand> GetAllCommands()
        {
            var commands = new List<ICommand>();

            commands.Add(new UpdateShopsCommand(new ShopProxy()));
            commands.Add(new CreateTerminalAbastoCommand());

            return commands;
        }

        private ICommand _currentCommand;

        public void SetCommand(ICommand command)
        {
            _currentCommand = command;
        }

        public void Execute()
        {
            if (_currentCommand == null) return;

            _currentCommand.Do();
            _currentCommand = null;
        }
    }
}
