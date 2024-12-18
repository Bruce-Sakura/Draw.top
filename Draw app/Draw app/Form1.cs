using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

/// Designer name:Wang Yongji
/// Date: Dec. 12/14/2024
/// Version :  lastest
/// Description:Draw app

namespace Draw_app
{
    public partial class Draw : Form
    {
        private Pen Pen; // Pen object used for drawing lines
        private Color penColor = Color.Black; // The color of the pen, default is black
        private float penWidth = 2; // The width of the pen, default is 2
        float eraserSize = 10; // The size of the eraser, default is 10
        private bool isMouseDown = false; // A flag to check if the mouse is pressed down
        private bool isEraserMode = false; // A flag to determine if eraser mode is active
        private DrawMode currentMode = DrawMode.None; // The current drawing mode (e.g., drawing or erasing)
        private int pictureBox1_width; // The width of the picture box where the drawing happens
        private int pictureBox1_height; // The height of the picture box where the drawing happens
        private Point startPoint; // The starting point of the drawing
        private Point endPoint; // The ending point of the drawing
        private List<Point> currentLine = new List<Point>(); // List of points that represents the current drawn line

        private List<Point> eraserLine = new List<Point>(); // List of points that represents the current erased line (for eraser tool)

        private Bitmap im, im2; // Bitmap objects for the current image and an additional image for undo/redo purposes
        //private Bitmap ereaseBitmap;
        private Graphics g; // Graphics object used for drawing on the Bitmap
        private Stack<Bitmap> history; // Stack for storing drawing history for undo functionality
        private Stack<Bitmap> redoHistory; // Stack for storing redo history, in case the user wants to redo the last undone action

        // Enum to define different drawing modes
        private enum DrawMode
        {
            None, // No drawing mode selected
            Line, // Drawing mode for lines
            Ellipse, // Drawing mode for ellipses
            Rectangle, // Drawing mode for rectangles
            FreeDraw, // Freehand drawing mode
            Triangle, // Drawing mode for triangles
            EraserShaper // Eraser drawing mode
        }

        // Constructor for initializing the drawing settings
        public Draw()
        {
            InitializeComponent(); // Initialize the form and its components
            Pen = new Pen(penColor, penWidth); // Initialize the pen with the selected color and width
            pictureBox1_width = pictureBox1.Width; // Get the width of the picture box for drawing
            pictureBox1_height = pictureBox1.Height; // Get the height of the picture box for drawing
        }

        // Event handler when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            button_free_draw.Focus();
            button_free_draw.PerformClick(); // Automatically trigger free draw mode when the form loads
            label_show_pen_size.Text = penWidth.ToString(); // Display the current pen size in the label
            toolStripStatusLabel_show_pensize.Text = penWidth.ToString(); // Show pen size in the status bar
            toolStripStatusLabel_show_color.BackColor = penColor; // Set the background color of the color indicator in the status bar
            toolStripStatusLabel_show_color.Text = string.Empty; // Clear the text in the color status label
            toolStripStatusLabel_show_color_name.Text = penColor.Name; // Display the name of the current pen color in the status bar

            im = new Bitmap(pictureBox1.Width, pictureBox1.Height); // Create a new bitmap for drawing based on the picture box size
            im2 = new Bitmap(im); // Create a copy of the bitmap for undo/redo functionality
            g = Graphics.FromImage(im); // Create a Graphics object from the bitmap to perform drawing operations
            history = new Stack<Bitmap>(); // Initialize the history stack for undo functionality
            redoHistory = new Stack<Bitmap>(); // Initialize the redo history stack for redo functionality
            SaveHistory(); // Save the current state to the history stack
            pictureBox1.Image = im; // Set the picture box's image to the current bitmap for displaying the drawing
            pictureBox1.Refresh(); // Refresh the picture box to display the updated image


            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

        }

        // Method to save the current drawing state to the history stack for undo functionality
        private void SaveHistory()
        {
            history.Push(new Bitmap(im)); // Push the current image as a bitmap into the history stack
        }

