using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using XtremeCommandBars;
using Demo_G.O.S.E.GUI.CommandBars;

namespace Demo_R.O.S.E.LoginServer.LoginServer.ConfigInfo
{
    public partial class ConfigInfoForm : Form
    {
        public Demo_G.O.S.E.GUI.CommandBars.CommandBarsGlobalSettings CommandBarsGlobalSettings;

        public ConfigInfoForm()
        {
            InitializeComponent();
        }

        private Demo_G.O.S.E.GUI.CommandBars.RibbonBar RibbonBar()
        {
            return (Demo_G.O.S.E.GUI.CommandBars.RibbonBar)CommandBars.ActiveMenuBar;
        }

        private void axCommandBars_Customization( object sender, Demo_G.O.S.E.GUI.CommandBars.ActiveX._DCommandBarsEvents_CustomizationEvent eventArgs )
		{
			eventArgs.options.ShowRibbonQuickAccessPage = true;

			Demo_G.O.S.E.GUI.CommandBars.CommandBarControls cmbControls = null;
			cmbControls = CommandBars.DesignerControls;
			Demo_G.O.S.E.GUI.CommandBars.CommandBarControl cmbControl = null;

			if (cmbControls.Count == 0)
			{
				string tempCaption1 = "&新建";
				bool tempBeginGroup2 = false;
				string tempDescriptionText3 = "Create a new document";
				string tempCategory4 = "文件";
				cmbControl = cmbControls.Add(Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_NEW, tempCaption1, tempBeginGroup2, tempDescriptionText3);
				cmbControl.Style = Demo_G.O.S.E.GUI.CommandBars.XTPButtonStyle.xtpButtonAutomatic;
				cmbControl.Category = tempCategory4;

				string tempCaption5 = "&打开";
				bool tempBeginGroup6 = false;
				string tempDescriptionText7 = "Open an existing document";
				cmbControl = cmbControls.Add(Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton,  ResourceId.ID_FILE_OPEN,  tempCaption5,  tempBeginGroup6,  tempDescriptionText7);
				cmbControl.Style = Demo_G.O.S.E.GUI.CommandBars.XTPButtonStyle.xtpButtonAutomatic;
				cmbControl.Category = tempCategory4;

				string tempCaption9 = "&保存";
				bool tempBeginGroup10 = false;
				string tempDescriptionText11 = "Save the active document";
				cmbControl = cmbControls.Add(Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton,  ResourceId.ID_FILE_SAVE,  tempCaption9,  tempBeginGroup10,  tempDescriptionText11);
				cmbControl.Style = Demo_G.O.S.E.GUI.CommandBars.XTPButtonStyle.xtpButtonAutomatic;
				cmbControl.Category = tempCategory4;

				string tempCaption13 = "&Print";
				bool tempBeginGroup14 = false;
				string tempDescriptionText15 = "Print the active document";
				cmbControl = cmbControls.Add(Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton,  ResourceId.ID_FILE_PRINT,  tempCaption13,  tempBeginGroup14,  tempDescriptionText15);
				cmbControl.Style = Demo_G.O.S.E.GUI.CommandBars.XTPButtonStyle.xtpButtonAutomatic;
				cmbControl.Category = tempCategory4;

				string tempCaption17 = "Print Set&up";
				bool tempBeginGroup18 = false;
				string tempDescriptionText19 = "Print Setup";
				cmbControl = cmbControls.Add(Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton,  ResourceId.ID_FILE_PRINT_SETUP,  tempCaption17,  tempBeginGroup18,  tempDescriptionText19);
				cmbControl.Style = Demo_G.O.S.E.GUI.CommandBars.XTPButtonStyle.xtpButtonAutomatic;
				cmbControl.Category = tempCategory4;

				string tempCategory24 = "Edit";
				string tempCaption29 = "&Paste";
				bool tempBeginGroup30 = false;
				string tempDescriptionText31 = "Insert Clipboard contents";
				cmbControl = cmbControls.Add(Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton,  ResourceId.ID_EDIT_PASTE,  tempCaption29,  tempBeginGroup30,  tempDescriptionText31);
				cmbControl.Style = Demo_G.O.S.E.GUI.CommandBars.XTPButtonStyle.xtpButtonAutomatic;
				cmbControl.Category = tempCategory24;

				string tempCaption57 = "About";
				bool tempBeginGroup58 = false;
				string tempDescriptionText59 = "";
				string tempCategory60 = "Help";
				cmbControl = cmbControls.Add(Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton,  ResourceId.ID_APP_ABOUT,  tempCaption57,  tempBeginGroup58,  tempDescriptionText59);
				cmbControl.Style = Demo_G.O.S.E.GUI.CommandBars.XTPButtonStyle.xtpButtonAutomatic;
				cmbControl.Category = tempCategory60;
			}
		}

