using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Repositories.UserActions
{
    public class UserActionRepository
    {
        private Dictionary<string, IUserAction> availableActions;

        public UserActionRepository()
        {
            this.availableActions = new Dictionary<string, IUserAction>();

            this.availableActions.Add("ChangeFontSizeAction", new ChangeFontSizeAction());
        }

        public Dictionary<string, IUserAction> GetAll()
        {
            return new Dictionary<string, IUserAction>(availableActions);
        }

        public IUserAction GetByKey(string key)
        {
            return availableActions.ContainsKey(key) ? availableActions[key] : null;
        }
    }

    public interface IUserAction
    {
        void Do();
        void Undo();
    }

    public class ChangeFontSizeAction : IUserAction
    {
        public void Do()
        {
            Console.WriteLine("The font is changed.");
        }

        public void Undo()
        {
            Console.WriteLine("The font back to normal.");
        }
    }
}
