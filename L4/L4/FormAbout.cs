//FormAbout.cs
using System;
using System.Windows.Forms;

namespace L4
{
    /// <summary>
    /// Represents the "About" form that displays current time and statistics 
    /// about how many times buttons have been clicked in the main form.
    /// </summary>
    public partial class FormAbout : Form
    {
        private Form1 mainForm = null;
        private Timer timeShow;
        private GenericDoublyLinkedList<Button> StatisticalMetrics;

        /// <summary>
        /// Initializes a new instance of the FormAbout class.
        /// </summary>
        /// <param name="callingForm">The main form that 
        /// opened this form.</param>
        /// <param name="Stats">A list containing button 
        /// usage statistics.</param>
        public FormAbout(Form callingForm, GenericDoublyLinkedList<Button> Stats)
        {
            InitializeComponent();
            StatisticalMetrics = Stats;

            mainForm = callingForm as Form1;
            timeShow = new Timer();
            timeShow.Interval = 1000; // Tick every second
            timeShow.Tick += Timer_Tick;
            timeShow.Start();
            UpdateTime();
            FillDataGrid();
        }

        /// <summary>
        /// Handles the timer tick event to update the time display.
        /// </summary>
        /// <param name="sender">The timer object.</param>
        /// <param name="e">Event arguments.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        /// <summary>
        /// Updates the label with the current time.
        /// </summary>
        private void UpdateTime()
        {
            label2.Text = "Time: " + DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Populates the DataGridView with button click statistics.
        /// </summary>
        private void FillDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var value in StatisticalMetrics)
            {
                dataGridView1.Rows.Add(value.ButtonName, value.TimesClicked);
            }
        }

        /// <summary>
        /// Opens a new form to display the task PDF file.
        /// </summary>
        /// <param name="e">Link clicked event arguments.</param>
        /// <param name="sender">The link label control.</param>
        private void LinkRead_LinkClicked
            (object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string filename = "task.pdf";
                FormTask formTask = new FormTask(filename);
                formTask.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred!");
            }
        }

        /// <summary>
        /// Closes the About form when the OK button is clicked.
        /// </summary>
        /// <param name="sender">The OK button.</param>
        /// <param name="e">Click event arguments.</param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
