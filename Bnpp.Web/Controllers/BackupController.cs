using Bnpp.Core.Services;
using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.IO.Pipes;




namespace Bnpp.Web.Controllers
{
	public class BackupController : Controller
	{
		private IWebHostEnvironment _env;
		private IBackupService _backupService;
		private IConfiguration Configuration;
		public BackupController(IWebHostEnvironment env, IBackupService backupService, IConfiguration _configuration)
		{
			Configuration = _configuration;
			_env = env;
			_backupService = backupService;
		}



		[HttpPost]
		public void BackupDatabase(string databaseName)
		{
			string filePath = BuildBackupPathWithFilename(databaseName);

			//Connect to DB
			SqlConnection connect;
			string con = this.Configuration.GetConnectionString("BnppConnection");
			connect = new SqlConnection(con);
			connect.Open();
			//----------------------------------------------------------------------------------------------------

			//Execute SQL---------------
			SqlCommand command;
			command = new SqlCommand(@"BACKUP DATABASE bnppDBNew TO DISK = '" + filePath + "';", connect);
			command.ExecuteNonQuery();
			//-------------------------------------------------------------------------------------------------------------------------------

			connect.Close();

		}

		private string BuildBackupPathWithFilename(string databaseName)
		{

			string filename = string.Format("backupdatabase_{0}-{1}.bak", databaseName, DateTime.Now.ToString("yyyy-MM-dd-mm"));
			var UploadsRootFolder = Path.Combine(_env.WebRootPath, "BackupDatabase");
			//var UploadsRootFolder = "C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQL2019\\MSSQL\\Backup";

			if (!Directory.Exists(UploadsRootFolder))
				Directory.CreateDirectory(UploadsRootFolder);
			return Path.Combine(UploadsRootFolder, filename);
		}

		[Route("Backup")]
		public IActionResult Index()
		{
			return View(_backupService.GetAllBackup());
		}

		[Route("Restore")]
		public IActionResult RestoreDatabase()
		{
			return View(_backupService.GetAllBackup());
		}

		public IActionResult CreateBackup(string bnppDBNew)
		{
			BuildBackupPathWithFilename(bnppDBNew);
			BackupDatabase(bnppDBNew);

			Backup myBack = new Backup();
			myBack.CreateDate = DateTime.Now;
			myBack.Name = string.Format("backupdatabase_{0}-{1}.bak", bnppDBNew, DateTime.Now.ToString("yyyy-MM-dd-mm"));
			_backupService.AddNewBackup(myBack);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult DeleteBackup(string[] backupsId)
		{
			foreach (string id in backupsId)
			{
				_backupService.DeleteBackup(Convert.ToInt32(id));
			}

			return Json(" Backup Successfully Deleted.");
		}

		//public IActionResult CreateRestore()
		//{

		//	//Connect SQL-----------
		//	SqlConnection connect;
			
		//	string con = this.Configuration.GetConnectionString("BnppConnection");
		//	connect = new SqlConnection(con);
		//	connect.Open();
		//	//-----------------------------------------------------------------------------------------

		//	//Excute SQL----------------
		//	SqlCommand command;
		//	command = new SqlCommand("use master", connect);
		//	command.ExecuteNonQuery();
		//	//command = new SqlCommand(@"restore database  FROM disk = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\Backup\bnppDBNew.bak' WITH REPLACE", connect);
		//	//command = new SqlCommand(@"restore database [bnppDBNew] FROM disk = 'C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\wwwroot\BackupDatabase\backupdatabase2023110159.bak' WITH REPLACE", connect); SET Single_User WITH Rollback Immediate

		//	command = new SqlCommand(@"restore database [bnppDBNew] FROM disk = 'C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\wwwroot\BackupDatabase\bnppDBNew.bak' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10", connect);
		//	command.ExecuteNonQuery();
		//	//--------------------------------------------------------------------------------------------------------
		//	connect.Close();

		//	return Content("Restore Database is Successfully Done!");
		//}



		public IActionResult Restore(string ConnectionString, string backupName)
		{
			
			string name = backupName.ToString();
			string backUpPath = this.Configuration.GetSection("appSettings")["backUpPath"] + name;
			string conection = this.Configuration.GetConnectionString("BnppConnection");
			SqlConnection con = new SqlConnection(conection);
			con.Open();

			string UseMaster = "USE master";
			SqlCommand UseMasterCommand = new SqlCommand(UseMaster, con);
			UseMasterCommand.ExecuteNonQuery();

			string Alter1 = @"ALTER DATABASE [bnppDBNew ] SET Single_User WITH Rollback Immediate";
			SqlCommand Alter1Cmd = new SqlCommand(Alter1, con);
			Alter1Cmd.ExecuteNonQuery();

			string Restore = @"RESTORE DATABASE [bnppDBNew] FROM DISK = N'" + backUpPath + @"' WITH REPLACE, FILE = 1,  NOUNLOAD,  STATS = 10";
			SqlCommand RestoreCmd = new SqlCommand(Restore, con);
			RestoreCmd.ExecuteNonQuery();

			string Alter2 = @"ALTER DATABASE [bnppDBNew] SET Multi_User";
			SqlCommand Alter2Cmd = new SqlCommand(Alter2, con);
			Alter2Cmd.ExecuteNonQuery();

			return RedirectToAction("index");


		}


		//Download
		[HttpPost]

		public IActionResult DownloadFile(int episodeId)
		{
			var episode = _backupService.GetBackupById(episodeId);
			string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BackupDatabase",
				episode.Name);
			string fileName = episode.Name;

			byte[] file = System.IO.File.ReadAllBytes(filepath);
			return File(file, "application/force-download", fileName);

		}

	}
}

