using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;

namespace Bnpp.Core.Services
{
	public class CommissioningService : ICommissioningService
	{
		private BnppContext _context;

		public CommissioningService(BnppContext context)
		{
			_context = context;
		}
		public List<Commissioning> GetAllCommissioning(int mechanicalId)
		{
			return _context.Commissioning.Where(c => c.IsDelete == false && c.MechanicalId == mechanicalId).ToList();
		}

		public int AddCommissioning(Commissioning commissioning)
		{
			commissioning.CreateDate = DateTime.Now;
			_context.Add(commissioning);
			_context.SaveChanges();
			return commissioning.CommissioningId;
		}

		public void UpdateCommissioning(Commissioning commissioning)
		{
			commissioning.CreateDate = DateTime.Now;
			_context.Update(commissioning);
			_context.SaveChanges();
		}

		public Commissioning GetCommissioningById(int commissioningId)
		{
			return _context.Commissioning.Find(commissioningId);
		}

		public void DeleteCommissioning(int commissioningId)
		{
			var commission = GetCommissioningById(commissioningId);
			commission.IsDelete = true;
			UpdateCommissioning(commission);
		}

		public List<CommissioningViewModel> GetAllCommissioningForExport(int mechanicalId)
		{
			return _context.Commissioning.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new CommissioningViewModel()
			{
				Parameter1 = c.Parameter1,
				Parameter2 = c.Parameter2,
				Parameter3 = c.Parameter3,
				Parameter4 = c.Parameter4
			}).ToList();
		}

		public CommissioningViewModel GetCommissioningByIdForExport(int commissioningId)
		{
			var install = GetCommissioningById(commissioningId);

			CommissioningViewModel commissioning = new CommissioningViewModel();

			commissioning.Parameter1 = install.Parameter1;
			commissioning.Parameter2 = install.Parameter2;
			commissioning.Parameter3 = install.Parameter3;
			commissioning.Parameter4 = install.Parameter4;

			return commissioning;
		}
	}
}
