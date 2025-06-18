//Form1.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace L4
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Enables or disables the control buttons based on the passed flag.
        /// </summary>
        public void ToggleControls(bool enabled = false)
        {
            saveToolStripMenuItem.Enabled = enabled; // Save menu item
            task1ToolStripMenuItem.Enabled = enabled; // Task 1 menu item
            task2ToolStripMenuItem.Enabled = enabled; // Task 2 menu item
            task3ToolStripMenuItem.Enabled = enabled; // Task 3 menu item
        }

        /// <summary>
        /// Displays the formatted output of data entries in the rich text box.
        /// </summary>
        /// <typeparam name="T">Generic type implementing IComparable and 
        /// IEquatable.</typeparam>
        /// <param name="header">Section header string.</param>
        /// <param name="tableHeader">Table header string.</param>
        /// <param name="tableFooter">Table footer string.</param>
        /// <param name="data">Enumerable list of elements to display.</param>
        public void Display<T>(string header, string tableHeader, 
            string tableFooter, IEnumerable<T> data) 
            where T : IComparable<T>, IEquatable<T>
        {
            richTextBox1.AppendText(header); 

            if (data.Count() > 0)
            {
                richTextBox1.AppendText(tableHeader); 

                foreach (T element in data)
                {
                    richTextBox1.AppendText(element.ToString() + 
                        Environment.NewLine); 
                }

                richTextBox1.AppendText(tableFooter); 
                richTextBox1.AppendText("\n"); 
            }
            else
            {
                richTextBox1.AppendText("No data to display" + 
                    Environment.NewLine);
            }
        }
    }
}
