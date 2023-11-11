using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bnpp.DataLayer.ViewModels
{
	public class ONOFFViewModel
	{
        public int ChangeStateId { get; set; }
		public int MechanicalId { get; set; }
		public string Description { get; set; }

        public DateTime ChangeStateDate { get; set; }

        public List<int> ChangingInStates { get; set; }
        public DateTime CreateDate { get; set; }

    }

	public class OFFViewModel
	{
		public string Description { get; set; }

		public DateTime ChangeStateDate { get; set; }

	}
}
