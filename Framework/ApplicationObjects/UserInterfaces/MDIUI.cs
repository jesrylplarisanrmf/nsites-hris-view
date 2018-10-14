using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Xml;
using System.Net;

using NSites_V.Global;
using NSites_V.ApplicationObjects.Classes;
using NSites_V.ApplicationObjects.Classes.Systems;
using NSites_V.ApplicationObjects.Classes.HRISs;
using NSites_V.ApplicationObjects.Classes.Payrolls;

using NSites_V.ApplicationObjects.UserInterfaces;
using NSites_V.ApplicationObjects.UserInterfaces.Generics;

using NSites_V.ApplicationObjects.UserInterfaces.HRISs;
using NSites_V.ApplicationObjects.UserInterfaces.HRISs.Masterfiles;
//using NSites_V.ApplicationObjects.UserInterfaces.HRISs.Reports;
using NSites_V.ApplicationObjects.UserInterfaces.Payrolls;
using NSites_V.ApplicationObjects.UserInterfaces.Payrolls.Masterfiles;
using NSites_V.ApplicationObjects.UserInterfaces.Systems;
using NSites_V.ApplicationObjects.UserInterfaces.Systems.Masterfiles;
using NSites_V.ApplicationObjects.UserInterfaces.Systems.Reports;

namespace NSites_V.ApplicationObjects.UserInterfaces
{
    public partial class MDINSites_VUI : Form
    {
        #region "VARIABLES"
        UserGroup loUserGroup;
        DataView ldvUserGroup;
        DataTable ldtUserGroup;
        SystemConfiguration loSystemConfiguration;
        #endregion "END OF VARIABLES"

        #region "CONSTRUCTORS"
        public MDINSites_VUI()
        {
            InitializeComponent();
            loUserGroup = new UserGroup();
            ldtUserGroup = new DataTable();
            loSystemConfiguration = new SystemConfiguration();
        }
        #endregion "END OF CONSTRUCTORS"

