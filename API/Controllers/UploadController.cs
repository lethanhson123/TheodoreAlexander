using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{

    public class UploadController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHR_BlockRepository _hR_BlockRepository;
        private readonly IHR_DepartmentRepository _hR_DepartmentRepository;
        private readonly IHR_DistrictRepository _hR_DistrictRepository;
        private readonly IHR_DivisionRepository _hR_DivisionRepository;
        private readonly IHR_DutyRepository _hR_DutyRepository;
        private readonly IHR_Employee_HistoryWorkRepository _hR_Employee_HistoryWorkRepository;
        private readonly IHR_EmployeeRepository _hR_EmployeeRepository;
        private readonly IHR_GroupRepository _hR_GroupRepository;
        private readonly IHR_ProvinceRepository _hR_ProvinceRepository;
        private readonly IHR_StatusRepository _hR_StatusRepository;
        private readonly IHR_TeamRepository _hR_TeamRepository;
        private readonly IHR_WardRepository _hR_WardRepository;
        private readonly IHR_WorkingStatusRepository _hR_WorkingStatusRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItem_StatusRepository _item_StatusRepository;
        private readonly IItem_PriceRepository _item_PriceRepository;
        private readonly IItem_2DfeatureRepository _item_2DfeatureRepository;
        private readonly IItem_3DfeatureRepository _item_3DfeatureRepository;
        private readonly IItem_CareRepository _item_CareRepository;
        private readonly IItem_CenturyRepository _item_CenturyRepository;
        private readonly IItem_ColourAndFinishRepository _item_ColourAndFinishRepository;
        private readonly IItem_GeographyRepository _item_GeographyRepository;
        private readonly IItem_ProcessAndTechniqueRepository _item_ProcessAndTechniqueRepository;
        private readonly IItem_ShapeRepository _item_ShapeRepository;
        private readonly IItem_HistoricalStyleRepository _item_HistoricalStyleRepository;
        private readonly IItem_FabricRepository _item_FabricRepository;
        private readonly IRelatedItemRepository _relatedItemRepository;
        private readonly IRelatedSkuForSpecialGroupRepository _relatedSkuForSpecialGroupRepository;
        private readonly ISKUListingForSizeAvailabilityRepository _sKUListingForSizeAvailabilityRepository;
        public UploadController(IWebHostEnvironment webHostEnvironment
            , IHR_BlockRepository hR_BlockRepository
            , IHR_DepartmentRepository hR_DepartmentRepository
            , IHR_DistrictRepository hR_DistrictRepository
            , IHR_DivisionRepository hR_DivisionRepository
            , IHR_DutyRepository hR_DutyRepository
            , IHR_Employee_HistoryWorkRepository hR_Employee_HistoryWorkRepository
            , IHR_EmployeeRepository hR_EmployeeRepository
            , IHR_GroupRepository hR_GroupRepository
            , IHR_ProvinceRepository hR_ProvinceRepository
            , IHR_StatusRepository hR_StatusRepository
            , IHR_TeamRepository hR_TeamRepository
            , IHR_WardRepository hR_WardRepository
            , IHR_WorkingStatusRepository hR_WorkingStatusRepository
            , IItemRepository itemRepository
            , IItem_StatusRepository item_StatusRepository
            , IItem_PriceRepository item_PriceRepository
            , IItem_2DfeatureRepository item_2DfeatureRepository
            , IItem_3DfeatureRepository item_3DfeatureRepository
            , IItem_CareRepository item_CareRepository
            , IItem_CenturyRepository item_CenturyRepository
            , IItem_ColourAndFinishRepository item_ColourAndFinishRepository
            , IItem_GeographyRepository item_GeographyRepository
            , IItem_ProcessAndTechniqueRepository item_ProcessAndTechniqueRepository
            , IItem_ShapeRepository item_ShapeRepository
            , IItem_HistoricalStyleRepository item_HistoricalStyleRepository
            , IItem_FabricRepository item_FabricRepository
            , IRelatedItemRepository relatedItemRepository
            , IRelatedSkuForSpecialGroupRepository relatedSkuForSpecialGroupRepository
            , ISKUListingForSizeAvailabilityRepository sKUListingForSizeAvailabilityRepository
            ) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _hR_BlockRepository = hR_BlockRepository;
            _hR_DepartmentRepository = hR_DepartmentRepository;
            _hR_DistrictRepository = hR_DistrictRepository;
            _hR_DivisionRepository = hR_DivisionRepository;
            _hR_DutyRepository = hR_DutyRepository;
            _hR_Employee_HistoryWorkRepository = hR_Employee_HistoryWorkRepository;
            _hR_EmployeeRepository = hR_EmployeeRepository;
            _hR_GroupRepository = hR_GroupRepository;
            _hR_ProvinceRepository = hR_ProvinceRepository;
            _hR_StatusRepository = hR_StatusRepository;
            _hR_TeamRepository = hR_TeamRepository;
            _hR_WardRepository = hR_WardRepository;
            _hR_WorkingStatusRepository = hR_WorkingStatusRepository;
            _itemRepository = itemRepository;
            _item_StatusRepository = item_StatusRepository;
            _item_PriceRepository = item_PriceRepository;
            _item_2DfeatureRepository = item_2DfeatureRepository;
            _item_3DfeatureRepository = item_3DfeatureRepository;
            _item_CareRepository = item_CareRepository;
            _item_CenturyRepository = item_CenturyRepository;
            _item_ColourAndFinishRepository = item_ColourAndFinishRepository;
            _item_GeographyRepository = item_GeographyRepository;
            _item_ProcessAndTechniqueRepository = item_ProcessAndTechniqueRepository;
            _item_ShapeRepository = item_ShapeRepository;
            _item_HistoricalStyleRepository = item_HistoricalStyleRepository;
            _item_FabricRepository = item_FabricRepository;
            _relatedItemRepository = relatedItemRepository;
            _relatedSkuForSpecialGroupRepository = relatedSkuForSpecialGroupRepository;
            _sKUListingForSizeAvailabilityRepository = sKUListingForSizeAvailabilityRepository;
        }
        [HttpPost]
        public JsonResult PostEmployeeListByExcelFile()
        {
            string result = AppGlobal.InitializationString;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = "Employee_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                    string pathSub = AppGlobal.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, AppGlobal.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        try
                        {
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                List<HR_Employee> list = new List<HR_Employee>();
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    //HR_Employee employee = new HR_Employee();
                                                    //if (workSheet.Cells[i, 1].Value != null)
                                                    //{
                                                    //    employee.FullName = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                    //}
                                                    //if (workSheet.Cells[i, 2].Value != null)
                                                    //{
                                                    //    employee.Code = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                    //}
                                                    //if (workSheet.Cells[i, 3].Value != null)
                                                    //{
                                                    //    employee.CodeManage = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                    //}
                                                    //if (workSheet.Cells[i, 4].Value != null)
                                                    //{
                                                    //    employee.Address = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                    //}
                                                    //if (workSheet.Cells[i, 5].Value != null)
                                                    //{
                                                    //    employee.AddressContact = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                    //}
                                                    //list.Add(employee);
                                                    try
                                                    {
                                                        HR_Employee employee = new HR_Employee();
                                                        HR_Employee_HistoryWork employeeHistoryWork = new HR_Employee_HistoryWork();
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            employee.Code = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            employee.FullName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 3].Value != null)
                                                        {
                                                            employee.Address = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 4].Value != null)
                                                        {
                                                            employee.AddressContact = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 5].Value != null)
                                                        {
                                                            employee.AddressProvisional = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 6].Value != null)
                                                        {

                                                        }
                                                        if (workSheet.Cells[i, 7].Value != null)
                                                        {
                                                            string date = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                            date = date.Split(' ')[0];
                                                            int year = DateTime.Now.Year;
                                                            int month = 1;
                                                            int day = 1;
                                                            if (date.Split('/').Length > 2)
                                                            {
                                                                year = int.Parse(date.Split('/')[2]);
                                                                month = int.Parse(date.Split('/')[0]);
                                                                day = int.Parse(date.Split('/')[1]);
                                                            }
                                                            else
                                                            {
                                                                year = int.Parse(date.Split('/')[0]);
                                                            }
                                                            employeeHistoryWork.DateJoined = new DateTime(year, month, day);
                                                        }
                                                        if (workSheet.Cells[i, 8].Value != null)
                                                        {
                                                            string date = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                            date = date.Split(' ')[0];
                                                            int year = DateTime.Now.Year;
                                                            int month = 1;
                                                            int day = 1;
                                                            if (date.Split('/').Length > 2)
                                                            {
                                                                year = int.Parse(date.Split('/')[2]);
                                                                month = int.Parse(date.Split('/')[0]);
                                                                day = int.Parse(date.Split('/')[1]);
                                                            }
                                                            else
                                                            {
                                                                year = int.Parse(date.Split('/')[0]);
                                                            }
                                                            employeeHistoryWork.DateLeft = new DateTime(year, month, day);
                                                        }
                                                        if (workSheet.Cells[i, 9].Value != null)
                                                        {
                                                            employeeHistoryWork.DivisionCode = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 10].Value != null)
                                                        {
                                                            employeeHistoryWork.StatusCode = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 11].Value != null)
                                                        {
                                                            employeeHistoryWork.StatusName = workSheet.Cells[i, 11].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 12].Value != null)
                                                        {
                                                            employeeHistoryWork.DepartmentCode = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 13].Value != null)
                                                        {
                                                            employeeHistoryWork.BlockName = workSheet.Cells[i, 13].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 14].Value != null)
                                                        {
                                                            employeeHistoryWork.DepartmentName = workSheet.Cells[i, 14].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 15].Value != null)
                                                        {
                                                            employeeHistoryWork.TeamName = workSheet.Cells[i, 15].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 16].Value != null)
                                                        {
                                                            employeeHistoryWork.GroupName = workSheet.Cells[i, 16].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 17].Value != null)
                                                        {
                                                            employeeHistoryWork.DutyCode = workSheet.Cells[i, 17].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 18].Value != null)
                                                        {
                                                            employeeHistoryWork.DutyName = workSheet.Cells[i, 18].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 19].Value != null)
                                                        {
                                                            employeeHistoryWork.WorkingStatusName = workSheet.Cells[i, 19].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 20].Value != null)
                                                        {
                                                            string date = workSheet.Cells[i, 20].Value.ToString().Trim();
                                                            date = date.Split(' ')[0];
                                                            int year = DateTime.Now.Year;
                                                            int month = 1;
                                                            int day = 1;
                                                            if (date.Split('/').Length > 2)
                                                            {
                                                                year = int.Parse(date.Split('/')[2]);
                                                                month = int.Parse(date.Split('/')[1]);
                                                                day = int.Parse(date.Split('/')[0]);
                                                            }
                                                            else
                                                            {
                                                                year = int.Parse(date.Split('/')[0]);
                                                            }
                                                            employee.BirthDate = new DateTime(year, month, day);
                                                        }
                                                        if (workSheet.Cells[i, 21].Value != null)
                                                        {
                                                            employee.BirthPlace = workSheet.Cells[i, 21].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 22].Value != null)
                                                        {
                                                            employee.BirthNativePlace = workSheet.Cells[i, 22].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 23].Value != null)
                                                        {
                                                            employee.Gender = int.Parse(workSheet.Cells[i, 23].Value.ToString().Trim());
                                                        }
                                                        if (workSheet.Cells[i, 24].Value != null)
                                                        {
                                                            employee.IDCard = workSheet.Cells[i, 24].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 25].Value != null)
                                                        {
                                                            string date = workSheet.Cells[i, 25].Value.ToString().Trim();
                                                            date = date.Split(' ')[0];
                                                            int year = DateTime.Now.Year;
                                                            int month = 1;
                                                            int day = 1;
                                                            if (date.Split('/').Length > 2)
                                                            {
                                                                year = int.Parse(date.Split('/')[2]);
                                                                month = int.Parse(date.Split('/')[1]);
                                                                day = int.Parse(date.Split('/')[0]);
                                                            }
                                                            else
                                                            {
                                                                year = int.Parse(date.Split('/')[0]);
                                                            }
                                                            employee.IDCardDate = new DateTime(year, month, day);
                                                        }
                                                        if (workSheet.Cells[i, 26].Value != null)
                                                        {
                                                            employee.IDCardIssued = workSheet.Cells[i, 26].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 27].Value != null)
                                                        {
                                                            employee.AttendanceCard = workSheet.Cells[i, 27].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 28].Value != null)
                                                        {
                                                            employee.Phone = workSheet.Cells[i, 28].Value.ToString().Trim();
                                                        }

                                                        HR_Division division = _hR_DivisionRepository.GetByCode(employeeHistoryWork.DivisionCode);
                                                        if (division == null)
                                                        {
                                                            division = new HR_Division();
                                                            division.Code = employeeHistoryWork.DivisionCode;
                                                            division.Name = employeeHistoryWork.DivisionCode;
                                                            _hR_DivisionRepository.Add(division);
                                                        }
                                                        if (division.ID > 0)
                                                        {
                                                            employeeHistoryWork.DivisionID = division.ID;
                                                        }

                                                        HR_Status status = _hR_StatusRepository.GetByCode(employeeHistoryWork.StatusCode);
                                                        if (status == null)
                                                        {
                                                            status = new HR_Status();
                                                            status.Code = employeeHistoryWork.StatusCode;
                                                            status.Name = employeeHistoryWork.StatusName;
                                                            _hR_StatusRepository.Add(status);
                                                        }
                                                        if (status.ID > 0)
                                                        {
                                                            employeeHistoryWork.StatusID = status.ID;
                                                        }

                                                        HR_Department department = _hR_DepartmentRepository.GetByCode(employeeHistoryWork.DepartmentCode);
                                                        if (department == null)
                                                        {
                                                            department = new HR_Department();
                                                            department.Code = employeeHistoryWork.DepartmentCode;
                                                            department.Name = employeeHistoryWork.DepartmentName;
                                                            _hR_DepartmentRepository.Add(department);
                                                        }
                                                        if (department.ID > 0)
                                                        {
                                                            employeeHistoryWork.DepartmentID = department.ID;
                                                        }

                                                        HR_Block block = _hR_BlockRepository.GetByName(employeeHistoryWork.BlockName);
                                                        if (block == null)
                                                        {
                                                            block = new HR_Block();
                                                            block.Name = employeeHistoryWork.BlockName;
                                                            _hR_BlockRepository.Add(block);
                                                        }
                                                        if (block.ID > 0)
                                                        {
                                                            employeeHistoryWork.BlockID = block.ID;
                                                        }

                                                        HR_Team team = _hR_TeamRepository.GetByName(employeeHistoryWork.TeamName);
                                                        if (team == null)
                                                        {
                                                            team = new HR_Team();
                                                            team.Name = employeeHistoryWork.TeamName;
                                                            _hR_TeamRepository.Add(team);
                                                        }
                                                        if (team.ID > 0)
                                                        {
                                                            employeeHistoryWork.TeamID = team.ID;
                                                        }

                                                        HR_Group group = _hR_GroupRepository.GetByName(employeeHistoryWork.GroupName);
                                                        if (group == null)
                                                        {
                                                            group = new HR_Group();
                                                            group.Name = employeeHistoryWork.GroupName;
                                                            _hR_GroupRepository.Add(group);
                                                        }
                                                        if (group.ID > 0)
                                                        {
                                                            employeeHistoryWork.GroupID = group.ID;
                                                        }

                                                        HR_Duty duty = _hR_DutyRepository.GetByCode(employeeHistoryWork.DutyCode);
                                                        if (duty == null)
                                                        {
                                                            duty = new HR_Duty();
                                                            duty.Code = employeeHistoryWork.DutyCode;
                                                            duty.Name = employeeHistoryWork.DutyName;
                                                            _hR_DutyRepository.Add(duty);
                                                        }
                                                        if (duty.ID > 0)
                                                        {
                                                            employeeHistoryWork.DutyID = duty.ID;
                                                        }

                                                        HR_WorkingStatus workingStatus = _hR_WorkingStatusRepository.GetByName(employeeHistoryWork.WorkingStatusName);
                                                        if (workingStatus == null)
                                                        {
                                                            workingStatus = new HR_WorkingStatus();
                                                            workingStatus.Name = employeeHistoryWork.WorkingStatusName;
                                                            _hR_WorkingStatusRepository.Add(workingStatus);
                                                        }
                                                        if (workingStatus.ID > 0)
                                                        {
                                                            employeeHistoryWork.GroupID = workingStatus.ID;
                                                        }

                                                        if (string.IsNullOrEmpty(employee.AddressProvisional))
                                                        {
                                                            if (string.IsNullOrEmpty(employee.AddressContact))
                                                            {
                                                                employee.AddressProvisional = employee.Address;
                                                            }
                                                            else
                                                            {
                                                                employee.AddressProvisional = employee.AddressContact;
                                                            }
                                                        }

                                                        if (string.IsNullOrEmpty(employee.AddressContact))
                                                        {
                                                            if (string.IsNullOrEmpty(employee.AddressProvisional))
                                                            {
                                                                employee.AddressContact = employee.Address;
                                                            }
                                                            else
                                                            {
                                                                employee.AddressContact = employee.AddressProvisional;
                                                            }
                                                        }

                                                        if (string.IsNullOrEmpty(employee.Address))
                                                        {
                                                            if (string.IsNullOrEmpty(employee.AddressContact))
                                                            {
                                                                employee.Address = employee.AddressProvisional;
                                                            }
                                                            else
                                                            {
                                                                employee.Address = employee.AddressContact;
                                                            }
                                                        }
                                                        HR_Province province = new HR_Province();
                                                        HR_District district = new HR_District();
                                                        HR_Ward ward = new HR_Ward();

                                                        List<string> listAddress = AppGlobal.SetProvinceAndDistrictAndWard(employee.Address);
                                                        if (listAddress.Count > 0)
                                                        {
                                                            province = _hR_ProvinceRepository.GetByNameContains(listAddress[0]);
                                                            if (province == null)
                                                            {
                                                                province = new HR_Province();
                                                                province.Name = listAddress[0];
                                                                _hR_ProvinceRepository.Add(province);
                                                            }
                                                            if (province.ID > 0)
                                                            {
                                                                employee.IDCardIssuedID = province.ID;
                                                            }
                                                        }

                                                        listAddress = AppGlobal.SetProvinceAndDistrictAndWard(employee.BirthPlace);
                                                        if (listAddress.Count > 0)
                                                        {
                                                            province = _hR_ProvinceRepository.GetByNameContains(listAddress[0]);
                                                            if (province == null)
                                                            {
                                                                province = new HR_Province();
                                                                province.Name = listAddress[0];
                                                                _hR_ProvinceRepository.Add(province);
                                                            }
                                                            if (province.ID > 0)
                                                            {
                                                                employee.BirthPlaceID = province.ID;
                                                            }
                                                        }

                                                        listAddress = AppGlobal.SetProvinceAndDistrictAndWard(employee.BirthNativePlace);
                                                        if (listAddress.Count > 0)
                                                        {
                                                            province = _hR_ProvinceRepository.GetByNameContains(listAddress[0]);
                                                            if (province == null)
                                                            {
                                                                province = new HR_Province();
                                                                province.Name = listAddress[0];
                                                                _hR_ProvinceRepository.Add(province);
                                                            }
                                                            if (province.ID > 0)
                                                            {
                                                                employee.BirthNativePlaceID = province.ID;
                                                            }
                                                        }

                                                        listAddress = AppGlobal.SetProvinceAndDistrictAndWard(employee.AddressContact);
                                                        if (listAddress.Count > 0)
                                                        {
                                                            employee.AddressContactProvince = listAddress[0];
                                                            province = _hR_ProvinceRepository.GetByNameContains(employee.AddressContactProvince);
                                                            if (province == null)
                                                            {
                                                                province = new HR_Province();
                                                                province.Name = employee.AddressContactProvince;
                                                                _hR_ProvinceRepository.Add(province);
                                                            }
                                                            if (province.ID > 0)
                                                            {
                                                                employee.AddressContactProvinceID = province.ID;
                                                            }
                                                        }
                                                        if (listAddress.Count > 1)
                                                        {
                                                            employee.AddressContactDistrict = listAddress[1];
                                                            district = _hR_DistrictRepository.GetByNameContains(employee.AddressContactDistrict);
                                                            if (district == null)
                                                            {
                                                                district = new HR_District();
                                                                district.ParentID = province.ID;
                                                                district.Name = employee.AddressContactDistrict;
                                                                _hR_DistrictRepository.Add(district);
                                                            }
                                                            if (district.ID > 0)
                                                            {
                                                                employee.AddressContactDistrictID = district.ID;
                                                            }
                                                        }
                                                        if (listAddress.Count > 2)
                                                        {
                                                            employee.AddressContactWard = listAddress[2];
                                                            ward = _hR_WardRepository.GetByNameContains(employee.AddressContactWard);
                                                            if (ward == null)
                                                            {
                                                                ward = new HR_Ward();
                                                                ward.ParentID = district.ID;
                                                                ward.Name = employee.AddressContactWard;
                                                                _hR_WardRepository.Add(ward);
                                                            }
                                                            if (ward.ID > 0)
                                                            {
                                                                employee.AddressContactWardID = ward.ID;
                                                            }
                                                        }

                                                        int employeeCheck = _hR_EmployeeRepository.Add(employee);
                                                        if (employeeCheck > 0)
                                                        {
                                                            if (employee.ID > 0)
                                                            {
                                                                employeeHistoryWork.EmployeeID = employee.ID;
                                                                employeeHistoryWork.EmployeeCode = employee.Code;
                                                                List<HR_Employee_HistoryWork> listHR_Employee_HistoryWork = _hR_Employee_HistoryWorkRepository.GetByEmployeeCodeToList(employeeHistoryWork.EmployeeCode);
                                                                if (listHR_Employee_HistoryWork.Count == 0)
                                                                {
                                                                    employeeHistoryWork.Active = true;
                                                                    _hR_Employee_HistoryWorkRepository.Add(employeeHistoryWork);
                                                                }
                                                            }
                                                        }

                                                    }
                                                    catch (Exception e)
                                                    {
                                                        result = e.Message;
                                                    }
                                                }
                                                //List<HR_Employee> listSub = new List<HR_Employee>();
                                                //foreach (HR_Employee item in list)
                                                //{
                                                //    if (!string.IsNullOrEmpty(item.Address))
                                                //    {
                                                //        HR_Employee itemSub001 = new HR_Employee();
                                                //        itemSub001.FullName = item.Address;
                                                //        foreach (HR_Employee itemSub in list)
                                                //        {
                                                //            if (item.Address == itemSub.FullName)
                                                //            {
                                                //                if (item.AddressContact == itemSub.Code)
                                                //                {
                                                //                    itemSub001.CodeManage = itemSub.CodeManage;
                                                //                }
                                                //            }
                                                //        }
                                                //        listSub.Add(itemSub001);
                                                //    }
                                                //}
                                                //try
                                                //{

                                                //    fileName = @"Dai" + AppGlobal.InitializationDateTimeCode + ".xlsx";
                                                //    var streamExport = new MemoryStream();
                                                //    using (var package001 = new ExcelPackage(streamExport))
                                                //    {
                                                //        System.Drawing.Color color = System.Drawing.Color.FromArgb(int.Parse("#c00000".Replace("#", ""), System.Globalization.NumberStyles.AllowHexSpecifier));
                                                //        var workSheet001 = package001.Workbook.Worksheets.Add("Sheet1");
                                                //        int row = 1;
                                                //        int column = 1;
                                                //        workSheet001.Cells[row, column].Value = "Fullname";
                                                //        column = column + 1;
                                                //        workSheet001.Cells[row, column].Value = "SKB";
                                                //        for (int i = 1; i <= column; i++)
                                                //        {
                                                //            workSheet001.Cells[row, i].Style.Font.Bold = true;
                                                //            workSheet001.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                                //            workSheet001.Cells[row, i].Style.Font.Color.SetColor(System.Drawing.Color.White);
                                                //            workSheet001.Cells[row, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                //            workSheet001.Cells[row, i].Style.Fill.BackgroundColor.SetColor(color);
                                                //            workSheet001.Cells[row, i].Style.Font.Name = "Times New Roman";
                                                //            workSheet001.Cells[row, i].Style.Font.Size = 11;
                                                //            workSheet001.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                //            workSheet001.Cells[row, i].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                                                //            workSheet001.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                //            workSheet001.Cells[row, i].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                                                //            workSheet001.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                //            workSheet001.Cells[row, i].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                                                //            workSheet001.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                                //            workSheet001.Cells[row, i].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                                                //        }

                                                //        row = row + 1;
                                                //        int no = 0;
                                                //        foreach (HR_Employee item in listSub)
                                                //        {
                                                //            no = no + 1;
                                                //            workSheet001.Cells[row, 1].Value = item.FullName;
                                                //            workSheet001.Cells[row, 2].Value = item.CodeManage;

                                                //            for (int i = 1; i <= column; i++)
                                                //            {
                                                //                switch (i)
                                                //                {
                                                //                    default:
                                                //                        workSheet001.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                                //                        break;
                                                //                    case 1:
                                                //                        workSheet001.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                                //                        break;
                                                //                }
                                                //                workSheet001.Cells[row, i].Style.Font.Name = "Times New Roman";
                                                //                workSheet001.Cells[row, i].Style.Font.Size = 11;
                                                //                workSheet001.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                //                workSheet001.Cells[row, i].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                                                //                workSheet001.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                //                workSheet001.Cells[row, i].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                                                //                workSheet001.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                //                workSheet001.Cells[row, i].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                                                //                workSheet001.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                                //                workSheet001.Cells[row, i].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                                                //            }
                                                //            row = row + 1;
                                                //        }
                                                //        for (int i = 1; i <= column; i++)
                                                //        {
                                                //            workSheet001.Column(i).AutoFit();
                                                //        }
                                                //        package001.Save();
                                                //    }
                                                //    streamExport.Position = 0;
                                                //    var physicalPathCreate = Path.Combine(_webHostEnvironment.WebRootPath, AppGlobal.Download, fileName);
                                                //    using (var stream001 = new FileStream(physicalPathCreate, FileMode.Create))
                                                //    {
                                                //        streamExport.CopyTo(stream001);
                                                //    }
                                                //    result = AppGlobal.DomainURL + AppGlobal.Download + "/" + fileName;
                                                //}
                                                //catch (Exception e)
                                                //{
                                                //    result = e.Message;
                                                //}
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                        }
                    }
                }
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult PostItemBedInfomationByExcelFile()
        {
            string result = AppGlobal.InitializationString;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = "ItemBedInfomation_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                    string pathSub = AppGlobal.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, AppGlobal.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        try
                        {
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    try
                                                    {
                                                        Item item = new Item();
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            item.SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                            result = result + item.SKU + ";";
                                                        }
                                                        if (workSheet.Cells[i, 42].Value != null)
                                                        {
                                                            try
                                                            {
                                                                item.CMSideAndFrontRailApronClearance = decimal.Parse(workSheet.Cells[i, 42].Value.ToString().Trim());
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                result = e.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 43].Value != null)
                                                        {
                                                            try
                                                            {
                                                                item.CMSlatToTopOfSideRailClearance = decimal.Parse(workSheet.Cells[i, 43].Value.ToString().Trim());
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                result = e.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 44].Value != null)
                                                        {
                                                            try
                                                            {
                                                                item.CMSlatToTopOfFootRailClearance = decimal.Parse(workSheet.Cells[i, 44].Value.ToString().Trim());

                                                            }
                                                            catch (Exception e)
                                                            {
                                                                result = e.Message;
                                                            }
                                                        }
                                                        _itemRepository.UpdateBedInfomationBySQL(item);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        result = e.Message;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                        }
                    }
                }
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult PostItemIsBestSellerByExcelFile()
        {
            string result = AppGlobal.InitializationString;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = "ItemIsBestSeller_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                    string pathSub = AppGlobal.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, AppGlobal.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        try
                        {
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    try
                                                    {
                                                        Item item = new Item();
                                                        item.IsBestSeller = false;
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            item.SKU = workSheet.Cells[i, 1].Value.ToString().Trim();

                                                        }
                                                        if (workSheet.Cells[i, 45].Value != null)
                                                        {
                                                            string isBestSeller = workSheet.Cells[i, 45].Value.ToString().Trim();
                                                            if (isBestSeller == "1")
                                                            {
                                                                item.IsBestSeller = true;
                                                            }
                                                            if (isBestSeller.ToLower() == "true")
                                                            {
                                                                item.IsBestSeller = true;
                                                            }
                                                            if (isBestSeller.ToLower() == "x")
                                                            {
                                                                item.IsBestSeller = true;
                                                            }
                                                        }
                                                        result = result + item.SKU + ";";
                                                        _itemRepository.UpdateIsBestSellerBySQL(item);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        result = e.Message;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                        }
                    }
                }
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult PostItemAdditionalFeaturesByExcelFile()
        {
            string result = AppGlobal.InitializationString;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = "ItemAdditionalFeatures_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                    string pathSub = AppGlobal.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, AppGlobal.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        try
                        {
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    try
                                                    {
                                                        Item item = new Item();
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            item.SKU = workSheet.Cells[i, 1].Value.ToString().Trim();

                                                        }
                                                        if (workSheet.Cells[i, 7].Value != null)
                                                        {
                                                            item.AdditionalFeatures = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                        }
                                                        result = result + item.SKU + ";";
                                                        _itemRepository.UpdateAdditionalFeaturesBySQL(item);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        result = e.Message;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                        }
                    }
                }
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult PostItemProductNameAndExtendedDescriptionByExcelFile()
        {
            string result = AppGlobal.InitializationString;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = "ItemProductNameAndExtendedDescription_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                    string pathSub = AppGlobal.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, AppGlobal.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        try
                        {
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    try
                                                    {
                                                        Item item = new Item();
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            item.SKU = workSheet.Cells[i, 1].Value.ToString().Trim();

                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            item.ProductName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 6].Value != null)
                                                        {
                                                            item.ExtendedDescription = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                        }
                                                        result = result + item.SKU + ";";
                                                        _itemRepository.UpdateProductNameAndExtendedDescriptionBySQL(item);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        result = e.Message;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                        }
                    }
                }
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult PostItemByExcelFile()
        {
            string result = AppGlobal.InitializationString;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = "Item_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                    string pathSub = AppGlobal.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, AppGlobal.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        try
                        {
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 3; i <= totalRows; i++)
                                                {
                                                    try
                                                    {
                                                        ItemDataTransfer item = new ItemDataTransfer();
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            item.SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (!string.IsNullOrEmpty(item.SKU))
                                                        {
                                                            if (workSheet.Cells[i, 2].Value != null)
                                                            {
                                                                item.ProductName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 3].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.Price = decimal.Parse(workSheet.Cells[i, 3].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 4].Value != null)
                                                            {
                                                                item.Story = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 5].Value != null)
                                                            {
                                                                item.VariationDescription = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 6].Value != null)
                                                            {
                                                                item.ExtendedDescription = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 7].Value != null)
                                                            {
                                                                item.AdditionalFeatures = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 8].Value != null)
                                                            {
                                                                item.ParentCode = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 9].Value != null)
                                                            {
                                                                item.DefaultCode = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 10].Value != null)
                                                            {
                                                                item.RoomAndUsageName = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 11].Value != null)
                                                            {
                                                                item.TypeName = workSheet.Cells[i, 11].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 12].Value != null)
                                                            {
                                                                item.BrandName = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 13].Value != null)
                                                            {
                                                                item.DesignerName = workSheet.Cells[i, 13].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 14].Value != null)
                                                            {
                                                                item.CollectionName = workSheet.Cells[i, 14].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 15].Value != null)
                                                            {
                                                                item.LifeStyleName = workSheet.Cells[i, 15].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 16].Value != null)
                                                            {
                                                                item.StyleName = workSheet.Cells[i, 16].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 17].Value != null)
                                                            {
                                                                item.PrimaryMaterialName = workSheet.Cells[i, 17].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 18].Value != null)
                                                            {
                                                                item.SecondaryMaterialName = workSheet.Cells[i, 18].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 19].Value != null)
                                                            {
                                                                item.TertiaryMaterialName = workSheet.Cells[i, 19].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 20].Value != null)
                                                            {
                                                                item.Keywords = workSheet.Cells[i, 20].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 21].Value != null)
                                                            {
                                                                item.OptionGroupName = workSheet.Cells[i, 21].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 22].Value != null)
                                                            {
                                                                item.OptionGroup2Name = workSheet.Cells[i, 22].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 23].Value != null)
                                                            {
                                                                item.OptionGroup3Name = workSheet.Cells[i, 23].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 24].Value != null)
                                                            {
                                                                string hasOtherSizes = workSheet.Cells[i, 24].Value.ToString().Trim();
                                                                if (hasOtherSizes == "0")
                                                                {
                                                                    item.HasOtherSizes = false;
                                                                }
                                                                if (hasOtherSizes == "1")
                                                                {
                                                                    item.HasOtherSizes = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 25].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.CBM = float.Parse(workSheet.Cells[i, 25].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 26].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.Depth = decimal.Parse(workSheet.Cells[i, 26].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 27].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.Width = decimal.Parse(workSheet.Cells[i, 27].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 28].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.Height = decimal.Parse(workSheet.Cells[i, 28].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 29].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.ChairSeatHeight = decimal.Parse(workSheet.Cells[i, 29].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 30].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.ChairArmHeight = decimal.Parse(workSheet.Cells[i, 30].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 31].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.ChairInsideSeatDepth = decimal.Parse(workSheet.Cells[i, 31].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 32].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.ChairInsideSeatWidth = decimal.Parse(workSheet.Cells[i, 32].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 33].Value != null)
                                                            {
                                                                item.MatchingArmOrSideName = workSheet.Cells[i, 33].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 34].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.TableClearance = decimal.Parse(workSheet.Cells[i, 34].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 35].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.TableClosedDepth = decimal.Parse(workSheet.Cells[i, 35].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 36].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.TableClosedWidth = decimal.Parse(workSheet.Cells[i, 36].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 37].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.TableClosedHeight = decimal.Parse(workSheet.Cells[i, 37].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 38].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.TableLeavesCount = int.Parse(workSheet.Cells[i, 38].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 39].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.TableLeavesWidth = decimal.Parse(workSheet.Cells[i, 39].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 40].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.TablesSeatsCountClosed = int.Parse(workSheet.Cells[i, 40].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 41].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.TablesSeatsCountOpen = int.Parse(workSheet.Cells[i, 41].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 42].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.CMSideAndFrontRailApronClearance = decimal.Parse(workSheet.Cells[i, 42].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 43].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.CMSlatToTopOfSideRailClearance = decimal.Parse(workSheet.Cells[i, 43].Value.ToString().Trim());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 44].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.CMSlatToTopOfFootRailClearance = decimal.Parse(workSheet.Cells[i, 44].Value.ToString().Trim());

                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 45].Value != null)
                                                            {
                                                                string isBestSeller = workSheet.Cells[i, 45].Value.ToString().Trim();
                                                                if (isBestSeller == "0")
                                                                {
                                                                    item.IsBestSeller = false;
                                                                }
                                                                if (isBestSeller == "1")
                                                                {
                                                                    item.IsBestSeller = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 46].Value != null)
                                                            {
                                                                string isUpholsteredBack_WoodBack = workSheet.Cells[i, 46].Value.ToString().Trim();
                                                                if (isUpholsteredBack_WoodBack == "0")
                                                                {
                                                                    item.IsUpholsteredBack_WoodBack = false;
                                                                }
                                                                if (isUpholsteredBack_WoodBack == "1")
                                                                {
                                                                    item.IsUpholsteredBack_WoodBack = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 47].Value != null)
                                                            {
                                                                string extending = workSheet.Cells[i, 47].Value.ToString().Trim();
                                                                if (extending == "0")
                                                                {
                                                                    item.Extending = false;
                                                                }
                                                                if (extending == "1")
                                                                {
                                                                    item.Extending = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 48].Value != null)
                                                            {
                                                                string nail = workSheet.Cells[i, 48].Value.ToString().Trim();
                                                                if (nail == "0")
                                                                {
                                                                    item.Nail = false;
                                                                }
                                                                if (nail == "1")
                                                                {
                                                                    item.Nail = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 49].Value != null)
                                                            {
                                                                string uPHFinish = workSheet.Cells[i, 49].Value.ToString().Trim();
                                                                if (uPHFinish == "0")
                                                                {
                                                                    item.UPHFinish = false;
                                                                }
                                                                if (uPHFinish == "1")
                                                                {
                                                                    item.UPHFinish = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 50].Value != null)
                                                            {
                                                                string isNew = workSheet.Cells[i, 50].Value.ToString().Trim();
                                                                if (isNew == "0")
                                                                {
                                                                    item.IsNew = false;
                                                                }
                                                                if (isNew == "1")
                                                                {
                                                                    item.IsNew = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 51].Value != null)
                                                            {
                                                                string isActive = workSheet.Cells[i, 51].Value.ToString().Trim();
                                                                if (isActive == "0")
                                                                {
                                                                    item.IsActive = false;
                                                                }
                                                                if (isActive == "1")
                                                                {
                                                                    item.IsActive = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 52].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item.QuantityMultiplier = int.Parse(workSheet.Cells[i, 52].Value.ToString().Trim());

                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 53].Value != null)
                                                            {
                                                                string isActiveTAUS = workSheet.Cells[i, 53].Value.ToString().Trim();
                                                                if (isActiveTAUS == "0")
                                                                {
                                                                    item.IsActiveTAUS = false;
                                                                }
                                                                if (isActiveTAUS == "1")
                                                                {
                                                                    item.IsActiveTAUS = true;
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 54].Value != null)
                                                            {
                                                                string isActiveINTL = workSheet.Cells[i, 54].Value.ToString().Trim();
                                                                if (isActiveINTL == "0")
                                                                {
                                                                    item.IsActiveINTL = false;
                                                                }
                                                                if (isActiveINTL == "1")
                                                                {
                                                                    item.IsActiveINTL = true;
                                                                }
                                                            }


                                                            Item_Price item_PriceUS = new Item_Price();
                                                            Item_Price item_PriceINTL = new Item_Price();

                                                            item_PriceUS.SKU = item.SKU;
                                                            item_PriceUS.Region = AppGlobal.TAUS.ToLower();
                                                            if (workSheet.Cells[i, 55].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item_PriceUS.Price = decimal.Parse(workSheet.Cells[i, 55].Value.ToString().Trim());

                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }

                                                            item_PriceINTL.SKU = item.SKU;
                                                            item_PriceINTL.Region = AppGlobal.International.ToLower();
                                                            if (workSheet.Cells[i, 56].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    item_PriceINTL.Price = decimal.Parse(workSheet.Cells[i, 56].Value.ToString().Trim());

                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string msg = e.Message;
                                                                }
                                                            }

                                                            result = result + item.SKU + ";";



                                                            string fileNameImage = item.SKU + "_main_1.jpg";
                                                            item.ImageSirv = "https://theodorealexander.sirv.com/ProductPhotos/" + item.SKU.Substring(0, 3) + "/" + fileNameImage;
                                                            item.Image = "https://theodorealexander.com/images/item/" + fileNameImage;

                                                            string ftpUrl = AppGlobal.InitializationString;
                                                            FtpWebRequest requestLIVEFTP;
                                                            byte[] fileContents;
                                                            string subPath = AppGlobal.Images + @"\item";
                                                            var physicalPathCreate = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileNameImage);
                                                            using (WebClient client = new WebClient())
                                                            {
                                                                try
                                                                {
                                                                    client.DownloadFile(new Uri(item.ImageSirv), physicalPathCreate);
                                                                    using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(physicalPathCreate))
                                                                    {
                                                                        image.Mutate(x => x.Resize(AppGlobal.ImageWidth, AppGlobal.ImageHeight));
                                                                        image.Save(physicalPathCreate);

                                                                        ftpUrl = AppGlobal.LIVEFTP + AppGlobal.Images + @"/item/" + fileNameImage;
                                                                        requestLIVEFTP = (FtpWebRequest)WebRequest.Create(ftpUrl);
                                                                        requestLIVEFTP.Method = WebRequestMethods.Ftp.UploadFile;
                                                                        requestLIVEFTP.Credentials = new NetworkCredential(AppGlobal.LIVEFTPUserName, AppGlobal.LIVEFTPPassword);
                                                                        fileContents = System.IO.File.ReadAllBytes(physicalPathCreate);
                                                                        requestLIVEFTP.ContentLength = fileContents.Length;
                                                                        using (Stream requestStream = requestLIVEFTP.GetRequestStream())
                                                                        {
                                                                            requestStream.Write(fileContents, 0, fileContents.Length);
                                                                        }
                                                                    }
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    string mes = e.Message;
                                                                }
                                                            }
                                                            _itemRepository.ItemInsertOrUpdateSingleItemBySQL(item);

                                                            Item_Status item_StatusUS = new Item_Status();
                                                            Item_Status item_StatusINTL = new Item_Status();


                                                            item_StatusUS.Region = AppGlobal.TAUS.ToLower();
                                                            item_StatusUS.SKU = item.SKU;
                                                            item_StatusUS.IsActive = item.IsActiveTAUS;

                                                            item_StatusINTL.Region = AppGlobal.International.ToLower();
                                                            item_StatusINTL.SKU = item.SKU;
                                                            item_StatusINTL.IsActive = item.IsActiveTAUS;

                                                            _item_StatusRepository.InsertBySQL(item_StatusUS);
                                                            _item_StatusRepository.InsertBySQL(item_StatusINTL);

                                                            _item_PriceRepository.InsertBySQL(item_PriceUS);
                                                            _item_PriceRepository.InsertBySQL(item_PriceINTL);
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[2];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_2Dfeature model = new Item_2Dfeature();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.FeatureName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_2DfeatureRepository.Insert001BySQL(SKU, model.FeatureName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[3];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_3Dfeature model = new Item_3Dfeature();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.FeatureName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_3DfeatureRepository.Insert001BySQL(SKU, model.FeatureName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[4];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_Care model = new Item_Care();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.CareName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_CareRepository.Insert001BySQL(SKU, model.CareName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[5];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_Century model = new Item_Century();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.CenturyName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_CenturyRepository.Insert001BySQL(SKU, model.CenturyName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[6];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_ColourAndFinish model = new Item_ColourAndFinish();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.ColourAndFinishName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_ColourAndFinishRepository.Insert001BySQL(SKU, model.ColourAndFinishName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[7];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_Geography model = new Item_Geography();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.GeographyName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_GeographyRepository.Insert001BySQL(SKU, model.GeographyName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[8];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[9];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_ProcessAndTechnique model = new Item_ProcessAndTechnique();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.ProcessAndTechniqueName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_ProcessAndTechniqueRepository.Insert001BySQL(SKU, model.ProcessAndTechniqueName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[10];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_Shape model = new Item_Shape();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.ShapeName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_ShapeRepository.Insert001BySQL(SKU, model.ShapeName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[11];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_HistoricalStyle model = new Item_HistoricalStyle();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.HistoricalStyleName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_HistoricalStyleRepository.Insert001BySQL(SKU, model.HistoricalStyleName);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[12];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    RelatedItem model = new RelatedItem();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            model.Item01SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.Item02SKU = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _relatedItemRepository.Insert001BySQL(model.Item01SKU, model.Item02SKU);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[13];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    RelatedSkuForSpecialGroup model = new RelatedSkuForSpecialGroup();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.SKU = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _relatedSkuForSpecialGroupRepository.Insert001BySQL(SKU, model.SKU);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[14];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    SKUListingForSizeAvailability model = new SKUListingForSizeAvailability();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.SKU = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _sKUListingForSizeAvailabilityRepository.Insert001BySQL(SKU, model.SKU);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[15];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                }
                                            }

                                            workSheet = package.Workbook.Worksheets[16];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string SKU = AppGlobal.InitializationString;
                                                    Item_Fabric model = new Item_Fabric();
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            SKU = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            model.FabricCode = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        _item_FabricRepository.Insert001BySQL(SKU, model.FabricCode);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        string msg = e.Message;
                                                    }
                                                }
                                            }
                                            _itemRepository.UpdateNewSearchTable();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                        }
                    }
                }
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult PostProvinceAndDistrictAndWardListByExcelFile()
        {
            string result = AppGlobal.InitializationString;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = "ProvinceAndDistrictAndWard" + AppGlobal.InitializationDateTimeCode + fileExtension;
                    string pathSub = AppGlobal.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, AppGlobal.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        try
                        {
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    try
                                                    {
                                                        HR_Province province = new HR_Province();
                                                        HR_District district = new HR_District();
                                                        HR_Ward ward = new HR_Ward();
                                                        if (workSheet.Cells[i, 7].Value != null)
                                                        {
                                                            province.Code = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 8].Value != null)
                                                        {
                                                            province.Name = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                        }
                                                        HR_Province provinceAdd = _hR_ProvinceRepository.GetByCode(province.Code);
                                                        if (provinceAdd == null)
                                                        {
                                                            provinceAdd = new HR_Province();
                                                            provinceAdd.Code = province.Code;
                                                            provinceAdd.Name = province.Name;
                                                            _hR_ProvinceRepository.Add(provinceAdd);
                                                        }

                                                        if (workSheet.Cells[i, 5].Value != null)
                                                        {
                                                            district.Code = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 6].Value != null)
                                                        {
                                                            district.Name = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                        }
                                                        HR_District districtAdd = _hR_DistrictRepository.GetByCode(district.Code);
                                                        if (districtAdd == null)
                                                        {
                                                            districtAdd = new HR_District();
                                                            districtAdd.Code = district.Code;
                                                            districtAdd.Name = district.Name;
                                                            if (provinceAdd != null)
                                                            {
                                                                if (provinceAdd.ID > 0)
                                                                {
                                                                    districtAdd.ParentID = provinceAdd.ID;
                                                                    _hR_DistrictRepository.Add(districtAdd);
                                                                }
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 1].Value != null)
                                                        {
                                                            ward.Code = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 2].Value != null)
                                                        {
                                                            ward.Name = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                        }
                                                        HR_Ward wardAdd = _hR_WardRepository.GetByCode(ward.Code);
                                                        if (wardAdd == null)
                                                        {
                                                            wardAdd = new HR_Ward();
                                                            wardAdd.Code = ward.Code;
                                                            wardAdd.Name = ward.Name;
                                                            if (districtAdd != null)
                                                            {
                                                                if (districtAdd.ID > 0)
                                                                {
                                                                    wardAdd.ParentID = districtAdd.ID;
                                                                    _hR_WardRepository.Add(wardAdd);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        result = e.Message;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                        }
                    }
                }
            }
            return Json(result);
        }
    }
}
