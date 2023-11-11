using Bnpp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.ViewModels
{
    public class TransientsViewModel
    {
        public string Name { get; set; }


        public string Code { get; set; }

        public string AllowableNumber { get; set; }
    }

    public class TransientsListViewModel
    {
        public string Name { get; set; }


        public string Code { get; set; }

        public string Values { get; set; }

        public int Count { get; set; }
    }


    public class TransientsForSearchInPeriodViewModel
    {
        public string Name { get; set; }


        public string Code { get; set; }

        public string Values { get; set; }

        public int Count { get; set; }
        public int NumberInPeriod { get; set; }
    }
}
