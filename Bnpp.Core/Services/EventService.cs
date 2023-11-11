using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services
{
	public class EventService : IEventService
	{
		private BnppContext _context;

		public EventService(BnppContext context)
		{
			_context = context;
		}
		public int AddEvents(Events events, IFormFile imgEvents)
		{
			events.CreateDate = DateTime.Now;

			if (imgEvents != null)
			{
				events.EventsImage = Guid.NewGuid() + Path.GetExtension(imgEvents.FileName);
				string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", events.EventsImage);

				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					imgEvents.CopyTo(stream);
				}
			}


			events.EventLevel = events.EventLevel.Replace("\r\n", string.Empty);
			_context.Add(events);
			_context.SaveChanges();
			return events.EventsId;
		}



		public void DeleteEvents(int eventsId)
		{
			var evnt = GetEventsById(eventsId);
			evnt.IsDelete = true;
			_context.Update(evnt);
			_context.SaveChanges();
		}

		public AfterStatusViewModel GetAfterStatusForShow(int eventsId)
		{
			return _context.Events.Where(e => e.EventsId == eventsId).Select(e => new AfterStatusViewModel()
			{
				AfterOperatingModes = e.AfterOperatingModes,
				AfterEffectiveWorkingDays = e.AfterEffectiveWorkingDays,
				AfterPressureWater = e.AfterPressureWater,
				AfterPressureinFirstCircuit = e.AfterPressureinFirstCircuit,
				AfterPressureinSecondCircuit = e.AfterPressureinSecondCircuit,
				AfterElectricalPower = e.AfterElectricalPower,
				AfterVaccuminCondensor = e.AfterVaccuminCondensor,
				AfterHeatPower = e.AfterHeatPower,
				EventsId = e.EventsId
			}).Single();
		}

		public List<Events> GetAllEvents(int mechanicalId)
		{
			return _context.Events.Where(e => e.IsDelete == false && e.MechanicalId == mechanicalId).ToList();
		}

		public BeforeStatusViewModel GetBeforStatusForShow(int eventsId)
		{
			return _context.Events.Where(e => e.EventsId == eventsId).Select(e => new BeforeStatusViewModel()
			{
				EventsId = e.EventsId,
				BeforeOperatingModes = e.BeforeOperatingModes,
				BeforeHeatPower = e.BeforeHeatPower,
				BeforePressureWater = e.BeforePressureWater,
				BeforePressureinFirstCircuit = e.BeforePressureinFirstCircuit,
				BeforePressureinSecondCircuit = e.BeforePressureinSecondCircuit,
				BeforeVaccuminCondensor = e.BeforeVaccuminCondensor,
				BeforeEffectiveWorkingDays = e.BeforeEffectiveWorkingDays,
				BeforeElectricalPower = e.BeforeElectricalPower
			}).Single();
		}

		public Events GetEventsById(int eventsId)
		{
			return _context.Events.Find(eventsId);
		}

		public void UpdateEvents(Events events, IFormFile imgEvents)
		{
			events.CreateDate = DateTime.Now;

			if (imgEvents != null)
			{
				if (events.EventsImage != null)
				{
					string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", events.EventsImage);
					if (File.Exists(deleteimagePath))
					{
						File.Delete(deleteimagePath);
					}

				}

				events.EventsImage = Guid.NewGuid() + Path.GetExtension(imgEvents.FileName);
				string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", events.EventsImage);

				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					imgEvents.CopyTo(stream);
				}
			}

			_context.Update(events);
			_context.SaveChanges();
		}

		public void AfterStatusEvents(AfterStatusViewModel afterEvents, int eventsId)
		{
			var afterEvnt = GetEventsById(eventsId);
			afterEvnt.AfterOperatingModes = afterEvents.AfterOperatingModes;
			afterEvnt.AfterHeatPower = afterEvents.AfterPressureWater;
			afterEvnt.AfterElectricalPower = afterEvents.AfterElectricalPower;
			afterEvnt.AfterEffectiveWorkingDays = afterEvents.AfterEffectiveWorkingDays;
			afterEvnt.AfterPressureWater = afterEvents.AfterPressureWater;
			afterEvnt.AfterPressureinFirstCircuit = afterEvents.AfterPressureinFirstCircuit;
			afterEvnt.AfterPressureinSecondCircuit = afterEvents.AfterPressureinSecondCircuit;
			afterEvnt.AfterVaccuminCondensor = afterEvents.AfterVaccuminCondensor;

			_context.Update(afterEvnt);
			_context.SaveChanges();
		}

		public void BeforeStatusEvents(BeforeStatusViewModel beforeEvents, int eventsId)
		{
			var beforeEvnt = GetEventsById(eventsId);
			beforeEvnt.BeforeOperatingModes = beforeEvents.BeforeOperatingModes;
			beforeEvnt.BeforeHeatPower = beforeEvents.BeforeHeatPower;
			beforeEvnt.BeforeElectricalPower = beforeEvents.BeforeElectricalPower;
			beforeEvnt.BeforeEffectiveWorkingDays = beforeEvents.BeforeEffectiveWorkingDays;
			beforeEvnt.BeforePressureWater = beforeEvents.BeforePressureWater;
			beforeEvnt.BeforePressureinFirstCircuit = beforeEvents.BeforePressureinFirstCircuit;
			beforeEvnt.BeforePressureinSecondCircuit = beforeEvents.BeforePressureinSecondCircuit;
			beforeEvnt.BeforeVaccuminCondensor = beforeEvents.BeforeVaccuminCondensor;
			_context.Update(beforeEvnt);
			_context.SaveChanges();
		}

		public List<ExternalEvents> GetAllExternalEvents(int mechanicalId)
		{
			return _context.ExternalEvents.Where(e => e.IsDelete == false && e.MechanicalId == mechanicalId).ToList();
		}

		public int AddExternalEvents(ExternalEvents external, IFormFile imgEvents)
		{
			external.CreateDate = DateTime.Now;

			if (imgEvents != null)
			{
				external.EventsImage = Guid.NewGuid() + Path.GetExtension(imgEvents.FileName);
				string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", external.EventsImage);

				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					imgEvents.CopyTo(stream);
				}
			}

			external.Filename = imgEvents.FileName;

			_context.Add(external);
			_context.SaveChanges();
			return external.ExternalEventsId;
		}

		public void DeleteExternaEvents(int eventsId)
		{
			var evnt = GetExternalEventsById(eventsId);
			evnt.IsDelete = true;
			_context.Update(evnt);
			_context.SaveChanges();
		}

		public ExternalEvents GetExternalEventsById(int eventsId)
		{
			return _context.ExternalEvents.Find(eventsId);
		}

		public void UpdateExternalEvents(ExternalEvents events, IFormFile imgEvents)
		{
			events.CreateDate = DateTime.Now;

			if (imgEvents != null)
			{
				if (events.EventsImage != null)
				{
					string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", events.EventsImage);
					if (File.Exists(deleteimagePath))
					{
						File.Delete(deleteimagePath);
					}

				}

				events.EventsImage = Guid.NewGuid() + Path.GetExtension(imgEvents.FileName);
				string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", events.EventsImage);

				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					imgEvents.CopyTo(stream);
				}
				events.Filename = imgEvents.FileName;
			}

			_context.Update(events);
			_context.SaveChanges();
		}

		public List<RelatedAgeingMechanism> GetAllRelatedAgeingMechanism()
		{
			return _context.RelatedAgeingMechanisms.Where(r => r.IsDelete == false).ToList();

		}

		public List<SelectListItem> GetRelatedAgeingMechanism()
		{
			return _context.RelatedAgeingMechanisms.Where(g => g.IsDelete == false)
				 .Select(g => new SelectListItem()
				 {
					 Text = g.AgeingMechanismTitle,
					 Value = g.AgeingMechanismTitle.ToString()
				 }).ToList();
		}

		public int AddRelatedAgeingMechanism(RelatedAgeingMechanism ageingMechanism)
		{
			ageingMechanism.CreateDate = DateTime.Now;
			_context.Add(ageingMechanism);
			_context.SaveChanges();

			return ageingMechanism.AgeingMechanismId;
		}

		public void DeleteAgeingMechanism(int ageingMechanismId)
		{
			var ageing = GetRelatedAgeingMechanismById(ageingMechanismId);
			ageing.IsDelete = true;
			_context.Update(ageing);
			_context.SaveChanges();
		}

		public RelatedAgeingMechanism GetRelatedAgeingMechanismById(int ageingMechanismId)
		{
			return _context.RelatedAgeingMechanisms.Find(ageingMechanismId);
		}

		public void UpdateRelatedAgeingMechanism(RelatedAgeingMechanism ageingMechanism)
		{
			ageingMechanism.CreateDate = DateTime.Now;
			_context.Update(ageingMechanism);
			_context.SaveChanges();
		}

		public List<ResponsibleUnit> GetAllResponsibleUnit()
		{
			return _context.ResponsibleUnits.Where(r => r.IsDelete == false).ToList();
		}

		public List<SelectListItem> GetResponsibleUnit()
		{
			return _context.ResponsibleUnits.Where(g => g.IsDelete == false)
				.Select(g => new SelectListItem()
				{
					Text = g.ResponsibleUnitTitle,
					Value = g.ResponsibleUnitTitle.ToString()
				}).ToList();
		}

		public int AddResponsibleUnit(ResponsibleUnit responsibleUnit)
		{
			responsibleUnit.CreateDate = DateTime.Now;
			_context.Add(responsibleUnit);
			_context.SaveChanges();

			return responsibleUnit.ResponsibleUnitId;
		}

		public ResponsibleUnit GetResponsibleUnitById(int responsibleId)
		{
			return _context.ResponsibleUnits.Find(responsibleId);
		}

		public void UpdateResponsibleUnit(ResponsibleUnit responsibleUnit)
		{
			responsibleUnit.CreateDate = DateTime.Now;
			_context.Update(responsibleUnit);
			_context.SaveChanges();
		}

		public void DeleteResponsibleUnit(int responsibleUnitId)
		{
			var unit = GetResponsibleUnitById(responsibleUnitId);
			unit.IsDelete = true;
			_context.Update(unit);
			_context.SaveChanges();
		}

		public List<ExternalEventsViewModel> GetAllExternalEventsForExport(int mechanicalId)
		{
			return _context.ExternalEvents.Where(e => e.IsDelete == false&&e.MechanicalId==mechanicalId).Select(c => new ExternalEventsViewModel()
			{
				Description = c.Description,
				EventDate = c.EventDate,
				EventName = c.EventName,
				EventsImage = c.EventsImage,
				Filename = c.Filename,
				NPPName = c.NPPName,
				ReactorType = c.ReactorType,
				RelatedAgeingMechanism = c.RelatedAgeingMechanism,
				ReportCode = c.ReportCode,
				ReportDate = c.ReportDate
			}).ToList();
		}

		public ExternalEventsViewModel GetExternalEventsByIdForExport(int eventId)
		{
			var external = GetExternalEventsById(eventId);
			ExternalEventsViewModel externalEventsViewModel = new ExternalEventsViewModel();
			externalEventsViewModel.Description = external.Description;
			externalEventsViewModel.EventDate = external.EventDate;
			externalEventsViewModel.EventName = external.EventName;
			externalEventsViewModel.EventsImage = external.EventsImage;
			externalEventsViewModel.Filename = external.Filename;
			externalEventsViewModel.NPPName = external.NPPName;
			externalEventsViewModel.ReactorType = external.ReactorType;
			externalEventsViewModel.RelatedAgeingMechanism = external.RelatedAgeingMechanism;
			externalEventsViewModel.ReportCode = external.ReportCode;
			externalEventsViewModel.ReportDate = external.ReportDate;

			return externalEventsViewModel;
		}

		public List<InternalEventsViewModel> GetAllEventsForExport(int mechanicalId)
		{
			return _context.Events.Where(m => m.IsDelete == false&&m.MechanicalId==mechanicalId).Select(c => new InternalEventsViewModel()
			{
				Filename = c.Filename,
				AfterEffectiveWorkingDays = c.AfterEffectiveWorkingDays,
				AfterElectricalPower = c.AfterElectricalPower,
				AfterHeatPower = c.AfterHeatPower,
				AfterOperatingModes = c.AfterOperatingModes,
				AfterPressureinFirstCircuit = c.AfterPressureinFirstCircuit,
				AfterPressureinSecondCircuit = c.AfterPressureinSecondCircuit,
				AfterPressureWater = c.AfterPressureWater,
				AfterVaccuminCondensor = c.AfterVaccuminCondensor,
				BeforeEffectiveWorkingDays = c.BeforeEffectiveWorkingDays,
				BeforeElectricalPower = c.BeforeElectricalPower,
				BeforeHeatPower = c.BeforeHeatPower,
				BeforeOperatingModes = c.BeforeOperatingModes,
				BeforePressureinFirstCircuit = c.BeforePressureinFirstCircuit,
				BeforePressureinSecondCircuit = c.BeforePressureinSecondCircuit,
				BeforePressureWater = c.BeforePressureWater,
				BeforeVaccuminCondensor = c.BeforeVaccuminCondensor,
				Description = c.Description,
				EventDate = c.EventDate,
				EventLevel = c.EventLevel,
				EventLocation = c.EventLocation,
				EventName = c.EventName,
				EventsImage = c.EventsImage,
				EventTime = c.EventTime,
				RelatedAgeingMechanism = c.RelatedAgeingMechanism,
				ReportDate = c.ReportDate,
				ReportNo = c.ReportNo,
				ResponsibleUnit = c.ResponsibleUnit
			}).ToList();
		}

		public InternalEventsViewModel GetEventsByIdForExport(int evenId)
		{
			var eventsd = GetEventsById(evenId);

			InternalEventsViewModel internalEvents = new InternalEventsViewModel();
			internalEvents.Filename = eventsd.Filename;
			internalEvents.AfterEffectiveWorkingDays = eventsd.AfterEffectiveWorkingDays;
			internalEvents.AfterElectricalPower = eventsd.AfterElectricalPower;
			internalEvents.AfterHeatPower = eventsd.AfterHeatPower;
			internalEvents.AfterOperatingModes = eventsd.AfterOperatingModes;
			internalEvents.AfterPressureinFirstCircuit = eventsd.AfterPressureinFirstCircuit;
			internalEvents.AfterPressureinSecondCircuit = eventsd.AfterPressureinSecondCircuit;
			internalEvents.AfterPressureWater = eventsd.AfterPressureWater;
			internalEvents.AfterVaccuminCondensor = eventsd.AfterVaccuminCondensor;
			internalEvents.BeforeEffectiveWorkingDays = eventsd.BeforeEffectiveWorkingDays;
			internalEvents.BeforeElectricalPower = eventsd.BeforeElectricalPower;
			internalEvents.BeforeHeatPower = eventsd.BeforeHeatPower;
			internalEvents.BeforeOperatingModes = eventsd.BeforeOperatingModes;
			internalEvents.BeforePressureinFirstCircuit = eventsd.BeforePressureinFirstCircuit;
			internalEvents.BeforePressureinSecondCircuit = eventsd.BeforePressureinSecondCircuit;
			internalEvents.BeforePressureWater = eventsd.BeforePressureWater;
			internalEvents.BeforeVaccuminCondensor = eventsd.BeforeVaccuminCondensor;
			internalEvents.Description = eventsd.Description;
			internalEvents.EventDate = eventsd.EventDate;
			internalEvents.EventLevel = eventsd.EventLevel;
			internalEvents.EventLocation = eventsd.EventLocation;
			internalEvents.EventName = eventsd.EventName;
			internalEvents.EventsImage = eventsd.EventsImage;
			internalEvents.EventTime = eventsd.EventTime;
			internalEvents.RelatedAgeingMechanism = eventsd.RelatedAgeingMechanism;
			internalEvents.ReportDate = eventsd.ReportDate;
			internalEvents.ReportNo = eventsd.ReportNo;
			internalEvents.ResponsibleUnit = eventsd.ResponsibleUnit;

			return internalEvents;
		}

	}
}
