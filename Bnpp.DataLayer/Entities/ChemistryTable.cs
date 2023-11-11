using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class ChemistryTable
    {
        [Key]
        public int ID { get; set; }


        [MaxLength(200)]
        public string System { get; set; }

        [MaxLength(200)]
        public string SamplingPoint { get; set; }

        [MaxLength(200)]
        public string Building { get; set; }

        [MaxLength(200)]
        public string SystemStateCaption { get; set; }

        [MaxLength(200)]
        public string CircuitCaption{ get; set; }

        
        public DateTime ExperimentDateTime { get; set; }

        [MaxLength(200)]
        public string ParameterCaption { get; set; }

        [MaxLength(200)]
        public string Value { get; set; }

        [MaxLength(200)]
        public string UnitCaption{ get; set; }

        [MaxLength(200)]
        public string ComparisonWithNormalValueSymbol { get; set; }

        [MaxLength(200)]
        public string NormalValue { get; set; }

        [MaxLength(200)]
        public string ComparisonWithNormalValueSymbol2 { get; set; }

        [MaxLength(200)]
        public string NormalValue2 { get; set; }

        [MaxLength(200)]
        public string ExecutingScheduleCaption { get; set; }

        [MaxLength(200)]
        public string NoteCaption{ get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
