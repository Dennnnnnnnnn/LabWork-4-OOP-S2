//FormTask.cs
using System.IO;
using System.Windows.Forms;

namespace L4
{
    /// <summary>
    /// Represents a form that displays a PDF or document 
    /// using the WebBrowser control.
    /// </summary>
    public partial class FormTask : Form
    {
        /// <summary>
        /// The filename of the document to be displayed.
        /// </summary>
        public string filename = null;

        /// <summary>
        /// Initializes a new instance of the FormTask class.
        /// </summary>
        /// <param name="filename">The name of file to be displayed.</param>
        public FormTask(string filename)
        {
            InitializeComponent();
            this.filename = filename;
            ShowDocument(filename); // Load and show the document
        }

        /// <summary>
        /// Displays the specified document in the WebBrowser control.
        /// </summary>
        /// <param name="filename">The path to the file to be displayed.</param>
        private void ShowDocument(string filename)
        {
            try
            {
                // Get the absolute path to the file
                string path = Path.GetFullPath(filename);
                // Navigate the WebBrowser control to the document
                webBrowser1.Navigate(path);
            }
            catch
            {
                MessageBox.Show("Error occurred!");
            }
        }
    }
}