        #region "METHODS"
        private void disabledMenuStrip()
        {
            try
            {
                foreach (ToolStripMenuItem item in mnsNSites_V.Items)
                {
                    item.Enabled = false;
                    foreach (ToolStripItem subitem in item.DropDownItems)
                    {
                        if (subitem is ToolStripMenuItem)
                        {
                            subitem.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void enabledMenuStrip()
        {
            try
            {
                ldtUserGroup = loUserGroup.getUserGroupMenuItems();

                GlobalVariables.DVRights = new DataView(loUserGroup.getUserGroupRights());
                ldvUserGroup = new DataView(ldtUserGroup);
                foreach (ToolStripMenuItem item in mnsNSites_V.Items)
                {
                    try
                    {
                        ldvUserGroup.RowFilter = "Menu = '" + item.Name + "'";
                    }
                    catch { }
                    if (ldvUserGroup.Count != 0)
                    {
                        item.Enabled = true;
                        processMenuItems(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void processMenuItems(ToolStripMenuItem pitem)
        {
            try
            {
                if (true)
                {
                    pitem.Enabled = true;
                }

                foreach (ToolStripItem subitem in pitem.DropDownItems)
                {
                    if (subitem is ToolStripMenuItem)
                    {
                        ldvUserGroup.RowFilter = "Item = '" + subitem.Name + "'";
                        if (ldvUserGroup.Count != 0)
                        {
                            subitem.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int displayControlOnTab(Control pControl, TabPage pTabPage)
        {
            try
            {
                // The tabpage.
                Form _FormControl = new Form();
                _FormControl = (Form)pControl;

                // Add to the tab control.
                pTabPage.Text = _FormControl.Text;
                pTabPage.Name = _FormControl.Name;
                tbcNSites_V.TabPages.Add(pTabPage);
                tbcNSites_V.SelectTab(pTabPage);
                _FormControl.TopLevel = false;
                _FormControl.Parent = this;
                _FormControl.Dock = DockStyle.Fill;
                _FormControl.FormBorderStyle = FormBorderStyle.None;
                pTabPage.Controls.Add(_FormControl);
                tbcNSites_V.SelectTab(tbcNSites_V.SelectedIndex);
                _FormControl.Show();
                return tbcNSites_V.SelectedIndex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void closeTabPage()
        {
            try
            {
                tbcNSites_V.TabPages.RemoveAt(tbcNSites_V.SelectedIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void changeHomeImage()
        {
            try
            {
                try
                {
                    byte[] hextobyte = GlobalFunctions.HexToBytes(GlobalVariables.ScreenSaverImage);
                    pctScreenSaver.BackgroundImage = GlobalFunctions.ConvertByteArrayToImage(hextobyte);
                    pctScreenSaver.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch
                {
                    pctScreenSaver.BackgroundImage = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void getGlobalVariablesData()
        {
            try
            {
                foreach (DataRow _drSystemConfig in loSystemConfiguration.getAllData().Rows)
                {
                    if (_drSystemConfig["Key"].ToString() == "CompanyLogo")
                    {
                        GlobalVariables.CompanyLogo = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "ReportLogo")
                    {
                        GlobalVariables.ReportLogo = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "DisplayRecordLimit")
                    {
                        GlobalVariables.DisplayRecordLimit = int.Parse(_drSystemConfig["Value"].ToString());
                    }
                    else if (_drSystemConfig["Key"].ToString() == "EmailAddress")
                    {
                        GlobalVariables.EmailAddress = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "EmailPassword")
                    {
                        GlobalVariables.EmailPassword = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "CurrentFinancialYear")
                    {
                        GlobalVariables.CurrentFinancialYear = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "ReviewedBy")
                    {
                        GlobalVariables.ReviewedBy = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "ApprovedBy")
                    {
                        GlobalVariables.ApprovedBy = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "SODebitAccount")
                    {
                        GlobalVariables.SODebitAccount = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "SOCreditAccount")
                    {
                        GlobalVariables.SOCreditAccount = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "PODebitAccount")
                    {
                        GlobalVariables.PODebitAccount = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "POCreditAccount")
                    {
                        GlobalVariables.POCreditAccount = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "CRDebitAccount")
                    {
                        GlobalVariables.CRDebitAccount = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "CRCreditAccount")
                    {
                        GlobalVariables.CRCreditAccount = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "CDDebitAccount")
                    {
                        GlobalVariables.CDDebitAccount = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "CDCreditAccount")
                    {
                        GlobalVariables.CDCreditAccount = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "CashierPeriodDebit")
                    {
                        GlobalVariables.CashierPeriodDebit = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "CashierPeriodCredit")
                    {
                        GlobalVariables.CashierPeriodCredit = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "RetainedEarningsCode")
                    {
                        GlobalVariables.RetainedEarningsCode = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "IncomeAndExpenseSummaryCode")
                    {
                        GlobalVariables.IncomeAndExpenseSummaryCode = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "AssetClassificationCode")
                    {
                        GlobalVariables.AssetClassificationCode = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "LiabilityClassificationCode")
                    {
                        GlobalVariables.LiabilityClassificationCode = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "EquityClassificationCode")
                    {
                        GlobalVariables.EquityClassificationCode = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "IncomeClassificationCode")
                    {
                        GlobalVariables.IncomeClassificationCode = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "ExpensesClassificationCode")
                    {
                        GlobalVariables.ExpensesClassificationCode = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "IncomeAndExpenseSummaryClassificationCode")
                    {
                        GlobalVariables.IncomeAndExpenseSummaryClassificationCode = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "OverridePassword")
                    {
                        GlobalVariables.OverridePassword = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "ScreenSaverImage")
                    {
                        GlobalVariables.ScreenSaverImage = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "MDITabAlignment")
                    {
                        GlobalVariables.TabAlignment = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "BackupMySqlDumpAddress")
                    {
                        GlobalVariables.BackupMySqlDumpAddress = _drSystemConfig["Value"].ToString();
                    }
                    else if (_drSystemConfig["Key"].ToString() == "RestoreMySqlAddress")
                    {
                        GlobalVariables.RestoreMySqlAddress = _drSystemConfig["Value"].ToString();
                    }
                }

                //byte[] hextobyte = GlobalFunctions.HexToBytes(GlobalVariables.ReportLogo);
                GlobalVariables.DTCompanyLogo = GlobalFunctions.getReportLogo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion "END OF METHODS"

        #region "EVENTS"
        private void MDIFrameWork_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += " [" + GlobalVariables.CurrentConnection + "]";
                pnlMenu.BackColor = Color.FromArgb(int.Parse(GlobalVariables.SecondaryColor));
                getGlobalVariablesData();
                try
                {
                    byte[] hextobyte = GlobalFunctions.HexToBytes(GlobalVariables.ScreenSaverImage);
                    pctScreenSaver.BackgroundImage = GlobalFunctions.ConvertByteArrayToImage(hextobyte);
                    pctScreenSaver.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch { }
                try
                {
                    byte[] hextobyteLogo = GlobalFunctions.HexToBytes(GlobalVariables.CompanyLogo);
                    pctLogo.BackgroundImage = GlobalFunctions.ConvertByteArrayToImage(hextobyteLogo);
                }
                catch { }
                try
                {
                    switch (GlobalVariables.TabAlignment)
                    {
                        case "Top":
                            tbcNSites_V.Alignment = TabAlignment.Top;
                            break;
                        case "Bottom":
                            tbcNSites_V.Alignment = TabAlignment.Bottom;
                            break;
                        case "Left":
                            tbcNSites_V.Alignment = TabAlignment.Left;
                            break;
                        case "Right":
                            tbcNSites_V.Alignment = TabAlignment.Right;
                            break;
                        default:
                            tbcNSites_V.Alignment = TabAlignment.Top;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                lblUsername.Text = "Welcome!  " + GlobalVariables.Userfullname;
                lblDateTime.Text = DateTime.Now.ToLongDateString();
                lblOwnerName.UseMnemonic = false;
                lblOwnerName.Text = GlobalVariables.CompanyName;
                lblApplicationName.Text = GlobalVariables.ApplicationName;
                if (GlobalVariables.Username != "admin" && GlobalVariables.Username != "technicalsupport")
                {
                    disabledMenuStrip();
                    enabledMenuStrip();
                }
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "MDIFrameWork_Load");
                em.ShowDialog();
                Application.Exit();
            }
        }

        private void tsmSystemConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "System Configuration")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                SystemConfigurationUI _SystemConfiguration = new SystemConfigurationUI();
                TabPage _SystemConfigurationTab = new TabPage();
                _SystemConfigurationTab.ImageIndex = 1;
                _SystemConfiguration.ParentList = this;
                displayControlOnTab(_SystemConfiguration, _SystemConfigurationTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmSystemConfiguration_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmUser_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "User List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                User _User = new User();
                Type _Type = typeof(User);
                ListFormSystemUI _ListForm = new ListFormSystemUI((object)_User, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 2;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmUser_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmUserGroup_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "User Group List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                UserGroupListUI _UserGroupList = new UserGroupListUI();
                TabPage _UserGroupTab = new TabPage();
                _UserGroupTab.ImageIndex = 3;
                _UserGroupList.ParentList = this;
                displayControlOnTab(_UserGroupList, _UserGroupTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmUserGroup_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmChangeUserPassword_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "Change User Password")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                ChangeUserPasswordUI _ChangeUserPassword = new ChangeUserPasswordUI();
                TabPage _ChangeUserPasswordTab = new TabPage();
                _ChangeUserPasswordTab.ImageIndex = 4;
                _ChangeUserPassword.ParentList = this;
                displayControlOnTab(_ChangeUserPassword, _ChangeUserPasswordTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmChangeUserPassword_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmLockScreen_Click(object sender, EventArgs e)
        {
            try
            {
                UnlockScreenUI _UnlockScreen = new UnlockScreenUI();
                _UnlockScreen.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmLockScreen_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion "END OF EVENTS"

        private void tsmScreenSaver_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "Screen Saver")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                ScreenSaverUI _ScreenSaver = new ScreenSaverUI();
                TabPage _ScreenSaverTab = new TabPage();
                _ScreenSaverTab.ImageIndex = 5;
                _ScreenSaver.ParentList = this;
                displayControlOnTab(_ScreenSaver, _ScreenSaverTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmScreenSaver_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmAuditTrail_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "Audit Trail")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                AuditTrailUI _AuditTrail = new AuditTrailUI();
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 55;
                _AuditTrail.ParentList = this;
                displayControlOnTab(_AuditTrail, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmAuditTrail_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmTechnicalUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //check technical support username and password
                if (GlobalVariables.Username == "technicalsupport")
                {
                    foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                    {
                        if (_tab.Text == "Technical Update")
                        {
                            tbcNSites_V.SelectedTab = _tab;
                            return;
                        }
                    }

                    TechnicalUpdateUI _TechnicalUpdate = new TechnicalUpdateUI();
                    TabPage _TechnicalUpdateTab = new TabPage();
                    _TechnicalUpdateTab.ImageIndex = 7;
                    _TechnicalUpdate.ParentList = this;
                    displayControlOnTab(_TechnicalUpdate, _TechnicalUpdateTab);
                }
                else
                {
                    MessageBoxUI ms = new MessageBoxUI("Only JC Technical Support can open this Function!", GlobalVariables.Icons.Error, GlobalVariables.Buttons.OK);
                    ms.showDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmTechnicalUpdate_Click");
                em.ShowDialog();
                return;
            }
        }

        private void btnClearTab_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text != "Home")
                    {
                        tbcNSites_V.TabPages.Remove(_tab);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "btnClearTab_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmSalesConfiguration_Click(object sender, EventArgs e)
        {

        }

        private void tsmEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "Employee List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                Employee _Employee = new Employee();
                Type _Type = typeof(Employee);
                ListFormHRISUI _ListForm = new ListFormHRISUI((object)_Employee, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 8;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmEmployee_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmBackupRestoreDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "Database Backup/Restore")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                DatabaseBackupRestoreUI loDatabaseBackupRestore = new DatabaseBackupRestoreUI();
                loDatabaseBackupRestore.ParentList = this;
                loDatabaseBackupRestore.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmBackupRestoreDatabase_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmEmploymentType_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "EmploymentType List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                EmploymentType _EmploymentType = new EmploymentType();
                Type _Type = typeof(EmploymentType);
                ListFormHRISUI _ListForm = new ListFormHRISUI((object)_EmploymentType, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmEmploymentType_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmDesignation_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "Designation List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                Designation _Designation = new Designation();
                Type _Type = typeof(Designation);
                ListFormHRISUI _ListForm = new ListFormHRISUI((object)_Designation, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmDesignation_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "Department List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                Department _Department = new Department();
                Type _Type = typeof(Department);
                ListFormHRISUI _ListForm = new ListFormHRISUI((object)_Department, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmDepartment_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmLeaveType_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "LeaveType List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                LeaveType _LeaveType = new LeaveType();
                Type _Type = typeof(LeaveType);
                ListFormHRISUI _ListForm = new ListFormHRISUI((object)_LeaveType, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmLeaveType_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmHoliday_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "Holiday List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                Holiday _Holiday = new Holiday();
                Type _Type = typeof(Holiday);
                ListFormHRISUI _ListForm = new ListFormHRISUI((object)_Holiday, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmHoliday_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmEarningType_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "EarningType List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                EarningType _EarningType = new EarningType();
                Type _Type = typeof(EarningType);
                ListFormPayrollUI _ListForm = new ListFormPayrollUI((object)_EarningType, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmEarningType_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmDeductionType_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "DeductionType List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                DeductionType _DeductionType = new DeductionType();
                Type _Type = typeof(DeductionType);
                ListFormPayrollUI _ListForm = new ListFormPayrollUI((object)_DeductionType, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmDeductionType_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmTaxType_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "TaxType List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                TaxType _TaxType = new TaxType();
                Type _Type = typeof(TaxType);
                ListFormPayrollUI _ListForm = new ListFormPayrollUI((object)_TaxType, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmTaxType_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmIncomeTaxTable_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "IncomeTaxTable List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                IncomeTaxTable _IncomeTaxTable = new IncomeTaxTable();
                Type _Type = typeof(IncomeTaxTable);
                ListFormPayrollUI _ListForm = new ListFormPayrollUI((object)_IncomeTaxTable, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmIncomeTaxTable_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmWorkSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage _tab in this.tbcNSites_V.TabPages)
                {
                    if (_tab.Text == "WorkSchedule List")
                    {
                        tbcNSites_V.SelectedTab = _tab;
                        return;
                    }
                }

                WorkSchedule _WorkSchedule = new WorkSchedule();
                Type _Type = typeof(WorkSchedule);
                ListFormHRISUI _ListForm = new ListFormHRISUI((object)_WorkSchedule, _Type);
                TabPage _ListFormTab = new TabPage();
                _ListFormTab.ImageIndex = 24;
                _ListForm.ParentList = this;
                displayControlOnTab(_ListForm, _ListFormTab);
            }
            catch (Exception ex)
            {
                ErrorMessageUI em = new ErrorMessageUI(ex.Message, this.Name, "tsmWorkSchedule_Click");
                em.ShowDialog();
                return;
            }
        }

        private void tsmPOSMerchandising_Click(object sender, EventArgs e)
        {

        }
    }
}
