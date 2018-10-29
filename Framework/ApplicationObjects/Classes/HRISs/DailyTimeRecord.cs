using NSites_V.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace NSites_V.ApplicationObjects.Classes.HRISs
{
    class DailyTimeRecord
    {
        #region "CONSTRUCTORS"
        public DailyTimeRecord()
        {

        }
        #endregion "END OF CONSTTRUCTORS"

        #region "PROPERTIES"
        public string DailyTimeRecordId
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public string EmployeeNo
        {
            get;
            set;
        }
        public string TimeIn
        {
            get;
            set;
        }
        public string BreakOut
        {
            get;
            set;
        }
        public string BreakIn
        {
            get;
            set;
        }
        public string TimeOut
        {
            get;
            set;
        }
        public string OvertimeIn
        {
            get;
            set;
        }
        public string OvertimeOut
        {
            get;
            set;
        }
        public decimal WorkingDay
        {
            get;
            set;
        }
        public decimal DaysWorkCount
        {
            get;
            set;
        }
        public string Late
        {
            get;
            set;
        }
        public string Undertime
        {
            get;
            set;
        }
        public string Overtime
        {
            get;
            set;
        }
        public string HoursWork
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        #endregion "END OF PROPERTIES"

        #region "METHODS"
        public DataTable getAllData(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/getDepartments?pDisplayType=" + pDisplayType + "&pPrimaryKey=" + pPrimaryKey + "&pSearchString=" + pSearchString + "").Result;
            return response.Content.ReadAsAsync<DataTable>().Result;
        }

        public DataTable getEmployeeListByType(string pEmploymentTypeId, string pSearchString, string pDepartmentId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/getEmployeeListByType?pEmploymentTypeId=" + pEmploymentTypeId + "&pSearchString=" + pSearchString + "&pDepartmentId=" + pDepartmentId + "").Result;
            return response.Content.ReadAsAsync<DataTable>().Result;
        }

        public bool save(GlobalVariables.Operation pOperation)
        {
            bool _status = false;
            try
            {
                switch (pOperation)
                {
                    case GlobalVariables.Operation.Add:
                        HttpClient clientAdd = new HttpClient();
                        clientAdd.BaseAddress = new Uri(GlobalVariables.BaseAddress);
                        HttpResponseMessage responseAdd = clientAdd.PostAsJsonAsync("api/main/insertDepartment/", this).Result;
                        _status = bool.Parse(responseAdd.Content.ReadAsStringAsync().Result);
                        break;
                    case GlobalVariables.Operation.Edit:
                        HttpClient clientEdit = new HttpClient();
                        clientEdit.BaseAddress = new Uri(GlobalVariables.BaseAddress);
                        HttpResponseMessage responseEdit = clientEdit.PostAsJsonAsync("api/main/updateDailyTimeRecord/", this).Result;
                        _status = bool.Parse(responseEdit.Content.ReadAsStringAsync().Result);
                        break;
                    default:
                        break;
                }
            }
            catch{ }
            return _status;
        }

        public DataTable getDailyTimeRecordDates(string pEmployeeNo, DateTime pFromDate, DateTime pToDate)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/getDailyTimeRecordDates?pEmployeeNo=" + pEmployeeNo + "&pFromDate= " + pFromDate.ToString("yyyy-MM-dd") + " &pToDate=" + pToDate.ToString("yyyy-MM-dd") + "").Result;
            return response.Content.ReadAsAsync<DataTable>().Result;
        }

        public DataTable getDailyTimeRecordByDate(string pEmployeeNo, DateTime pFromDate, DateTime pToDate)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/getDailyTimeRecordByDate?pEmployeeNo=" + pEmployeeNo + "&pFromDate=" + pFromDate.ToString("yyyy-MM-dd") + "&pToDate=" + pToDate.ToString("yyyy-MM-dd") + "").Result;
            return response.Content.ReadAsAsync<DataTable>().Result;
        }

        public bool insertTimeIn(string pDailyTimeRecordId, string pTimeIn)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/insertTimeIn?pDailyTimeRecordId=" + pDailyTimeRecordId + "&pTimeIn=" + pTimeIn + "&pUsername=" + GlobalVariables.Username + "&pHostname=" + GlobalVariables.Hostname + "").Result;
            return bool.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public bool insertBreakOut(string pDailyTimeRecordId, string pBreakOut)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/insertBreakOut?pDailyTimeRecordId=" + pDailyTimeRecordId + "&pBreakOut=" + pBreakOut + "&pUsername=" + GlobalVariables.Username + "&pHostname=" + GlobalVariables.Hostname + "").Result;
            return bool.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public bool insertBreakIn(string pDailyTimeRecordId, string pBreakIn)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/insertBreakIn?pDailyTimeRecordId=" + pDailyTimeRecordId + "&pBreakIn=" + pBreakIn + "&pUsername=" + GlobalVariables.Username + "&pHostname=" + GlobalVariables.Hostname + "").Result;
            return bool.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public bool insertTimeOut(string pDailyTimeRecordId, string pTimeOut)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/insertTimeOut?pDailyTimeRecordId=" + pDailyTimeRecordId + "&pTimeOut=" + pTimeOut + "&pUsername=" + GlobalVariables.Username + "&pHostname=" + GlobalVariables.Hostname + "").Result;
            return bool.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public bool insertLate1(string pDailyTimeRecordId, string pLate1)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/insertLate1?pDailyTimeRecordId=" + pDailyTimeRecordId + "&pLate1=" + pLate1 + "&pUsername=" + GlobalVariables.Username + "&pHostname=" + GlobalVariables.Hostname + "").Result;
            return bool.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public bool insertLate2(string pDailyTimeRecordId, string pLate2)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/insertLate2?pDailyTimeRecordId=" + pDailyTimeRecordId + "&pLate2=" + pLate2 + "&pUsername=" + GlobalVariables.Username + "&pHostname=" + GlobalVariables.Hostname + "").Result;
            return bool.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public bool insertUndertime1(string pDailyTimeRecordId, string pUndertime1)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/insertUndertime1?pDailyTimeRecordId=" + pDailyTimeRecordId + "&pUndertime1=" + pUndertime1 + "&pUsername=" + GlobalVariables.Username + "&pHostname=" + GlobalVariables.Hostname + "").Result;
            return bool.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public bool insertUndertime2(string pDailyTimeRecordId, string pUndertime2)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/insertUndertime2?pDailyTimeRecordId=" + pDailyTimeRecordId + "&pUndertime2=" + pUndertime2 + "&pUsername=" + GlobalVariables.Username + "&pHostname=" + GlobalVariables.Hostname + "").Result;
            return bool.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public DataTable updateDTRShiftSchedule(string pEmployeeNo, DateTime pFromDate, DateTime pToDate, string pShiftSchedule)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
            HttpResponseMessage response = client.GetAsync("api/main/updateDTRShiftSchedule?pEmployeeNo=" + pEmployeeNo + "&pFromDate=" + pFromDate.ToString("yyyy-MM-dd") + "&pToDate=" + pToDate.ToString("yyyy-MM-dd") + "&pShiftSchedule=" + pShiftSchedule).Result;
            return response.Content.ReadAsAsync<DataTable>().Result;
        }

        public bool remove(string pId)
        {
            bool _result = false;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalVariables.BaseAddress);
                HttpResponseMessage response = client.GetAsync("api/main/removeDepartment?pId=" + pId + "&pUserId=" + GlobalVariables.UserId).Result;
                _result = bool.Parse(response.Content.ReadAsStringAsync().Result);
            }
            catch { }
            return _result;
        }
        #endregion "END OF METHODS"
    }
}
