using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.BasicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IBackupService
    {
        int AddNewBackup(Backup newbackup);
        List<Backup> GetAllBackup();
        void DeleteBackup(int backupId);
        Backup GetBackupById(int backupId);
    }
}
