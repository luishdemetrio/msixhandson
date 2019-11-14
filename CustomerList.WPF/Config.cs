using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerList.WPF
{
    public class Config
    {
        [JsonProperty("isCheckForUpdatesEnabled")]
        public bool IsCheckForUpdatesEnabled
        {
            get;
            set;
        }

      
    }
}
