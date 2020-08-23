using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class ResponseBase
    {
        public bool OperationSucceeded { get; set; }
        public string Error { get; set; }
        public string ErrorText { get; set; }
    }
}
