using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalPrivado.BO
{
    [Serializable]
    public class MedicoImagenes
    {
        [JsonProperty(PropertyName = "Url")]
        public String Url { get; set; }
        [JsonProperty(PropertyName = "ThumbnailUrl")]
        public String ThumbnailUrl { get; set; }
    }
    
}
