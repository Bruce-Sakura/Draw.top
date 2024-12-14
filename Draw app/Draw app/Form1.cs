using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Draw_app.Form1;


namespace Draw_app
{

    public partial class Form1 : Form
    {
        private Pen Pen;
        private Color penColor = Color.Black;  // 默认笔的颜色
        private float penWidth = 2;  // 默认笔的宽度

        private bool isMouseDown = false;  // 判断鼠标是否按下
        private bool isEraserMode = false;  // 判断是否是橡皮擦模式
        private DrawMode currentMode = DrawMode.None;  // 当前绘图模式

        private Point startPoint;  // 绘图起始点
        private Point endPoint;  // 绘图结束点
        private List<Point> currentLine = new List<Point>();  // 自由绘制时的点列表

        private List<Shape> shapes = new List<Shape>();  // 存储已绘制的图形


        // 绘图模式的枚举，表示不同的绘图类型
        private enum DrawMode
        {
            None,  // 没有模式
            Line,  // 画直线
            Ellipse,  // 画椭圆
            Rectangle,  // 画矩形
            FreeDraw,  // 自由绘制
            Triangle  // 画三角形
        }

        public Form1()
        {
            InitializeComponent();
            this.panel_draw_area.MouseDown += panel_draw_area_MouseDown;
            this.panel_draw_area.MouseMove += panel_draw_area_MouseMove;
            this.panel_draw_area.MouseUp += panel_draw_area_MouseUp;
            this.panel_draw_area.Paint += panel_draw_area_Paint;

            Pen = new Pen(penColor, penWidth);  // 创建默认画笔
        }

        // Form 加载时执行，初始化一些默认设置
        private void Form1_Load(object sender, EventArgs e)
        {
            button_free_draw.PerformClick();  // 默认选择自由绘制模式
            label_show_pen_size.Text = penWidth.ToString();  // 显示当前笔的宽度
            EnableDoubleBuffering(panel_draw_area);  // 启用双重缓冲，减少闪烁
        }

        // 启用双重缓冲以减少闪烁
        private void EnableDoubleBuffering(Control control)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        // 基类 Shape，代表不同的图形
        private abstract class Shape
        {
            public Color PenColor { get; set; }  // 图形的颜色
            public float PenWidth { get; set; }  // 图形的线宽
            public bool IsFilled { get; set; }  // 是否填充
            public abstract void Draw(Graphics g);  // 绘制图形的抽象方法

            // Contains method to be overridden
            public abstract bool Contains(Point p);  // 判断点是否在图形内
        }

        // 直线类，继承自 Shape
        // Line class inherits from Shape
        private class Line : Shape
        {
            public Point Start { get; set; }  // 起点
            public Point End { get; set; }  // 终点

            // Constructor to initialize the line's start, end points, color, and width
            public Line(Point start, Point end, Color color, float width)
            {
                this.Start = start;
                this.End = end;
                this.PenColor = color;
                this.PenWidth = width;
            }

            // Override Draw method to draw the line
            public override void Draw(Graphics g)
            {
                using (Pen pen = new Pen(PenColor, PenWidth))  // Use the specified color and width
                {
                    g.DrawLine(pen, Start, End);
                }
            }

            // Implement the Contains method for Line (this is an example; you might want to provide a different logic)
            public override bool Contains(Point p)
            {
                // For simplicity, we check if the point lies exactly on the line segment
                float tolerance = 5.0f;  // You can adjust this tolerance value as needed

                // Calculate the distance from the point to the line (simple distance formula)
                float distance = Math.Abs((End.Y - Start.Y) * p.X - (End.X - Start.X) * p.Y + End.X * Start.Y - End.Y * Start.X) /
                                 (float)Math.Sqrt(Math.Pow(End.Y - Start.Y, 2) + Math.Pow(End.X - Start.X, 2));

                return distance <= tolerance;  // Returns true if the point is close to the line segment
            }
        }


        // Triangle 类继承 Shape
        private class Triangle : Shape
        {
            private Point point1;
            private Point point2;
            private Point point3;

