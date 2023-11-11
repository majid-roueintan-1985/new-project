using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.BasicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services
{
    public class BackupService : IBackupService
    {
        private BnppContext _context;
        public BackupService(BnppContext context)
        {
            _context = context;
        }
        public int AddNewBackup(Backup newbackup)
        {
            newbackup.CreateDate = DateTime.Now;

            _context.Add(newbackup);
            _context.SaveChanges();

            return newbackup.BackupId;
        }

        public void DeleteBackup(int backupId)
        {
            var back = GetBackupById(backupId);
            back.IsDelete = true;
            _context.Update(back);
            _context.SaveChanges();
        }

        public List<Backup> GetAllBackup()
        {
            return _context.Backups.Where(b=>b.IsDelete==false).ToList();
        }

        public Backup GetBackupById(int backupId)
        {
            return _context.Backups.Find(backupId);
        }
    }
}
