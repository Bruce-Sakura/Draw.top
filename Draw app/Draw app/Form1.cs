using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

/// Designer name:Wang Yongji
/// Date: Dec. 12/14/2024
/// Version :  lastest
/// Description:Draw app

namespace Draw_app
{
    public partial class Draw : Form
    {
        private Pen Pen;
        private Color penColor = Color.Black;
        private float penWidth = 2;
        float eraserSize = 10;
        private bool isMouseDown = false;
        private bool isEraserMode = false;
        private DrawMode currentMode = DrawMode.None;
        private int pictureBox1_width;
        private int pictureBox1_height;
        private Point startPoint;
        private Point endPoint;
        private List<Point> currentLine = new List<Point>();
        private Bitmap im, im2;
        private Graphics g;
        private Stack<Bitmap> history, redoHistory;


        private enum DrawMode
        {
            None,
            Line,
            Ellipse,
            Rectangle,
            FreeDraw,
            Triangle,
            EraserShaper
        }

        public Draw()
        {
            InitializeComponent();
            Pen = new Pen(penColor, penWidth);
            pictureBox1_width = pictureBox1.Width;
            pictureBox1_height = pictureBox1.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_free_draw.PerformClick();
            label_show_pen_size.Text = penWidth.ToString();
            toolStripStatusLabel_show_pensize.Text = penWidth.ToString();
            toolStripStatusLabel_show_color.BackColor = penColor;
            toolStripStatusLabel_show_color.Text = string.Empty;
            toolStripStatusLabel_show_color_name.Text = penColor.Name;

            im = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            im2 = new Bitmap(im);
            g = Graphics.FromImage(im);
            history = new Stack<Bitmap>();
            redoHistory = new Stack<Bitmap>();
            SaveHistory();
            pictureBox1.Image = im;
            pictureBox1.Refresh();
        
        }
        private void SaveHistory()
        {
            history.Push(new Bitmap(im));
        }

