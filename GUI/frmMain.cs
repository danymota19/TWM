using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TWM.GUI
{
    public partial class frmMain : Form
    {
        private bool JustStarted = false;
        private enum panel
        {
            none,
            maintenanceWork,
            regularMaintenance,
            workingHours
        }
        private panel CurrentPanel = panel.none;
        private RegularMaintenanceUserControl regularMaintenanceUserControl = new RegularMaintenanceUserControl();
        private MaintenanceWorkUserControl maintenanceWorkUserControl = new MaintenanceWorkUserControl();
        private WorkingHrsUserControl workingHrsUserControl = new WorkingHrsUserControl();
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void setPanelVisibility(panel currentPanel) {
            if (JustStarted)
            {
                mainBox.Visible = true;
                LoadComponentsMenu();
                JustStarted = false;
            }

            foreach (Control ctrl in mainPanel.Controls)
            {
                ctrl.Dispose();
            }

            switch(currentPanel)
            {
                case panel.maintenanceWork : 
                {
                    maintenanceWorkUserControl.Dock = DockStyle.Fill;
                    mainPanel.Controls.Add(maintenanceWorkUserControl);
                    break;
                }
                case panel.regularMaintenance : 
                {
                    regularMaintenanceUserControl.Dock = DockStyle.Fill;
                    mainPanel.Controls.Add(regularMaintenanceUserControl);
                    break;
                }
                case panel.workingHours : 
                {
                    workingHrsUserControl.Dock = DockStyle.Fill;
                    mainPanel.Controls.Add(workingHrsUserControl);
                    break;
                }
            }
            CurrentPanel = currentPanel;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            JustStarted = true;
            this.WindowState = FormWindowState.Maximized;
            //this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fm = new frmLogin();
            fm.Show();
        }

        private void componentsBtn_Click(object sender, EventArgs e)
        { 
            setPanelVisibility(panel.regularMaintenance);
        }

        private void workingHrsBtn_Click(object sender, EventArgs e)
        {
            setPanelVisibility(panel.workingHours);
        }

        private void maintenanceBtn_Click(object sender, EventArgs e)
        {
            setPanelVisibility(panel.maintenanceWork);
        }


        private void componentsMenuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (CurrentPanel == panel.maintenanceWork) {
               // regularMaintenanceTableLayoutPanel.Visible = true;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        
       
    }
}
