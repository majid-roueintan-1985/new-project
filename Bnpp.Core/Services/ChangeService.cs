using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.AgeingDocuments;
using Bnpp.DataLayer.Entities.ONOFF;
using Bnpp.DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services
{
    public class ChangeService : IChangeService
    {
        private BnppContext _context;

        public ChangeService(BnppContext context)
        {
            _context = context;
        }


        public int AddChangeState(ChangeState change)
        {
            change.CreateDate = DateTime.Now;
            _context.Add(change);
            _context.SaveChanges();
            return change.ChangeStateId;
        }

        public void DeleteChangeState(int changeId)
        {
            var changing=_context.ChangeState.Find(changeId);
            changing.IsDelete = true;
            _context.Update(changing);
            _context.SaveChanges();
        }

        public List<ONOFFViewModel> GetAllChangeState()
        {


            return _context.ChangeState.Where(c => c.IsDelete == false).
                Include(c => c.ChangingInState).ThenInclude(s => s.States)
                .Select(c => new ONOFFViewModel()
                {
                    ChangeStateId=c.ChangeStateId,
                    CreateDate = c.CreateDate,
                    ChangeStateDate = c.ChangeStateDate,
                    Description = c.Description,
                    ChangingInStates = c.ChangingInState.Select(s => s.StateId).ToList()
                }).ToList();
        }



        public ONOFFViewModel GetChangeStateById(int changeId)
        {

            return _context.ChangeState.Where(u => u.ChangeStateId == changeId).Include(u => u.ChangingInState)
                .Select(u => new ONOFFViewModel()
                {
                    ChangeStateId=u.ChangeStateId,
                    CreateDate = u.CreateDate,
                    ChangeStateDate = u.ChangeStateDate,
                    Description = u.Description,
                    ChangingInStates = u.ChangingInState.Select(s => s.StateId).ToList(),
                    MechanicalId=u.MechanicalId
                }).Single();
        }

        public void UpdateChangeState(ChangeState change)
        {
            change.CreateDate=DateTime.Now;
            _context.Update(change);
            _context.SaveChanges();
        }


        public List<States> GetAllStates()
        {
            return _context.State.Where(c => c.IsDelete == false).ToList();
        }

        public void AddStateToStaeChanges(int chngestateId, List<int> states)
        {
            foreach (var p in states)
            {

                _context.ChangingInState.Add(new ChangingInState()
                {
                    StateId = p,
                    ChangeStateId = chngestateId
                });
            }



            _context.SaveChanges();
        }

        public void EDitStateToStaeChanges(int chngestateId, List<int> statess)
        {
           

            //-------Delete All Roles User ---------//
            _context.ChangingInState.Where(r => r.ChangeStateId == chngestateId).ToList().ForEach(r => _context.ChangingInState.Remove(r));

            //-----Add New Roles To User ------------//

            AddStateToStaeChanges(chngestateId, statess);
        }

		public List<OFFViewModel> GetAllChangeStateForExport(int mechanicalId)
		{
			return _context.ChangeState.Where(u => u.IsDelete == false&&u.MechanicalId==mechanicalId)
			   .Select(u => new OFFViewModel()
			   {
				   ChangeStateDate = u.ChangeStateDate,
				   Description = u.Description
			   }).ToList();
		}

		public OFFViewModel GetChangeStateByIdForExport(int changeId)
		{
            var state = _context.ChangeState.Find(changeId);

			OFFViewModel oFFViewModel=new OFFViewModel();
            oFFViewModel.Description = state.Description;
            oFFViewModel.ChangeStateDate = state.ChangeStateDate;

            return oFFViewModel;
		}
	}
}
