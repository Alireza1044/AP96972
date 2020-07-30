namespace CodedUITestProject1
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
	using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

	public static class UIMapListBoxUtility
    {
        public static void SelectAnotherValue(WpfList control)
        {
            var currentValue = UIMapListBoxUtility.GetSelectedValue(control);

            var allValues = UIMapListBoxUtility.GetListOfItems(control);

            string newValue = null;

            foreach (string item in allValues)
            {
                if (item != currentValue)
                {
                    newValue = item;
                }
            }

            control.SelectedItemsAsString = newValue;
        }

        public static string GetSelectedValue(WpfList control)
        {
            return control.SelectedItemsAsString;
        }

        public static List<string> GetListOfItems(WpfList control)
        {
            UITestControlCollection items =
                control.GetProperty("Items") as
                UITestControlCollection;

            List<string> values = new List<string>();

            foreach (WinListItem item in items)
            {
                values.Add(item.DisplayText);
            }

            return values;
        }
    }
}