            // 构造函数，传入点和绘制参数
            public Triangle(Point point1, Point point2, Point point3, Color color, float width)
            {
                this.point1 = point1;
                this.point2 = point2;
                this.point3 = point3;

                // 使用基类构造函数初始化 PenColor 和 PenWidth
                this.PenColor = color;
                this.PenWidth = width;
            }

            // 重写 Draw 方法来绘制三角形
            public override void Draw(Graphics g)
            {
                using (Pen pen = new Pen(PenColor, PenWidth))  // 使用父类提供的 PenColor 和 PenWidth
                {
                    g.DrawPolygon(pen, new Point[] { point1, point2, point3 });
                }
            }

            // 重写 Contains 方法来判断点是否在三角形内
            public override bool Contains(Point p)
            {
                // 计算三角形的三个子三角形面积
                float area1 = Area(p, point1, point2);
                float area2 = Area(p, point2, point3);
                float area3 = Area(p, point3, point1);

                // 计算三角形的总面积
                float totalArea = Area(point1, point2, point3);

                // 如果三个子三角形面积之和等于总面积，则点在三角形内
                return (area1 + area2 + area3 == totalArea);
            }

            // 计算两个点和一个目标点组成的三角形面积（使用叉积计算面积）
            private float Area(Point p1, Point p2, Point p3)
            {
                return Math.Abs((p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2.0f);
            }
        }


        // 矩形类，继承自 Shape
        private class MyRectangle : Shape
        {
            public Rectangle Bounds { get; }  // 矩形的边界

            public MyRectangle(Point start, Point end, Color color, float width, bool isFilled)
            {
                var x = Math.Min(start.X, end.X);  // 计算矩形左上角的 X 坐标
                var y = Math.Min(start.Y, end.Y);  // 计算矩形左上角的 Y 坐标
                var width_ = Math.Abs(end.X - start.X);  // 计算矩形的宽度
                var height = Math.Abs(end.Y - start.Y);  // 计算矩形的高度
                Bounds = new Rectangle(x, y, width_, height);
                PenColor = color;
                PenWidth = width;
                IsFilled = isFilled;
            }

            public override void Draw(Graphics g)
            {
                if (IsFilled)  // 如果需要填充
                {
                    using (Brush brush = new SolidBrush(PenColor))  // 使用画刷填充矩形
                    {
                        g.FillRectangle(brush, Bounds);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(PenColor, PenWidth))  // 绘制空心矩形
                    {
                        g.DrawRectangle(pen, Bounds);
                    }
                }
            }

            // 重写 Contains 方法来判断点是否在矩形内
            public override bool Contains(Point p)
            {
                return Bounds.Contains(p);  // 使用 Rectangle.Contains 来判断点是否在矩形内
            }
        }


        // 椭圆类，继承自 Shape
        private class Ellipse : Shape
        {
            public Rectangle Bounds { get; }

            public Ellipse(Point start, Point end, Color color, float width, bool isFilled)
            {
                var x = Math.Min(start.X, end.X);
                var y = Math.Min(start.Y, end.Y);
                var width_ = Math.Abs(end.X - start.X);
                var height = Math.Abs(end.Y - start.Y);
                Bounds = new Rectangle(x, y, width_, height);
                PenColor = color;
                PenWidth = width;
                IsFilled = isFilled;
            }

            public override void Draw(Graphics g)
            {
                if (IsFilled)  // 填充椭圆
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

            // 重写 Contains 方法来判断点是否在椭圆内
            public override bool Contains(Point p)
            {
                float centerX = Bounds.X + Bounds.Width / 2;
                float centerY = Bounds.Y + Bounds.Height / 2;
                float ellipseWidth = Bounds.Width / 2;
                float ellipseHeight = Bounds.Height / 2;

                // 椭圆的数学公式：((x - centerX)^2 / a^2) + ((y - centerY)^2 / b^2) <= 1
                return ((p.X - centerX) * (p.X - centerX)) / (ellipseWidth * ellipseWidth) +
                       ((p.Y - centerY) * (p.Y - centerY)) / (ellipseHeight * ellipseHeight) <= 1;
            }
        }


