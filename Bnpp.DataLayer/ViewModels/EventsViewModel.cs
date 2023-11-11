using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.ViewModels
{
    public class BeforeStatusViewModel
    {
        public int EventsId { get; set; }
        public string BeforeHeatPower { get; set; }
        public string BeforeParameter { get; set; }
        public string BeforeOperatingModes { get; set; }
        public string BeforeElectricalPower { get; set; }
        public string BeforeEffectiveWorkingDays { get; set; }
        public string BeforePressureWater { get; set; }
        public string BeforePressureinFirstCircuit { get; set; }
        public string BeforePressureinSecondCircuit { get; set; }
        public string BeforeVaccuminCondensor { get; set; }
       
    }

    public class AfterStatusViewModel
    {
        public int EventsId { get; set; }
        public string AfterParameter { get; set; }
        public string AfterOperatingModes { get; set; }
        public string AfterHeatPower { get; set; }
        public string AfterElectricalPower { get; set; }
        public string AfterEffectiveWorkingDays { get; set; }
        public string AfterPressureWater { get; set; }
        public string AfterPressureinFirstCircuit { get; set; }
        public string AfterPressureinSecondCircuit { get; set; }
        public string AfterVaccuminCondensor { get; set; }

    }
}
