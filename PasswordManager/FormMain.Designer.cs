namespace PasswordManager
{
	partial class FormMain
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.panelMain = new System.Windows.Forms.Panel();
			this.buttonExport = new System.Windows.Forms.Button();
			this.buttonChangeAccount = new System.Windows.Forms.Button();
			this.buttonCopyPassword = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonAddAccount = new System.Windows.Forms.Button();
			this.buttonCreatePassword = new System.Windows.Forms.Button();
			this.comboBoxService = new System.Windows.Forms.ComboBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnService = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelAuth = new System.Windows.Forms.Panel();
			this.buttonAuth = new System.Windows.Forms.Button();
			this.labelAuth = new System.Windows.Forms.Label();
			this.textBoxAuth = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.panelAuth.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			label1.Location = new System.Drawing.Point(782, 137);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(69, 25);
			label1.TabIndex = 1;
			label1.Text = "Логин:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			label2.Location = new System.Drawing.Point(782, 201);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(82, 25);
			label2.TabIndex = 1;
			label2.Text = "Пароль:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			label3.Location = new System.Drawing.Point(782, 305);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(253, 25);
			label3.TabIndex = 1;
			label3.Text = "Дополнительное описание:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			label4.Location = new System.Drawing.Point(782, 73);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(79, 25);
			label4.TabIndex = 1;
			label4.Text = "Сервис:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			label5.Location = new System.Drawing.Point(782, 9);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(185, 25);
			label5.TabIndex = 1;
			label5.Text = "Поиск по сервисам:";
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.buttonExport);
			this.panelMain.Controls.Add(this.buttonChangeAccount);
			this.panelMain.Controls.Add(this.buttonCopyPassword);
			this.panelMain.Controls.Add(this.buttonDelete);
			this.panelMain.Controls.Add(this.buttonAddAccount);
			this.panelMain.Controls.Add(this.buttonCreatePassword);
			this.panelMain.Controls.Add(this.comboBoxService);
			this.panelMain.Controls.Add(this.textBoxDescription);
			this.panelMain.Controls.Add(this.textBoxPassword);
			this.panelMain.Controls.Add(this.textBoxSearch);
			this.panelMain.Controls.Add(this.textBoxLogin);
			this.panelMain.Controls.Add(label4);
			this.panelMain.Controls.Add(label3);
			this.panelMain.Controls.Add(label2);
			this.panelMain.Controls.Add(label5);
			this.panelMain.Controls.Add(label1);
			this.panelMain.Controls.Add(this.dataGridView);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1079, 636);
			this.panelMain.TabIndex = 0;
			// 
			// buttonExport
			// 
			this.buttonExport.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.buttonExport.Location = new System.Drawing.Point(779, 582);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(132, 42);
			this.buttonExport.TabIndex = 2;
			this.buttonExport.Text = "Экспортировать в Zip файл";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
			// 
			// buttonChangeAccount
			// 
			this.buttonChangeAccount.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.buttonChangeAccount.Location = new System.Drawing.Point(779, 372);
			this.buttonChangeAccount.Name = "buttonChangeAccount";
			this.buttonChangeAccount.Size = new System.Drawing.Size(132, 34);
			this.buttonChangeAccount.TabIndex = 2;
			this.buttonChangeAccount.Text = "Изменить";
			this.buttonChangeAccount.UseVisualStyleBackColor = true;
			this.buttonChangeAccount.Click += new System.EventHandler(this.buttonChangeAccount_Click);
			// 
			// buttonCopyPassword
			// 
			this.buttonCopyPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.buttonCopyPassword.Location = new System.Drawing.Point(943, 268);
			this.buttonCopyPassword.Name = "buttonCopyPassword";
			this.buttonCopyPassword.Size = new System.Drawing.Size(132, 34);
			this.buttonCopyPassword.TabIndex = 2;
			this.buttonCopyPassword.Text = "Скопировать";
			this.buttonCopyPassword.UseVisualStyleBackColor = true;
			this.buttonCopyPassword.Click += new System.EventHandler(this.buttonCopyPassword_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.buttonDelete.Location = new System.Drawing.Point(877, 412);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(158, 34);
			this.buttonDelete.TabIndex = 2;
			this.buttonDelete.Text = "Удалить";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonAddAccount
			// 
			this.buttonAddAccount.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.buttonAddAccount.Location = new System.Drawing.Point(917, 372);
			this.buttonAddAccount.Name = "buttonAddAccount";
			this.buttonAddAccount.Size = new System.Drawing.Size(158, 34);
			this.buttonAddAccount.TabIndex = 2;
			this.buttonAddAccount.Text = "Добавить";
			this.buttonAddAccount.UseVisualStyleBackColor = true;
			this.buttonAddAccount.Click += new System.EventHandler(this.buttonAddAccount_Click);
			// 
			// buttonCreatePassword
			// 
			this.buttonCreatePassword.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.buttonCreatePassword.Location = new System.Drawing.Point(779, 268);
			this.buttonCreatePassword.Name = "buttonCreatePassword";
			this.buttonCreatePassword.Size = new System.Drawing.Size(158, 34);
			this.buttonCreatePassword.TabIndex = 2;
			this.buttonCreatePassword.Text = "Сгенерировать пароль";
			this.buttonCreatePassword.UseVisualStyleBackColor = true;
			this.buttonCreatePassword.Click += new System.EventHandler(this.buttonCreatePassword_Click);
			// 
			// comboBoxService
			// 
			this.comboBoxService.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.comboBoxService.FormattingEnabled = true;
			this.comboBoxService.Location = new System.Drawing.Point(779, 101);
			this.comboBoxService.Name = "comboBoxService";
			this.comboBoxService.Size = new System.Drawing.Size(296, 33);
			this.comboBoxService.TabIndex = 2;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.textBoxDescription.Location = new System.Drawing.Point(779, 333);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(296, 33);
			this.textBoxDescription.TabIndex = 1;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.textBoxPassword.Location = new System.Drawing.Point(779, 229);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(296, 33);
			this.textBoxPassword.TabIndex = 1;
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.textBoxSearch.Location = new System.Drawing.Point(779, 37);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(296, 33);
			this.textBoxSearch.TabIndex = 1;
			this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.textBoxLogin.Location = new System.Drawing.Point(779, 165);
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(296, 33);
			this.textBoxLogin.TabIndex = 1;
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToResizeColumns = false;
			this.dataGridView.AllowUserToResizeRows = false;
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ColumnService,
            this.Login,
            this.Description});
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.25F);
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Left;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(776, 636);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
			// 
			// Id
			// 
			this.Id.HeaderText = "Id";
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Visible = false;
			// 
			// ColumnService
			// 
			this.ColumnService.HeaderText = "Сервис";
			this.ColumnService.Name = "ColumnService";
			this.ColumnService.ReadOnly = true;
			// 
			// Login
			// 
			this.Login.HeaderText = "Логин";
			this.Login.Name = "Login";
			this.Login.ReadOnly = true;
			// 
			// Description
			// 
			this.Description.HeaderText = "Описание";
			this.Description.Name = "Description";
			this.Description.ReadOnly = true;
			// 
			// panelAuth
			// 
			this.panelAuth.Controls.Add(this.buttonAuth);
			this.panelAuth.Controls.Add(this.labelAuth);
			this.panelAuth.Controls.Add(this.textBoxAuth);
			this.panelAuth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelAuth.Location = new System.Drawing.Point(0, 0);
			this.panelAuth.Name = "panelAuth";
			this.panelAuth.Size = new System.Drawing.Size(1079, 636);
			this.panelAuth.TabIndex = 1;
			// 
			// button1
			// 
			this.buttonAuth.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAuth.Location = new System.Drawing.Point(444, 317);
			this.buttonAuth.Name = "buttonAuth";
			this.buttonAuth.Size = new System.Drawing.Size(145, 34);
			this.buttonAuth.TabIndex = 2;
			this.buttonAuth.Text = "Войти";
			this.buttonAuth.UseVisualStyleBackColor = true;
			this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
			// 
			// labelAuth
			// 
			this.labelAuth.AutoSize = true;
			this.labelAuth.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.labelAuth.Location = new System.Drawing.Point(439, 243);
			this.labelAuth.Name = "labelAuth";
			this.labelAuth.Size = new System.Drawing.Size(154, 25);
			this.labelAuth.TabIndex = 1;
			this.labelAuth.Text = "Введите пароль:";
			// 
			// textBoxAuth
			// 
			this.textBoxAuth.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.textBoxAuth.Location = new System.Drawing.Point(444, 278);
			this.textBoxAuth.Name = "textBoxAuth";
			this.textBoxAuth.PasswordChar = '*';
			this.textBoxAuth.Size = new System.Drawing.Size(145, 33);
			this.textBoxAuth.TabIndex = 0;
			this.textBoxAuth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxAuth_KeyUp);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1079, 636);
			this.Controls.Add(this.panelAuth);
			this.Controls.Add(this.panelMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "Менеджер паролей";
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panelAuth.ResumeLayout(false);
			this.panelAuth.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Panel panelAuth;
		private System.Windows.Forms.Label labelAuth;
		private System.Windows.Forms.TextBox textBoxAuth;
		private System.Windows.Forms.Button buttonAuth;
		private System.Windows.Forms.ComboBox comboBoxService;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxLogin;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button buttonChangeAccount;
		private System.Windows.Forms.Button buttonCopyPassword;
		private System.Windows.Forms.Button buttonAddAccount;
		private System.Windows.Forms.Button buttonCreatePassword;
		private System.Windows.Forms.Button buttonExport;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnService;
		private System.Windows.Forms.DataGridViewTextBoxColumn Login;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.TextBox textBoxSearch;
	}
}

