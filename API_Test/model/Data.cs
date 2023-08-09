using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.model
{
    public class Data
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("capacity")]
        public string Capacity { get; set; }

        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("CPU model")]
        public string CPUModel { get; set; }

        [JsonProperty("cpumodel")]
        public string cpuodel { get; set; }

        public string CPU_Model
        {
            get { return CPUModel ?? cpuodel; }
            set { CPUModel = value; }
        }

        [JsonProperty("Hard disk size")]
        public string HardDiskSize { get; set; }

        [JsonProperty("Strap Colour")]
        public string StrapColour { get; set; }

        [JsonProperty("Case Size")]
        public string CaseSize { get; set; }

        [JsonProperty("Color")]
        public string WirelessColor { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Capacity")]
        public string iPadCapacity { get; set; }

        [JsonProperty("Screen size")]
        public double? ScreenSize { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
