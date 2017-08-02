using RGiesecke.DllExport;
using SigmaNEST;
using SigmaNEST.Plugin;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace SigmaNESTPlugin
{
    public class Plugin
    {
        #region Private fields

        private static ISNApp SNApp;
        private static IniFile ConfigIni;

        #endregion

        #region Entry Point

        /// <summary>
        /// This is the constructor and main entry point of the plugin.
        /// Here is where you will define the plugin properties and
        /// execute any other code upon construction.
        /// </summary>
        [DllExport]
        public static void CreateCSharpPlugin([MarshalAs(UnmanagedType.Interface)]out ISNPlugin SNPluginHandle, ISNApp ASNApp, ISNPokeIntf ASNPoke)
        {
            // Plugin setup
            var snPlugin = new SNPlugin(ASNApp, ASNPoke)
            {
                Author = "Plugin Author",
                Version = "1.0.0.0",
                AuthorizationGUID = Guid.NewGuid().ToString(),
                DateCreated = File.GetCreationTime(Assembly.GetExecutingAssembly().Location).ToOADate(),
                PlugInDescription = "SN C# Plugin",
                PlugInExplenation = "This is a template for a SIGMANEST C# Plugin.",
                ButtonLocations = new[]
                {
                    SNPluginTypes.ButtonLocation_WorkSpace,
                    SNPluginTypes.ButtonLocation_Help
                },
                ConfigCallback = Configure,
                ExecuteCallback = Execute
            };

            // Set global variables
            SNApp = snPlugin.SNApp;
            ConfigIni = new IniFile(snPlugin.GetConfigFile_PathNameExt("INI", 0));
            
            /* Add additional constructor code here */

            // Pass handle back to SigmaNEST
            SNPluginHandle = snPlugin;
        }

        #endregion

        #region Config and Execute Events

        /// <summary>
        /// If CanConfig is enabled - execute any code here for config
        /// e.g. display a dlg and allow user to set a Save to Path.
        /// </summary>
        /// <param name="parameters">Optional parameters passed in through batch commands.</param>
        public static void Configure(string parameters)
        {
            // This is an example config dialog that writes to an INI file
            frmConfig FormConfig = new frmConfig(SNApp, ConfigIni);
            FormConfig.ShowDialog();
            FormConfig.Dispose();
        }

        /// <summary>
        /// This function will be called by SN when ever the PlugIn is to be executed.
        /// This Action can be initiated by either the user clicking on the Ribbon Bar PlugIn Button
        /// or whenever the PlugIns is Called from API or BATCH command.
        /// </summary>
        /// <param name="parameters">Optional parameters passed in through batch commands.</param>
        public static void Execute(string parameters)
        {
            // This is an example execution dialog that has some example functions
            frmExecute FormExecute = new frmExecute(SNApp);
            FormExecute.ShowDialog();
            FormExecute.Dispose();
        }

        #endregion

        #region SigmaNEST Event Exports
        /*
            This is the exports section of the C# plugin. Because C# does not support 
            exporting unmanaged methods natively, there is an IL rewriter (DllExport.exe) 
            handling this as a post-build event. Because of this only uncomment the 
            [DllExport] attributes for the methods you intend to use in your plugin.
            
            DO NOT CHANGE THE SIGNATURE OF ANY EVENT OR THE [DllExport] Attribute
            
            To enable an event, remove the // characters from that methods "[DllExport]"
            attribute.
            
            e.g.SIGNATURE
            [DllExport]
            public static void OnPartSave(ISNPartObj APart)
        */

        /// <summary>
        /// When a part is saved in SigmaNEST
        /// This event is fired.
        /// </summary>
        [DllExport]
        public static void OnPartSave(ISNPartObj APart)
        {
            // This is an example event procedure which reads the INI file
            string EventMsg = ConfigIni.IniReadValue("Settings", "EventMessage");
            EventMsg = (EventMsg != "") ? EventMsg : "Hello World";
            MessageBox.Show(EventMsg, "OnPartSave Event");
        }

        /// <summary>
        /// When a part is saved in SigmaNEST this event
        /// is fired just before the save command is executed.
        /// </summary>
        //[DllExport]
        public static void BeforePartSave(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforePartSave Event");
        }

        /// <summary>
        /// After a part is created This event is fired.
        /// </summary>
        //[DllExport]
        public static void AfterPartCreate(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - AfterPartCreate Event");
        }

        /// <summary>
        /// When you selected edit part in SigmaNEST
        /// This event is fired before the edit dialog
        /// opens.
        /// </summary>
        //[DllExport]
        public static void BeforePartEdit(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforePartEdit Event");
        }

        /// <summary>
        /// When you edit a part in SigmaNEST
        /// This event is fired before the edit dialog
        /// closes
        /// </summary>
        //[DllExport]
        public static void AfterPartEdit(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - AfterPartEdit Event");
        }

        /// <summary>
        /// This event is fired when a sheet is saved.
        /// This can be from the Sheets List or in batch
        /// </summary>
        //[DllExport]
        public static void OnSheetSave(ISNSheetObj ASheet)
        {
            MessageBox.Show("SigmaNEST Plugin - OnSheetSave Event");
        }

        /// <summary>
        /// When a remnant is created (Crop or from a drawing(create Sheet))
        /// this event is fired -
        /// </summary>
        //[DllExport]
        public static void BeforeRemnantCreate(ISNSheetObj ASheet)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforeRemnantCreate Event");
        }

        /// <summary>
        /// When a remnant is saved
        /// this event is fired -
        /// </summary>
        //[DllExport]
        public static void BeforeRemnantSave(ISNSheetObj ASheet)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforeRemnantSave Event");
        }

        /// <summary>
        /// Before a nest is posted in SigmaNEST this
        /// event is fired - e.g make sure all parts
        /// on the nest has NC
        /// </summary>
        //[DllExport]
        public static void BeforePost(ISNNestObj ANest)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforePost Event");
        }

        /// <summary>
        /// When you post a nest in SigmaNEST
        /// this event fires as the program is created
        /// </summary>
        //[DllExport]
        public static void OnPost(ISNNestObj ANest)
        {
            MessageBox.Show("SigmaNEST Plugin - OnPost Event");
        }

        /// <summary>
        /// When posting a Task (All layouts).
        /// </summary>
        //[DllExport]
        public static void OnTaskPost(ISNTaskObj ATask)
        {
            MessageBox.Show("SigmaNEST Plugin - OnTaskPost Event");
        }

        /// <summary>
        /// After a program is created this event fires.
        /// </summary>
        //[DllExport]
        public static void OnAfterPost()
        {
            MessageBox.Show("SigmaNEST Plugin - OnAfterPost Event");
        }

        /// <summary>
        /// before a program is created from part mode this
        /// event is fired.
        /// </summary>
        //[DllExport]
        public static void BeforePostPartMode(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforePostPartMode Event");
        }

        /// <summary>
        /// When a program is created for a single part from Part mode
        /// </summary>
        //[DllExport]
        public static void OnPostPartMode(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - OnPostPartMode Event");
        }

        /// <summary>
        /// after a program is created for a single part from Part mode
        /// </summary>
        //[DllExport]
        public static void OnAfterPostPartMode()
        {
            MessageBox.Show("SigmaNEST Plugin - OnAfterPostPartMode Event");
        }

        /// <summary>
        /// When SigmaNEST starts - only fires after the plugin is created
        /// </summary>
        [DllExport]
        public static void OnSNStartUp()
        {
            MessageBox.Show("SigmaNEST Plugin - OnSNStartUp Event");
        }

        /// <summary>
        /// When a WS is saved
        /// </summary>
        //[DllExport]
        public static void OnWSSave()
        {
            MessageBox.Show("SigmaNEST Plugin - OnWSSave Event");
        }

        /// <summary>
        /// When a WS is loaded
        /// </summary>
        //[DllExport]
        public static void OnWSLoad()
        {
            MessageBox.Show("SigmaNEST Plugin - OnWSLoad Event");
        }

        /// <summary>
        /// when a task is created this event is fired - includes auto task
        /// </summary>
        //[DllExport]
        public static void OnTaskCreate(ISNTaskObj ATask)
        {
            MessageBox.Show("SigmaNEST Plugin - OnTaskCreate Event");
        }

        /// <summary>
        /// When a WO is created - includes batch
        /// </summary>
        //[DllExport]
        public static void OnWOCreate(ISNWorkOrderObj ASNWorkOrder)
        {
            MessageBox.Show("SigmaNEST Plugin - OnWOCreate Event");
        }

        /// <summary>
        /// Fires when a part is added to a WO
        /// </summary>
        //[DllExport]
        public static void OnAddPartToWorkOrder(ISNWorkOrderPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - OnAddPartToWorkOrder Event");
        }

        /// <summary>
        /// After a program is updated
        /// </summary>
        //[DllExport]
        public static void AfterProgUpdate(ISNProgramObj ASNProgramObj)
        {
            MessageBox.Show("SigmaNEST Plugin - AfterProgUpdate Event");
        }

        /// <summary>
        /// When the OnGetRemName event fires this is executed
        /// </summary>
        /// <returns>Return the created remnant name</returns>
        //[DllExport]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static string OnGetRemName(int ACntSheet, [MarshalAs(UnmanagedType.LPWStr)] string ASheetNamePrefix, [MarshalAs(UnmanagedType.LPWStr)] string AMaterial, double AThickness)
        {
            return "";
        }

        /// <summary>
        /// When the GetSheetName event fires this is executed
        /// </summary>
        /// <returns>Returns a new Sheet Name</returns>
        //[DllExport]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static string OnGetSheetName(int ACntSheet, [MarshalAs(UnmanagedType.LPWStr)] string ASheetNamePrefix)
        {
            MessageBox.Show("SigmaNEST Plugin - OnGetSheetName Event");
            return "";
        }

        /// <summary>
        /// When the SigmaNEST timer event fires this is executed
        /// </summary>
        //[DllExport]
        public static void TimerEvent()
        {
            MessageBox.Show("SigmaNEST Plugin - TimerEvent Event");
        }

        /// <summary>
        /// When a program is updated this event fires includes
        /// program update from batch
        /// </summary>
        //[DllExport]
        public static void OnProgUpdate(ISNProgramObj AProgramRecord)
        {
            MessageBox.Show("SigmaNEST Plugin - OnProgUpdate Event");
        }

        /// <summary>
        /// When a quote is submitted this event fires
        /// </summary>
        //[DllExport]
        public static void OnQuoteSubmit([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber)
        {
            MessageBox.Show("SigmaNEST Plugin - OnQuoteSubmit Event");
        }

        /// <summary>
        /// When a quote is submitted this event fires
        /// </summary>
        //[DllExport]
        public static void OnBeforeQuoteSubmit([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber)
        {
            MessageBox.Show("SigmaNEST Plugin - OnBeforeQuoteSubmit Event");
        }

        /// <summary>
        /// Called when converting quote to wo.
        /// </summary>
        //[DllExport]
        public static void OnConvertQuoteToWO([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber, [MarshalAs(UnmanagedType.LPWStr)] string aOrderNumber, [MarshalAs(UnmanagedType.LPWStr)] string aCustomer, [MarshalAs(UnmanagedType.LPWStr)] string aCustomerPO, [MarshalAs(UnmanagedType.LPWStr)] string aWONumber, [MarshalAs(UnmanagedType.AsAny)] DateTime aDueDate)
        {
            MessageBox.Show("SigmaNEST Plugin - OnConvertQuoteToWO Event");
        }

        /// <summary>
        /// Called when closing SigmaNEST.
        /// </summary>
        //[DllExport]
        public static void OnCloseSigmaNEST()
        {
            MessageBox.Show("SigmaNEST Plugin - OnCloseSigmaNEST Event");
        }

        /// <summary>
        /// Called when clearing the workspace.
        /// </summary>
        //[DllExport]
        public static void OnClearWorkspace()
        {
            MessageBox.Show("SigmaNEST Plugin - OnClearWorkspace Event");
        }

        /// <summary>
        /// Called before a part is deleted from the SigmaNEST workspace
        /// </summary>
        /// <param name="APart">Name of the part to be deleted</param>
        //[DllExport]
        public void BeforeDeletePartFromWorkspace(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforeDeletePartFromWorkspace Event");
        }

        /// <summary>
        /// Called when Develop Shape Workspace ribbon button in SigmaNEST is pressed
        /// </summary>
        //[DllExport]
        public void OnNewDevelopShape()
        {
            MessageBox.Show("SigmaNEST Plugin - OnNewDevelopShape Event");
        }

        /// <summary>
        /// Called prior to nesting
        /// </summary>
        /// <param name="ATaskObj"></param>
        //[DllExport]
        public void BeforeNest(ISNTaskObj ATaskObj)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforeNest Event");
        }

        /// <summary>
        /// Called after nesting
        /// </summary>
        /// <param name="ATaskObj"></param>
        //[DllExport]
        public void AfterNest(ISNTaskObj ATaskObj)
        {
            MessageBox.Show("SigmaNEST Plugin - AfterNest Event");
        }

        /// <summary>
        /// Called before a workspace is cleared
        /// </summary>
        //[DllExport]
        public void BeforeClearWorkspace()
        {
            MessageBox.Show("SigmaNEST Plugin - BeforeClearWorkspace Event");
        }

        /// <summary>
        /// Called after a workspace is loaded.
        /// </summary>
        //[DllExport]
        public void BeforeLoadWorkspace()
        {
            MessageBox.Show("SigmaNEST Plugin - BeforeClearWorkspace Event");
        }


        /// <summary>
        /// Called before any SigmaNEST action event. Executed action name and paraeter are passed in
        /// as inputs. Return value "CanContinue", return false to allow SigmaNEST action to continue
        /// or true to cancel/exit current SigmaNEST action code.
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aParam"></param>
        /// <returns></returns>
        //[DllExport]
        public bool OnActionMenu([MarshalAs(UnmanagedType.LPWStr)] string aName, [MarshalAs(UnmanagedType.LPWStr)] string aParam)
        {
            MessageBox.Show("SigmaNEST Plugin - OnActionMenu Event: " + aName);
            return false;
        }

        /// <summary>
        /// Called after any SigmaNEST action event. Executed action name and paraeter are passed in
        /// as inputs.
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aParam"></param>
        //[DllExport]
        public void OnActionMenuDone([MarshalAs(UnmanagedType.LPWStr)] string aName, [MarshalAs(UnmanagedType.LPWStr)] string aParam)
        {
            MessageBox.Show("SigmaNEST Plugin - OnActionMenuDone Event: " + aName);
        }

        #endregion
    }
}
