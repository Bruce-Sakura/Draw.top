namespace Draw_app
{
    partial class Form1
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
            this.button_LINE = new System.Windows.Forms.Button();
            this.button_Ellipse = new System.Windows.Forms.Button();
            this.button_Rectangle = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_pen_black = new System.Windows.Forms.Button();
            this.button_pen_red = new System.Windows.Forms.Button();
            this.button_pen_size_up = new System.Windows.Forms.Button();
            this.button_pen_size_down = new System.Windows.Forms.Button();
            this.label_show_pen_size = new System.Windows.Forms.Label();
            this.panel_control = new System.Windows.Forms.Panel();
            this.button_eraser = new System.Windows.Forms.Button();
            this.button_save_jpg = new System.Windows.Forms.Button();
            this.button_undo = new System.Windows.Forms.Button();
            this.colorEdit = new System.Windows.Forms.Button();
            this.checkBox1_fill = new System.Windows.Forms.CheckBox();
            this.button_Triangle = new System.Windows.Forms.Button();
            this.button_free_draw = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_draw_area = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_control.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel_draw_area.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_LINE
            // 
            this.button_LINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LINE.Location = new System.Drawing.Point(65, 38);
            this.button_LINE.Name = "button_LINE";
            this.button_LINE.Size = new System.Drawing.Size(47, 45);
            this.button_LINE.TabIndex = 0;
            this.button_LINE.Text = "|";
            this.button_LINE.UseVisualStyleBackColor = true;
            this.button_LINE.Click += new System.EventHandler(this.button_LINE_Click);
            // 
            // button_Ellipse
            // 
            this.button_Ellipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ellipse.Location = new System.Drawing.Point(118, 38);
            this.button_Ellipse.Name = "button_Ellipse";
            this.button_Ellipse.Size = new System.Drawing.Size(47, 45);
            this.button_Ellipse.TabIndex = 1;
            this.button_Ellipse.Text = "⭕︎";
            this.button_Ellipse.UseVisualStyleBackColor = true;
            this.button_Ellipse.Click += new System.EventHandler(this.button_Ellipse_Click);
            // 
            // button_Rectangle
            // 
            this.button_Rectangle.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Rectangle.Location = new System.Drawing.Point(171, 38);
            this.button_Rectangle.Name = "button_Rectangle";
            this.button_Rectangle.Size = new System.Drawing.Size(47, 45);
            this.button_Rectangle.TabIndex = 2;
            this.button_Rectangle.Text = "🔲";
            this.button_Rectangle.UseVisualStyleBackColor = true;
            this.button_Rectangle.Click += new System.EventHandler(this.button_Rectangle_Click);
            // 
            // button_clear
            // 
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.Location = new System.Drawing.Point(1062, 38);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(50, 50);
            this.button_clear.TabIndex = 3;
            this.button_clear.Text = "🗑";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_pen_black
            // 
            this.button_pen_black.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_pen_black.Location = new System.Drawing.Point(478, 38);
            this.button_pen_black.Name = "button_pen_black";
            this.button_pen_black.Size = new System.Drawing.Size(50, 50);
            this.button_pen_black.TabIndex = 4;
            this.button_pen_black.UseVisualStyleBackColor = false;
            this.button_pen_black.Click += new System.EventHandler(this.button_pen_black_Click);
            // 
            // button_pen_red
            // 
            this.button_pen_red.BackColor = System.Drawing.Color.Red;
            this.button_pen_red.Location = new System.Drawing.Point(534, 38);
            this.button_pen_red.Name = "button_pen_red";
            this.button_pen_red.Size = new System.Drawing.Size(50, 50);
            this.button_pen_red.TabIndex = 5;
            this.button_pen_red.UseVisualStyleBackColor = false;
            this.button_pen_red.Click += new System.EventHandler(this.button_pen_red_Click);
            // 
            // button_pen_size_up
            // 
            this.button_pen_size_up.BackColor = System.Drawing.SystemColors.Control;
            this.button_pen_size_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pen_size_up.Location = new System.Drawing.Point(702, 37);
            this.button_pen_size_up.Name = "button_pen_size_up";
            this.button_pen_size_up.Size = new System.Drawing.Size(50, 50);
            this.button_pen_size_up.TabIndex = 6;
            this.button_pen_size_up.Text = "+";
            this.button_pen_size_up.UseVisualStyleBackColor = false;
            this.button_pen_size_up.Click += new System.EventHandler(this.button_pen_size_up_Click);
            // 
            // button_pen_size_down
            // 
            this.button_pen_size_down.BackColor = System.Drawing.SystemColors.Control;
            this.button_pen_size_down.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pen_size_down.Location = new System.Drawing.Point(758, 37);
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
            this.label_show_pen_size.Location = new System.Drawing.Point(814, 37);
            this.label_show_pen_size.Name = "label_show_pen_size";
            this.label_show_pen_size.Size = new System.Drawing.Size(50, 50);
            this.label_show_pen_size.TabIndex = 8;
            this.label_show_pen_size.Text = "N";
            this.label_show_pen_size.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_control
            // 
            this.panel_control.BackColor = System.Drawing.Color.Silver;
            this.panel_control.Controls.Add(this.button_eraser);
            this.panel_control.Controls.Add(this.button_save_jpg);
            this.panel_control.Controls.Add(this.button_undo);
            this.panel_control.Controls.Add(this.colorEdit);
            this.panel_control.Controls.Add(this.checkBox1_fill);
            this.panel_control.Controls.Add(this.button_Triangle);
            this.panel_control.Controls.Add(this.button_free_draw);
            this.panel_control.Controls.Add(this.button_Rectangle);
            this.panel_control.Controls.Add(this.label_show_pen_size);
            this.panel_control.Controls.Add(this.button_LINE);
            this.panel_control.Controls.Add(this.button_pen_size_down);
            this.panel_control.Controls.Add(this.button_Ellipse);
            this.panel_control.Controls.Add(this.button_pen_size_up);
            this.panel_control.Controls.Add(this.button_clear);
            this.panel_control.Controls.Add(this.button_pen_red);
            this.panel_control.Controls.Add(this.button_pen_black);
            this.panel_control.Controls.Add(this.menuStrip1);
            this.panel_control.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_control.Location = new System.Drawing.Point(0, 0);
            this.panel_control.Name = "panel_control";
            this.panel_control.Size = new System.Drawing.Size(1124, 100);
            this.panel_control.TabIndex = 9;
            // 
            // button_eraser
            // 
            this.button_eraser.BackColor = System.Drawing.SystemColors.Control;
            this.button_eraser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_eraser.Location = new System.Drawing.Point(1006, 39);
            this.button_eraser.Name = "button_eraser";
            this.button_eraser.Size = new System.Drawing.Size(50, 50);
            this.button_eraser.TabIndex = 15;
            this.button_eraser.Text = "🧲";
            this.button_eraser.UseVisualStyleBackColor = false;
            this.button_eraser.Click += new System.EventHandler(this.button_eraser_Click);
            // 
            // button_save_jpg
            // 
            this.button_save_jpg.BackColor = System.Drawing.SystemColors.Control;
            this.button_save_jpg.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save_jpg.Location = new System.Drawing.Point(422, 38);
            this.button_save_jpg.Name = "button_save_jpg";
            this.button_save_jpg.Size = new System.Drawing.Size(50, 50);
            this.button_save_jpg.TabIndex = 14;
            this.button_save_jpg.Text = "💾";
            this.button_save_jpg.UseVisualStyleBackColor = false;
            this.button_save_jpg.Click += new System.EventHandler(this.button_save_jpg_Click);
            // 
            // button_undo
            // 
            this.button_undo.BackColor = System.Drawing.SystemColors.Control;
            this.button_undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_undo.Location = new System.Drawing.Point(366, 38);
            this.button_undo.Name = "button_undo";
            this.button_undo.Size = new System.Drawing.Size(50, 50);
            this.button_undo.TabIndex = 13;
            this.button_undo.Text = "🔙";
            this.button_undo.UseVisualStyleBackColor = false;
            this.button_undo.Click += new System.EventHandler(this.button_undo_Click);
            // 
            // colorEdit
            // 
            this.colorEdit.BackColor = System.Drawing.SystemColors.Control;
            this.colorEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorEdit.Location = new System.Drawing.Point(590, 38);
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.Size = new System.Drawing.Size(50, 50);
            this.colorEdit.TabIndex = 12;
            this.colorEdit.Text = "🎨";
            this.colorEdit.UseVisualStyleBackColor = false;
            this.colorEdit.Click += new System.EventHandler(this.colorEdit_Click);
            // 
            // checkBox1_fill
            // 
            this.checkBox1_fill.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1_fill.Location = new System.Drawing.Point(278, 39);
            this.checkBox1_fill.Name = "checkBox1_fill";
            this.checkBox1_fill.Size = new System.Drawing.Size(82, 45);
            this.checkBox1_fill.TabIndex = 11;
            this.checkBox1_fill.Text = "Fill";
            this.checkBox1_fill.UseVisualStyleBackColor = true;
            // 
            // button_Triangle
            // 
            this.button_Triangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Triangle.Location = new System.Drawing.Point(224, 38);
            this.button_Triangle.Name = "button_Triangle";
            this.button_Triangle.Size = new System.Drawing.Size(47, 45);
            this.button_Triangle.TabIndex = 10;
            this.button_Triangle.Text = "🛆";
            this.button_Triangle.UseVisualStyleBackColor = true;
            this.button_Triangle.Click += new System.EventHandler(this.button_Triangle_Click);
            // 
            // button_free_draw
            // 
            this.button_free_draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_free_draw.Location = new System.Drawing.Point(12, 38);
            this.button_free_draw.Name = "button_free_draw";
            this.button_free_draw.Size = new System.Drawing.Size(47, 45);
            this.button_free_draw.TabIndex = 9;
            this.button_free_draw.Text = "✏";
            this.button_free_draw.UseVisualStyleBackColor = true;
            this.button_free_draw.Click += new System.EventHandler(this.button_free_draw_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1124, 28);
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel_draw_area
            // 
            this.panel_draw_area.BackColor = System.Drawing.Color.White;
            this.panel_draw_area.Controls.Add(this.statusStrip3);
            this.panel_draw_area.Controls.Add(this.statusStrip2);
            this.panel_draw_area.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel_draw_area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_draw_area.Location = new System.Drawing.Point(0, 100);
            this.panel_draw_area.Name = "panel_draw_area";
            this.panel_draw_area.Size = new System.Drawing.Size(1124, 517);
            this.panel_draw_area.TabIndex = 10;
            this.panel_draw_area.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_draw_area_Paint);
            this.panel_draw_area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_draw_area_MouseDown);
            this.panel_draw_area.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_draw_area_MouseMove);
            this.panel_draw_area.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_draw_area_MouseUp);
            // 
            // statusStrip2
            // 
            this.statusStrip2.AutoSize = false;
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(100, 493);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(100, 20);
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 14);
            this.toolStripStatusLabel2.Text = "1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(100, 20);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 14);
            this.toolStripStatusLabel1.Text = "1";
            // 
            // statusStrip3
            // 
            this.statusStrip3.AutoSize = false;
            this.statusStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3});
            this.statusStrip3.Location = new System.Drawing.Point(200, 493);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(100, 20);
            this.statusStrip3.TabIndex = 11;
            this.statusStrip3.Text = "2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(17, 14);
            this.toolStripStatusLabel3.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 617);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel_draw_area);
            this.Controls.Add(this.panel_control);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_control.ResumeLayout(false);
            this.panel_control.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_draw_area.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel_control;
        private System.Windows.Forms.Panel panel_draw_area;
        private System.Windows.Forms.Button button_free_draw;
        private System.Windows.Forms.CheckBox checkBox1_fill;
        private System.Windows.Forms.Button button_Triangle;
        private System.Windows.Forms.Button colorEdit;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_undo;
        private System.Windows.Forms.Button button_save_jpg;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button button_eraser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
    }
}