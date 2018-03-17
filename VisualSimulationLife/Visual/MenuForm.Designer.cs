namespace VisualSimulationLife {
	partial class MenuForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && ( components != null )) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
			this.DescriptionProgram = new System.Windows.Forms.Label();
			this.AddresFile = new System.Windows.Forms.TextBox();
			this.TextFile = new System.Windows.Forms.Label();
			this.EnterFile = new System.Windows.Forms.Button();
			this.NumberBotText = new System.Windows.Forms.Label();
			this.NumberBot = new System.Windows.Forms.NumericUpDown();
			this.CoefficientTrainig = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.START = new System.Windows.Forms.Button();
			this.DinamicChoise = new System.Windows.Forms.Label();
			this.DinamicChose = new System.Windows.Forms.CheckBox();
			this.ChoiseFile = new System.Windows.Forms.Button();
			this.Menu = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.NumberBot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CoefficientTrainig)).BeginInit();
			this.Menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// DescriptionProgram
			// 
			this.DescriptionProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DescriptionProgram.AutoSize = true;
			this.DescriptionProgram.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DescriptionProgram.ForeColor = System.Drawing.Color.Black;
			this.DescriptionProgram.Location = new System.Drawing.Point(277, 9);
			this.DescriptionProgram.Name = "DescriptionProgram";
			this.DescriptionProgram.Size = new System.Drawing.Size(627, 95);
			this.DescriptionProgram.TabIndex = 0;
			this.DescriptionProgram.Text = resources.GetString("DescriptionProgram.Text");
			this.DescriptionProgram.Click += new System.EventHandler(this.DescriptionProgram_Click);
			// 
			// AddresFile
			// 
			this.AddresFile.Location = new System.Drawing.Point(278, 38);
			this.AddresFile.Name = "AddresFile";
			this.AddresFile.Size = new System.Drawing.Size(553, 20);
			this.AddresFile.TabIndex = 1;
			this.AddresFile.TextChanged += new System.EventHandler(this.AddresFile_TextChanged);
			// 
			// TextFile
			// 
			this.TextFile.AutoSize = true;
			this.TextFile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TextFile.ForeColor = System.Drawing.Color.Black;
			this.TextFile.Location = new System.Drawing.Point(3, 39);
			this.TextFile.Name = "TextFile";
			this.TextFile.Size = new System.Drawing.Size(274, 19);
			this.TextFile.TabIndex = 2;
			this.TextFile.Text = "Файл с сохраненной нейроной сетью";
			this.TextFile.Click += new System.EventHandler(this.label1_Click);
			// 
			// EnterFile
			// 
			this.EnterFile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.EnterFile.ForeColor = System.Drawing.Color.Black;
			this.EnterFile.Location = new System.Drawing.Point(1033, 35);
			this.EnterFile.Name = "EnterFile";
			this.EnterFile.Size = new System.Drawing.Size(109, 25);
			this.EnterFile.TabIndex = 4;
			this.EnterFile.Text = "Потвердить";
			this.EnterFile.UseVisualStyleBackColor = true;
			this.EnterFile.Click += new System.EventHandler(this.EnterFile_Click);
			// 
			// NumberBotText
			// 
			this.NumberBotText.AutoSize = true;
			this.NumberBotText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NumberBotText.ForeColor = System.Drawing.Color.Black;
			this.NumberBotText.Location = new System.Drawing.Point(3, 126);
			this.NumberBotText.Name = "NumberBotText";
			this.NumberBotText.Size = new System.Drawing.Size(258, 19);
			this.NumberBotText.TabIndex = 5;
			this.NumberBotText.Text = "Выбор колличества ботов на поле";
			this.NumberBotText.Click += new System.EventHandler(this.NumberBotText_Click);
			// 
			// NumberBot
			// 
			this.NumberBot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NumberBot.ForeColor = System.Drawing.Color.Black;
			this.NumberBot.Location = new System.Drawing.Point(278, 117);
			this.NumberBot.Name = "NumberBot";
			this.NumberBot.Size = new System.Drawing.Size(120, 26);
			this.NumberBot.TabIndex = 6;
			this.NumberBot.ValueChanged += new System.EventHandler(this.NumberBot_ValueChanged);
			// 
			// CoefficientTrainig
			// 
			this.CoefficientTrainig.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CoefficientTrainig.ForeColor = System.Drawing.Color.Black;
			this.CoefficientTrainig.Location = new System.Drawing.Point(278, 192);
			this.CoefficientTrainig.Name = "CoefficientTrainig";
			this.CoefficientTrainig.Size = new System.Drawing.Size(120, 26);
			this.CoefficientTrainig.TabIndex = 8;
			this.CoefficientTrainig.ValueChanged += new System.EventHandler(this.CoefficientTrainig_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(3, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(170, 19);
			this.label3.TabIndex = 7;
			this.label3.Text = "Коэфициент обучения";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// START
			// 
			this.START.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.START.ForeColor = System.Drawing.Color.Black;
			this.START.Location = new System.Drawing.Point(855, 220);
			this.START.Name = "START";
			this.START.Size = new System.Drawing.Size(273, 76);
			this.START.TabIndex = 9;
			this.START.Text = "Начать симуляцию";
			this.START.UseVisualStyleBackColor = true;
			this.START.Click += new System.EventHandler(this.START_Click);
			// 
			// DinamicChoise
			// 
			this.DinamicChoise.AutoSize = true;
			this.DinamicChoise.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DinamicChoise.ForeColor = System.Drawing.Color.Black;
			this.DinamicChoise.Location = new System.Drawing.Point(3, 250);
			this.DinamicChoise.Name = "DinamicChoise";
			this.DinamicChoise.Size = new System.Drawing.Size(227, 19);
			this.DinamicChoise.TabIndex = 10;
			this.DinamicChoise.Text = "Динамические условия среды";
			this.DinamicChoise.Click += new System.EventHandler(this.DinamicChoise_Click);
			// 
			// DinamicChose
			// 
			this.DinamicChose.AutoSize = true;
			this.DinamicChose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DinamicChose.ForeColor = System.Drawing.Color.Black;
			this.DinamicChose.Location = new System.Drawing.Point(278, 246);
			this.DinamicChose.Name = "DinamicChose";
			this.DinamicChose.Size = new System.Drawing.Size(198, 23);
			this.DinamicChose.TabIndex = 11;
			this.DinamicChose.Text = "Динамические условия";
			this.DinamicChose.UseVisualStyleBackColor = true;
			this.DinamicChose.CheckedChanged += new System.EventHandler(this.DinamicChose_CheckedChanged);
			// 
			// ChoiseFile
			// 
			this.ChoiseFile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ChoiseFile.ForeColor = System.Drawing.Color.Black;
			this.ChoiseFile.Location = new System.Drawing.Point(855, 35);
			this.ChoiseFile.Name = "ChoiseFile";
			this.ChoiseFile.Size = new System.Drawing.Size(158, 25);
			this.ChoiseFile.TabIndex = 12;
			this.ChoiseFile.Text = "Выбрать файл";
			this.ChoiseFile.UseVisualStyleBackColor = true;
			this.ChoiseFile.Click += new System.EventHandler(this.ChoiseFile_Click);
			// 
			// Menu
			// 
			this.Menu.Controls.Add(this.AddresFile);
			this.Menu.Controls.Add(this.START);
			this.Menu.Controls.Add(this.DinamicChose);
			this.Menu.Controls.Add(this.DinamicChoise);
			this.Menu.Controls.Add(this.ChoiseFile);
			this.Menu.Controls.Add(this.EnterFile);
			this.Menu.Controls.Add(this.NumberBot);
			this.Menu.Controls.Add(this.label3);
			this.Menu.Controls.Add(this.CoefficientTrainig);
			this.Menu.Controls.Add(this.NumberBotText);
			this.Menu.Controls.Add(this.TextFile);
			this.Menu.ForeColor = System.Drawing.Color.Black;
			this.Menu.Location = new System.Drawing.Point(3, 117);
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(1177, 358);
			this.Menu.TabIndex = 13;
			// 
			// MenuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Ivory;
			this.ClientSize = new System.Drawing.Size(1182, 482);
			this.Controls.Add(this.Menu);
			this.Controls.Add(this.DescriptionProgram);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MenuForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Настройка симуляции";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.MenuForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.NumberBot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CoefficientTrainig)).EndInit();
			this.Menu.ResumeLayout(false);
			this.Menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label DescriptionProgram;
		private System.Windows.Forms.TextBox AddresFile;
		private System.Windows.Forms.Label TextFile;
		private System.Windows.Forms.Button EnterFile;
		private System.Windows.Forms.Label NumberBotText;
		private System.Windows.Forms.NumericUpDown NumberBot;
		private System.Windows.Forms.NumericUpDown CoefficientTrainig;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button START;
		private System.Windows.Forms.Label DinamicChoise;
		private System.Windows.Forms.CheckBox DinamicChose;
		private System.Windows.Forms.Button ChoiseFile;
		public System.Windows.Forms.Panel Menu;
	}
}