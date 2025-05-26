using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Utilities
{
    public static class VaultUtils
    {
        public static string GetConnectionString()
        {
            var keyVaultUrl = "https://vaibhav1.vault.azure.net/";
            var secretName = "ConnectionString";

            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            KeyVaultSecret secret = client.GetSecret(secretName);

            return secret.Value;
        }
    }
}
