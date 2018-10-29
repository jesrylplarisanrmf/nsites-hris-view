using NSites_V.ApplicationObjects.Classes.HRISs;
using NSites_V.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSites_V.ApplicationObjects.UserInterfaces.HRISs.Transactions
{
    public partial class ChangeShiftScheduleUI : Form
    {
        string _EmployeeNo;
        string _EmployeeName;
        DateTime _Date;
        DateTime _StarDate;
        DateTime _EndDate;
        string _ShiftSchedule;
        DailyTimeRecord loDailyTimeRecord;
        public bool _lFromSave;

        public ChangeShiftScheduleUI(string pEmployeeNo, string pEmployeeName, DateTime pDate, DateTime pStartDate, DateTime pEndDate, string pShiftSchedule)
        {
            InitializeComponent();
            _EmployeeNo = pEmployeeNo;
            _EmployeeName = pEmployeeName;
            _Date = pDate;
            _StarDate = pStartDate;
            _EndDate = pEndDate;
            _ShiftSchedule = pShiftSchedule;
            loDailyTimeRecord = new DailyTimeRecord();
            _lFromSave = false;
        }

        #region "METHODS"
        //Time In
        private void insertTimeIn(string pDailyTimeRecordId, string pTimeIn)
        {
            bool _status = false;
            _status = loDailyTimeRecord.insertTimeIn(pDailyTimeRecordId, pTimeIn);
        }

        //Break Out
        private void insertBreakOut(string pDailyTimeRecordId, string pTimeOut)
        {
            bool _status = false;
            _status = loDailyTimeRecord.insertBreakOut(pDailyTimeRecordId, pTimeOut);
        }

        //Break In
        private void insertBreakIn(string pDailyTimeRecordId, string pBreakIn)
        {
            bool _status = false;
            _status = loDailyTimeRecord.insertBreakIn(pDailyTimeRecordId, pBreakIn);
        }

        //Time Out
        private void insertTimeOut(string pDailyTimeRecordId, string pTimeOut)
        {
            bool _status = false;
            _status = loDailyTimeRecord.insertTimeOut(pDailyTimeRecordId, pTimeOut);
        }

        //insert Late1
        private void insertLate1(string pDailyTimeRecordId, string pLate1)
        {
            bool _status = false;
            _status = loDailyTimeRecord.insertLate1(pDailyTimeRecordId, pLate1);
        }

        //insert Late2
        private void insertLate2(string pDailyTimeRecordId, string pLate2)
        {
            bool _status = false;
            _status = loDailyTimeRecord.insertLate2(pDailyTimeRecordId, pLate2);
        }

        //insert Undertime1
        private void insertUndertime1(string pDailyTimeRecordId, string pUndertime1)
        {
            bool _status = false;
            _status = loDailyTimeRecord.insertUndertime1(pDailyTimeRecordId, pUndertime1);
        }

        //insert Undertime2
        private void insertUndertime2(string pDailyTimeRecordId, string pUndertime2)
        {
           
            bool _status = false;
            _status = loDailyTimeRecord.insertUndertime2(pDailyTimeRecordId, pUndertime2);
        }
        #endregion

        private void ChangeShiftScheduleUI_Load(object sender, EventArgs e)
        {
            _lFromSave = false;
            txtEmployeeName.Text = _EmployeeName;
            dtpStartDate.Value = _Date;
            dtpEndDate.Value = _Date;
            string[] _shift = _ShiftSchedule.Split(';');
            string _shiftTI = _shift[0];
            string _shiftBO = _shift[1];
            string _shiftBI = _shift[2];
            string _shiftTO = _shift[3];
            string _nextDay = _shift[4].Replace("ND=", "");
            if (_shiftBO == "" || _shiftBI == "")
            {
                chkBreak.Checked = false;
                dtpTimeIn.Value = DateTime.Parse(_shiftTI);
                dtpTimeOut.Value = DateTime.Parse(_shiftTO);
                chkNextDay.Checked = (_nextDay == "Y" ? true : false);
            }
            else
            {
                chkBreak.Checked = true;
                dtpTimeIn.Value = DateTime.Parse(_shiftTI);
                dtpBreakOut.Value = DateTime.Parse(_shiftBO);
                dtpBreakIn.Value = DateTime.Parse(_shiftBI);
                dtpTimeOut.Value = DateTime.Parse(_shiftTO);
                chkNextDay.Checked = (_nextDay == "Y" ? true : false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpStartDate.Value.Date < _StarDate.Date || dtpStartDate.Value.Date > _EndDate.Date)
                {
                    MessageBoxUI _mb = new MessageBoxUI("Start Date must be within Date Range!", GlobalVariables.Icons.Warning, GlobalVariables.Buttons.OK);
                    _mb.showDialog();
                    dtpStartDate.Focus();
                    return;
                }
                if (dtpEndDate.Value.Date > _EndDate.Date || dtpEndDate.Value.Date < _StarDate.Date)
                {
                    MessageBoxUI _mb = new MessageBoxUI("End Date must be within Date Range!", GlobalVariables.Icons.Warning, GlobalVariables.Buttons.OK);
                    _mb.showDialog();
                    dtpEndDate.Focus();
                    return;
                }
                if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
                {
                    MessageBoxUI _mb = new MessageBoxUI("End Date must not be lesser than Start Date!", GlobalVariables.Icons.Warning, GlobalVariables.Buttons.OK);
                    _mb.showDialog();
                    dtpEndDate.Focus();
                    return;
                }
                if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
                {
                    MessageBoxUI _mb = new MessageBoxUI("Start Date must not be greater than End Date!", GlobalVariables.Icons.Warning, GlobalVariables.Buttons.OK);
                    _mb.showDialog();
                    dtpStartDate.Focus();
                    return;
                }
                string _shiftSchedule = "";
                if (chkBreak.Checked)
                {
                    _shiftSchedule = string.Format("{0:hh:mm tt}", dtpTimeIn.Value) + ";" +
                        string.Format("{0:hh:mm tt}", dtpBreakOut.Value) + ";" +
                        string.Format("{0:hh:mm tt}", dtpBreakIn.Value) + ";" +
                        string.Format("{0:hh:mm tt}", dtpTimeOut.Value) + ";ND=" +
                        (chkNextDay.Checked ? "Y" : "N");
                }
                else
                {
                    _shiftSchedule = string.Format("{0:hh:mm tt}", dtpTimeIn.Value) + ";;;" +
                        string.Format("{0:hh:mm tt}", dtpTimeOut.Value) + ";ND=" +
                        (chkNextDay.Checked ? "Y" : "N");
                }

                loDailyTimeRecord.updateDTRShiftSchedule(_EmployeeNo, dtpStartDate.Value, dtpEndDate.Value, _shiftSchedule);

                #region "UPDATE DTR TI,BO,BI,TO"
                foreach (DataRow _drDTR in loDailyTimeRecord.getDailyTimeRecordByDate(_EmployeeNo, dtpStartDate.Value, dtpEndDate.Value).Rows)
                {
                    try
                    {
                        if (_drDTR["RawDTR"].ToString() != "")
                        {
                            string[] _dtr = _drDTR["RawDTR"].ToString().Split(';');
                            foreach (string dtr in _dtr)
                            {
                                string[] _shift = _drDTR["ShiftSchedule"].ToString().Split(';');
                                string _shiftTI = "";
                                string _shiftBO = "";
                                string _shiftBI = "";
                                string _shiftTO = "";
                                try
                                {
                                    _shiftTI = _shift[0];
                                    _shiftBO = _shift[1];
                                    _shiftBI = _shift[2];
                                    _shiftTO = _shift[3];
                                }
                                catch
                                {
                                    continue;
                                }

                                if (dtr != "")
                                {
                                    string[] _raw = dtr.Split('=');
                                    if (_raw[0].ToString() == "TI")
                                    {
                                        insertTimeIn(_drDTR["DailyTimeRecordId"].ToString(), _raw[1].ToString());

                                        string _late1 = "00:00";
                                        try
                                        {
                                            _late1 = string.Format("{0:HH:mm}", DateTime.Parse(DateTime.Parse(_raw[1].ToString()).TimeOfDay.Subtract(DateTime.Parse(_shiftTI).TimeOfDay).ToString()));
                                        }
                                        catch
                                        {
                                            _late1 = "00:00";
                                        }
                                        if (_late1 != "00:00")
                                        {
                                            insertLate1(_drDTR["DailyTimeRecordId"].ToString(), _late1);
                                        }
                                    }
                                    else if (_raw[0].ToString() == "BO")
                                    {
                                        insertBreakOut(_drDTR["DailyTimeRecordId"].ToString(), _raw[1].ToString());

                                        string _undertime1 = "00:00";
                                        try
                                        {
                                            _undertime1 = string.Format("{0:HH:mm}", DateTime.Parse(DateTime.Parse(_shiftBO).TimeOfDay.Subtract(DateTime.Parse(_raw[1].ToString()).TimeOfDay).ToString()));
                                        }
                                        catch
                                        {
                                            _undertime1 = "00:00";
                                        }

                                        if (_undertime1 != "00:00")
                                        {
                                            insertUndertime1(_drDTR["DailyTimeRecordId"].ToString(), _undertime1);
                                        }
                                    }
                                    else if (_raw[0].ToString() == "BI")
                                    {
                                        /*if (_drDTR["BreakIn"].ToString() == "")
                                        {
                                            foreach (DataRow _drEmpDTR in loDailyTimeRecord.getDailyTimeRecord(_EmployeeNo, DateTime.Parse(_drDTR["Date"].ToString())).Rows)
                                            {
                                                if (_drEmpDTR["BreakIn"].ToString() == "")
                                                {*/
                                                    insertBreakIn(_drDTR["DailyTimeRecordId"].ToString(), _raw[1].ToString());

                                                    string _late2 = "00:00";
                                                    try
                                                    {
                                                        _late2 = string.Format("{0:HH:mm}", DateTime.Parse(DateTime.Parse(_raw[1].ToString()).TimeOfDay.Subtract(DateTime.Parse(_shiftBI).TimeOfDay).ToString()));
                                                    }
                                                    catch
                                                    {
                                                        _late2 = "00:00";
                                                    }
                                                    if (_late2 != "00:00")
                                                    {
                                                        insertLate2(_drDTR["DailyTimeRecordId"].ToString(), _late2);
                                                    }
                                                /*}
                                            }
                                        }*/
                                    }
                                    else if (_raw[0].ToString() == "TO")
                                    {
                                        insertTimeOut(_drDTR["DailyTimeRecordId"].ToString(), _raw[1].ToString());

                                        string _undertime2 = "00:00";
                                        try
                                        {
                                            _undertime2 = string.Format("{0:HH:mm}", DateTime.Parse(DateTime.Parse(_shiftTO).TimeOfDay.Subtract(DateTime.Parse(_raw[1].ToString()).TimeOfDay).ToString()));
                                        }
                                        catch
                                        {
                                            _undertime2 = "00:00";
                                        }
                                        if (_undertime2 != "00:00")
                                        {
                                            insertUndertime2(_drDTR["DailyTimeRecordId"].ToString(), _undertime2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                #endregion ""

                _lFromSave = true;

                MessageBoxUI _mb1 = new MessageBoxUI("Shift Schedule has been successfully changed!", GlobalVariables.Icons.Save, GlobalVariables.Buttons.OK);
                _mb1.showDialog();
                this.Close();
            }
            catch { }


        }

        private void chkBreak_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBreak.Checked)
            {
                dtpBreakIn.Visible = true;
                dtpBreakOut.Visible = true;
            }
            else
            {
                dtpBreakIn.Visible = false;
                dtpBreakOut.Visible = false;
            }
        }
    }
}
