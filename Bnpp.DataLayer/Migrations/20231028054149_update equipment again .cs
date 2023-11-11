using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateequipmentagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkingPrograms_MechanicalId",
                table: "WorkingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Standard_MechanicalId",
                table: "Standard");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_MechanicalId",
                table: "SpareParts");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_MechanicalId",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_OperationalDocuments_MechanicalId",
                table: "OperationalDocuments");

            migrationBuilder.DropIndex(
                name: "IX_MechanismDocuments_MechanicalId",
                table: "MechanismDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Mechanism_MechanicalId",
                table: "Mechanism");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_MechanicalId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_MechanicalId",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_MaintenancePrograms_MechanicalId",
                table: "MaintenancePrograms");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceForms_MechanicalId",
                table: "MaintenanceForms");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDocument_MechanicalId",
                table: "MaintenanceDocument");

            migrationBuilder.DropIndex(
                name: "IX_Installation_MechanicalId",
                table: "Installation");

            migrationBuilder.DropIndex(
                name: "IX_InspectionPrograms_MechanicalId",
                table: "InspectionPrograms");

            migrationBuilder.DropIndex(
                name: "IX_HForms_MechanicalId",
                table: "HForms");

            migrationBuilder.DropIndex(
                name: "IX_GeneralData_MechanicalId",
                table: "GeneralData");

            migrationBuilder.DropIndex(
                name: "IX_ExternalEvents_MechanicalId",
                table: "ExternalEvents");

            migrationBuilder.DropIndex(
                name: "IX_Events_MechanicalId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Drawing_MechanicalId",
                table: "Drawing");

            migrationBuilder.DropIndex(
                name: "IX_DesignDocuments_MechanicalId",
                table: "DesignDocuments");

            migrationBuilder.DropIndex(
                name: "IX_DesignData_MechanicalId",
                table: "DesignData");

            migrationBuilder.DropIndex(
                name: "IX_DefectList_MechanicalId",
                table: "DefectList");

            migrationBuilder.DropIndex(
                name: "IX_DefectionReports_MechanicalId",
                table: "DefectionReports");

            migrationBuilder.DropIndex(
                name: "IX_ControlPoints_MechanicalId",
                table: "ControlPoints");

            migrationBuilder.DropIndex(
                name: "IX_Components_MechanicalId",
                table: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Commissioning_MechanicalId",
                table: "Commissioning");

            migrationBuilder.DropIndex(
                name: "IX_ChemicalNorms_MechanicalId",
                table: "ChemicalNorms");

            migrationBuilder.DropIndex(
                name: "IX_ChangeState_MechanicalId",
                table: "ChangeState");

            migrationBuilder.DropIndex(
                name: "IX_Ageing_MechanicalId",
                table: "Ageing");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingPrograms_MechanicalId",
                table: "WorkingPrograms",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Standard_MechanicalId",
                table: "Standard",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_MechanicalId",
                table: "SpareParts",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_MechanicalId",
                table: "Sensors",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationalDocuments_MechanicalId",
                table: "OperationalDocuments",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanismDocuments_MechanicalId",
                table: "MechanismDocuments",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanism_MechanicalId",
                table: "Mechanism",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MechanicalId",
                table: "Measurements",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_MechanicalId",
                table: "Manufacturers",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePrograms_MechanicalId",
                table: "MaintenancePrograms",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceForms_MechanicalId",
                table: "MaintenanceForms",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDocument_MechanicalId",
                table: "MaintenanceDocument",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Installation_MechanicalId",
                table: "Installation",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPrograms_MechanicalId",
                table: "InspectionPrograms",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_HForms_MechanicalId",
                table: "HForms",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralData_MechanicalId",
                table: "GeneralData",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalEvents_MechanicalId",
                table: "ExternalEvents",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MechanicalId",
                table: "Events",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Drawing_MechanicalId",
                table: "Drawing",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignDocuments_MechanicalId",
                table: "DesignDocuments",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignData_MechanicalId",
                table: "DesignData",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectList_MechanicalId",
                table: "DefectList",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectionReports_MechanicalId",
                table: "DefectionReports",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlPoints_MechanicalId",
                table: "ControlPoints",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_MechanicalId",
                table: "Components",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissioning_MechanicalId",
                table: "Commissioning",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalNorms_MechanicalId",
                table: "ChemicalNorms",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeState_MechanicalId",
                table: "ChangeState",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ageing_MechanicalId",
                table: "Ageing",
                column: "MechanicalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkingPrograms_MechanicalId",
                table: "WorkingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Standard_MechanicalId",
                table: "Standard");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_MechanicalId",
                table: "SpareParts");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_MechanicalId",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_OperationalDocuments_MechanicalId",
                table: "OperationalDocuments");

            migrationBuilder.DropIndex(
                name: "IX_MechanismDocuments_MechanicalId",
                table: "MechanismDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Mechanism_MechanicalId",
                table: "Mechanism");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_MechanicalId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_MechanicalId",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_MaintenancePrograms_MechanicalId",
                table: "MaintenancePrograms");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceForms_MechanicalId",
                table: "MaintenanceForms");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDocument_MechanicalId",
                table: "MaintenanceDocument");

            migrationBuilder.DropIndex(
                name: "IX_Installation_MechanicalId",
                table: "Installation");

            migrationBuilder.DropIndex(
                name: "IX_InspectionPrograms_MechanicalId",
                table: "InspectionPrograms");

            migrationBuilder.DropIndex(
                name: "IX_HForms_MechanicalId",
                table: "HForms");

            migrationBuilder.DropIndex(
                name: "IX_GeneralData_MechanicalId",
                table: "GeneralData");

            migrationBuilder.DropIndex(
                name: "IX_ExternalEvents_MechanicalId",
                table: "ExternalEvents");

            migrationBuilder.DropIndex(
                name: "IX_Events_MechanicalId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Drawing_MechanicalId",
                table: "Drawing");

            migrationBuilder.DropIndex(
                name: "IX_DesignDocuments_MechanicalId",
                table: "DesignDocuments");

            migrationBuilder.DropIndex(
                name: "IX_DesignData_MechanicalId",
                table: "DesignData");

            migrationBuilder.DropIndex(
                name: "IX_DefectList_MechanicalId",
                table: "DefectList");

            migrationBuilder.DropIndex(
                name: "IX_DefectionReports_MechanicalId",
                table: "DefectionReports");

            migrationBuilder.DropIndex(
                name: "IX_ControlPoints_MechanicalId",
                table: "ControlPoints");

            migrationBuilder.DropIndex(
                name: "IX_Components_MechanicalId",
                table: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Commissioning_MechanicalId",
                table: "Commissioning");

            migrationBuilder.DropIndex(
                name: "IX_ChemicalNorms_MechanicalId",
                table: "ChemicalNorms");

            migrationBuilder.DropIndex(
                name: "IX_ChangeState_MechanicalId",
                table: "ChangeState");

            migrationBuilder.DropIndex(
                name: "IX_Ageing_MechanicalId",
                table: "Ageing");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingPrograms_MechanicalId",
                table: "WorkingPrograms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Standard_MechanicalId",
                table: "Standard",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_MechanicalId",
                table: "SpareParts",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_MechanicalId",
                table: "Sensors",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationalDocuments_MechanicalId",
                table: "OperationalDocuments",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MechanismDocuments_MechanicalId",
                table: "MechanismDocuments",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mechanism_MechanicalId",
                table: "Mechanism",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MechanicalId",
                table: "Measurements",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_MechanicalId",
                table: "Manufacturers",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePrograms_MechanicalId",
                table: "MaintenancePrograms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceForms_MechanicalId",
                table: "MaintenanceForms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDocument_MechanicalId",
                table: "MaintenanceDocument",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Installation_MechanicalId",
                table: "Installation",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPrograms_MechanicalId",
                table: "InspectionPrograms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HForms_MechanicalId",
                table: "HForms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralData_MechanicalId",
                table: "GeneralData",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalEvents_MechanicalId",
                table: "ExternalEvents",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_MechanicalId",
                table: "Events",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drawing_MechanicalId",
                table: "Drawing",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DesignDocuments_MechanicalId",
                table: "DesignDocuments",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DesignData_MechanicalId",
                table: "DesignData",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefectList_MechanicalId",
                table: "DefectList",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefectionReports_MechanicalId",
                table: "DefectionReports",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlPoints_MechanicalId",
                table: "ControlPoints",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_MechanicalId",
                table: "Components",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commissioning_MechanicalId",
                table: "Commissioning",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalNorms_MechanicalId",
                table: "ChemicalNorms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeState_MechanicalId",
                table: "ChangeState",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ageing_MechanicalId",
                table: "Ageing",
                column: "MechanicalId",
                unique: true);
        }
    }
}