        private void axCommandBars_Execute( object sender, Demo_G.O.S.E.GUI.CommandBars.ActiveX._DCommandBarsEvents_ExecuteEvent eventArgs )
		{
			switch (eventArgs.control.Id)
			{	
				case (int)Demo_G.O.S.E.GUI.CommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCUSTOMIZE:
					CommandBars.ShowCustomizeDialog(3);
					break;
				case ResourceId.ID_APP_ABOUT:
					MessageBox.Show("Version " + System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMajorPart + "." + System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMinorPart);
					break;
				case ResourceId.ID_FILE_NEW:
                    //LoadNewDoc("");
					break;
				case ResourceId.ID_APP_EXIT:
					this.Close();
					break;
				case (int)Demo_G.O.S.E.GUI.CommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCONTROLTAB:
					System.Diagnostics.Debug.WriteLine("Selected Tab has Changed");
					break;
				case ResourceId.ID_FILE_PRINT_PREVIEW:
                    //LoadPrintPreview();
					break;
				case ResourceId.ID_VIEW_STATUS_BAR:
					CommandBars.StatusBar.Visible = !CommandBars.StatusBar.Visible;
					CommandBars.RecalcLayout();
					break;
				case ResourceId.ID_VIEW_WORKSPACE:
					eventArgs.control.Checked = !eventArgs.control.Checked;
					CommandBars.ShowTabWorkspace(eventArgs.control.Checked);
					break;
				case ResourceId.ID_WINDOW_ARRANGE:
					this.LayoutMdi(MdiLayout.ArrangeIcons);
					break;
				case ResourceId.ID_WINDOW_NEW:
                    //LoadNewDoc("");
					break;
				case ResourceId.ID_PREVIEW_PREVIEW_CLOSE:
					RibbonBar().FindTab(ResourceId.ID_TAB_PRINT_PREVIEW).Visible = false;
					RibbonBar().FindTab(ResourceId.ID_TAB_HOME).Visible = true;
					RibbonBar().FindTab(ResourceId.ID_TAB_EDIT).Visible = true;
					RibbonBar().FindTab(ResourceId.ID_TAB_VIEW).Visible = true;
					this.ActiveMdiChild.Close();
					this.ActiveMdiChild.WindowState = FormWindowState.Normal;
					if (RibbonBar().FindControl(Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlCheckBox, ResourceId.ID_VIEW_WORKSPACE, false,true).Checked) 
					{
						CommandBars.ShowTabWorkspace(true);
					}					
					RibbonBar().FindTab(ResourceId.ID_TAB_HOME).Selected = true;
					break;
				case ResourceId.ID_PREVIEW_PRINT_PRINT:
				case ResourceId.ID_FILE_PRINT:
					// create and show...
					PrintDialog printDialog1 = new PrintDialog();
					printDialog1.AllowSomePages = true;

					// Show the help button.
					printDialog1.ShowHelp = true;
			
					System.Drawing.Printing.PrintDocument docToPrint = 
						new System.Drawing.Printing.PrintDocument();
					
					printDialog1.Document = docToPrint;

                    if (printDialog1.ShowDialog(CommandBars) == DialogResult.OK)
					{
						
					} 

					break;
				case ResourceId.ID_FILE_CLOSE:
					this.ActiveMdiChild.Close();
					break;
				case ResourceId.ID_FILE_SAVE:
				case ResourceId.ID_FILE_SAVE_AS:
					SaveFileDialog SaveDialog = new SaveFileDialog();
					SaveDialog.ShowDialog(CommandBars);
					break;
				case ResourceId.ID_FILE_OPEN:
					OpenFileDialog openFileDialog1 = new OpenFileDialog();

					openFileDialog1.InitialDirectory = "c:\\" ;
					openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
					openFileDialog1.FilterIndex = 2 ;
					openFileDialog1.RestoreDirectory = true ;

                    if (openFileDialog1.ShowDialog(CommandBars) == DialogResult.OK)
					{
						if(openFileDialog1.FileName.Length != 0)
						{
                            //LoadNewDoc(openFileDialog1.FileName);
						}
					}
					break;
				case ResourceId.ID_EDIT_SELECT_ALL:
				case ResourceId.ID_EDIT_SELECT:
					System.Windows.Forms.RichTextBox rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
					rtfText.SelectAll();
					break;
				case ResourceId.ID_EDIT_UNDO:
					rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
					rtfText.Undo();
					break;
				case ResourceId.ID_EDIT_CUT:
					rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
					rtfText.Cut();
					break;
				case ResourceId.ID_EDIT_COPY:
					rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
					rtfText.Copy();
					break;
				case ResourceId.ID_EDIT_PASTE:
					rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
					rtfText.Paste();
					break;
				default:
					MessageBox.Show(eventArgs.control.Caption + " clicked", "Button Clicked");
					break;	
			};
		}

