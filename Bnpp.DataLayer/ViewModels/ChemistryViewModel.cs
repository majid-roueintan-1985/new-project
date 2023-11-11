using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.ViewModels
{
    public class ChartViewModel
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public int ComparisonWithNormalValueSymbol{ get; set; }
        public int NormalValue  { get; set; }
        public int ComparisonWithNormalValueSymbol2 { get; set; }
        public int NormalValue2  { get; set; }
        public DateTime Time { get; set; }


    }

    public class Chart1ViewModel
    {
       
        public string Value { get; set; }
       
        //public string NormalValue { get; set; }
      
    }
}
