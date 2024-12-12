using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw_app
{

    public partial class Form1 : Form
    {
        private Pen Pen; // 确保在类中声明 Pen 对象
        private bool isMouseDown = false;

        private enum DrawMode { None, Line, Ellipse, Rectangle, FreeDraw, Triangle }
        private DrawMode currentMode = DrawMode.None;
        private Point startPoint;
        private Point endPoint;
        private Color penColor = Color.Black;  // 默认画笔颜色
        private float penWidth = 2;  // 默认画笔宽度为 2
        // 存储自由绘制的线条（连续的点）
        private List<Point> currentLine = new List<Point>();

        // 存储已绘制的图形
        private List<Shape> shapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
            // 确保事件正确绑定
            this.panel_draw_area.MouseDown += new MouseEventHandler(panel_draw_area_MouseDown);
            this.panel_draw_area.MouseMove += new MouseEventHandler(panel_draw_area_MouseMove);
            this.panel_draw_area.MouseUp += new MouseEventHandler(panel_draw_area_MouseUp);
            this.panel_draw_area.Paint += new PaintEventHandler(panel_draw_area_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_free_draw.PerformClick();
            label_show_pen_size.Text = penWidth.ToString();

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panel_draw_area, new object[] { true });

        }
        //建自定义 Panel 类
        public class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                this.DoubleBuffered = true;
                this.ResizeRedraw = true; // 窗口调整时自动重绘
            }
        }


        // 创建一个基类 Shape，代表不同的图形
        private abstract class Shape
        {
            public Color PenColor { get; set; } // 每个图形的颜色
            public float PenWidth { get; set; } // 每个图形的笔触宽度
            public bool IsFilled { get; set; } // 是否填充
            public abstract void Draw(Graphics g);  // 不需要传递颜色和宽度，因为颜色和宽度已在图形中保存
        }

        // 直线类
        private class Line : Shape
        {
            public Point Start { get; }
            public Point End { get; }

            public Line(Point start, Point end, Color color, float width)
            {
                Start = start;
                End = end;
                PenColor = color;
                PenWidth = width;
            }

            public override void Draw(Graphics g)
            {
                g.DrawLine(new Pen(PenColor, PenWidth), Start, End);  // 使用图形自带的颜色和宽度
            }
        }

        // 自定义矩形类（避免与 System.Drawing.Rectangle 冲突）
        private class MyRectangle : Shape
        {
            public System.Drawing.Rectangle Bounds { get; }

            public MyRectangle(Point start, Point end, Color color, float width, bool isFilled)
            {
                var width_ = Math.Abs(end.X - start.X);
                var height = Math.Abs(end.Y - start.Y);
                var x = Math.Min(start.X, end.X);
                var y = Math.Min(start.Y, end.Y);
                Bounds = new System.Drawing.Rectangle(x, y, width_, height);
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


        // 三角形类
        private class Triangle : Shape
        {
            // 三角形顶点数组
            public Point[] Vertices { get; private set; }
            public bool IsFilled { get; private set; }

            // 构造函数
            public Triangle(Point start, Point end, Color color, float width, bool isFilled)
            {
                // 根据起点和终点计算三角形的三个顶点
                int midX = (start.X + end.X) / 2; // 底边中点的 X 坐标
                Vertices = new Point[]
                {
            new Point(midX, start.Y),    // 顶点
            new Point(start.X, end.Y),  // 左下角
            new Point(end.X, end.Y)     // 右下角
                };

                PenColor = color;
                PenWidth = width;
                IsFilled = isFilled;
            }

            // 绘制方法
            public override void Draw(Graphics g)
            {
                if (IsFilled)
                {
                    // 使用填充模式绘制三角形
                    using (Brush brush = new SolidBrush(PenColor))
                    {
                        g.FillPolygon(brush, Vertices);
                    }
                }
                else
                {
                    // 使用轮廓模式绘制三角形
                    using (Pen pen = new Pen(PenColor, PenWidth))
                    {
                        g.DrawPolygon(pen, Vertices);
                    }
                }
            }
        }


        // 椭圆
        private class Ellipse : Shape
        {
            public Rectangle Bounds { get; }

            public Ellipse(Point start, Point end, Color color, float width, bool isFilled)
            {
                var width_ = Math.Abs(end.X - start.X);
                var height = Math.Abs(end.Y - start.Y);
                var x = Math.Min(start.X, end.X);
                var y = Math.Min(start.Y, end.Y);
                Bounds = new Rectangle(x, y, width_, height);
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


        // 自由绘画线条类
        private class FreeDrawLine : Shape
        {
            public List<Point> Points { get; }

            public FreeDrawLine(List<Point> points, Color color, float width)
            {
                Points = points;
                PenColor = color;
                PenWidth = width;
            }

            public override void Draw(Graphics g)
            {
                for (int i = 1; i < Points.Count; i++)
                {
                    g.DrawLine(new Pen(PenColor, PenWidth), Points[i - 1], Points[i]);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            // 清空已绘制的图形
            shapes.Clear();

            // 重置绘图模式
            currentMode = DrawMode.None;

            // 重置所有按钮的状态（例如，取消选中状态）
            button_LINE.BackColor = SystemColors.Control;
            button_Ellipse.BackColor = SystemColors.Control;
            button_Rectangle.BackColor = SystemColors.Control;
            button_free_draw.BackColor = SystemColors.Control;

            // 强制重绘窗体，刷新画布
            panel_draw_area.Invalidate();  // 触发面板的重新绘制
            panel_draw_area.Update();      // 强制更新面板，立即重新绘制
        }


        // 点击“直线”按钮时，设置绘图模式为“直线”
        private void button_LINE_Click(object sender, EventArgs e)
        {
            checkBox1_fill.Enabled = true;
            currentMode = DrawMode.Line;
            UpdateButtonStates(button_LINE); // 更新按钮状态
        }

        // 点击“椭圆”按钮时，设置绘图模式为“椭圆”
        private void button_Ellipse_Click(object sender, EventArgs e)
        {
            checkBox1_fill.Enabled = true;
            currentMode = DrawMode.Ellipse;
            UpdateButtonStates(button_Ellipse); // 更新按钮状态
        }

        // 点击“矩形”按钮时，设置绘图模式为“矩形”
        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            checkBox1_fill.Enabled = true;
            currentMode = DrawMode.Rectangle;
            UpdateButtonStates(button_Rectangle); // 更新按钮状态
        }

        // 点击自由绘画按钮时，设置绘图模式为“自由绘画”
        private void button_free_draw_Click(object sender, EventArgs e)
        {
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
            penColor = Color.Black;  // 设置画笔为黑色
        }

        // 点击红色画笔按钮
        private void button_pen_red_Click(object sender, EventArgs e)
        {
            penColor = Color.Red;  // 设置画笔为红色
        }

        // 点击“加粗画笔”按钮，增加画笔的粗细
        private void button_pen_size_up_Click(object sender, EventArgs e)
        {
            penWidth += 1;  // 每次点击增加画笔宽度
            label_show_pen_size.Text = penWidth.ToString();
        }

        // 点击“减小画笔”按钮，减小画笔的粗细
        private void button_pen_size_down_Click(object sender, EventArgs e)
        {
            if (penWidth > 1) penWidth -= 1;  // 每次点击减小画笔宽度，最小值为 1
            label_show_pen_size.Text = penWidth.ToString();
        }

        // 处理鼠标按下事件，记录起始点
        private void panel_draw_area_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentMode != DrawMode.None)
            {
                startPoint = e.Location;
                isMouseDown = true;  // 设置标志，表示开始绘制

                // 如果是自由绘画模式，开始记录绘制路径
                if (currentMode == DrawMode.FreeDraw)
                {
                    currentLine.Add(startPoint);
                }
            }
        }


        // 处理鼠标移动事件，更新终点坐标
        // 鼠标移动事件，更新终点坐标
        private void panel_draw_area_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && currentMode != DrawMode.None)
            {
                if (currentMode == DrawMode.FreeDraw)
                {
                    currentLine.Add(e.Location);
                }
                else
                {
                    endPoint = e.Location; // 实时更新终点
                }
                panel_draw_area.Invalidate(); // 触发重绘
            }
        }

        private void panel_draw_area_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                isMouseDown = false;
                endPoint = e.Location;

                // 根据当前绘图模式创建图形对象
                Shape shape = null;
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
                        if (currentLine.Count > 1)
                        {
                            shape = new FreeDrawLine(new List<Point>(currentLine), penColor, penWidth);
                        }
                        currentLine.Clear(); // 清空自由绘制的点集
                        break;
                }

                if (shape != null)
                {
                    shapes.Add(shape);
                }

                panel_draw_area.Invalidate(); // 触发重绘
            }
        }




        private void panel_draw_area_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 绘制已保存的图形
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }

            // 实时绘制当前正在创建的图形
            if (isMouseDown)
            {
                switch (currentMode)
                {
                    case DrawMode.Line:
                        g.DrawLine(new Pen(penColor, penWidth), startPoint, endPoint);
                        break;
                    case DrawMode.Rectangle:
                        var tempRect = new MyRectangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked);
                        tempRect.Draw(g);
                        break;
                    case DrawMode.Ellipse:
                        var tempEllipse = new Ellipse(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked);
                        tempEllipse.Draw(g);
                        break;
                    case DrawMode.Triangle:
                        var tempTriangle = new Triangle(startPoint, endPoint, penColor, penWidth, checkBox1_fill.Checked);
                        tempTriangle.Draw(g);
                        break;
                    case DrawMode.FreeDraw:
                        if (currentLine.Count > 1)
                        {
                            g.DrawLines(new Pen(penColor, penWidth), currentLine.ToArray());
                        }
                        break;
                }
            }
        }


        private Rectangle GetRectangle(Point start, Point end)
        {
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            return new Rectangle(x, y, width, height);
        }

        private void button_Triangle_Click(object sender, EventArgs e)
        {
            checkBox1_fill.Enabled = true;
            currentMode = DrawMode.Triangle;
            UpdateButtonStates(button_Triangle); // 更新按钮状态
        }

        private void label_show_pen_size_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_fill_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel_control_Paint(object sender, PaintEventArgs e)
        {

        }

        private void colorEdit_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // 更新选定的颜色
                Color selectedColor = colorDialog1.Color; // 获取选定颜色

                //// 更新显示的颜色
                //stsColor.BackColor = selectedColor;

                // 设置 Pen 的颜色
                penColor = selectedColor;
            }
        }

        private void button_undo_Click(object sender, EventArgs e)
        {
            if (shapes.Count > 0)
            {
                shapes.RemoveAt(shapes.Count - 1);
                panel_draw_area.Invalidate();
            }
        }

        private void button_save_jpg_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bitmap = new Bitmap(panel_draw_area.Width, panel_draw_area.Height);
                    panel_draw_area.DrawToBitmap(bitmap, new Rectangle(0, 0, panel_draw_area.Width, panel_draw_area.Height));
                    bitmap.Save(saveFileDialog.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
