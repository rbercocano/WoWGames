using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames
{
    public class EPayCancellationException :Exception
    {
        public EPayCancellationException(string message):base(message)
        {

        }
    }
}