        private void axCommandBars_UpdateEvent( object sender, Demo_G.O.S.E.GUI.CommandBars.ActiveX._DCommandBarsEvents_UpdateEvent eventArgs )
		{
			switch (eventArgs.control.Id)
			{	
				case ResourceId.ID_VIEW_STATUS_BAR:
					eventArgs.control.Checked = CommandBars.StatusBar.Visible;
					break;
				case ResourceId.ID_FILE_PRINT_PREVIEW:
				case ResourceId.ID_FILE_PRINT:
				case ResourceId.ID_FILE_CLOSE:
				case ResourceId.ID_FILE_SAVE:
				case ResourceId.ID_WINDOW_ARRANGE:
				case ResourceId.ID_WINDOW_NEW:
				case ResourceId.ID_WINDOW_SWITCH:
					eventArgs.control.Enabled = (this.MdiChildren.Length != 0 ? true : false);
					break;
				case (int)Demo_G.O.S.E.GUI.CommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCONTROLTAB:
					if (RibbonBar().FindTab(ResourceId.ID_TAB_PRINT_PREVIEW).Visible == true) 
					{
						RibbonBar().FindTab(ResourceId.ID_TAB_EDIT).Visible = false;
					}
					else if (this.MdiChildren.Length != 0) 
					{
						RibbonBar().FindTab(ResourceId.ID_TAB_EDIT).Visible = (this.MdiChildren.Length != 0 ? true : false);
					}
					break;
				case ResourceId.ID_EDIT_REPLACE:
				case ResourceId.ID_EDIT_FIND:
				case ResourceId.ID_EDIT_SELECT_ALL:
					if (this.MdiChildren.Length == 0) 
					{
						eventArgs.control.Enabled = false;
					}
					else
					{
						System.Windows.Forms.RichTextBox rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
						eventArgs.control.Enabled = rtfText.CanSelect;
					}
					break;
				case ResourceId.ID_EDIT_CUT:
				case ResourceId.ID_EDIT_COPY:
					if (this.MdiChildren.Length == 0) 
					{
						eventArgs.control.Enabled = false;
					}
					else
					{
						System.Windows.Forms.RichTextBox rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
						eventArgs.control.Enabled = (rtfText.SelectionLength == 0 ? false : true);
					}
					break;
				case ResourceId.ID_EDIT_UNDO:
					if (this.MdiChildren.Length == 0) 
					{
						eventArgs.control.Enabled = false;
					}
					else
					{
						System.Windows.Forms.RichTextBox rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
						eventArgs.control.Enabled = rtfText.CanUndo;
					}
					break;
				case ResourceId.ID_EDIT_PASTE:
				case ResourceId.ID_EDIT_PASTE_SPECIAL:
					if (this.MdiChildren.Length == 0) 
					{
						eventArgs.control.Enabled = false;
					}
					else
					{
						System.Windows.Forms.RichTextBox rtfText = (System.Windows.Forms.RichTextBox)this.ActiveMdiChild.Controls[0];
						System.Windows.Forms.DataFormats.Format myFormat = System.Windows.Forms.DataFormats.GetFormat(DataFormats.Text);
						eventArgs.control.Enabled = rtfText.CanPaste(myFormat);
					}
					break;
			};
			
		}

