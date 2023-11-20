using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.FeatureDto
{
    public class GetFeatureDto
    {
        public int FeatureId { get; set; }
        public string Title1 { get; set; }
        public string Decription1 { get; set; }
        public string Title2 { get; set; }
        public string Decription2 { get; set; }
        public string Title3 { get; set; }
        public string Decription3 { get; set; }
    }
}
