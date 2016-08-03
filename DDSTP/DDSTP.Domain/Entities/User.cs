using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace DDSTP.Domain
{
    public enum UserType
    {
        Administrator,
        Terminal
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public UserType UserType { get; set; }

        private string _jsonActions;
        public string JsonActions
        {
            get { return _jsonActions; }
            set
            {
                _jsonActions = value;
                _allowedActions = JsonConvert.DeserializeObject<HashSet<string>>(value);
            }
        }

        private HashSet<string> _allowedActions = new HashSet<string>();
        public IEnumerable<string> AllowedActions
        {
            get { return _allowedActions.ToList(); }
        }

        public void AddAction(string key)
        {
            _allowedActions.Add(key);
            JsonActions = JsonConvert.SerializeObject(_allowedActions);
        }

        public void RemoveAction(string key)
        {
            _allowedActions.Remove(key);
            JsonActions = JsonConvert.SerializeObject(_allowedActions);
        }
    }
}
