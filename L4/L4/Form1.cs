//Form1.cs
using System;
using System.IO;
using System.Windows.Forms;

namespace L4
{
    public partial class Form1 : Form
    {
        string File1; // File path for rectangle data
        string File2; // File path for triangle data

        // List of rectangles
        GenericDoublyLinkedList<Rectangle> Rectangles;
        // List of triangles
        GenericDoublyLinkedList<Triangle> Triangles;

        // Tracks clicks per feature
        GenericDoublyLinkedList<Button> StatisticalMetrics = 
            new GenericDoublyLinkedList<Button>(); 

        /// <summary>
        /// Initializes the form and sets up default values and UI state.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ToggleControls();
            Rectangles = new GenericDoublyLinkedList<Rectangle>();
            Triangles = new GenericDoublyLinkedList<Triangle>();
        }

        /// <summary>
        /// Loads rectangle data from a file and displays it.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event data.</param>
        private void RectanglesToolStripMenuItem_Click
            (object sender, EventArgs e)
        {
            UpdateButtonsData("Rectangles");
            openFileDialog1.Title = "Open initial data file: Students.txt";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files|*.txt|Word Documents|*.doc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File1 = openFileDialog1.FileName;
                try
                {
                    Rectangles = IOUtils.ReadRectangles(File1);
                    Display("Initial data: rectangles" + 
                        Environment.NewLine, Rectangle.Header(), 
                        Rectangle.Footer(), Rectangles);
                    ToggleControls(true);
                }
                catch (Exception)
                {
                    ToggleControls(false);
                }
            }
        }

        /// <summary>
        /// Loads triangle data from a file and displays it.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event data.</param>
        private void TrianglesToolStripMenuItem_Click
            (object sender, EventArgs e)
        {
            UpdateButtonsData("Triangles");
            openFileDialog1.Title = "Open initial data file: Students.txt";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files|*.txt|Word Documents|*.doc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File2 = openFileDialog1.FileName;
                try
                {
                    Triangles = IOUtils.ReadTriangles(File2);
                    Display("Initial data: triangles" + 
                        Environment.NewLine, Triangle.Header(), 
                        Triangle.Footer(), Triangles);
                    ToggleControls(true);
                }
                catch (Exception)
                {
                    ToggleControls(false);
                }
            }
        }

        /// <summary>
        /// Finds rectangles containing exactly one triangle 
        /// vertex and displays them.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event data.</param>
        private void Task1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateButtonsData("Task 1");
            GenericDoublyLinkedList<RectangleOneTriangleVertex> 
                RectanglesWithOneTriangleVertex = 
                TaskUtils.OneTriangleVertexInside(Rectangles, Triangles);
            RectanglesWithOneTriangleVertex.Sort();
            Display("Rectangles with exactly one triangle " +
                "vertex inside the rectangle: " + Environment.NewLine, 
                RectangleOneTriangleVertex.Header(), 
                RectangleOneTriangleVertex.Footer(), 
                RectanglesWithOneTriangleVertex);
        }

        /// <summary>
        /// Finds triangles fully inside rectangles and displays them.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event data.</param>
        private void Task2ToolStripMenuItem_Click
            (object sender, EventArgs e)
        {
            UpdateButtonsData("Task 2");
            GenericDoublyLinkedList<TriangleInsideRectangle> 
                TrianglesInsideRectangle = TaskUtils.TriangleInsideRectangle
                (Rectangles, Triangles);
            TrianglesInsideRectangle.Sort();
            Display("Rectangles with triangles inside: " + Environment.NewLine, 
                TriangleInsideRectangle.Header(), TriangleInsideRectangle.Footer(), 
                TrianglesInsideRectangle);
        }

        /// <summary>
        /// Finds and compares the largest rectangle and triangle by area.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event data.</param>
        private void Task3ToolStripMenuItem_Click
            (object sender, EventArgs e)
        {
            UpdateButtonsData("Task 3");
            Rectangle largestRectangle = TaskUtils.LargestObject<Rectangle>(Rectangles);
            Triangle largestTriangle = TaskUtils.LargestObject<Triangle>(Triangles);
            double rectangleArea = 0;
            double triangleArea = 0;

            if (largestRectangle != null)
            {
                rectangleArea = largestRectangle.Area();
                richTextBox1.AppendText($"The biggest rectangle: " +
                    $"{largestRectangle.RectangleName} with area " +
                    $"{rectangleArea}" + Environment.NewLine);
            }
            else
            {
                richTextBox1.AppendText($"No biggest rectangle was found" + 
                    Environment.NewLine);
            }

            if (largestTriangle != null)
            {
                triangleArea = largestTriangle.Area();
                richTextBox1.AppendText($"The biggest triangle: " +
                    $"{largestTriangle.TriangleName} with area {triangleArea}" +
                    Environment.NewLine);
            }
            else
            {
                richTextBox1.AppendText($"No biggest triangle was found" + 
                    Environment.NewLine);
            }

            if (largestTriangle != null && largestRectangle != null)
            {
                double difference = Math.Abs(rectangleArea - triangleArea);
                if (rectangleArea > triangleArea)
                {
                    richTextBox1.AppendText($"Rectangle " +
                        $"{largestRectangle.RectangleName} is larger than " +
                        $"{largestTriangle.TriangleName} by {difference} " +
                        $"square units" + Environment.NewLine);
                }
                else if (rectangleArea < triangleArea)
                {
                    richTextBox1.AppendText($"Triangle " +
                        $"{largestTriangle.TriangleName} is larger than " +
                        $"{largestRectangle.RectangleName} by {difference} " +
                        $"square units" + Environment.NewLine);
                }
                else
                {
                    richTextBox1.AppendText("Triangle's and rectangle's " +
                        "areas are equal" + Environment.NewLine);
                }
            }
            else
            {
                richTextBox1.AppendText("Cannot compare null objects" + 
                    Environment.NewLine);
            }
        }

        /// <summary>
        /// Updates or creates a statistical entry for specified button name.
        /// </summary>
        /// <param name="data">The name of the button or feature clicked.</param>
        private void UpdateButtonsData(string data)
        {
            bool found = false;

            foreach (Button b in StatisticalMetrics)
            {
                if (b.ButtonName == data)
                {
                    b.TimesClicked++;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                StatisticalMetrics.AddToEnd(new Button(data, 1));
            }
        }

        /// <summary>
        /// Displays the About form and tracks its access.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event data.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateButtonsData("About");
            FormAbout formAbout = new FormAbout(this, StatisticalMetrics);
            formAbout.Show();
        }

        /// <summary>
        /// Saves the content of the result box to a file.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event data.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateButtonsData("Save");
            saveFileDialog1.Title = "Save your results";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files|*.txt|Word Documents|*.doc";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // File path to save results
                string FileResults = saveFileDialog1.FileName; 
                using (StreamWriter writer = 
                    new StreamWriter(FileResults, false))
                {
                    foreach (string item in richTextBox1.Lines)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event data.</param>
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