        // Event handler for mouse button down event on the drawing area
        private void panel_draw_area_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if drawing mode is not 'None' and the left mouse button is pressed
            if (currentMode != DrawMode.None && e.Button == MouseButtons.Left) // fix!!!
            {
                startPoint = e.Location; // Capture the starting point of the mouse
                isMouseDown = true; // Set flag to true indicating mouse is pressed
                if (currentMode == DrawMode.FreeDraw) // If in FreeDraw mode, initialize the drawing line
                {
                    currentLine.Clear(); // Clear any previous lines
                    currentLine.Add(startPoint); // Add the starting point to the line
                }
                else if (currentMode == DrawMode.EraserShaper)
                {
                    eraserLine.Clear();
                    eraserLine.Add(startPoint);
                }
                SaveHistory(); // Save the current drawing state to the history stack
            }
        }

        // Event handler for mouse movement on the drawing area
        private void panel_draw_area_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if the mouse is pressed (drawing)
            if (isMouseDown)
            {
                endPoint = e.Location; // Capture the current mouse position as the end point
                im2 = new Bitmap(im); // Make a copy of the current image for the redo functionality
                Shape shape = null; // Variable to hold the shape being drawn

                // Set the drawing surface (Graphics object) based on the drawing mode
                if (currentMode == DrawMode.FreeDraw || currentMode == DrawMode.EraserShaper)
                    g = Graphics.FromImage(im); // For FreeDraw or Eraser, use the current image
                else
                    g = Graphics.FromImage(im2); // For other shapes, use the copied image (for redo)

                // Switch between different drawing modes
                switch (currentMode)
                {
                    case DrawMode.Line:
                        shape = new Line(startPoint, endPoint, penColor, penWidth); // Draw a line
                        break;
                    case DrawMode.Rectangle:
                        shape = new MyRectangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked); // Draw a rectangle
                        break;
                    case DrawMode.Ellipse:
                        shape = new Ellipse(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked); // Draw an ellipse
                        break;
                    case DrawMode.Triangle:
                        shape = new Triangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked); // Draw a triangle
                        break;
                    case DrawMode.FreeDraw:
                        currentLine.Add(endPoint); // Add the current mouse position to the line points
                        if (currentLine.Count > 2)
                            shape = new FreeDrawLine(currentLine, penColor, penWidth); // Draw freehand line if enough points are collected
                        break;
                    case DrawMode.EraserShaper:
                        // Define the size of the eraser shape and create a rectangle for it
                        //Rectangle eraserRect = new Rectangle(
                        //    (int)(e.X - eraserSize / 2), // Calculate the top-left X position of the eraser
                        //    (int)(e.Y - eraserSize / 2), // Calculate the top-left Y position of the eraser
                        //    (int)eraserSize, // Set the width of the eraser
                        //    (int)eraserSize // Set the height of the eraser
                        //);
                        //shape = new Eraser(eraserRect, eraserSize); // Create an EraserShape object with the calculated rectangle
                        eraserLine.Add(endPoint);
                        if (eraserLine.Count > 2)
                        {

                            shape = new Eraser(eraserLine, eraserSize); 
                        }
                        break;

                }

                // If a shape was created, draw it on the graphics object
                if (shape != null) shape.Draw(g);

                // Update the image in the picture box based on the current mode
                if (currentMode == DrawMode.FreeDraw || currentMode == DrawMode.EraserShaper)
                    pictureBox1.Image = im; // For FreeDraw or Eraser, update with the current image
                else
                    pictureBox1.Image = im2; // For other shapes, update with the copied image for redo functionality

                // Refresh the picture box to show the updated drawing
                pictureBox1.Refresh();
            }
        }


        // Event handler for mouse button up event on the drawing area
        private void panel_draw_area_MouseUp(object sender, MouseEventArgs e)
        {
            // Check if the mouse button was previously pressed (drawing was in progress)
            if (isMouseDown)
            {
                isMouseDown = false; // Set the flag to false to indicate that mouse is no longer pressed
                endPoint = e.Location; // Capture the current mouse location as the end point
                Shape shape = null; // Variable to hold the shape that will be drawn
                g = Graphics.FromImage(im); // Use the current image as the drawing surface

                // Switch between different drawing modes to create the appropriate shape
                switch (currentMode)
                {
                    case DrawMode.Line:
                        shape = new Line(startPoint, endPoint, penColor, penWidth); // Create a line shape
                        break;
                    case DrawMode.Rectangle:
                        shape = new MyRectangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked); // Create a rectangle shape, considering whether it should be filled
                        break;
                    case DrawMode.Ellipse:
                        shape = new Ellipse(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked); // Create an ellipse shape, considering whether it should be filled
                        break;
                    case DrawMode.Triangle:
                        shape = new Triangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked); // Create a triangle shape, considering whether it should be filled
                        break;
                }

                // If a shape was created, draw it on the graphics object
                if (shape != null) shape.Draw(g);

                pictureBox1.Image = im; // Update the picture box with the latest image (which now includes the new shape)
                pictureBox1.Refresh(); // Refresh the picture box to reflect the updated image
            }
        }

        // Event handler for the "Clear" button click
        private void button_clear_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            SaveHistory();  // Save the current drawing state to history for undo functionality
            g.Clear(Color.White);  // Clear the canvas by filling it with white color
                                   //currentMode = DrawMode.None; // Optionally reset drawing mode (currently commented out)
                                   //UpdateButtonStates(null); // Optionally update button states (currently commented out)
            pictureBox1.Refresh();  // Refresh the picture box to reflect the cleared canvas
        }

        // Event handler for the "Line" button click to set drawing mode to "Line"
        private void button_LINE_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            checkBox1_fill.Enabled = false;  // Disable the "fill" checkbox (not applicable for lines)
            checkBox1_fill.Checked = false;  // Uncheck the "fill" checkbox (not applicable for lines)
            currentMode = DrawMode.Line;  // Set the current drawing mode to "Line"
            UpdateButtonStates(button_LINE); // Update button states to reflect the selected mode
        }

        // Event handler for the "Ellipse" button click to set drawing mode to "Ellipse"
        private void button_Ellipse_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            checkBox1_fill.Enabled = true;  // Enable the "fill" checkbox (applicable for ellipses)
            currentMode = DrawMode.Ellipse;  // Set the current drawing mode to "Ellipse"
            UpdateButtonStates(button_Ellipse); // Update button states to reflect the selected mode
        }

        // Event handler for the "Rectangle" button click to set drawing mode to "Rectangle"
        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            checkBox1_fill.Enabled = true;  // Enable the "fill" checkbox (applicable for rectangles)
            currentMode = DrawMode.Rectangle;  // Set the current drawing mode to "Rectangle"
            UpdateButtonStates(button_Rectangle); // Update button states to reflect the selected mode
        }

        // Event handler for the "Free Draw" button click to set drawing mode to "Free Draw"
        private void button_free_draw_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            checkBox1_fill.Enabled = false;  // Disable the "fill" checkbox (not applicable for free draw)
            checkBox1_fill.Checked = false;  // Uncheck the "fill" checkbox (not applicable for free draw)
            currentMode = DrawMode.FreeDraw;  // Set the current drawing mode to "Free Draw"
            UpdateButtonStates(button_free_draw); // Update button states to reflect the selected mode
        }

        // Method to update the state of drawing buttons, highlighting the selected one
        private void UpdateButtonStates(Button selectedButton)
        {
            // Reset the background color of all buttons to default
            button_LINE.BackColor = SystemColors.Control;
            button_Ellipse.BackColor = SystemColors.Control;
            button_Rectangle.BackColor = SystemColors.Control;
            button_free_draw.BackColor = SystemColors.Control;

            // Set the background color of the selected button to indicate it is active
            selectedButton.BackColor = Color.LightGray;
        }

        // Event handler for the "Black Pen" button click
        private void button_pen_black_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            penColor = Color.Black;  // Set the pen color to black
            toolStripStatusLabel_show_color.BackColor = penColor;  // Update the status bar color to black
            toolStripStatusLabel_show_color_name.Text = penColor.Name;  // Update the status bar with the pen color name
        }

        // Event handler for the "Red Pen" button click
        private void button_pen_red_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            penColor = Color.Red;  // Set the pen color to red
            toolStripStatusLabel_show_color.BackColor = penColor;  // Update the status bar color to red
            toolStripStatusLabel_show_color_name.Text = penColor.Name;  // Update the status bar with the pen color name
        }

        // Event handler for the "Increase Pen Size" button click
        private void button_pen_size_up_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            if (penWidth < 9)
            {
                penWidth += 1; // Increase the pen width by 1 each time the button is clicked
                button_pen_size_down.Enabled = true;  // Enable the "Decrease Pen Size" button
            }
            else
            {
                penWidth = 10;  // Set pen width to the maximum value of 10
                button_pen_size_up.Enabled = false;  // Disable the "Increase Pen Size" button
            }
            label_show_pen_size.Text = penWidth.ToString();  // Update the pen size label
            toolStripStatusLabel_show_pensize.Text = penWidth.ToString();  // Update the status bar with the pen size
        }

        // Event handler for the "Decrease Pen Size" button click
        private void button_pen_size_down_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            if (penWidth > 2)
            {
                penWidth -= 1;  // Decrease the pen width by 1 each time the button is clicked, with a minimum value of 1
                button_pen_size_up.Enabled = true;  // Enable the "Increase Pen Size" button
            }
            else
            {
                penWidth = 1;  // Set pen width to the minimum value of 1
                button_pen_size_down.Enabled = false;  // Disable the "Decrease Pen Size" button
            }
            label_show_pen_size.Text = penWidth.ToString();  // Update the pen size label
            toolStripStatusLabel_show_pensize.Text = penWidth.ToString();  // Update the status bar with the pen size
        }

        // Event handler for the "Eraser" button click to enable eraser mode
        private void button_eraser_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = true;  // Show the eraser size adjustment control

            checkBox1_fill.Enabled = false;  // Disable the "fill" checkbox (not applicable in eraser mode)
            checkBox1_fill.Checked = false;  // Uncheck the "fill" checkbox
            currentMode = DrawMode.EraserShaper; // Set the current drawing mode to "Eraser" (corrected mode)
            UpdateButtonStates((Button)sender); // Update button states to reflect the selected mode
        }

        // Event handler for the "Undo" button click to undo the last drawing action
        private void button_undo_Click(object sender, EventArgs e)
        {
            if (history.Count > 0)
            {
                redoHistory.Push(new Bitmap(im));  // Save the current drawing state to the redo history
                im = history.Pop();  // Pop the last drawing state from the history
                g = Graphics.FromImage(im);  // Create a Graphics object from the new image
                pictureBox1.Image = im;  // Update the picture box with the new image
                pictureBox1.Refresh();  // Refresh the picture box to display the changes
            }
        }


        // Event handler for the "Triangle" button click, which sets the drawing mode to "Triangle"
        private void button_Triangle_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            checkBox1_fill.Enabled = true;  // Enable the "fill" checkbox (if needed for triangles)
            currentMode = DrawMode.Triangle;  // Set the drawing mode to "Triangle"
            UpdateButtonStates(button_Triangle);  // Update the button states to reflect the selected mode
        }

        // Event handler for the "Redo" button click, which redoes the last undone action
        private void button_redo_Click(object sender, EventArgs e)
        {
            if (redoHistory.Count > 0)
            {
                history.Push(new Bitmap(im));  // Save the current state to history
                im = redoHistory.Pop();  // Get the last undone image state from redo history
                g = Graphics.FromImage(im);  // Create a new Graphics object from the new image
                pictureBox1.Image = im;  // Update the picture box with the new image
                pictureBox1.Refresh();  // Refresh the picture box to display the changes
            }
        }

        // Event handler for the color picker button click, allowing the user to select a new pen color
        private void colorEdit_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the selected color from the color dialog
                Color selectedColor = colorDialog1.Color;

                // Set the pen color to the selected color
                penColor = selectedColor;
            }
            toolStripStatusLabel_show_color.BackColor = penColor;  // Update the status bar to show the selected color
            toolStripStatusLabel_show_color_name.Text = penColor.Name;  // Display the color name in the status bar
        }

        // Event handler for the "Save JPG" button click, which allows the user to save the drawing as an image
        private void button_save_jpg_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // Hide the eraser size adjustment control

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set the filter for saving image files (PNG or JPEG)
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the current image to the selected file
                    im.Save(saveFileDialog.FileName);
                }
            }
        }

        // Event handler for the "Exit" menu item click, which exits the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Close the application
        }

        // Event handler for the "Save File" menu item click, which allows the user to save the drawing as an image
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set the filter for saving image files (PNG or JPEG)
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the current image to the selected file
                    im.Save(saveFileDialog.FileName);
                }
            }
        }

        // Abstract base class for shapes
        private abstract class Shape
        {
            public Color PenColor { get; set; }  // The color of the pen used for drawing the shape
            public float PenWidth { get; set; }  // The width of the pen
            public bool IsFilled { get; set; }  // Whether the shape should be filled

            // Abstract method for drawing the shape (to be implemented by derived classes)
            public abstract void Draw(Graphics g);
        }

        // Line class that represents a line shape
        private class Line : Shape
        {
            public Point Start { get; set; }  // The start point of the line
            public Point End { get; set; }  // The end point of the line

            // Constructor to initialize the line with start and end points, color, and width
            public Line(Point start, Point end, Color color, float width)
            {
                Start = start;
                End = end;
                PenColor = color;
                PenWidth = width;
            }

            // Override the Draw method to draw the line on the given Graphics object
            public override void Draw(Graphics g)
            {
                using (Pen pen = new Pen(PenColor, PenWidth))  // Create a new pen with the specified color and width
                {
                    g.DrawLine(pen, Start, End);  // Draw the line on the graphics object
                }
            }
        }


        // MyRectangle class represents a rectangle shape.
        private class MyRectangle : Shape
        {
            public Rectangle Bounds { get; }  // The bounding rectangle for the shape

            // Constructor to initialize the rectangle with start and end points, color, width, and fill option.
            public MyRectangle(Point start, Point end, Color color, float width, bool isFilled)
            {
                // Calculate the bounding rectangle's top-left corner and size based on start and end points
                Bounds = new Rectangle(
                    Math.Min(start.X, end.X),  // X coordinate of the top-left corner
                    Math.Min(start.Y, end.Y),  // Y coordinate of the top-left corner
                    Math.Abs(end.X - start.X), // Width of the rectangle
                    Math.Abs(end.Y - start.Y)  // Height of the rectangle
                );
                PenColor = color;  // Set the pen color
                PenWidth = width;  // Set the pen width
                IsFilled = isFilled;  // Set whether the rectangle should be filled or not
            }

            // Override the Draw method to draw the rectangle on the given Graphics object
            public override void Draw(Graphics g)
            {
                if (IsFilled)  // If the shape is filled
                {
                    using (Brush brush = new SolidBrush(PenColor))  // Create a brush with the pen color
                    {
                        g.FillRectangle(brush, Bounds);  // Fill the rectangle with the brush
                    }
                }
                else  // If the shape is not filled
                {
                    using (Pen pen = new Pen(PenColor, PenWidth))  // Create a pen with the specified color and width
                    {
                        g.DrawRectangle(pen, Bounds);  // Draw the rectangle's outline
                    }
                }
            }
        }
        // Ellipse class represents an ellipse shape.
        private class Ellipse : Shape
        {
            public Rectangle Bounds { get; }  // The bounding rectangle for the ellipse

            // Constructor to initialize the ellipse with start and end points, color, width, and fill option.
            public Ellipse(Point start, Point end, Color color, float width, bool isFilled)
            {
                // Calculate the bounding rectangle's top-left corner and size based on start and end points
                Bounds = new Rectangle(
                    Math.Min(start.X, end.X),  // X coordinate of the top-left corner
                    Math.Min(start.Y, end.Y),  // Y coordinate of the top-left corner
                    Math.Abs(end.X - start.X), // Width of the ellipse (distance between start and end X)
                    Math.Abs(end.Y - start.Y)  // Height of the ellipse (distance between start and end Y)
                );
                PenColor = color;  // Set the pen color
                PenWidth = width;  // Set the pen width
                IsFilled = isFilled;  // Set whether the ellipse should be filled or not
            }

            // Override the Draw method to draw the ellipse on the given Graphics object
            public override void Draw(Graphics g)
            {
                if (IsFilled)  // If the shape is filled
                {
                    using (Brush brush = new SolidBrush(PenColor))  // Create a brush with the pen color
                    {
                        g.FillEllipse(brush, Bounds);  // Fill the ellipse with the brush
                    }
                }
                else  // If the shape is not filled
                {
                    using (Pen pen = new Pen(PenColor, PenWidth))  // Create a pen with the specified color and width
                    {
                        g.DrawEllipse(pen, Bounds);  // Draw the ellipse's outline
                    }
                }
            }
        }


        // Triangle class represents a triangle shape.
        private class Triangle : Shape
        {
            public Point[] Vertices { get; }  // Array of points representing the vertices of the triangle

            // Constructor to initialize the triangle with start and end points, color, width, and fill option.
            public Triangle(Point start, Point end, Color color, float width, bool isFilled)
            {
                // Define the vertices of the triangle based on the start and end points.
                // The triangle is assumed to be an isosceles triangle with its top vertex at the midpoint of the start and end X coordinates.
                Vertices = new Point[]
                {
            new Point((start.X + end.X) / 2, start.Y),  // Top vertex (midpoint of the X-axis and the start Y)
            new Point(start.X, end.Y),  // Bottom-left vertex (start X, end Y)
            new Point(end.X, end.Y)     // Bottom-right vertex (end X, end Y)
                };
                PenColor = color;  // Set the pen color
                PenWidth = width;  // Set the pen width
                IsFilled = isFilled;  // Set whether the triangle should be filled or not
            }

            // Override the Draw method to draw the triangle on the given Graphics object
            public override void Draw(Graphics g)
            {
                if (IsFilled)  // If the shape is filled
                {
                    using (Brush brush = new SolidBrush(PenColor))  // Create a brush with the pen color
                    {
                        g.FillPolygon(brush, Vertices);  // Fill the triangle using the brush
                    }
                }
                else  // If the shape is not filled
                {
                    using (Pen pen = new Pen(PenColor, PenWidth))  // Create a pen with the specified color and width
                    {
                        g.DrawPolygon(pen, Vertices);  // Draw the triangle's outline
                    }
                }
            }
        }


        // This event is triggered when the value of the eraser size trackbar changes
        private void trackBar_eraser_size_ValueChanged(object sender, EventArgs e)
        {
            // Update the eraser size with the current value of the trackbar
            eraserSize = trackBar_eraser_size.Value;
        }


        // This event is triggered when the "AI Everywhere" menu item is clicked
        private void aIEveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Define the URL to open
            string url = "https://aieverywhere.top";

            // Open the URL in the default web browser
            System.Diagnostics.Process.Start(url);
        }



        //private class FreeDrawLine : Shape
        //{
        //    public List<Point> Points { get; }

        //    public FreeDrawLine(List<Point> points, Color color, float width)
        //    {
        //        Points = points;
        //        PenColor = color;
        //        PenWidth = width;
        //    }

        //    public override void Draw(Graphics g) //fix!!!
        //    {
        //        using (Pen pen = new Pen(PenColor, PenWidth))
        //        {
        //            g.DrawCurve(pen, Points.ToArray());
        //        }
        //    }
        //}
        // Represents a free-drawn line shape, allowing multiple points to be connected
        private class FreeDrawLine : Shape
        {
            public List<Point> Points { get; }  // List of points representing the free-drawn line
            public Color PenColor { get; set; }  // Pen color
            public float PenWidth { get; set; }  // Pen width

            // Constructor to initialize the points, color, and width of the free-drawn line
            public FreeDrawLine(List<Point> points, Color color, float width)
            {
                Points = points;
                PenColor = color;
                PenWidth = width;
            }

            // Draw the free-drawn line on the graphics context
            public override void Draw(Graphics g)
            {
                // Enable anti-aliasing to smooth the lines
                g.SmoothingMode = SmoothingMode.AntiAlias;

                if (Points.Count > 1)
                {
                    // Use a Pen to draw the line, connecting multiple points
                    using (Pen pen = new Pen(PenColor, PenWidth))
                    {
                        // Set the start and end cap for the line to round
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;

                        // Set the line join to smooth for connecting segments
                        pen.LineJoin = LineJoin.Round;

                        // Draw the line by connecting the points in the list
                        g.DrawLines(pen, Points.ToArray());
                    }
                }
            }
        }

        // Represents an eraser shape that removes a portion of the drawing
        //private class EraserShape : Shape
        //{
        //    public Rectangle EraseArea { get; }  // The area to be erased

        //    // Constructor to initialize the eraser shape with an erase area
        //    public EraserShape(Rectangle eraseArea)
        //    {
        //        EraseArea = eraseArea;
        //        PenColor = Color.White;  // Set the pen color to white to erase
        //    }

        //    // Draw the eraser shape (i.e., erase a portion of the image)
        //    public override void Draw(Graphics g)
        //    {
        //        // Enable anti-aliasing to smooth the lines
        //        g.SmoothingMode = SmoothingMode.AntiAlias;

        //        // Set the start and end cap for the line to round
        //        //pen.StartCap = LineCap.Round;
        //        //pen.EndCap = LineCap.Round;

        //        // Use a white brush to "erase" by drawing a white rectangle
        //        Brush brush = new SolidBrush(PenColor);
        //        g.FillRectangle(brush, EraseArea);  // Erase by filling the rectangle with white
        //    }
        //}

        // Define an Eraser class, inheriting from Shape
        private class Eraser : Shape
        {
            // Property: Stores the collection of points forming the eraser path
            public List<Point> Points { get; }

            // Property: Eraser color (fixed to white)
            public Color EraseColor { get; } = Color.White;

            // Property: Eraser width (fixed size)
            public float EraserSize { get; }

            // Constructor: Initializes the path points, color, and size of the eraser
            public Eraser(List<Point> points, float eraserSize)
            {
                // Create a new list to ensure each instance holds its own path
                Points = new List<Point>(points);
                EraserSize = eraserSize;
            }

            // Method: Draws the eraser path
            public override void Draw(Graphics g)
            {
                // Enable anti-aliasing for smoother eraser paths
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Only draw if there are at least two points to form a path
                if (Points.Count > 1)
                {
                    // Use a Pen to simulate the eraser effect
                    using (Pen erasePen = new Pen(EraseColor, EraserSize))
                    {
                        // Set line caps and joints to be rounded for smoother edges
                        erasePen.StartCap = LineCap.Round;
                        erasePen.EndCap = LineCap.Round;
                        erasePen.LineJoin = LineJoin.Round;

                        // Draw the eraser effect along the path points
                        g.DrawLines(erasePen, Points.ToArray());
                    }
                }
            }
        }

    }
}


