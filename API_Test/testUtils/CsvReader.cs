using API_Test.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.testUtils
{
    class CsvReader
    {
        public static IEnumerable<object[]> ReadDevicesFromCsv(string csvFilePath)
        {
            var csvLines = File.ReadAllLines(csvFilePath).Skip(1);
            var devices = new List<object[]>();

            foreach (var line in csvLines)
            {
                var values = line.Split(',');
                if (values.Length == 6)
                {
                    var deviceName = values[0];
                    Data deviceData = new Data
                    {
                        Year = int.Parse(values[1]),
                        Price = double.Parse(values[2]),
                        CPUModel = values[3],
                        Color = values[4],
                        Capacity = values[5]
                    };

                    var testData = new object[] { deviceName, deviceData };
                    devices.Add(testData);
                }
            }
            return devices;
        }
    }
}