        // 自由绘制类，继承自 Shape
        // FreeDrawLine 类修改，公开 SmoothPoints 方法
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
                Points = SmoothPoints(Points);  // 平滑处理
            }

            public override void Draw(Graphics g)
            {
                for (int i = 1; i < Points.Count; i++)
                {
                    g.DrawLine(new Pen(PenColor, PenWidth), Points[i - 1], Points[i]);
                }
            }

            // 公共的平滑处理方法
            public List<Point> SmoothPoints(List<Point> points)
            {
                List<Point> smoothedPoints = new List<Point>();
                int windowSize = 5;  // 增加平滑窗口大小
                for (int i = 0; i < points.Count; i++)
                {
                    int start = Math.Max(0, i - windowSize / 2);
                    int end = Math.Min(points.Count - 1, i + windowSize / 2);
                    int sumX = 0, sumY = 0, count = 0;

                    // 计算窗口内所有点的加权平均
                    for (int j = start; j <= end; j++)
                    {
                        sumX += points[j].X;
                        sumY += points[j].Y;
                        count++;
                    }

                    // 加权平均计算
                    int avgX = sumX / count;
                    int avgY = sumY / count;

                    // 将平滑后的点添加到结果列表中
                    smoothedPoints.Add(new Point(avgX, avgY));
                }
                return smoothedPoints;
            }


            public override bool Contains(Point p)
            {
                float tolerance = 5.0f;
                for (int i = 1; i < Points.Count; i++)
                {
                    Point p1 = Points[i - 1];
                    Point p2 = Points[i];
                    float distance = DistanceToSegment(p, p1, p2);
                    if (distance <= tolerance)
                        return true;
                }
                return false;
            }

            private float DistanceToSegment(Point p, Point p1, Point p2)
            {
                float dx = p2.X - p1.X;
                float dy = p2.Y - p1.Y;
                float t = ((p.X - p1.X) * dx + (p.Y - p1.Y) * dy) / (dx * dx + dy * dy);
                t = Math.Max(0, Math.Min(1, t));
                float closestX = p1.X + t * dx;
                float closestY = p1.Y + t * dy;
                return (float)Math.Sqrt((p.X - closestX) * (p.X - closestX) + (p.Y - closestY) * (p.Y - closestY));
            }
        }

        // 擦除类，继承自 Shape
        private class EraserShape : Shape
        {
            public Rectangle EraseArea { get; }

            public EraserShape(Rectangle eraseArea)
            {
                EraseArea = eraseArea;
                PenColor = Color.White;  // 擦除的颜色为透明
                PenWidth = 50;  // 擦除的宽度设置较大
                IsFilled = true;  // 使用填充方式进行擦除
            }

            public override void Draw(Graphics g)
            {
                g.FillRectangle(new SolidBrush(Color.Transparent), EraseArea);  // 擦除区域用透明填充
            }

            // 实现 Contains 方法，判断点是否在擦除区域内
            public override bool Contains(Point p)
            {
                return EraseArea.Contains(p);  // 直接检查点是否在擦除区域内
            }

            // 擦除并平滑擦除区域
            public void Erase(Graphics g, List<FreeDrawLine> freeDrawLines)
            {
                foreach (var freeDrawLine in freeDrawLines)
                {
                    var smoothPoints = freeDrawLine.SmoothPoints(freeDrawLine.Points);
                    // 从后往前删除点，避免修改列表时的问题
                    for (int i = smoothPoints.Count - 1; i >= 0; i--)
                    {
                        var point = smoothPoints[i];
                        if (EraseArea.Contains(point))
                        {
                            // 擦除平滑曲线中的点
                            freeDrawLine.Points.Remove(point);
                        }
                    }
                    freeDrawLine.Draw(g); // 重新绘制擦除后的曲线
                }
            }
        }    