        private void ConfigInfoForm_Load( object sender, EventArgs e )
        {
            CommandBars.GlobalSettings.ResourceFile = "Demo G.O.S.E.GUI.ResourceZhCn.dll";

            CreateRibbonBar();

            CommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'N' ), ResourceId.ID_FILE_NEW );
            CommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'O' ), ResourceId.ID_FILE_OPEN );
            CommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'S' ), ResourceId.ID_FILE_SAVE );
            CommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'X' ), ResourceId.ID_EDIT_CUT );
            CommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'C' ), ResourceId.ID_EDIT_COPY );
            CommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'V' ), ResourceId.ID_EDIT_PASTE );
            CommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'A' ), ResourceId.ID_EDIT_SELECT_ALL );

            LoadIcons();

            Demo_G.O.S.E.GUI.CommandBars.StatusBar StatusBar = null;
            StatusBar = CommandBars.StatusBar;
            StatusBar.Visible = true;

            StatusBar.AddPane( 0 );
            StatusBar.AddPane( ResourceId.ID_INDICATOR_CAPS );
            StatusBar.AddPane( ResourceId.ID_INDICATOR_NUM );
            StatusBar.AddPane( ResourceId.ID_INDICATOR_SCRL );

            RibbonBar().EnableFrameTheme();

            CommandBars.Options.KeyboardCuesShow = Demo_G.O.S.E.GUI.CommandBars.XTPKeyboardCuesShow.xtpKeyboardCuesShowWindowsDefault;

            foreach ( Control ctrl in this.Controls )
            {
                if ( ctrl is MdiClient )
                {
                    CommandBars.SetMDIClient( ctrl.Handle.ToInt32() );
                }
            }

            //Demo_G.O.S.E.GUI.CommandBars.TabWorkspace Workspace;

            CommandBars.EnableCustomization( true );
        }

        private void LoadIcons()
        {
            CommandBars.Options.UseSharedImageList = false;

            CommandBars.Icons.LoadBitmap( "../\\res\\GroupClipboard.png", new object[] { ResourceId.ID_EDIT_PASTE, ResourceId.ID_EDIT_CUT, ResourceId.ID_EDIT_COPY, ResourceId.ID_FORMAT_PAINTER }, Demo_G.O.S.E.GUI.CommandBars.XTPImageState.xtpImageNormal );
            CommandBars.Icons.LoadBitmap( "../\\res\\GroupFind.png", new object[] { ResourceId.ID_EDIT_FIND, ResourceId.ID_EDIT_REPLACE, ResourceId.ID_EDIT_GOTO, ResourceId.ID_EDIT_SELECT }, Demo_G.O.S.E.GUI.CommandBars.XTPImageState.xtpImageNormal );
            CommandBars.Icons.LoadBitmap( "../\\res\\SmallIcons.png", new object[] { ResourceId.ID_FILE_NEW, ResourceId.ID_FILE_OPEN, ResourceId.ID_FILE_SAVE, ResourceId.ID_EDIT_CUT, ResourceId.ID_EDIT_COPY, ResourceId.ID_EDIT_PASTE, ResourceId.ID_EDIT_UNDO, ResourceId.ID_EDIT_REDO, ResourceId.ID_FILE_PRINT, ResourceId.ID_APP_ABOUT }, Demo_G.O.S.E.GUI.CommandBars.XTPImageState.xtpImageNormal );
            CommandBars.Icons.LoadBitmap( "../\\res\\LargeIcons.png", new object[] { ResourceId.ID_FILE_NEW, ResourceId.ID_FILE_OPEN, ResourceId.ID_FILE_SAVE, ResourceId.ID_EDIT_PASTE, ResourceId.ID_EDIT_FIND, ResourceId.ID_FILE_PRINT, ResourceId.ID_FILE_CLOSE, ResourceId.ID_VIEW_NORMAL, ResourceId.ID_FILE_PRINT_PREVIEW, ResourceId.ID_VIEW_FULLSCREEN, ResourceId.ID_WINDOW_NEW, ResourceId.ID_WINDOW_ARRANGE, ResourceId.ID_WINDOW_SWITCH }, Demo_G.O.S.E.GUI.CommandBars.XTPImageState.xtpImageNormal );
            CommandBars.Icons.LoadBitmap( "../\\res\\shiny-gear.png", ResourceId.ID_SYSTEM_ICON, Demo_G.O.S.E.GUI.CommandBars.XTPImageState.xtpImageNormal );
            CommandBars.Icons.LoadIcon( "../\\res\\GroupPopup.ico", ResourceId.ID_GROUP_POPUPICON, Demo_G.O.S.E.GUI.CommandBars.XTPImageState.xtpImageNormal );
            CommandBars.Icons.LoadBitmap( "../\\res\\PrintPreview.png", new object[] { ResourceId.ID_PREVIEW_PREVIEW_CLOSE, ResourceId.ID_PREVIEW_ZOOM_100_PERCENT, ResourceId.ID_PREVIEW_ZOOM_ZOOM, ResourceId.ID_PREVIEW_PAGESETUP_SIZE, ResourceId.ID_PREVIEW_PAGESETUP_ORIENTATION, ResourceId.ID_PREVIEW_PAGESETUP_MARGINS, ResourceId.ID_PREVIEW_PRINT_OPTIONS, ResourceId.ID_PREVIEW_PRINT_PRINT }, Demo_G.O.S.E.GUI.CommandBars.XTPImageState.xtpImageNormal );
            CommandBars.Icons.LoadBitmap( "../\\res\\PrintPreviewSmall.png", new object[] { ResourceId.ID_PREVIEW_ZOOM_1PAGE, ResourceId.ID_PREVIEW_ZOOM_2PAGES, ResourceId.ID_PREVIEW_ZOOM_PAGE_WIDTH, ResourceId.ID_PREVIEW_PREVIEW_SHRINK, ResourceId.ID_PREVIEW_PREVIEW_NEXT, ResourceId.ID_PREVIEW_PREVIEW_PREVIOUS }, Demo_G.O.S.E.GUI.CommandBars.XTPImageState.xtpImageNormal );

            Demo_G.O.S.E.GUI.CommandBars.ToolTipContext ToolTipContext = null;
            ToolTipContext = CommandBars.ToolTipContext;
            ToolTipContext.Style = Demo_G.O.S.E.GUI.CommandBars.XTPToolTipStyle.xtpToolTipOffice2007;
            ToolTipContext.ShowTitleAndDescription( true, Demo_G.O.S.E.GUI.CommandBars.XTPToolTipIcon.xtpToolTipIconNone );
            ToolTipContext.SetMargin( 2, 2, 2, 2 );
            ToolTipContext.MaxTipWidth = 180;
        }

        private void CreateRibbonBar()
        {
            Demo_G.O.S.E.GUI.CommandBars.RibbonBar l_RibbonBar = null;
            l_RibbonBar = CommandBars.AddRibbonBar( "ConfigInfo Ribbon" );
            l_RibbonBar.EnableDocking( Demo_G.O.S.E.GUI.CommandBars.XTPToolBarFlags.xtpFlagStretched );

            Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup l_ControlFile = null;
            l_ControlFile = l_RibbonBar.AddSystemButton();
            l_ControlFile.IconId = ResourceId.ID_SYSTEM_ICON;
            l_ControlFile.CommandBar.SetIconSize( 32, 32 );

            l_ControlFile.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_NEW, "新建(&N)", false, false );
            l_ControlFile.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_OPEN, "打开(&O)...", false, false );
            
            Demo_G.O.S.E.GUI.CommandBars.CommandBarControl l_Control = null;
            l_Control = l_ControlFile.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_PRINT_SETUP, "页面设置(&U)...", false, false );
            l_Control.BeginGroup = true;

            l_Control = l_ControlFile.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_MRU_FILE1, "最近的文件(&F)", false, false );
            l_Control.Enabled = false;
            l_Control.BeginGroup = true;

            l_Control = l_ControlFile.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_APP_EXIT, "退出(&X)", false, false );
            l_Control.BeginGroup = true;

            Demo_G.O.S.E.GUI.CommandBars.CommandBarControl ControlAbout = null;
            ControlAbout = l_RibbonBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_APP_ABOUT, "关于(&A)", false, false );
            ControlAbout.Flags = Demo_G.O.S.E.GUI.CommandBars.XTPControlFlags.xtpFlagRightAlign;

            //----------------------------------------------------------------------------------------------------------
            Demo_G.O.S.E.GUI.CommandBars.RibbonTab l_TabHome = l_RibbonBar.InsertTab( 0, "主页(&H)" );
            l_TabHome.Id = ResourceId.ID_TAB_HOME;

            Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupFile = null;
            l_GroupFile = l_TabHome.Groups.AddGroup( "文件", ResourceId.ID_GROUP_FILE );
            l_GroupFile.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_NEW, "新建(&N)", false, false );
            l_GroupFile.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_OPEN, "打开(&O)", false, false );
            l_GroupFile.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_CLOSE, "关闭(&C)", false, false );

            Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup l_ControlSaveAs = null;
            l_ControlSaveAs = (Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup)l_GroupFile.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlSplitButtonPopup, ResourceId.ID_FILE_SAVE, "保存(&S)", false, false );
            l_ControlSaveAs.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_SAVE, "保存(&S)", false, false );
            l_ControlSaveAs.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_SAVE_AS, "另存为(&A)...", false, false );

            Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup l_ControlPrint = null;
            l_ControlPrint = (Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup)l_GroupFile.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlSplitButtonPopup, ResourceId.ID_FILE_PRINT, "打印(&P)", false, false );
            l_ControlPrint.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_PRINT, "打印(&P)", false, false );
            l_ControlPrint.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_PRINT_SETUP, "页面设置(&U)...", false, false );
            l_ControlPrint.BeginGroup = true;
            //----------------------------------------------------------------------------------------------------------



            //----------------------------------------------------------------------------------------------------------
            Demo_G.O.S.E.GUI.CommandBars.RibbonTab l_TabEdit = l_RibbonBar.InsertTab( 1, "编辑(&E)" );
            l_TabEdit.Id = ResourceId.ID_TAB_EDIT;

            //Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupClipboard = l_TabEdit.Groups.AddGroup( "剪贴板", Resource.ID_GROUP_CLIPBOARD );
            //l_GroupClipboard.ShowOptionButton = true;
            //l_GroupClipboard.IconId = Resource.ID_EDIT_PASTE;
            //l_GroupClipboard.ControlGroupOption.TooltipText = "显示剪贴板对话框";

            //l_GroupClipboard.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_EDIT_CUT, "剪切(&C)", false, false );
            //l_GroupClipboard.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_EDIT_COPY, "复制(&C)", false, false );
            
            //l_Control = l_GroupClipboard.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_FORMAT_PAINTER, "Format Painter", false, false );
            //l_Control.Enabled = false;

            //Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup l_ControlPaste = null;
            //l_ControlPaste = (Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup)l_GroupClipboard.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlSplitButtonPopup, Resource.ID_EDIT_PASTE, "粘贴(&P)", false, false );
            //l_ControlPaste.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_EDIT_PASTE, "粘贴(&P)", false, false );
            //l_ControlPaste.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_EDIT_PASTE_SPECIAL, "&Paste Special", false, false );

            //Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupEditing = null;
            //l_GroupEditing = l_TabEdit.Groups.AddGroup( "编辑项", Resource.ID_GROUP_EDITING );
            //l_GroupEditing.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_EDIT_FIND, "查找(&F)", false, false );
            //l_GroupEditing.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_EDIT_REPLACE, "替换(&R)", false, false );

            //l_Control = l_GroupEditing.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_EDIT_GOTO, "转到(&G)", false, false );
            //l_Control.Enabled = false;

            //Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup l_ControlSelect = null;
            //l_ControlSelect = (Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup)l_GroupEditing.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlPopup, Resource.ID_EDIT_SELECT, "选择(&S)", false, false );
            //l_ControlSelect.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, Resource.ID_EDIT_SELECT_ALL, "选择全部", false, false );

            //l_TabEdit.Visible = false;
            //----------------------------------------------------------------------------------------------------------


            //----------------------------------------------------------------------------------------------------------
            Demo_G.O.S.E.GUI.CommandBars.RibbonTab l_TabView = l_RibbonBar.InsertTab( 2, "视图(&V)" );
            l_TabView.Id = ResourceId.ID_TAB_VIEW;

            Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupDocumentViews = null;
            l_GroupDocumentViews = l_TabView.Groups.AddGroup( "文档视图", ResourceId.ID_GROUP_DOCUMENTVIEWS );

            l_Control = l_GroupDocumentViews.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_VIEW_NORMAL, "通常(&N)", false, false );
            l_Control.Checked = true;

            l_GroupDocumentViews.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_PRINT_PREVIEW, "打印预览", false, false );
            l_GroupDocumentViews.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_VIEW_FULLSCREEN, "全屏(&F)", false, false );

            Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupShowHide = null;
            l_GroupShowHide = l_TabView.Groups.AddGroup( "显示/隐藏", ResourceId.ID_GROUP_SHOWHIDE );
            l_GroupShowHide.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlCheckBox, ResourceId.ID_VIEW_STATUS_BAR, "状态栏", false, false );
            l_GroupShowHide.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlCheckBox, ResourceId.ID_VIEW_WORKSPACE, "工作区域", false, false );

            Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupWindow = null;
            l_GroupWindow = l_TabView.Groups.AddGroup( "窗口", ResourceId.ID_GROUP_WINDOW );
            l_GroupWindow.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_WINDOW_NEW, "新建窗口", false, false );
            l_GroupWindow.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_WINDOW_ARRANGE, "Arrange Icons", false, false );
            
            Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup l_ControlPopup = null;
            l_ControlPopup = (Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup)l_GroupWindow.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlPopup, ResourceId.ID_WINDOW_SWITCH, "Switch Windows", false, false );
            l_ControlPopup.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, (int)Demo_G.O.S.E.GUI.CommandBars.XTPCommandBarsSpecialCommands.XTP_ID_WINDOWLIST, "Item 1", false, false );
            //----------------------------------------------------------------------------------------------------------



            //----------------------------------------------------------------------------------------------------------
            Demo_G.O.S.E.GUI.CommandBars.RibbonTab l_TabPrintPreview = l_RibbonBar.InsertTab( 3, "&Print Preview" );
            l_TabPrintPreview.Id = ResourceId.ID_TAB_PRINT_PREVIEW;

            Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupPrint = null;
            l_GroupPrint = l_TabPrintPreview.Groups.AddGroup( "Print", ResourceId.ID_GROUP_PRINT );

            l_GroupPrint.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_PRINT, "Print", false, false );
            l_GroupPrint.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_PRINT_OPTIONS, "Options", false, false );

            Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupPageSetup = null;
            l_GroupPageSetup = l_TabPrintPreview.Groups.AddGroup( "Page Setup", ResourceId.ID_GROUP_PAGESETUP );
            l_GroupPageSetup.ShowOptionButton = true;

            l_ControlPopup = (Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup)l_GroupPageSetup.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlPopup, ResourceId.ID_PREVIEW_PAGESETUP_MARGINS, "Margins", false, false );
            l_ControlPopup.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_MARGINS_CUSTOM_MARGINS, "Custom M&argins...", false, false );

            l_ControlPopup = (Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup)l_GroupPageSetup.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlPopup, ResourceId.ID_PREVIEW_PAGESETUP_ORIENTATION, "Orientation", false, false );
            l_ControlPopup.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_ORIENTATION_PORTRAIT, "Portrait", false, false );
            l_ControlPopup.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_ORIENTATION_LANDSCAPE, "Landscape", false, false );

            l_ControlPopup = (Demo_G.O.S.E.GUI.CommandBars.CommandBarPopup)l_GroupPageSetup.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlPopup, ResourceId.ID_PREVIEW_PAGESETUP_SIZE, "Size", false, false );
            l_ControlPopup.CommandBar.Controls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_SIZE_MORE_PAPER_SIZES, "More P&aper Sizes...", false, false );

            Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupZoom = null;
            l_GroupZoom = l_TabPrintPreview.Groups.AddGroup( "Zoom", ResourceId.ID_GROUP_ZOOM );
            l_GroupZoom.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_ZOOM_ZOOM, "Zoom", false, false );
            l_GroupZoom.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_ZOOM_100_PERCENT, "100%", false, false );
            l_GroupZoom.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_ZOOM_1PAGE, "One Page", false, false );
            l_GroupZoom.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_ZOOM_2PAGES, "Two Pages", false, false );
            l_GroupZoom.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_ZOOM_PAGE_WIDTH, "Page Width", false, false );

            Demo_G.O.S.E.GUI.CommandBars.RibbonGroup l_GroupPreview = null;
            l_GroupPreview = l_TabPrintPreview.Groups.AddGroup( "Preview", ResourceId.ID_GROUP_PREVIEW );
            l_GroupPreview.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlCheckBox, ResourceId.ID_PREVIEW_PREVIEW_RULER, "Show Ruler", false, false );
            l_GroupPreview.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlCheckBox, ResourceId.ID_PREVIEW_PREVIEW_MAGNIFIER, "Magnifier", false, false );
            l_GroupPreview.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_PREVIEW_SHRINK, "Shrink One Page", false, false );
            l_GroupPreview.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_PREVIEW_NEXT, "Next Page", false, false );
            l_GroupPreview.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_PREVIEW_PREVIOUS, "Previous Page", false, false );
            
            l_Control = l_GroupPreview.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_PREVIEW_PREVIEW_CLOSE, "Close Print Preview", false, false );
            l_Control.BeginGroup = true;

            //l_TabPrintPreview.Visible = false;
            //----------------------------------------------------------------------------------------------------------

            l_RibbonBar.QuickAccessControls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_SAVE, "保存(&S)", false, false );
            l_RibbonBar.QuickAccessControls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_EDIT_UNDO, "撤消(&U)", false, false );
            l_RibbonBar.QuickAccessControls.Add( Demo_G.O.S.E.GUI.CommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_PRINT, "打印(&P)", false, false );
        }

    }
}