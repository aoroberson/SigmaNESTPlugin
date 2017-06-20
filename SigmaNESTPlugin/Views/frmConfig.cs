// ***********************************************************************
// Assembly         : SigmaNESTPlugin
// Author           : Anthony Roberson
// Created          : 10-09-2015
//
// Last Modified By : Anthony Roberson
// Last Modified On : 10-12-2015
// ***********************************************************************
// <copyright file="frmConfig.cs" company="SigmaTEK Systems">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using SigmaNEST;
using SigmaNEST.Plugin;
using System;
using System.Windows.Forms;

namespace SigmaNESTPlugin
{
    /// <summary>
    /// Class frmConfig.
    /// </summary>
    public partial class frmConfig : Form
    {
        ISNApp FSNApp;
        IniFile FConFigIni;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmConfig"/> class.
        /// </summary>
        /// <param name="ASNApp">The SN application.</param>
        /// <param name="AConFigIni">The passed in ini file object.</param>
        public frmConfig(ISNApp ASNApp, IniFile AConFigIni)
        {
            InitializeComponent();

            FSNApp = ASNApp;
            FConFigIni = AConFigIni;
        }

        /// <summary>
        /// Handles the Load event of the frmConfig control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmConfig_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < FSNApp.ConstVar.MachineList.Count; i++)
            {
                cbo_1.Items.Add(FSNApp.ConstVar.MachineList.AtIndex[i].MachineName);
            }
            ReadIni();
        }

        /// <summary>
        /// Handles the Click event of the btnDone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDone_Click(object sender, EventArgs e)
        {
            WriteIni();
        }

        /// <summary>
        /// Reads the config ini to the form.
        /// </summary>
        private void ReadIni()
        {
            string LMac1Index = FConFigIni.IniReadValue("Settings", "ActiveMachine");
            cbo_1.SelectedIndex = (LMac1Index != "") ? Convert.ToInt32(LMac1Index) : 0;

            string EventMsg = FConFigIni.IniReadValue("Settings", "EventMessage");
            txt_1.Text = (EventMsg != "") ? EventMsg : "Hello World";
        }

        /// <summary>
        /// Writes the config ini from the form.
        /// </summary>
        private void WriteIni()
        {
            FConFigIni.IniWriteValue("Settings", "ActiveMachine", cbo_1.SelectedIndex.ToString());
            FConFigIni.IniWriteValue("Settings", "EventMessage", txt_1.Text);
        }
    }
}