        // 按钮方法

        // 清除画布
        private void button_clear_Click(object sender, EventArgs e)
        {
            shapes.Clear();  // 清空绘制的图形列表
            currentMode = DrawMode.None;  // 重置绘图模式
            ResetButtonStates();  // 重置按钮状态
            panel_draw_area.Invalidate();  // 刷新面板
            panel_draw_area.Update();
        }

        // 重置按钮状态
        private void ResetButtonStates()
        {
            // 恢复所有按钮的默认背景颜色
            button_LINE.BackColor = SystemColors.Control;
            button_Ellipse.BackColor = SystemColors.Control;
            button_Rectangle.BackColor = SystemColors.Control;
            button_free_draw.BackColor = SystemColors.Control;
        }

        // 设置绘图模式的方法
        private void SetDrawMode(DrawMode mode, Button selectedButton)
        {
            isEraserMode = false;  // 退出擦除模式
            checkBox1_fill.Enabled = mode == DrawMode.Ellipse || mode == DrawMode.Rectangle;  // 启用填充选项框
            checkBox1_fill.Checked = false;  // 默认不勾选填充

            currentMode = mode;  // 设置当前绘图模式
            UpdateButtonStates(selectedButton);  // 更新按钮状态
        }

        // 更新按钮的状态
        private void UpdateButtonStates(Button selectedButton)
        {
            button_LINE.BackColor = SystemColors.Control;
            button_Ellipse.BackColor = SystemColors.Control;
            button_Rectangle.BackColor = SystemColors.Control;
            button_free_draw.BackColor = SystemColors.Control;

            selectedButton.BackColor = Color.LightGray;  // 被选中的按钮背景颜色设置为灰色
        }

        // 按钮点击事件，设置绘图模式为直线
        private void button_LINE_Click(object sender, EventArgs e) => SetDrawMode(DrawMode.Line, button_LINE);

        // 按钮点击事件，设置绘图模式为椭圆
        private void button_Ellipse_Click(object sender, EventArgs e) => SetDrawMode(DrawMode.Ellipse, button_Ellipse);

        // 按钮点击事件，设置绘图模式为矩形
        private void button_Rectangle_Click(object sender, EventArgs e) => SetDrawMode(DrawMode.Rectangle, button_Rectangle);

        // 按钮点击事件，设置绘图模式为自由绘制
        private void button_free_draw_Click(object sender, EventArgs e) => SetDrawMode(DrawMode.FreeDraw, button_free_draw);


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

        private void button_Triangle_Click(object sender, EventArgs e)
        {
            isEraserMode = false; // 取消橡皮擦模式
            checkBox1_fill.Enabled = true;
            currentMode = DrawMode.Triangle;
            UpdateButtonStates(button_Triangle); // 更新按钮状态
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
        private void button_eraser_Click(object sender, EventArgs e)
        {
            isEraserMode = true; // 启用橡皮擦模式
            //currentMode = DrawMode.None; // 禁用其他绘制模式
            UpdateButtonStates((Button)sender); // 更新按钮状态
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
                    Bitmap bitmap = new Bitmap(panel_draw_area.Width, panel_draw_area.Height);
                    panel_draw_area.DrawToBitmap(bitmap, new Rectangle(0, 0, panel_draw_area.Width, panel_draw_area.Height));
                    bitmap.Save(saveFileDialog.FileName);
                }
            }
        }

