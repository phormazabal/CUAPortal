using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PortalPrivado.BO
{
    [Serializable]
    public class Medicos
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }
        public List<Value> Value { get; set; }
    }
    [Serializable]
    public class Value
    {
        [JsonProperty("odata.type")]
        public String Cabecera { get; set; } 
        public String Id { get; set; }
        public String LastModified { get; set; }
        public String PublicationDate { get; set; }
        public String DateCreated { get; set; }
        public String UrlName { get; set; }
        public String AreaInteres { get; set; }
        public String MiniBiografia { get; set; }
        public String Descripcion { get; set; }
        public String Nombres { get; set; }
        public String VMA { get; set; }
        public String Obeservaciones { get; set; }
        public String Apellidos { get; set; }
        public String IdiomasAtencion { get; set; }
        public String Title { get; set; }
        public String ActividadDocente { get; set; }
        public String LinkReserva { get; set; }
        public String Jefatura { get; set; }
        public String AreaInvestigacion { get; set; }
        public String UbicacionConsulta { get; set; }
        public String DescripcionProfesional { get; set; }
        public String Rut { get; set; }
        public MedicoImagenes oImagenes { get; set; }

    }
}
        
    

