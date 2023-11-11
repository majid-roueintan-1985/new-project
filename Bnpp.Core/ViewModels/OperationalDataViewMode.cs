using Bnpp.DataLayer.Entities.OperationalDatas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class SensorViewModel
    {
        public string SensorName { get; set; }

        public string AKZ { get; set; }

        public string Unit { get; set; }

        public string MinimumValue { get; set; }

        public string MaximumValue { get; set; }

        public string NormalValue { get; set; }

        public string TransientEvents { get; set; }

    }


    public class ChemicalWaterViewModel
    {
        public string ParameterName { get; set; }

        public string AKZ { get; set; }

        public string Unit { get; set; }

        public string MinimumValue { get; set; }

        public string MaximumValue { get; set; }

        public string NormalValue { get; set; }

        public string TransientEvents { get; set; }

    }
}
