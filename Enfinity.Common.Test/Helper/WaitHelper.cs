using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public static class WaitHelper
    {       
        public static async Task WaitForSeconds(int seconds)
        {
            await Task.Delay(seconds * 1000);
        }
    }
}