        // 鼠标按下事件：初始化绘图或擦除过程
        private void panel_draw_area_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentMode != DrawMode.None)
            {
                startPoint = e.Location;
                isMouseDown = true; // 设置标志，表示开始绘制

                if (currentMode == DrawMode.FreeDraw)
                {
                    currentLine.Clear(); // 清空旧路径
                    currentLine.Add(startPoint); // 开始记录路径
                }
                else if (isEraserMode)
                {
                    erasedShapeStart = startPoint; // 记录擦除区域的起始位置
                }
            }
        }

        // 鼠标移动事件：更新绘制或擦除过程
        private void panel_draw_area_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (isEraserMode)
                {
                    Erase(e); // 使用单独的擦除方法
                }
                else if (currentMode == DrawMode.FreeDraw)
                {
                    currentLine.Add(e.Location); // 添加到当前路径
                    panel_draw_area.Invalidate(); // 刷新绘图区域
                }
            }
        }

        // 鼠标松开事件：完成绘制或擦除
        private void panel_draw_area_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                isMouseDown = false;
                endPoint = e.Location;

                if (isEraserMode)
                {
                    RecordErase(e); // 记录擦除区域
                }
                else
                {
                    CreateShape(); // 根据当前模式创建图形
                }

                panel_draw_area.Invalidate(); // 触发重绘
            }
        }

        // 声明变量
        private Point erasedShapeStart;
        private List<EraserShape> erasedShapes = new List<EraserShape>();

        // 处理擦除功能
        private void Erase(MouseEventArgs e)
        {
            using (Graphics g = panel_draw_area.CreateGraphics())
            {
                float eraserSize = penWidth * 5;
                Rectangle eraserRect = new Rectangle(
                    (int)(e.X - eraserSize / 2),
                    (int)(e.Y - eraserSize / 2),
                    (int)eraserSize,
                    (int)eraserSize
                );
                g.FillRectangle(new SolidBrush(panel_draw_area.BackColor), eraserRect);

                // 记录擦除区域
                EraserShape eraserShape = new EraserShape(eraserRect);
                erasedShapes.Add(eraserShape); // 保存擦除区域
            }
        }

        // 记录擦除的区域
        private void RecordErase(MouseEventArgs e)
        {
            float eraserSize = penWidth * 5;
            Rectangle eraserRect = new Rectangle(
                (int)(e.X - eraserSize / 2),
                (int)(e.Y - eraserSize / 2),
                (int)eraserSize,
                (int)eraserSize
            );
            EraserShape eraserShape = new EraserShape(eraserRect);
            erasedShapes.Add(eraserShape); // 将擦除区域添加到擦除列表
        }

        // 创建新图形
        private void CreateShape()
        {
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
                    // 假设你有一个方法获取第三个点
                    Point point3 = GetThirdPoint(startPoint, endPoint);
                    shape = new Triangle(startPoint, endPoint, point3, penColor, penWidth); // 传入三个点
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
                shapes.Add(shape); // 将新图形添加到图形集合
            }
        }
        private Point GetThirdPoint(Point start, Point end)
        {
            // 示例：计算一个垂直的第三个点
            int x = (start.X + end.X) / 2; // 中点
            int y = Math.Min(start.Y, end.Y) - 100; // 选择一个点，向上偏移100像素
            return new Point(x, y);
        }



        // 绘制面板：绘制所有已保存的图形，并实时绘制当前图形
        private void panel_draw_area_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 绘制已保存的图形
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }

            // 绘制已擦除的区域
            foreach (var erasedShape in erasedShapes)
            {
                erasedShape.Draw(g);
            }

            // 实时绘制当前正在创建的图形
            if (isMouseDown)
            {
                DrawCurrentShape(g);
            }
        }

        // 根据当前模式绘制实时图形
        private void DrawCurrentShape(Graphics g)
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
                    // 计算第三个点，可以通过起始点和结束点来推算，假设是等腰三角形
                    Point thirdPoint = new Point(
                        (startPoint.X + endPoint.X) / 2, // 计算两个点的中点
                        Math.Min(startPoint.Y, endPoint.Y) - 50 // 假设将第三个点置于某个垂直偏移的位置
                    );

                    var tempTriangle = new Triangle(startPoint, endPoint, thirdPoint, penColor, penWidth);
                    tempTriangle.Draw(g); // 绘制Triangle图形
                    break ;
                case DrawMode.FreeDraw:
                    if (currentLine.Count > 1)
                    {
                        g.DrawLines(new Pen(penColor, penWidth), currentLine.ToArray());
                    }
                    break;
            }
        }


    }
}
