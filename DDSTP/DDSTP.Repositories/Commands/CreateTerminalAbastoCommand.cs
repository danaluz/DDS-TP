using DDSTP.Data;
using DDSTP.Domain;
using DDSTP.Repositories.UserActions;

namespace DDSTP.Repositories.Commands
{
    public class CreateTerminalAbastoCommand : ICommand
    {
        public string Name
        {
            get { return "CreateTerminalAbastoCommand"; }
        }

        public void Do()
        {
            var context = new dbDDSTPContext();

            var terminalAbasto = new User();
            terminalAbasto.Name = "Abasto";
            terminalAbasto.UserType = UserType.Terminal;
            
            var actionsRepository = new UserActionRepository();

            var actions = actionsRepository.GetAll();

            foreach (var action in actions)
            {
                terminalAbasto.AddAction(action.Key);
            }

            var userRepo = new UserRepository(context);

            userRepo.Add(terminalAbasto);

            context.SaveChanges();
        }
    }
}
