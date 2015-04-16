
using System.Management.Automation;

namespace CoDelivery.Core.Infra.Clients
{
    public class PowerShellClient
    {
        private PowerShell _powerShell;

        public PowerShellClient()
        {
            _powerShell = PowerShell.Create();
        }

        public string ExecuteCommand(string command)
        {
            _powerShell.AddScript(command);

            var result = "";

            foreach (var psobject in _powerShell.Invoke())
            {
                result += psobject.BaseObject.ToString();
            }

            return result;
        }
    }
}