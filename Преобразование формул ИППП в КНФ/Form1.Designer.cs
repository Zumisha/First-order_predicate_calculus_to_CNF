namespace Lab5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.button_convert = new System.Windows.Forms.Button();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.textBox_info1 = new System.Windows.Forms.TextBox();
            this.textBox_info2 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_clean = new System.Windows.Forms.Button();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_input
            // 
            this.textBox_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_input.Location = new System.Drawing.Point(13, 27);
            this.textBox_input.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(598, 26);
            this.textBox_input.TabIndex = 0;
            // 
            // button_convert
            // 
            this.button_convert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_convert.Location = new System.Drawing.Point(13, 66);
            this.button_convert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_convert.Name = "button_convert";
            this.button_convert.Size = new System.Drawing.Size(191, 35);
            this.button_convert.TabIndex = 1;
            this.button_convert.Text = "Преобразовать в КНФ";
            this.button_convert.UseVisualStyleBackColor = true;
            this.button_convert.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_output
            // 
            this.textBox_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_output.Location = new System.Drawing.Point(13, 111);
            this.textBox_output.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_output.Multiline = true;
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.ReadOnly = true;
            this.textBox_output.Size = new System.Drawing.Size(598, 180);
            this.textBox_output.TabIndex = 2;
            // 
            // textBox_info1
            // 
            this.textBox_info1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_info1.Location = new System.Drawing.Point(13, 301);
            this.textBox_info1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_info1.Multiline = true;
            this.textBox_info1.Name = "textBox_info1";
            this.textBox_info1.ReadOnly = true;
            this.textBox_info1.Size = new System.Drawing.Size(247, 146);
            this.textBox_info1.TabIndex = 9;
            this.textBox_info1.Text = "# - квантор всеобщности.\r\n$ - квантор существования.\r\nV - дизъюнкция.\r\n& - коньюн" +
    "кция.\r\n! - отрицание.\r\na...z - переменные и константы. (могут иметь вид x195)";
            // 
            // textBox_info2
            // 
            this.textBox_info2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_info2.Location = new System.Drawing.Point(364, 301);
            this.textBox_info2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_info2.Multiline = true;
            this.textBox_info2.Name = "textBox_info2";
            this.textBox_info2.ReadOnly = true;
            this.textBox_info2.Size = new System.Drawing.Size(247, 146);
            this.textBox_info2.TabIndex = 10;
            this.textBox_info2.Text = "> - импликация.\r\n= - эквивалентность.\r\n+ - сложение по модулю 2.\r\n/ - штрих Шеффе" +
    "ра.\r\n| - стрелка Пирса.\r\nA...Z (кроме V) - предикаты. Например: A(x1, y, z3)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(624, 25);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файToolStripMenuItem
            // 
            this.файToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файToolStripMenuItem.Name = "файToolStripMenuItem";
            this.файToolStripMenuItem.Size = new System.Drawing.Size(48, 19);
            this.файToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 19);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(420, 66);
            this.button_clean.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(191, 35);
            this.button_clean.TabIndex = 12;
            this.button_clean.Text = "Очистить";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.Clean_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 461);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.textBox_info2);
            this.Controls.Add(this.textBox_info1);
            this.Controls.Add(this.textBox_output);
            this.Controls.Add(this.button_convert);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Button button_convert;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.TextBox textBox_info1;
        private System.Windows.Forms.TextBox textBox_info2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

