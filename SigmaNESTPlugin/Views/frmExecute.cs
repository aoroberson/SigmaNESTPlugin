// ***********************************************************************
// Assembly         : SigmaNESTPlugin
// Author           : Anthony Roberson
// Created          : 10-09-2015
//
// Last Modified By : Anthony Roberson
// Last Modified On : 10-12-2015
// ***********************************************************************
// <copyright file="frmExecute.cs" company="SigmaTEK Systems">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using SigmaNEST;
using System.Windows.Forms;

/// <summary>
/// The SigmaNESTPlugin namespace.
/// </summary>
namespace SigmaNESTPlugin
{
    /// <summary>
    /// Class frmExecute.
    /// </summary>
    public partial class frmExecute : Form
    {
        ISNApp FSNApp;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmExecute"/> class.
        /// </summary>
        /// <param name="ASNApp">The SN application.</param>
        public frmExecute(ISNApp ASNApp)
        {
            InitializeComponent();
            FSNApp = ASNApp;
        }

        /// <summary>
        /// Handles the Click event of the btnAboutSN control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAboutSN_Click(object sender, System.EventArgs e)
        {
            FSNApp.ShowHelpAbout();
        }

        /// <summary>
        /// Handles the Click event of the btnLoadWS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnLoadWS_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog OpenFileDlg = new OpenFileDialog();
            OpenFileDlg.Filter = "Workspace Files (*.WS)|*.WS|All files (*.*)|*.*";
            OpenFileDlg.Title = "Please select an Workspace file to open.";

            if (OpenFileDlg.ShowDialog() == DialogResult.OK)
            {
                FSNApp.ExecuteBatchCommand("LOAD,WS," + OpenFileDlg.FileName);
                FSNApp.ExecuteBatchCommand("PARTTILE");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDone_Click(object sender, System.EventArgs e)
        {
            Close();
        }

    }
}
