namespace Draw_app
{
    partial class Draw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Draw));
            this.button_LINE = new System.Windows.Forms.Button();
            this.button_Ellipse = new System.Windows.Forms.Button();
            this.button_Rectangle = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_pen_black = new System.Windows.Forms.Button();
            this.button_pen_red = new System.Windows.Forms.Button();
            this.button_pen_size_up = new System.Windows.Forms.Button();
            this.button_pen_size_down = new System.Windows.Forms.Button();
            this.label_show_pen_size = new System.Windows.Forms.Label();
            this.trackBar_eraser_size = new System.Windows.Forms.TrackBar();
            this.button_redo = new System.Windows.Forms.Button();
            this.button_eraser = new System.Windows.Forms.Button();
            this.button_save_jpg = new System.Windows.Forms.Button();
            this.button_undo = new System.Windows.Forms.Button();
            this.colorEdit = new System.Windows.Forms.Button();
            this.checkBox1_fill = new System.Windows.Forms.CheckBox();
            this.button_Triangle = new System.Windows.Forms.Button();
            this.button_free_draw = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lable1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_show_color = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_show_color_name = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_show_pensize = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aIEveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_control = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_eraser_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel_control.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_LINE
            // 
            this.button_LINE.BackColor = System.Drawing.Color.White;
            this.button_LINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LINE.Location = new System.Drawing.Point(12, 28);
            this.button_LINE.Name = "button_LINE";
            this.button_LINE.Size = new System.Drawing.Size(50, 50);
            this.button_LINE.TabIndex = 0;
            this.button_LINE.Text = "|";
            this.button_LINE.UseVisualStyleBackColor = false;
            this.button_LINE.Click += new System.EventHandler(this.button_LINE_Click);
            // 
            // button_Ellipse
            // 
            this.button_Ellipse.BackColor = System.Drawing.Color.White;
            this.button_Ellipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ellipse.Location = new System.Drawing.Point(68, 28);
            this.button_Ellipse.Name = "button_Ellipse";
            this.button_Ellipse.Size = new System.Drawing.Size(50, 50);
            this.button_Ellipse.TabIndex = 1;
            this.button_Ellipse.Text = "⭕︎";
            this.button_Ellipse.UseVisualStyleBackColor = false;
            this.button_Ellipse.Click += new System.EventHandler(this.button_Ellipse_Click);
            // 
            // button_Rectangle
            // 
            this.button_Rectangle.BackColor = System.Drawing.Color.White;
            this.button_Rectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Rectangle.Location = new System.Drawing.Point(12, 82);
            this.button_Rectangle.Name = "button_Rectangle";
            this.button_Rectangle.Size = new System.Drawing.Size(50, 50);
            this.button_Rectangle.TabIndex = 2;
            this.button_Rectangle.Text = "🔲";
            this.button_Rectangle.UseVisualStyleBackColor = false;
            this.button_Rectangle.Click += new System.EventHandler(this.button_Rectangle_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.White;
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.Location = new System.Drawing.Point(940, 26);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(100, 100);
            this.button_clear.TabIndex = 3;
            this.button_clear.Text = "🗑";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_pen_black
            // 
            this.button_pen_black.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_pen_black.Location = new System.Drawing.Point(233, 24);
            this.button_pen_black.Name = "button_pen_black";
            this.button_pen_black.Size = new System.Drawing.Size(50, 50);
            this.button_pen_black.TabIndex = 4;
            this.button_pen_black.UseVisualStyleBackColor = false;
            this.button_pen_black.Click += new System.EventHandler(this.button_pen_black_Click);
            // 
            // button_pen_red
            // 
            this.button_pen_red.BackColor = System.Drawing.Color.Red;
            this.button_pen_red.Location = new System.Drawing.Point(233, 80);
            this.button_pen_red.Name = "button_pen_red";
            this.button_pen_red.Size = new System.Drawing.Size(50, 50);
            this.button_pen_red.TabIndex = 5;
            this.button_pen_red.UseVisualStyleBackColor = false;
            this.button_pen_red.Click += new System.EventHandler(this.button_pen_red_Click);
            // 
            // button_pen_size_up
            // 
            this.button_pen_size_up.BackColor = System.Drawing.Color.White;
            this.button_pen_size_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pen_size_up.Location = new System.Drawing.Point(556, 51);
            this.button_pen_size_up.Name = "button_pen_size_up";
            this.button_pen_size_up.Size = new System.Drawing.Size(50, 50);
            this.button_pen_size_up.TabIndex = 6;
            this.button_pen_size_up.Text = "+";
            this.button_pen_size_up.UseVisualStyleBackColor = false;
            this.button_pen_size_up.Click += new System.EventHandler(this.button_pen_size_up_Click);
            // 
            // button_pen_size_down
            // 
            this.button_pen_size_down.BackColor = System.Drawing.Color.White;
            this.button_pen_size_down.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pen_size_down.Location = new System.Drawing.Point(612, 50);
            this.button_pen_size_down.Name = "button_pen_size_down";
            this.button_pen_size_down.Size = new System.Drawing.Size(50, 50);
            this.button_pen_size_down.TabIndex = 7;
            this.button_pen_size_down.Text = "-";
            this.button_pen_size_down.UseVisualStyleBackColor = false;
            this.button_pen_size_down.Click += new System.EventHandler(this.button_pen_size_down_Click);
            // 
            // label_show_pen_size
            // 
            this.label_show_pen_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_show_pen_size.Location = new System.Drawing.Point(668, 51);
            this.label_show_pen_size.Name = "label_show_pen_size";
            this.label_show_pen_size.Size = new System.Drawing.Size(50, 50);
            this.label_show_pen_size.TabIndex = 8;
            this.label_show_pen_size.Text = "N";
            this.label_show_pen_size.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_eraser_size
            // 
            this.trackBar_eraser_size.AutoSize = false;
            this.trackBar_eraser_size.Location = new System.Drawing.Point(724, 59);
            this.trackBar_eraser_size.Maximum = 50;
            this.trackBar_eraser_size.Minimum = 10;
            this.trackBar_eraser_size.Name = "trackBar_eraser_size";
            this.trackBar_eraser_size.Size = new System.Drawing.Size(104, 33);
            this.trackBar_eraser_size.TabIndex = 18;
            this.trackBar_eraser_size.Value = 10;
            this.trackBar_eraser_size.Visible = false;
            this.trackBar_eraser_size.ValueChanged += new System.EventHandler(this.trackBar_eraser_size_ValueChanged);
            // 
            // button_redo
            // 
            this.button_redo.BackColor = System.Drawing.Color.White;
            this.button_redo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_redo.Location = new System.Drawing.Point(10, 80);
            this.button_redo.Name = "button_redo";
            this.button_redo.Size = new System.Drawing.Size(50, 50);
            this.button_redo.TabIndex = 17;
            this.button_redo.Text = "↪️";
            this.button_redo.UseVisualStyleBackColor = false;
            this.button_redo.Click += new System.EventHandler(this.button_redo_Click);
            // 
            // button_eraser
            // 
            this.button_eraser.BackColor = System.Drawing.Color.White;
            this.button_eraser.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_eraser.Location = new System.Drawing.Point(834, 26);
            this.button_eraser.Name = "button_eraser";
            this.button_eraser.Size = new System.Drawing.Size(100, 100);
            this.button_eraser.TabIndex = 15;
            this.button_eraser.Text = "👻";
            this.button_eraser.UseVisualStyleBackColor = false;
            this.button_eraser.Click += new System.EventHandler(this.button_eraser_Click);
            // 
            // button_save_jpg
            // 
            this.button_save_jpg.BackColor = System.Drawing.Color.White;
            this.button_save_jpg.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save_jpg.Location = new System.Drawing.Point(66, 26);
            this.button_save_jpg.Name = "button_save_jpg";
            this.button_save_jpg.Size = new System.Drawing.Size(50, 50);
            this.button_save_jpg.TabIndex = 14;
            this.button_save_jpg.Text = "💾";
            this.button_save_jpg.UseVisualStyleBackColor = false;
            this.button_save_jpg.Click += new System.EventHandler(this.button_save_jpg_Click);
            // 
            // button_undo
            // 
            this.button_undo.BackColor = System.Drawing.Color.White;
            this.button_undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_undo.Location = new System.Drawing.Point(10, 26);
            this.button_undo.Name = "button_undo";
            this.button_undo.Size = new System.Drawing.Size(50, 50);
            this.button_undo.TabIndex = 13;
            this.button_undo.Text = "↩️";
            this.button_undo.UseVisualStyleBackColor = false;
            this.button_undo.Click += new System.EventHandler(this.button_undo_Click);
            // 
            // colorEdit
            // 
            this.colorEdit.BackColor = System.Drawing.Color.White;
            this.colorEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.colorEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorEdit.Location = new System.Drawing.Point(289, 27);
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.Size = new System.Drawing.Size(100, 100);
            this.colorEdit.TabIndex = 12;
            this.colorEdit.Text = "🎨";
            this.colorEdit.UseVisualStyleBackColor = false;
            this.colorEdit.Click += new System.EventHandler(this.colorEdit_Click);
            // 
            // checkBox1_fill
            // 
            this.checkBox1_fill.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1_fill.Location = new System.Drawing.Point(124, 54);
            this.checkBox1_fill.Name = "checkBox1_fill";
            this.checkBox1_fill.Size = new System.Drawing.Size(82, 50);
            this.checkBox1_fill.TabIndex = 11;
            this.checkBox1_fill.Text = "Fill";
            this.checkBox1_fill.UseVisualStyleBackColor = true;
            // 
            // button_Triangle
            // 
            this.button_Triangle.BackColor = System.Drawing.Color.White;
            this.button_Triangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Triangle.Location = new System.Drawing.Point(68, 82);
            this.button_Triangle.Name = "button_Triangle";
            this.button_Triangle.Size = new System.Drawing.Size(50, 50);
            this.button_Triangle.TabIndex = 10;
            this.button_Triangle.Text = "🛆";
            this.button_Triangle.UseVisualStyleBackColor = false;
            this.button_Triangle.Click += new System.EventHandler(this.button_Triangle_Click);
            // 
            // button_free_draw
            // 
            this.button_free_draw.BackColor = System.Drawing.Color.White;
            this.button_free_draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_free_draw.Location = new System.Drawing.Point(195, 30);
            this.button_free_draw.Name = "button_free_draw";
            this.button_free_draw.Size = new System.Drawing.Size(100, 100);
            this.button_free_draw.TabIndex = 9;
            this.button_free_draw.Text = "✏";
            this.button_free_draw.UseVisualStyleBackColor = false;
            this.button_free_draw.Click += new System.EventHandler(this.button_free_draw_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 177);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1411, 544);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_draw_area_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_draw_area_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_draw_area_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lable1,
            this.toolStripStatusLabel_show_color,
            this.toolStripStatusLabel_show_color_name,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_show_pensize});
            this.statusStrip1.Location = new System.Drawing.Point(0, 689);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1411, 32);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lable1
            // 
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(52, 26);
            this.lable1.Text = "Color: ";
            // 
            // toolStripStatusLabel_show_color
            // 
            this.toolStripStatusLabel_show_color.AutoSize = false;
            this.toolStripStatusLabel_show_color.Name = "toolStripStatusLabel_show_color";
            this.toolStripStatusLabel_show_color.Size = new System.Drawing.Size(43, 26);
            this.toolStripStatusLabel_show_color.Text = "color";
            // 
            // toolStripStatusLabel_show_color_name
            // 
            this.toolStripStatusLabel_show_color_name.AutoSize = false;
            this.toolStripStatusLabel_show_color_name.Name = "toolStripStatusLabel_show_color_name";
            this.toolStripStatusLabel_show_color_name.Size = new System.Drawing.Size(86, 26);
            this.toolStripStatusLabel_show_color_name.Text = "color_name";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 26);
            this.toolStripStatusLabel1.Text = "Pen size: ";
            // 
            // toolStripStatusLabel_show_pensize
            // 
            this.toolStripStatusLabel_show_pensize.Name = "toolStripStatusLabel_show_pensize";
            this.toolStripStatusLabel_show_pensize.Size = new System.Drawing.Size(34, 26);
            this.toolStripStatusLabel_show_pensize.Text = "size";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1411, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.saveFileToolStripMenuItem.Text = "save file";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aIEveryToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aIEveryToolStripMenuItem
            // 
            this.aIEveryToolStripMenuItem.Name = "aIEveryToolStripMenuItem";
            this.aIEveryToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.aIEveryToolStripMenuItem.Text = "AI everywhere";
            this.aIEveryToolStripMenuItem.Click += new System.EventHandler(this.aIEveryToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel_control
            // 
            this.panel_control.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_control.Controls.Add(this.groupBox2);
            this.panel_control.Controls.Add(this.groupBox1);
            this.panel_control.Controls.Add(this.menuStrip1);
            this.panel_control.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_control.Location = new System.Drawing.Point(0, 0);
            this.panel_control.Name = "panel_control";
            this.panel_control.Size = new System.Drawing.Size(1411, 177);
            this.panel_control.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button_undo);
            this.groupBox2.Controls.Add(this.button_save_jpg);
            this.groupBox2.Controls.Add(this.button_redo);
            this.groupBox2.Controls.Add(this.trackBar_eraser_size);
            this.groupBox2.Controls.Add(this.button_pen_black);
            this.groupBox2.Controls.Add(this.button_eraser);
            this.groupBox2.Controls.Add(this.button_pen_red);
            this.groupBox2.Controls.Add(this.colorEdit);
            this.groupBox2.Controls.Add(this.button_clear);
            this.groupBox2.Controls.Add(this.label_show_pen_size);
            this.groupBox2.Controls.Add(this.button_pen_size_up);
            this.groupBox2.Controls.Add(this.button_pen_size_down);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(359, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1052, 149);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button_free_draw);
            this.groupBox1.Controls.Add(this.button_LINE);
            this.groupBox1.Controls.Add(this.button_Ellipse);
            this.groupBox1.Controls.Add(this.button_Rectangle);
            this.groupBox1.Controls.Add(this.button_Triangle);
            this.groupBox1.Controls.Add(this.checkBox1_fill);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 149);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1411, 721);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel_control);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Draw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_eraser_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_control.ResumeLayout(false);
            this.panel_control.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LINE;
        private System.Windows.Forms.Button button_Ellipse;
        private System.Windows.Forms.Button button_Rectangle;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_pen_black;
        private System.Windows.Forms.Button button_pen_red;
        private System.Windows.Forms.Button button_pen_size_up;
        private System.Windows.Forms.Button button_pen_size_down;
        private System.Windows.Forms.Label label_show_pen_size;
        private System.Windows.Forms.Button button_free_draw;
        private System.Windows.Forms.CheckBox checkBox1_fill;
        private System.Windows.Forms.Button button_Triangle;
        private System.Windows.Forms.Button colorEdit;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_undo;
        private System.Windows.Forms.Button button_save_jpg;
        private System.Windows.Forms.Button button_eraser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_redo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_show_pensize;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_show_color;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_show_color_name;
        private System.Windows.Forms.ToolStripStatusLabel lable1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TrackBar trackBar_eraser_size;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aIEveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel_control;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}