        private void panel_draw_area_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentMode != DrawMode.None && e.Button == MouseButtons.Left) // fix!!!
            {
                startPoint = e.Location;
                isMouseDown = true;
                if (currentMode == DrawMode.FreeDraw)
                {
                    currentLine.Clear();
                    currentLine.Add(startPoint);
                }
                SaveHistory();
            }
        }

        private void panel_draw_area_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                endPoint = e.Location;
                im2 = new Bitmap(im);
                Shape shape = null;
                if (currentMode == DrawMode.FreeDraw || currentMode == DrawMode.EraserShaper) g = Graphics.FromImage(im);
                else g = Graphics.FromImage(im2);
                switch (currentMode)
                {
                    case DrawMode.Line:
                        shape = new Line(startPoint, endPoint, penColor, penWidth);
                        break;
                    case DrawMode.Rectangle:
                        shape = new MyRectangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked);
                        break;
                    case DrawMode.Ellipse:
                        shape = new Ellipse(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked);
                        break;
                    case DrawMode.Triangle:
                        shape = new Triangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked); 
                        break;
                    case DrawMode.FreeDraw:
                        currentLine.Add(endPoint);
                        if (currentLine.Count > 2) shape = new FreeDrawLine(currentLine, penColor, penWidth);
                        break;
                    case DrawMode.EraserShaper:
                        //float eraserSize = penWidth * 5; // 橡皮擦大小可调整
                        Rectangle eraserRect = new Rectangle(
                            (int)(e.X - eraserSize / 2),
                            (int)(e.Y - eraserSize / 2),
                            (int)eraserSize,
                            (int)eraserSize
                        );
                        shape = new EraserShape(eraserRect);
                        break;
                }
                if (shape!= null) shape.Draw(g);
                if (currentMode == DrawMode.FreeDraw || currentMode == DrawMode.EraserShaper) pictureBox1.Image = im;
                else pictureBox1.Image = im2;
            
                pictureBox1.Refresh();
            }
        }

        private void panel_draw_area_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                isMouseDown = false;
                endPoint = e.Location;
                Shape shape = null;
                g = Graphics.FromImage(im);
                switch (currentMode)
                {
                    case DrawMode.Line:
                        shape = new Line(startPoint, endPoint, penColor, penWidth);
                        break;
                    case DrawMode.Rectangle:
                        shape = new MyRectangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked);
                        break;
                    case DrawMode.Ellipse:
                        shape = new Ellipse(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked);
                        break;
                    case DrawMode.Triangle:
                        shape = new Triangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked);
                        break;
                }
                
                if (shape != null) shape.Draw(g);
                pictureBox1.Image = im;
                pictureBox1.Refresh();
            }
        }



        private void button_clear_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            SaveHistory();
            g.Clear(Color.White);
            //currentMode = DrawMode.None;
            //UpdateButtonStates(null);
            pictureBox1.Refresh();
        }

        // 点击“直线”按钮时，设置绘图模式为“直线”
        private void button_LINE_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            checkBox1_fill.Enabled = false;
            checkBox1_fill.Checked = false;
            currentMode = DrawMode.Line;
            UpdateButtonStates(button_LINE); // 更新按钮状态
        }

        // 点击“椭圆”按钮时，设置绘图模式为“椭圆”
        private void button_Ellipse_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            checkBox1_fill.Enabled = true;
            currentMode = DrawMode.Ellipse;
            UpdateButtonStates(button_Ellipse); // 更新按钮状态
        }

        // 点击“矩形”按钮时，设置绘图模式为“矩形”
        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            checkBox1_fill.Enabled = true;
            currentMode = DrawMode.Rectangle;
            UpdateButtonStates(button_Rectangle); // 更新按钮状态
        }

        // 点击自由绘画按钮时，设置绘图模式为“自由绘画”
        private void button_free_draw_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            checkBox1_fill.Enabled = false;
            checkBox1_fill.Checked = false;
            currentMode = DrawMode.FreeDraw;
            UpdateButtonStates(button_free_draw); // 更新按钮状态
        }

        // 用于更新按钮的状态，使当前按钮保持选中状态
        private void UpdateButtonStates(Button selectedButton)
        {
            // 重置所有按钮的背景颜色
            button_LINE.BackColor = SystemColors.Control;
            button_Ellipse.BackColor = SystemColors.Control;
            button_Rectangle.BackColor = SystemColors.Control;
            button_free_draw.BackColor = SystemColors.Control;

            // 将当前按钮背景颜色设置为选中状态
            selectedButton.BackColor = Color.LightGray;
        }

        // 点击黑色画笔按钮
        private void button_pen_black_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            penColor = Color.Black;  // 设置画笔为黑色
            toolStripStatusLabel_show_color.BackColor = penColor;
            toolStripStatusLabel_show_color_name.Text = penColor.Name;
        }

        // 点击红色画笔按钮
        private void button_pen_red_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            penColor = Color.Red;  // 设置画笔为红色
            toolStripStatusLabel_show_color.BackColor = penColor;
            toolStripStatusLabel_show_color_name.Text = penColor.Name;
        }

        // 点击“加粗画笔”按钮，增加画笔的粗细
        private void button_pen_size_up_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            if (penWidth < 9) 
            {
                penWidth += 1; // 每次点击增加画笔宽度
                button_pen_size_down.Enabled = true;
            }
            else
            {
                penWidth = 10;
                button_pen_size_up.Enabled = false;
            }
            label_show_pen_size.Text = penWidth.ToString();
            toolStripStatusLabel_show_pensize.Text = penWidth.ToString();
        }

        // 点击“减小画笔”按钮，减小画笔的粗细
        private void button_pen_size_down_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            if (penWidth > 2)
            {
                penWidth -= 1;  // 每次点击减小画笔宽度，最小值为 1
                button_pen_size_up.Enabled = true;
            }
            else
            {
                penWidth = 1;
                button_pen_size_down.Enabled = false;
            }
            label_show_pen_size.Text = penWidth.ToString();
            toolStripStatusLabel_show_pensize.Text = penWidth.ToString();
        }

        private void button_eraser_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = true;  // 启用橡皮擦大小调整控件

            checkBox1_fill.Enabled = false;
            checkBox1_fill.Checked = false;
            currentMode = DrawMode.EraserShaper; // fix:改为橡皮擦模式
            UpdateButtonStates((Button)sender); // 更新按钮状态
        }

        private void button_undo_Click(object sender, EventArgs e)
        {
            if (history.Count > 0)
            {
                redoHistory.Push(new Bitmap(im));
                im = history.Pop();
                g = Graphics.FromImage(im);
                pictureBox1.Image = im;
                pictureBox1.Refresh();
            }
        }

        private void button_Triangle_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件checkBox1_fill.Enabled = true;
            currentMode = DrawMode.Triangle;
            UpdateButtonStates(button_Triangle); // 更新按钮状态
        }
        private void button_redo_Click(object sender, EventArgs e)
        {
            if (redoHistory.Count > 0)
            {
                history.Push(new Bitmap(im));
                im = redoHistory.Pop();
                g = Graphics.FromImage(im);
                pictureBox1.Image = im;
                pictureBox1.Refresh();
            }
        }

        private void colorEdit_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // 更新选定的颜色
                Color selectedColor = colorDialog1.Color; // 获取选定颜色

                // 更新显示的颜色
                //stsColor.BackColor = selectedColor;

                // 设置 Pen 的颜色
                penColor = selectedColor;
            }
            toolStripStatusLabel_show_color.BackColor = penColor;
            toolStripStatusLabel_show_color_name.Text = penColor.Name;
        }

        private void button_save_jpg_Click(object sender, EventArgs e)
        {
            trackBar_eraser_size.Visible = false;  // 禁止用橡皮擦大小调整控件

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    im.Save(saveFileDialog.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    im.Save(saveFileDialog.FileName);
                }
            }
        }

        private abstract class Shape
        {
            public Color PenColor { get; set; }
            public float PenWidth { get; set; }
            public bool IsFilled { get; set; }

            public abstract void Draw(Graphics g);

            
        }

        private class Line : Shape
        {
            public Point Start { get; set; }
            public Point End { get; set; }

            public Line(Point start, Point end, Color color, float width)
            {
                Start = start;
                End = end;
                PenColor = color;
                PenWidth = width;
            }

            public override void Draw(Graphics g)
            {
                using (Pen pen = new Pen(PenColor, PenWidth))
                {
                    g.DrawLine(pen, Start, End);
                }
            }
        }

        private class MyRectangle : Shape
        {
            public Rectangle Bounds { get; }

            public MyRectangle(Point start, Point end, Color color, float width, bool isFilled)
            {
                Bounds = new Rectangle(
                    Math.Min(start.X, end.X),
                    Math.Min(start.Y, end.Y),
                    Math.Abs(end.X - start.X),
                    Math.Abs(end.Y - start.Y)
                );
                PenColor = color;
                PenWidth = width;
                IsFilled = isFilled;
            }

            public override void Draw(Graphics g)
            {
                if (IsFilled)
                {
                    using (Brush brush = new SolidBrush(PenColor))
                    {
                        g.FillRectangle(brush, Bounds);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(PenColor, PenWidth))
                    {
                        g.DrawRectangle(pen, Bounds);
                    }
                }
            }
        }

        private class Ellipse : Shape
        {
            public Rectangle Bounds { get; }

            public Ellipse(Point start, Point end, Color color, float width, bool isFilled)
            {
                Bounds = new Rectangle(
                    Math.Min(start.X, end.X),
                    Math.Min(start.Y, end.Y),
                    Math.Abs(end.X - start.X),
                    Math.Abs(end.Y - start.Y)
                );
                PenColor = color;
                PenWidth = width;
                IsFilled = isFilled;
            }

            public override void Draw(Graphics g)
            {
                if (IsFilled)
                {
                    using (Brush brush = new SolidBrush(PenColor))
                    {
                        g.FillEllipse(brush, Bounds);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(PenColor, PenWidth))
                    {
                        g.DrawEllipse(pen, Bounds);
                    }
                }
            }
        }

        private class Triangle : Shape
        {
            public Point[] Vertices { get; }

            public Triangle(Point start, Point end, Color color, float width, bool isFilled)
            {
                Vertices = new Point[]
                {
                    new Point((start.X + end.X) / 2, start.Y),
                    new Point(start.X, end.Y),
                    new Point(end.X, end.Y)
                };
                PenColor = color;
                PenWidth = width;
                IsFilled = isFilled;
            }

            public override void Draw(Graphics g)
            {
                if (IsFilled)
                {
                    using (Brush brush = new SolidBrush(PenColor))
                    {
                        g.FillPolygon(brush, Vertices);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(PenColor, PenWidth))
                    {
                        g.DrawPolygon(pen, Vertices);
                    }
                }
            }
        }

        private void trackBar_eraser_size_ValueChanged(object sender, EventArgs e)
        {
            eraserSize = trackBar_eraser_size.Value;
        }

        private void aIEveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://aieverywhere.top";
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
        private class FreeDrawLine : Shape
        {
            public List<Point> Points { get; }
            public Color PenColor { get; set; }
            public float PenWidth { get; set; }

            public FreeDrawLine(List<Point> points, Color color, float width)
            {
                Points = points;
                PenColor = color;
                PenWidth = width;
            }

            public override void Draw(Graphics g)
            {
                // 设置抗锯齿
                g.SmoothingMode = SmoothingMode.AntiAlias;

                if (Points.Count > 1)
                {
                    // 使用 Pen 来绘制线条
                    using (Pen pen = new Pen(PenColor, PenWidth))
                    {
                        // 使用 Graphics.DrawLines 方法绘制直线，连接多个点
                        g.DrawLines(pen, Points.ToArray());
                    }
                }
            }
        }

        private class EraserShape : Shape
        {
            public Rectangle EraseArea { get; }

            public EraserShape(Rectangle eraseArea)
            {
                EraseArea = eraseArea;
                PenColor = Color.White;
            }

            public override void Draw(Graphics g)
            {
                Brush brush = new SolidBrush(PenColor);
                g.FillRectangle(brush, EraseArea);
            }
        }
        
    }
}
