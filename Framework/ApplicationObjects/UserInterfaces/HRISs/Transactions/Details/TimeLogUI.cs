using NSites_V.ApplicationObjects.Classes.Generics;
using NSites_V.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSites_V.ApplicationObjects.UserInterfaces.HRISs.Transactions.Details
{
    public partial class TimeLogUI : Form
    {
        Common loCommon;
        public DateTime lDate;
        public string lBiometricsId;
        public string lTime = "";
        public bool lFromSelection;
        CryptorEngine loCryptoEngine;

        public TimeLogUI(string pName, string pBiometricsId, DateTime pDate)
        {
            InitializeComponent();
            lblName.Text = pName;
            lBiometricsId = pBiometricsId;
            lDate = pDate;
            lFromSelection = false;
            loCommon = new Common();
            loCryptoEngine = new CryptorEngine();
        }

        private void TimeLogUI_Load(object sender, EventArgs e)
        {
            string _DatabaseAddress = "";
            try
            {
                string line = null;
                char[] splitter1 = { ';' };
                char[] splitter2 = { ':' };
                System.IO.TextReader readFile = new StreamReader(".../Main/text/databaseURL.txt");
                line = readFile.ReadLine();
                if (line != null)
                {
                    string _StringToWrite = loCryptoEngine.DecryptString(line);
                    _DatabaseAddress = _StringToWrite;
                }
                readFile.Close();
                readFile = null;
            }
            catch
            { }
            lTime = "";
            dgvTimeLog.DataSource = null;
            DataTable ldtTimeLog = loCommon.getTimeLogByEmployee(lDate, _DatabaseAddress, lBiometricsId);
            dgvTimeLog.DataSource = ldtTimeLog;
            lFromSelection = false;
        }

        private void dgvTimeLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
