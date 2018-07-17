﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 15.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace CodedUITestProject1
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
	using System.IO;
	using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// RecordedMethod1 - Use 'RecordedMethod1Params' to pass parameters into this method.
        /// </summary>
        public void RecordedMethod1()
        {
            #region Variable Declarations
            WinListItem uIFinalProjectexeListItem = this.UIDebugWindow.UIItemWindow.UIItemsViewList.UIFinalProjectexeListItem;
            WpfButton uIItemButton = this.UIMainWindowWindow.UIItemButton;
            WpfEdit uINoteTitleTextBoxEdit = this.UINoteManagerWindow.UINoteTitleTextBoxEdit;
            WpfEdit uINoteDescriptionTextBEdit = this.UINoteManagerWindow.UINoteDescriptionTextBEdit;
            WpfButton uIItemButton1 = this.UINoteManagerWindow.UIItemButton;
            #endregion

            // Double-Click 'FinalProject.exe' list item
            Mouse.DoubleClick(uIFinalProjectexeListItem, new Point(40, 98));

            // Click '+' button
            Mouse.Click(uIItemButton, new Point(48, 44));

            // Type 'this is it!' in 'NoteTitleTextBox' text box
            uINoteTitleTextBoxEdit.Text = this.RecordedMethod1Params.UINoteTitleTextBoxEditText;

            // Type 'this is the test' in 'NoteDescriptionTextBox' text box
            uINoteDescriptionTextBEdit.Text = this.RecordedMethod1Params.UINoteDescriptionTextBEditText;

            // Click '+' button
            Mouse.Click(uIItemButton1, new Point(42, 42));
        }
		private static string CalculateApplicationPath()
		{

			var appDir = NUnit.Framework.TestContext.CurrentContext.TestDirectory;
			appDir += @"/../../../FinalProject/bin/Debug";
			var applicationPath = Path.Combine(appDir, "FinalProject.exe");
			return applicationPath;
		}
		/// <summary>
		/// RecordedMethod2 - Use 'RecordedMethod2Params' to pass parameters into this method.
		/// </summary>
		public void RecordedMethod2()
        {
			#region Variable Declarations
			System.Diagnostics.Process.Start(CalculateApplicationPath());
			WpfWindow uIWpfWindow = this.UIWpfWindow;
            WpfEdit uINoteTitleTextBoxEdit = this.UINoteManagerWindow.UINoteTitleTextBoxEdit;
            WpfButton uIItemButton = this.UINoteManagerWindow.UIItemButton;
            WpfEdit uINoteDescriptionTextBEdit = this.UINoteManagerWindow.UINoteDescriptionTextBEdit;
            #endregion

            // Click 'Wpf' window
            Mouse.Click(uIWpfWindow, new Point(39, 20));

            // Click 'Wpf' window
            Mouse.Click(uIWpfWindow, new Point(219, 83));

            // Type 'this is it' in 'NoteTitleTextBox' text box
            uINoteTitleTextBoxEdit.Text = this.RecordedMethod2Params.UINoteTitleTextBoxEditText;

            // Type '{Tab}' in 'NoteTitleTextBox' text box
            Keyboard.SendKeys(uINoteTitleTextBoxEdit, this.RecordedMethod2Params.UINoteTitleTextBoxEditSendKeys, ModifierKeys.None);

            // Type 'th' in '+' button
            Keyboard.SendKeys(uIItemButton, this.RecordedMethod2Params.UIItemButtonSendKeys, ModifierKeys.None);

            // Click 'Wpf' window
            Mouse.Click(uIWpfWindow, new Point(300, 259));

            // Type 'thi' in 'NoteDescriptionTextBox' text box
            uINoteDescriptionTextBEdit.Text = this.RecordedMethod2Params.UINoteDescriptionTextBEditText;

            // The control is not available or not valid.

            // Type 'this is the test' in 'NoteDescriptionTextBox' text box
            uINoteDescriptionTextBEdit.Text = this.RecordedMethod2Params.UINoteDescriptionTextBEditText1;

            // Click 'Wpf' window
            Mouse.Click(uIWpfWindow, new Point(14, 25));

            // Click 'Wpf' window
            Mouse.Click(uIWpfWindow, new Point(53, 53));
        }
        
        #region Properties
        public virtual RecordedMethod1Params RecordedMethod1Params
        {
            get
            {
                if ((this.mRecordedMethod1Params == null))
                {
                    this.mRecordedMethod1Params = new RecordedMethod1Params();
                }
                return this.mRecordedMethod1Params;
            }
        }
        
        public virtual RecordedMethod2Params RecordedMethod2Params
        {
            get
            {
                if ((this.mRecordedMethod2Params == null))
                {
                    this.mRecordedMethod2Params = new RecordedMethod2Params();
                }
                return this.mRecordedMethod2Params;
            }
        }
        
        public UIDebugWindow UIDebugWindow
        {
            get
            {
                if ((this.mUIDebugWindow == null))
                {
                    this.mUIDebugWindow = new UIDebugWindow();
                }
                return this.mUIDebugWindow;
            }
        }
        
        public UIMainWindowWindow UIMainWindowWindow
        {
            get
            {
                if ((this.mUIMainWindowWindow == null))
                {
                    this.mUIMainWindowWindow = new UIMainWindowWindow();
                }
                return this.mUIMainWindowWindow;
            }
        }
        
        public UINoteManagerWindow UINoteManagerWindow
        {
            get
            {
                if ((this.mUINoteManagerWindow == null))
                {
                    this.mUINoteManagerWindow = new UINoteManagerWindow();
                }
                return this.mUINoteManagerWindow;
            }
        }
        
        public UIWpfWindow UIWpfWindow
        {
            get
            {
                if ((this.mUIWpfWindow == null))
                {
                    this.mUIWpfWindow = new UIWpfWindow();
                }
                return this.mUIWpfWindow;
            }
        }
        #endregion
        
        #region Fields
        private RecordedMethod1Params mRecordedMethod1Params;
        
        private RecordedMethod2Params mRecordedMethod2Params;
        
        private UIDebugWindow mUIDebugWindow;
        
        private UIMainWindowWindow mUIMainWindowWindow;
        
        private UINoteManagerWindow mUINoteManagerWindow;
        
        private UIWpfWindow mUIWpfWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'RecordedMethod1'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class RecordedMethod1Params
    {
        
        #region Fields
        /// <summary>
        /// Type 'this is it!' in 'NoteTitleTextBox' text box
        /// </summary>
        public string UINoteTitleTextBoxEditText = "this is it!";
        
        /// <summary>
        /// Type 'this is the test' in 'NoteDescriptionTextBox' text box
        /// </summary>
        public string UINoteDescriptionTextBEditText = "this is the test";
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'RecordedMethod2'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class RecordedMethod2Params
    {
        
        #region Fields
        /// <summary>
        /// Type 'this is it' in 'NoteTitleTextBox' text box
        /// </summary>
        public string UINoteTitleTextBoxEditText = "this is it";
        
        /// <summary>
        /// Type '{Tab}' in 'NoteTitleTextBox' text box
        /// </summary>
        public string UINoteTitleTextBoxEditSendKeys = "{Tab}";
        
        /// <summary>
        /// Type 'th' in '+' button
        /// </summary>
        public string UIItemButtonSendKeys = "th";
        
        /// <summary>
        /// Type 'thi' in 'NoteDescriptionTextBox' text box
        /// </summary>
        public string UINoteDescriptionTextBEditText = "thi";
        
        /// <summary>
        /// Type 'this is the test' in 'NoteDescriptionTextBox' text box
        /// </summary>
        public string UINoteDescriptionTextBEditText1 = "this is the test";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIDebugWindow : WinWindow
    {
        
        public UIDebugWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Debug";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "CabinetWClass";
            this.WindowTitles.Add("Debug");
            #endregion
        }
        
        #region Properties
        public UIItemWindow UIItemWindow
        {
            get
            {
                if ((this.mUIItemWindow == null))
                {
                    this.mUIItemWindow = new UIItemWindow(this);
                }
                return this.mUIItemWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIItemWindow mUIItemWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIItemWindow : WinWindow
    {
        
        public UIItemWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.AccessibleName] = "Items View";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "DirectUIHWND";
            this.WindowTitles.Add("Debug");
            #endregion
        }
        
        #region Properties
        public UIItemsViewList UIItemsViewList
        {
            get
            {
                if ((this.mUIItemsViewList == null))
                {
                    this.mUIItemsViewList = new UIItemsViewList(this);
                }
                return this.mUIItemsViewList;
            }
        }
        #endregion
        
        #region Fields
        private UIItemsViewList mUIItemsViewList;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIItemsViewList : WinList
    {
        
        public UIItemsViewList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinList.PropertyNames.Name] = "Items View";
            this.WindowTitles.Add("Debug");
            #endregion
        }
        
        #region Properties
        public WinListItem UIFinalProjectexeListItem
        {
            get
            {
                if ((this.mUIFinalProjectexeListItem == null))
                {
                    this.mUIFinalProjectexeListItem = new WinListItem(this);
                    #region Search Criteria
                    this.mUIFinalProjectexeListItem.SearchProperties[WinListItem.PropertyNames.Name] = "FinalProject.exe";
                    this.mUIFinalProjectexeListItem.WindowTitles.Add("Debug");
                    #endregion
                }
                return this.mUIFinalProjectexeListItem;
            }
        }
        #endregion
        
        #region Fields
        private WinListItem mUIFinalProjectexeListItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIMainWindowWindow : WpfWindow
    {
        
        public UIMainWindowWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "MainWindow";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("MainWindow");
            #endregion
        }
        
        #region Properties
        public WpfButton UIItemButton
        {
            get
            {
                if ((this.mUIItemButton == null))
                {
                    this.mUIItemButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIItemButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "AddBtnMain";
                    this.mUIItemButton.WindowTitles.Add("MainWindow");
                    #endregion
                }
                return this.mUIItemButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfButton mUIItemButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UINoteManagerWindow : WpfWindow
    {
        
        public UINoteManagerWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "NoteManager";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("NoteManager");
            #endregion
        }
        
        #region Properties
        public WpfEdit UINoteTitleTextBoxEdit
        {
            get
            {
                if ((this.mUINoteTitleTextBoxEdit == null))
                {
                    this.mUINoteTitleTextBoxEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUINoteTitleTextBoxEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "NoteTitleTextBox";
                    this.mUINoteTitleTextBoxEdit.WindowTitles.Add("NoteManager");
                    #endregion
                }
                return this.mUINoteTitleTextBoxEdit;
            }
        }
        
        public WpfEdit UINoteDescriptionTextBEdit
        {
            get
            {
                if ((this.mUINoteDescriptionTextBEdit == null))
                {
                    this.mUINoteDescriptionTextBEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUINoteDescriptionTextBEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "NoteDescriptionTextBox";
                    this.mUINoteDescriptionTextBEdit.WindowTitles.Add("NoteManager");
                    #endregion
                }
                return this.mUINoteDescriptionTextBEdit;
            }
        }
        
        public WpfButton UIItemButton
        {
            get
            {
                if ((this.mUIItemButton == null))
                {
                    this.mUIItemButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIItemButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "AddBtnEdit";
                    this.mUIItemButton.WindowTitles.Add("NoteManager");
                    #endregion
                }
                return this.mUIItemButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfEdit mUINoteTitleTextBoxEdit;
        
        private WpfEdit mUINoteDescriptionTextBEdit;
        
        private WpfButton mUIItemButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIWpfWindow : WpfWindow
    {
        
        public UIWpfWindow()
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            #endregion
        }
    }
}
