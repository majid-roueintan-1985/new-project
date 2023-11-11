using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class ChemistryViewModel
    {
        public string System { get; set; }

        
        public string SamplingPoint { get; set; }

        
        public string Building { get; set; }

        
        public string SystemStateCaption { get; set; }

        
        public string CircuitCaption { get; set; }


        public DateTime ExperimentDateTime { get; set; }

        
        public string ParameterCaption { get; set; }

        
        public string Value { get; set; }

        
        public string UnitCaption { get; set; }

        
        public string ComparisonWithNormalValueSymbol { get; set; }

        
        public string NormalValue { get; set; }

        
        public string ComparisonWithNormalValueSymbol2 { get; set; }

        
        public string NormalValue2 { get; set; }

        
        public string ExecutingScheduleCaption { get; set; }

        
        public string NoteCaption { get; set; }
    }
}
