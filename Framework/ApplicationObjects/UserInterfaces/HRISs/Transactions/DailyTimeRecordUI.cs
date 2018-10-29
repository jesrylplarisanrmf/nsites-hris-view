using JBC_HRIS_Payroll.ApplicationObjects.UserInterfaces.Report.TransactionRpt;
using NSites_V.ApplicationObjects.Classes.HRISs;
using NSites_V.ApplicationObjects.UserInterfaces.Generics;
using NSites_V.ApplicationObjects.UserInterfaces.HRISs.Transactions.Details;
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
    public partial class DailyTimeRecordUI : Form
    {
        Employee loEmployee;
        EmploymentType loEmploymentType;
        DailyTimeRecord loDailyTimeRecord;
        Department loDepartment;
        DataTable ldtDailyTimeRecord;
        DailyTimeRecordRpt loDailyTimeRecordRpt;
        ReportViewerUI loReportViewer;
        TimeLogUI loTimeLog;

        public DailyTimeRecordUI()
        {
            InitializeComponent();
            loEmployee = new Employee();
            loEmploymentType = new EmploymentType();
            loDailyTimeRecord = new DailyTimeRecord();
            loDepartment = new Department();
            ldtDailyTimeRecord = new DataTable();
            loDailyTimeRecordRpt = new DailyTimeRecordRpt();
            loReportViewer = new ReportViewerUI();
        }

        #region "PROPERTIES"
        public Form ParentList
        {
            get;
            set;
        }
        #endregion "END OF PROPERTIES"

        private void refresh(string pSearchString, string pDepartmentId)
        {
            try
            {
                dgvEmployeeList.DataSource = null;
                dgvDailyTimeRecord.DataSource = null;
                DataTable test = loDailyTimeRecord.getEmployeeListByType(cboEmploymentType.SelectedValue.ToString(), pSearchString, pDepartmentId);
                dgvEmployeeList.DataSource = test;
                displayDetails();
            }
            catch { }
        }

        private void displayDetails()
        {
            try
            {
                dgvDailyTimeRecord.DataSource = null;
                ldtDailyTimeRecord = loDailyTimeRecord.getDailyTimeRecordDates(dgvEmployeeList.CurrentRow.Cells[0].Value.ToString(), dtpFrom.Value, dtpTo.Value);
                dgvDailyTimeRecord.DataSource = ldtDailyTimeRecord;

                dgvDailyTimeRecord.Columns[0].Frozen = true;
                dgvDailyTimeRecord.Columns[1].Frozen = true;
                dgvDailyTimeRecord.Columns[2].Frozen = true;
                dgvDailyTimeRecord.Columns[3].Frozen = true;

                dgvDailyTimeRecord.Columns[0].ReadOnly = true;
                dgvDailyTimeRecord.Columns[1].ReadOnly = true;
                dgvDailyTimeRecord.Columns[2].ReadOnly = true;
                dgvDailyTimeRecord.Columns[3].ReadOnly = true;
                dgvDailyTimeRecord.Columns[4].ReadOnly = true;
                dgvDailyTimeRecord.Columns[0].DefaultCellStyle.BackColor = SystemColors.Control;
                dgvDailyTimeRecord.Columns[1].DefaultCellStyle.BackColor = SystemColors.Control;
                dgvDailyTimeRecord.Columns[2].DefaultCellStyle.BackColor = SystemColors.Control;
                dgvDailyTimeRecord.Columns[3].DefaultCellStyle.BackColor = SystemColors.Control;
                dgvDailyTimeRecord.Columns[4].DefaultCellStyle.BackColor = SystemColors.Control;

                dgvDailyTimeRecord.Columns[11].DefaultCellStyle.BackColor = SystemColors.Info;
                dgvDailyTimeRecord.Columns[12].DefaultCellStyle.BackColor = SystemColors.Info;
                dgvDailyTimeRecord.Columns[13].DefaultCellStyle.BackColor = SystemColors.Info;
                dgvDailyTimeRecord.Columns[14].DefaultCellStyle.BackColor = SystemColors.Info;
            }
            catch { }
        }

        private void ProcessDailyTimeRecordRegularUI_Load(object sender, EventArgs e)
        {
            cboEmploymentType.ValueMember = "Id";
            cboEmploymentType.DisplayMember = "Description";
            cboEmploymentType.DataSource = loEmploymentType.getAllData("ViewAll", "", "");
            cboEmploymentType.SelectedIndex = 1;

            cboDepartment.ValueMember = "Id";
            cboDepartment.DisplayMember = "Description";
            cboDepartment.DataSource = loDepartment.getAllData("ViewAll", "", "");
            cboDepartment.SelectedIndex = 4;

            dtpFrom.Value = DateTime.Parse("2018-2-1");
            dtpTo.Value = DateTime.Parse("2018-2-28");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!GlobalFunctions.checkRights("tsmProcessDailyTimeRecord", "Refresh"))
            {
                return;
            }

            cboDepartment.SelectedIndex = -1;
            txtEmployeeName.Clear();
            refresh("", "");
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex >= 0)
            {
                txtEmployeeName.Clear();
                refresh("", cboDepartment.SelectedValue.ToString());
            }
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text != "")
            {
                cboDepartment.SelectedIndex = -1;
                refresh(txtEmployeeName.Text, "");
            }
        }

        private void dgvEmployeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            displayDetails();
        }

        private void dgvEmployeeList_KeyUp(object sender, KeyEventArgs e)
        {
            displayDetails();
        }

        private void dgvDailyTimeRecord_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Late" ||
                this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Undertime" ||
                this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Overtime")
            {
                if (e.Value != null && e.Value.ToString() != "00:00:00")
                {
                    string[] time = e.Value.ToString().Split(':');
                    try
                    {
                        e.Value = time[0] + ":" + time[1];
                    }
                    catch
                    {
                        e.Value = "";
                    }
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    e.Value = "";
                }
            }
            else if (this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Day")
            {
                if (e.Value != null && (e.Value.ToString() == "Saturday" || e.Value.ToString() == "Sunday"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            else if (this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Time In" ||
                this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Break Out" ||
                this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Break In" ||
                this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Time Out")
            {
                if (e.Value != null && e.Value.ToString() == "Day Off")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
            }
            else if (this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Id")
            {
                if (e.Value != null)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else if (this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Working Day" ||
                this.dgvDailyTimeRecord.Columns[e.ColumnIndex].Name == "Days Work")
            {
                if (e.Value != null)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!GlobalFunctions.checkRights("tsmProcessDailyTimeRecord", "Save"))
            {
                return;
            }

            try
            {
                for (int i = 0; i < dgvDailyTimeRecord.Rows.Count; i++)
                {
                    if (dgvDailyTimeRecord.Rows[i].DefaultCellStyle.BackColor == Color.PaleGreen)
                    {
                        loDailyTimeRecord.DailyTimeRecordId = dgvDailyTimeRecord.Rows[i].Cells[0].Value.ToString();
                        loDailyTimeRecord.Date = DateTime.Now;
                        loDailyTimeRecord.EmployeeNo = dgvEmployeeList.CurrentRow.Cells[0].Value.ToString();

                        loDailyTimeRecord.TimeIn = dgvDailyTimeRecord.Rows[i].Cells[5].Value.ToString();
                        loDailyTimeRecord.BreakOut = dgvDailyTimeRecord.Rows[i].Cells[6].Value.ToString();
                        loDailyTimeRecord.BreakIn = dgvDailyTimeRecord.Rows[i].Cells[7].Value.ToString();
                        loDailyTimeRecord.TimeOut = dgvDailyTimeRecord.Rows[i].Cells[8].Value.ToString();
                        loDailyTimeRecord.OvertimeIn = dgvDailyTimeRecord.Rows[i].Cells[9].Value.ToString();
                        loDailyTimeRecord.OvertimeOut = dgvDailyTimeRecord.Rows[i].Cells[10].Value.ToString();

                        /*if (dgvDailyTimeRecord.Rows[i].Cells[11].Value.ToString() != "")
                        {
                            loDailyTimeRecord.WorkingDay = decimal.Parse(dgvDailyTimeRecord.Rows[i].Cells[11].Value.ToString());
                        }
                        else
                        {
                            loDailyTimeRecord.WorkingDay = 0;
                        }
                        if (dgvDailyTimeRecord.Rows[i].Cells[12].Value.ToString() != "")
                        {
                            loDailyTimeRecord.DaysWorkCount = decimal.Parse(dgvDailyTimeRecord.Rows[i].Cells[12].Value.ToString());
                        }
                        else
                        {
                            loDailyTimeRecord.DaysWorkCount = 0;
                        }*/

                        if (dgvDailyTimeRecord.Rows[i].Cells[11].Value.ToString() != "")
                        {
                            loDailyTimeRecord.Late = dgvDailyTimeRecord.Rows[i].Cells[11].Value.ToString();
                        }
                        else
                        {
                            loDailyTimeRecord.Late = "00:00:00";
                        }
                        if (dgvDailyTimeRecord.Rows[i].Cells[12].Value.ToString() != "")
                        {
                            loDailyTimeRecord.Undertime = dgvDailyTimeRecord.Rows[i].Cells[12].Value.ToString();
                        }
                        else
                        {
                            loDailyTimeRecord.Undertime = "00:00:00";
                        }
                        if (dgvDailyTimeRecord.Rows[i].Cells[13].Value.ToString() != "")
                        {
                            loDailyTimeRecord.Overtime = dgvDailyTimeRecord.Rows[i].Cells[13].Value.ToString();
                        }
                        else
                        {
                            loDailyTimeRecord.Overtime = "00:00:00";
                        }

                        loDailyTimeRecord.HoursWork = "00:00:00";
                        loDailyTimeRecord.Remarks = dgvDailyTimeRecord.Rows[i].Cells[14].Value.ToString();
                        loDailyTimeRecord.save(GlobalVariables.Operation.Edit);
                    }
                }

                MessageBoxUI _mb = new MessageBoxUI("Daily Time Record has been saved successfully!", GlobalVariables.Icons.Save, GlobalVariables.Buttons.OK);
                _mb.showDialog();
                displayDetails();
            }
            catch{ }
        }

        private void dgvDailyTimeRecord_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvDailyTimeRecord.CurrentRow.DefaultCellStyle.BackColor = Color.PaleGreen;
            try
            {
                dgvDailyTimeRecord.CurrentRow.Cells[11].Value = string.Format("{0:n}", decimal.Parse(dgvDailyTimeRecord.CurrentRow.Cells[11].Value.ToString()));
            }
            catch
            {
                dgvDailyTimeRecord.CurrentRow.Cells[11].Value = "0.00";
            }
            try
            {
                dgvDailyTimeRecord.CurrentRow.Cells[12].Value = string.Format("{0:n}", decimal.Parse(dgvDailyTimeRecord.CurrentRow.Cells[12].Value.ToString()));
            }
            catch
            {
                dgvDailyTimeRecord.CurrentRow.Cells[12].Value = "0.00";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ParentList.GetType().GetMethod("closeTabPage").Invoke(ParentList, null);
        }

        private void dgvDailyTimeRecord_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point pt = dgvDailyTimeRecord.PointToScreen(e.Location);
                cmsFunction.Show(pt);
            }
        }

        private void tsmiLate4hrs_Click(object sender, EventArgs e)
        {
            dgvDailyTimeRecord.CurrentRow.Cells[11].Value = "04:00:00";
            dgvDailyTimeRecord.CurrentRow.DefaultCellStyle.BackColor = Color.PaleGreen;
        }

        private void tsmiLate8hrs_Click(object sender, EventArgs e)
        {
            dgvDailyTimeRecord.CurrentRow.Cells[11].Value = "08:00:00";
            dgvDailyTimeRecord.CurrentRow.DefaultCellStyle.BackColor = Color.PaleGreen;
        }

        private void tsmiUndertime4hrs_Click(object sender, EventArgs e)
        {
            dgvDailyTimeRecord.CurrentRow.Cells[12].Value = "04:00:00";
            dgvDailyTimeRecord.CurrentRow.DefaultCellStyle.BackColor = Color.PaleGreen;
        }

        private void tsmiUndertime8hrs_Click(object sender, EventArgs e)
        {
            dgvDailyTimeRecord.CurrentRow.Cells[12].Value = "08:00:00";
            dgvDailyTimeRecord.CurrentRow.DefaultCellStyle.BackColor = Color.PaleGreen;
        }

        private void tsmiOpenTime_Click(object sender, EventArgs e)
        {
            try { 
                dgvDailyTimeRecord.CurrentRow.Cells[13].Value = string.Format("{0:HH:mm}", DateTime.Parse(dgvDailyTimeRecord.CurrentRow.Cells[10].Value.ToString()).TimeOfDay.Subtract(DateTime.Parse(dgvDailyTimeRecord.CurrentRow.Cells[9].Value.ToString()).TimeOfDay).ToString());
                dgvDailyTimeRecord.CurrentRow.DefaultCellStyle.BackColor = Color.PaleGreen;
            }catch { }
        }

        private void tsmiOvertime5_Click(object sender, EventArgs e)
        {
            // TODO: Ask Jap about this...
        }

        private void tsmOvertime6_Click(object sender, EventArgs e)
        {
            // TODO: Ask Jap about this...
        }

        /*private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!GlobalFunctions.checkRights("tsmProcessDailyTimeRecord", "Preview"))
            {
                return;
            }
            if (dgvDailyTimeRecord.Rows.Count > 0)
            {
                loDailyTimeRecordRpt.SetDataSource(GlobalVariables.DTCompanyLogo);
                loDailyTimeRecordRpt.Database.Tables[1].SetDataSource(GlobalFunctions.convertDataGridToDataTableDateTime(dgvDailyTimeRecord));
                loDailyTimeRecordRpt.SetParameterValue("CompanyName", GlobalVariables.CompanyName);
                loDailyTimeRecordRpt.SetParameterValue("LGUProvince", GlobalVariables.LGUProvince);
                loDailyTimeRecordRpt.SetParameterValue("CompanyAddress", GlobalVariables.CompanyAddress);
                loDailyTimeRecordRpt.SetParameterValue("CompanyContactNumber", GlobalVariables.CompanyContactNumber);
                loDailyTimeRecordRpt.SetParameterValue("Username", GlobalVariables.Userfullname);
                loDailyTimeRecordRpt.SetParameterValue("Title", "Daily Time Records");
                loDailyTimeRecordRpt.SetParameterValue("SubTitle", "Daily Time Records");
                loDailyTimeRecordRpt.SetParameterValue("EmployeeName", dgvEmployeeList.CurrentRow.Cells[1].Value.ToString());
                loDailyTimeRecordRpt.SetParameterValue("Department", dgvEmployeeList.CurrentRow.Cells[2].Value.ToString());
                loDailyTimeRecordRpt.SetParameterValue("Designation", dgvEmployeeList.CurrentRow.Cells[3].Value.ToString());
                loDailyTimeRecordRpt.SetParameterValue("EmploymentType", "Regular");
                loDailyTimeRecordRpt.SetParameterValue("FromDate", dtpFrom.Value.ToShortDateString());
                loDailyTimeRecordRpt.SetParameterValue("ToDate", dtpTo.Value.ToShortDateString());
                loReportViewer.crystalReportViewer.ReportSource = loDailyTimeRecordRpt;
                loReportViewer.ShowDialog();
            }
        }*/

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void breakOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void breakInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void overtimeInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void overtimeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cboEmploymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDepartment.SelectedIndex = -1;
            txtEmployeeName.Clear();
            refresh("", "");
        }

        private void tsmiChangeShiftSchedule_Click(object sender, EventArgs e)
        {
            ChangeShiftScheduleUI loChangeShiftSchedule = new ChangeShiftScheduleUI(
                dgvEmployeeList.CurrentRow.Cells[0].Value.ToString(),
                dgvEmployeeList.CurrentRow.Cells[1].Value.ToString(),
                DateTime.Parse(dgvDailyTimeRecord.CurrentRow.Cells[1].Value.ToString()), 
                dtpFrom.Value, dtpTo.Value,
                dgvDailyTimeRecord.CurrentRow.Cells[3].Value.ToString()
            );

            loChangeShiftSchedule.ShowDialog();
            if (loChangeShiftSchedule._lFromSave)
            {
                displayDetails();
            }
        }
    }
}
