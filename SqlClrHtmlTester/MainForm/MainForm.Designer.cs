namespace SqlClrHtmlTester
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.cmsBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSaveAsHtml = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcel = new System.Windows.Forms.Button();
            this.tabStyle = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCustomStyle = new System.Windows.Forms.TextBox();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAppend = new System.Windows.Forms.CheckBox();
            this.txtRCO = new System.Windows.Forms.NumericUpDown();
            this.cmbRotate = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabConnect = new System.Windows.Forms.TabPage();
            this.listBoxConnection = new System.Windows.Forms.ListBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.cmbAuth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabQuery = new System.Windows.Forms.TabPage();
            this.txtParams = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.tbMonitor = new System.Windows.Forms.TabPage();
            this.chkIsUserDefined = new System.Windows.Forms.CheckBox();
            this.btnUnloadAppDomain = new System.Windows.Forms.Button();
            this.btnLoadAppDomain = new System.Windows.Forms.Button();
            this.chbUserVisible = new System.Windows.Forms.CheckBox();
            this.txtClrName = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtAppDomainName = new System.Windows.Forms.TextBox();
            this.txtAppDomainAddress = new System.Windows.Forms.TextBox();
            this.txtPrincipalName = new System.Windows.Forms.TextBox();
            this.txtPermissionSet = new System.Windows.Forms.TextBox();
            this.txtCreationTime = new System.Windows.Forms.TextBox();
            this.txtLoadTime = new System.Windows.Forms.TextBox();
            this.txtModifiedDate = new System.Windows.Forms.TextBox();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.txtAssemblyId = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.totalAllocatedMemory = new System.Windows.Forms.TextBox();
            this.txtSurvivedMemory = new System.Windows.Forms.TextBox();
            this.totalProcesorTime = new System.Windows.Forms.TextBox();
            this.txtWeakRefCount = new System.Windows.Forms.TextBox();
            this.txtStrongRefCount = new System.Windows.Forms.TextBox();
            this.txtPrincipalId = new System.Windows.Forms.TextBox();
            this.listBoxAssemblies = new System.Windows.Forms.ListBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnGetHtml = new System.Windows.Forms.Button();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLocate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetTSql = new System.Windows.Forms.Button();
            this.pn = new Shared.Controls.PopupNotifier();
            this.labelConnectionInfo = new System.Windows.Forms.Label();
            this.tabResult.SuspendLayout();
            this.cmsBrowser.SuspendLayout();
            this.tabStyle.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRCO)).BeginInit();
            this.tabConnect.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.tbMonitor.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabResult
            // 
            this.tabResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.tabResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabResult.Controls.Add(this.webBrowser1);
            this.tabResult.Controls.Add(this.btnExcel);
            this.tabResult.Location = new System.Drawing.Point(4, 25);
            this.tabResult.Name = "tabResult";
            this.tabResult.Size = new System.Drawing.Size(776, 457);
            this.tabResult.TabIndex = 2;
            this.tabResult.Text = "Result";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.ContextMenuStrip = this.cmsBrowser;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(772, 453);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1_DocumentCompleted);
            // 
            // cmsBrowser
            // 
            this.cmsBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCopyToClipboard,
            this.itemSaveAsHtml,
            this.itemExcel});
            this.cmsBrowser.Name = "cmsBrowser";
            this.cmsBrowser.Size = new System.Drawing.Size(170, 70);
            // 
            // itemCopyToClipboard
            // 
            this.itemCopyToClipboard.Name = "itemCopyToClipboard";
            this.itemCopyToClipboard.Size = new System.Drawing.Size(169, 22);
            this.itemCopyToClipboard.Text = "Copy to clipboard";
            this.itemCopyToClipboard.Click += new System.EventHandler(this.ItemCopyToClipboard_Click);
            // 
            // itemSaveAsHtml
            // 
            this.itemSaveAsHtml.Name = "itemSaveAsHtml";
            this.itemSaveAsHtml.Size = new System.Drawing.Size(169, 22);
            this.itemSaveAsHtml.Text = "Save as HTML";
            this.itemSaveAsHtml.Click += new System.EventHandler(this.ItemSaveAsHtml_Click);
            // 
            // itemExcel
            // 
            this.itemExcel.Name = "itemExcel";
            this.itemExcel.Size = new System.Drawing.Size(169, 22);
            this.itemExcel.Text = "Save as Excel ";
            this.itemExcel.Click += new System.EventHandler(this.ItemExcel_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(675, 425);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 1;
            // 
            // tabStyle
            // 
            this.tabStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.tabStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabStyle.Controls.Add(this.label13);
            this.tabStyle.Controls.Add(this.txtCustomStyle);
            this.tabStyle.Controls.Add(this.cmbStyle);
            this.tabStyle.Controls.Add(this.label12);
            this.tabStyle.Location = new System.Drawing.Point(4, 25);
            this.tabStyle.Name = "tabStyle";
            this.tabStyle.Size = new System.Drawing.Size(776, 457);
            this.tabStyle.TabIndex = 3;
            this.tabStyle.Text = "Style";
            this.tabStyle.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Custom style";
            // 
            // txtCustomStyle
            // 
            this.txtCustomStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomStyle.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtCustomStyle.Location = new System.Drawing.Point(10, 84);
            this.txtCustomStyle.Multiline = true;
            this.txtCustomStyle.Name = "txtCustomStyle";
            this.txtCustomStyle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCustomStyle.Size = new System.Drawing.Size(766, 363);
            this.txtCustomStyle.TabIndex = 8;
            // 
            // cmbStyle
            // 
            this.cmbStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStyle.AutoCompleteCustomSource.AddRange(new string[] {
            "Custom",
            "Black",
            "Brown",
            "Rose",
            "Red",
            "Blue",
            "Green"});
            this.cmbStyle.BackColor = System.Drawing.SystemColors.Control;
            this.cmbStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(10, 29);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(221, 24);
            this.cmbStyle.TabIndex = 1;
            this.cmbStyle.SelectedValueChanged += new System.EventHandler(this.cmbStyle_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Style :";
            // 
            // tabTable
            // 
            this.tabTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.tabTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabTable.Controls.Add(this.groupBox1);
            this.tabTable.Location = new System.Drawing.Point(4, 25);
            this.tabTable.Name = "tabTable";
            this.tabTable.Size = new System.Drawing.Size(776, 457);
            this.tabTable.TabIndex = 4;
            this.tabTable.Text = "Html table";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAppend);
            this.groupBox1.Controls.Add(this.txtRCO);
            this.groupBox1.Controls.Add(this.cmbRotate);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtFooter);
            this.groupBox1.Controls.Add(this.txtCaption);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 453);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spetial parametars";
            // 
            // chkAppend
            // 
            this.chkAppend.AutoSize = true;
            this.chkAppend.Location = new System.Drawing.Point(14, 273);
            this.chkAppend.Name = "chkAppend";
            this.chkAppend.Size = new System.Drawing.Size(15, 14);
            this.chkAppend.TabIndex = 17;
            this.chkAppend.UseVisualStyleBackColor = true;
            // 
            // txtRCO
            // 
            this.txtRCO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRCO.BackColor = System.Drawing.SystemColors.Control;
            this.txtRCO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtRCO.Location = new System.Drawing.Point(14, 203);
            this.txtRCO.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtRCO.Name = "txtRCO";
            this.txtRCO.Size = new System.Drawing.Size(116, 23);
            this.txtRCO.TabIndex = 16;
            // 
            // cmbRotate
            // 
            this.cmbRotate.BackColor = System.Drawing.SystemColors.Control;
            this.cmbRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbRotate.FormattingEnabled = true;
            this.cmbRotate.Items.AddRange(new object[] {
            "NoRotate",
            "AutoRotate",
            "AlwaysRotate"});
            this.cmbRotate.Location = new System.Drawing.Point(12, 140);
            this.cmbRotate.Name = "cmbRotate";
            this.cmbRotate.Size = new System.Drawing.Size(225, 24);
            this.cmbRotate.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 248);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Append to existing content";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Rotate  column ordinal :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Rotate :";
            // 
            // txtFooter
            // 
            this.txtFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFooter.BackColor = System.Drawing.SystemColors.Control;
            this.txtFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtFooter.Location = new System.Drawing.Point(12, 92);
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.Size = new System.Drawing.Size(755, 23);
            this.txtFooter.TabIndex = 5;
            // 
            // txtCaption
            // 
            this.txtCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaption.BackColor = System.Drawing.SystemColors.Control;
            this.txtCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtCaption.Location = new System.Drawing.Point(12, 43);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(755, 23);
            this.txtCaption.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Footer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Caption";
            // 
            // tabConnect
            // 
            this.tabConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.tabConnect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabConnect.Controls.Add(this.listBoxConnection);
            this.tabConnect.Controls.Add(this.btnTestConnection);
            this.tabConnect.Controls.Add(this.cmbDatabase);
            this.tabConnect.Controls.Add(this.cmbAuth);
            this.tabConnect.Controls.Add(this.label5);
            this.tabConnect.Controls.Add(this.label4);
            this.tabConnect.Controls.Add(this.label3);
            this.tabConnect.Controls.Add(this.label2);
            this.tabConnect.Controls.Add(this.label14);
            this.tabConnect.Controls.Add(this.label1);
            this.tabConnect.Controls.Add(this.txtPassword);
            this.tabConnect.Controls.Add(this.txtUserName);
            this.tabConnect.Controls.Add(this.txtServer);
            this.tabConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabConnect.Location = new System.Drawing.Point(4, 25);
            this.tabConnect.Name = "tabConnect";
            this.tabConnect.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnect.Size = new System.Drawing.Size(776, 457);
            this.tabConnect.TabIndex = 0;
            this.tabConnect.Text = "Connect";
            // 
            // listBoxConnection
            // 
            this.listBoxConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxConnection.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxConnection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxConnection.FormattingEnabled = true;
            this.listBoxConnection.ItemHeight = 34;
            this.listBoxConnection.Location = new System.Drawing.Point(409, 25);
            this.listBoxConnection.Name = "listBoxConnection";
            this.listBoxConnection.Size = new System.Drawing.Size(362, 378);
            this.listBoxConnection.TabIndex = 44;
            this.listBoxConnection.TabStop = false;
            this.listBoxConnection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LstConnections_DrawItem);
            this.listBoxConnection.SelectedIndexChanged += new System.EventHandler(this.LstConnections_SelectedIndexChanged);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.BackColor = System.Drawing.SystemColors.Control;
            this.btnTestConnection.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnTestConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTestConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Location = new System.Drawing.Point(36, 332);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(249, 23);
            this.btnTestConnection.TabIndex = 3;
            this.btnTestConnection.TabStop = false;
            this.btnTestConnection.Text = "Test connection";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.BackColor = System.Drawing.SystemColors.Control;
            this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(36, 270);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(249, 24);
            this.cmbDatabase.TabIndex = 42;
            this.cmbDatabase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbDatabase_MouseClick);
            // 
            // cmbAuth
            // 
            this.cmbAuth.BackColor = System.Drawing.SystemColors.Control;
            this.cmbAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbAuth.FormattingEnabled = true;
            this.cmbAuth.ItemHeight = 16;
            this.cmbAuth.Items.AddRange(new object[] {
            "Windows authentication",
            "Sql server authentication"});
            this.cmbAuth.Location = new System.Drawing.Point(36, 97);
            this.cmbAuth.Name = "cmbAuth";
            this.cmbAuth.Size = new System.Drawing.Size(249, 24);
            this.cmbAuth.TabIndex = 6;
            this.cmbAuth.SelectedValueChanged += new System.EventHandler(this.CmbAuth_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Database name  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "User name  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Authentication :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(400, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Recient connection :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server name :";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPassword.Location = new System.Drawing.Point(36, 210);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(247, 23);
            this.txtPassword.TabIndex = 20;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUserName.Location = new System.Drawing.Point(36, 151);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(247, 23);
            this.txtUserName.TabIndex = 10;
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.SystemColors.Control;
            this.txtServer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtServer.Location = new System.Drawing.Point(34, 41);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(247, 23);
            this.txtServer.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabConnect);
            this.tabControl1.Controls.Add(this.tabQuery);
            this.tabControl1.Controls.Add(this.tabTable);
            this.tabControl1.Controls.Add(this.tabStyle);
            this.tabControl1.Controls.Add(this.tabResult);
            this.tabControl1.Controls.Add(this.tbMonitor);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 486);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabQuery
            // 
            this.tabQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.tabQuery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabQuery.Controls.Add(this.txtParams);
            this.tabQuery.Controls.Add(this.label7);
            this.tabQuery.Controls.Add(this.label6);
            this.tabQuery.Controls.Add(this.txtQuery);
            this.tabQuery.Location = new System.Drawing.Point(4, 25);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuery.Size = new System.Drawing.Size(776, 457);
            this.tabQuery.TabIndex = 1;
            this.tabQuery.Text = "Query";
            this.tabQuery.UseVisualStyleBackColor = true;
            // 
            // txtParams
            // 
            this.txtParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParams.BackColor = System.Drawing.SystemColors.Control;
            this.txtParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtParams.Location = new System.Drawing.Point(8, 31);
            this.txtParams.Multiline = true;
            this.txtParams.Name = "txtParams";
            this.txtParams.Size = new System.Drawing.Size(758, 42);
            this.txtParams.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Parametars";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Query";
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.BackColor = System.Drawing.SystemColors.Control;
            this.txtQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtQuery.Location = new System.Drawing.Point(5, 96);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuery.Size = new System.Drawing.Size(766, 366);
            this.txtQuery.TabIndex = 20;
            // 
            // tbMonitor
            // 
            this.tbMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.tbMonitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbMonitor.Controls.Add(this.chkIsUserDefined);
            this.tbMonitor.Controls.Add(this.btnUnloadAppDomain);
            this.tbMonitor.Controls.Add(this.btnLoadAppDomain);
            this.tbMonitor.Controls.Add(this.chbUserVisible);
            this.tbMonitor.Controls.Add(this.txtClrName);
            this.tbMonitor.Controls.Add(this.txtState);
            this.tbMonitor.Controls.Add(this.txtAppDomainName);
            this.tbMonitor.Controls.Add(this.txtAppDomainAddress);
            this.tbMonitor.Controls.Add(this.txtPrincipalName);
            this.tbMonitor.Controls.Add(this.txtPermissionSet);
            this.tbMonitor.Controls.Add(this.txtCreationTime);
            this.tbMonitor.Controls.Add(this.txtLoadTime);
            this.tbMonitor.Controls.Add(this.txtModifiedDate);
            this.tbMonitor.Controls.Add(this.txtCreatedDate);
            this.tbMonitor.Controls.Add(this.txtAssemblyId);
            this.tbMonitor.Controls.Add(this.txtValue);
            this.tbMonitor.Controls.Add(this.txtCost);
            this.tbMonitor.Controls.Add(this.totalAllocatedMemory);
            this.tbMonitor.Controls.Add(this.txtSurvivedMemory);
            this.tbMonitor.Controls.Add(this.totalProcesorTime);
            this.tbMonitor.Controls.Add(this.txtWeakRefCount);
            this.tbMonitor.Controls.Add(this.txtStrongRefCount);
            this.tbMonitor.Controls.Add(this.txtPrincipalId);
            this.tbMonitor.Controls.Add(this.listBoxAssemblies);
            this.tbMonitor.Controls.Add(this.label29);
            this.tbMonitor.Controls.Add(this.label27);
            this.tbMonitor.Controls.Add(this.label25);
            this.tbMonitor.Controls.Add(this.label20);
            this.tbMonitor.Controls.Add(this.label18);
            this.tbMonitor.Controls.Add(this.label19);
            this.tbMonitor.Controls.Add(this.label28);
            this.tbMonitor.Controls.Add(this.label26);
            this.tbMonitor.Controls.Add(this.label24);
            this.tbMonitor.Controls.Add(this.label23);
            this.tbMonitor.Controls.Add(this.label22);
            this.tbMonitor.Controls.Add(this.label21);
            this.tbMonitor.Controls.Add(this.label33);
            this.tbMonitor.Controls.Add(this.label32);
            this.tbMonitor.Controls.Add(this.label35);
            this.tbMonitor.Controls.Add(this.label34);
            this.tbMonitor.Controls.Add(this.label36);
            this.tbMonitor.Controls.Add(this.label31);
            this.tbMonitor.Controls.Add(this.label30);
            this.tbMonitor.Controls.Add(this.label37);
            this.tbMonitor.Controls.Add(this.label17);
            this.tbMonitor.Controls.Add(this.label16);
            this.tbMonitor.Location = new System.Drawing.Point(4, 25);
            this.tbMonitor.Name = "tbMonitor";
            this.tbMonitor.Size = new System.Drawing.Size(776, 457);
            this.tbMonitor.TabIndex = 5;
            this.tbMonitor.Text = "Monitor";
            // 
            // chkIsUserDefined
            // 
            this.chkIsUserDefined.AutoSize = true;
            this.chkIsUserDefined.Enabled = false;
            this.chkIsUserDefined.Location = new System.Drawing.Point(322, 167);
            this.chkIsUserDefined.Name = "chkIsUserDefined";
            this.chkIsUserDefined.Size = new System.Drawing.Size(15, 14);
            this.chkIsUserDefined.TabIndex = 48;
            this.chkIsUserDefined.UseVisualStyleBackColor = true;
            // 
            // btnUnloadAppDomain
            // 
            this.btnUnloadAppDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnloadAppDomain.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnloadAppDomain.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnUnloadAppDomain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUnloadAppDomain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUnloadAppDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnloadAppDomain.Location = new System.Drawing.Point(588, 420);
            this.btnUnloadAppDomain.Name = "btnUnloadAppDomain";
            this.btnUnloadAppDomain.Size = new System.Drawing.Size(178, 23);
            this.btnUnloadAppDomain.TabIndex = 4;
            this.btnUnloadAppDomain.TabStop = false;
            this.btnUnloadAppDomain.Text = "Unload appdomain";
            this.btnUnloadAppDomain.UseVisualStyleBackColor = false;
            this.btnUnloadAppDomain.Click += new System.EventHandler(this.btnUnLoadAppDomain_Click);
            // 
            // btnLoadAppDomain
            // 
            this.btnLoadAppDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAppDomain.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoadAppDomain.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnLoadAppDomain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLoadAppDomain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLoadAppDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadAppDomain.Location = new System.Drawing.Point(391, 420);
            this.btnLoadAppDomain.Name = "btnLoadAppDomain";
            this.btnLoadAppDomain.Size = new System.Drawing.Size(178, 23);
            this.btnLoadAppDomain.TabIndex = 4;
            this.btnLoadAppDomain.TabStop = false;
            this.btnLoadAppDomain.Text = "Load appdomain";
            this.btnLoadAppDomain.UseVisualStyleBackColor = false;
            this.btnLoadAppDomain.Click += new System.EventHandler(this.btnLoadAppDomain_Click);
            // 
            // chbUserVisible
            // 
            this.chbUserVisible.AutoSize = true;
            this.chbUserVisible.Enabled = false;
            this.chbUserVisible.Location = new System.Drawing.Point(240, 167);
            this.chbUserVisible.Name = "chbUserVisible";
            this.chbUserVisible.Size = new System.Drawing.Size(15, 14);
            this.chbUserVisible.TabIndex = 48;
            this.chbUserVisible.UseVisualStyleBackColor = true;
            // 
            // txtClrName
            // 
            this.txtClrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClrName.BackColor = System.Drawing.SystemColors.Control;
            this.txtClrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtClrName.Location = new System.Drawing.Point(240, 109);
            this.txtClrName.Multiline = true;
            this.txtClrName.Name = "txtClrName";
            this.txtClrName.ReadOnly = true;
            this.txtClrName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClrName.Size = new System.Drawing.Size(526, 39);
            this.txtClrName.TabIndex = 47;
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.SystemColors.Control;
            this.txtState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtState.Location = new System.Drawing.Point(240, 315);
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(347, 23);
            this.txtState.TabIndex = 46;
            // 
            // txtAppDomainName
            // 
            this.txtAppDomainName.BackColor = System.Drawing.SystemColors.Control;
            this.txtAppDomainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtAppDomainName.Location = new System.Drawing.Point(240, 263);
            this.txtAppDomainName.Multiline = true;
            this.txtAppDomainName.Name = "txtAppDomainName";
            this.txtAppDomainName.ReadOnly = true;
            this.txtAppDomainName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAppDomainName.Size = new System.Drawing.Size(347, 33);
            this.txtAppDomainName.TabIndex = 46;
            // 
            // txtAppDomainAddress
            // 
            this.txtAppDomainAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtAppDomainAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtAppDomainAddress.Location = new System.Drawing.Point(240, 211);
            this.txtAppDomainAddress.Name = "txtAppDomainAddress";
            this.txtAppDomainAddress.ReadOnly = true;
            this.txtAppDomainAddress.Size = new System.Drawing.Size(347, 23);
            this.txtAppDomainAddress.TabIndex = 46;
            // 
            // txtPrincipalName
            // 
            this.txtPrincipalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrincipalName.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrincipalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPrincipalName.Location = new System.Drawing.Point(311, 26);
            this.txtPrincipalName.Name = "txtPrincipalName";
            this.txtPrincipalName.ReadOnly = true;
            this.txtPrincipalName.Size = new System.Drawing.Size(455, 23);
            this.txtPrincipalName.TabIndex = 46;
            // 
            // txtPermissionSet
            // 
            this.txtPermissionSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPermissionSet.BackColor = System.Drawing.SystemColors.Control;
            this.txtPermissionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPermissionSet.Location = new System.Drawing.Point(311, 68);
            this.txtPermissionSet.Name = "txtPermissionSet";
            this.txtPermissionSet.ReadOnly = true;
            this.txtPermissionSet.Size = new System.Drawing.Size(457, 23);
            this.txtPermissionSet.TabIndex = 46;
            // 
            // txtCreationTime
            // 
            this.txtCreationTime.BackColor = System.Drawing.SystemColors.Control;
            this.txtCreationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtCreationTime.Location = new System.Drawing.Point(602, 263);
            this.txtCreationTime.Name = "txtCreationTime";
            this.txtCreationTime.ReadOnly = true;
            this.txtCreationTime.Size = new System.Drawing.Size(164, 23);
            this.txtCreationTime.TabIndex = 46;
            // 
            // txtLoadTime
            // 
            this.txtLoadTime.BackColor = System.Drawing.SystemColors.Control;
            this.txtLoadTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLoadTime.Location = new System.Drawing.Point(602, 211);
            this.txtLoadTime.Name = "txtLoadTime";
            this.txtLoadTime.ReadOnly = true;
            this.txtLoadTime.Size = new System.Drawing.Size(164, 23);
            this.txtLoadTime.TabIndex = 46;
            // 
            // txtModifiedDate
            // 
            this.txtModifiedDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtModifiedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtModifiedDate.Location = new System.Drawing.Point(602, 167);
            this.txtModifiedDate.Name = "txtModifiedDate";
            this.txtModifiedDate.ReadOnly = true;
            this.txtModifiedDate.Size = new System.Drawing.Size(164, 23);
            this.txtModifiedDate.TabIndex = 46;
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtCreatedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtCreatedDate.Location = new System.Drawing.Point(399, 167);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.ReadOnly = true;
            this.txtCreatedDate.Size = new System.Drawing.Size(157, 23);
            this.txtCreatedDate.TabIndex = 46;
            // 
            // txtAssemblyId
            // 
            this.txtAssemblyId.BackColor = System.Drawing.SystemColors.Control;
            this.txtAssemblyId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtAssemblyId.Location = new System.Drawing.Point(242, 68);
            this.txtAssemblyId.Name = "txtAssemblyId";
            this.txtAssemblyId.ReadOnly = true;
            this.txtAssemblyId.Size = new System.Drawing.Size(61, 23);
            this.txtAssemblyId.TabIndex = 46;
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.SystemColors.Control;
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtValue.Location = new System.Drawing.Point(401, 368);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(76, 23);
            this.txtValue.TabIndex = 46;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.SystemColors.Control;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtCost.Location = new System.Drawing.Point(331, 368);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(61, 23);
            this.txtCost.TabIndex = 46;
            this.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalAllocatedMemory
            // 
            this.totalAllocatedMemory.BackColor = System.Drawing.SystemColors.Control;
            this.totalAllocatedMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.totalAllocatedMemory.Location = new System.Drawing.Point(629, 368);
            this.totalAllocatedMemory.Name = "totalAllocatedMemory";
            this.totalAllocatedMemory.ReadOnly = true;
            this.totalAllocatedMemory.Size = new System.Drawing.Size(127, 23);
            this.totalAllocatedMemory.TabIndex = 46;
            this.totalAllocatedMemory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSurvivedMemory
            // 
            this.txtSurvivedMemory.BackColor = System.Drawing.SystemColors.Control;
            this.txtSurvivedMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtSurvivedMemory.ForeColor = System.Drawing.Color.Red;
            this.txtSurvivedMemory.Location = new System.Drawing.Point(242, 420);
            this.txtSurvivedMemory.Name = "txtSurvivedMemory";
            this.txtSurvivedMemory.ReadOnly = true;
            this.txtSurvivedMemory.Size = new System.Drawing.Size(127, 23);
            this.txtSurvivedMemory.TabIndex = 46;
            this.txtSurvivedMemory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalProcesorTime
            // 
            this.totalProcesorTime.BackColor = System.Drawing.SystemColors.Control;
            this.totalProcesorTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.totalProcesorTime.Location = new System.Drawing.Point(483, 368);
            this.totalProcesorTime.Name = "totalProcesorTime";
            this.totalProcesorTime.ReadOnly = true;
            this.totalProcesorTime.Size = new System.Drawing.Size(127, 23);
            this.totalProcesorTime.TabIndex = 46;
            this.totalProcesorTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWeakRefCount
            // 
            this.txtWeakRefCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtWeakRefCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtWeakRefCount.Location = new System.Drawing.Point(240, 368);
            this.txtWeakRefCount.Name = "txtWeakRefCount";
            this.txtWeakRefCount.ReadOnly = true;
            this.txtWeakRefCount.Size = new System.Drawing.Size(61, 23);
            this.txtWeakRefCount.TabIndex = 46;
            this.txtWeakRefCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStrongRefCount
            // 
            this.txtStrongRefCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtStrongRefCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtStrongRefCount.Location = new System.Drawing.Point(602, 315);
            this.txtStrongRefCount.Name = "txtStrongRefCount";
            this.txtStrongRefCount.ReadOnly = true;
            this.txtStrongRefCount.Size = new System.Drawing.Size(61, 23);
            this.txtStrongRefCount.TabIndex = 46;
            this.txtStrongRefCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrincipalId
            // 
            this.txtPrincipalId.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrincipalId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPrincipalId.Location = new System.Drawing.Point(240, 26);
            this.txtPrincipalId.Name = "txtPrincipalId";
            this.txtPrincipalId.ReadOnly = true;
            this.txtPrincipalId.Size = new System.Drawing.Size(61, 23);
            this.txtPrincipalId.TabIndex = 46;
            // 
            // listBoxAssemblies
            // 
            this.listBoxAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxAssemblies.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxAssemblies.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxAssemblies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxAssemblies.FormattingEnabled = true;
            this.listBoxAssemblies.ItemHeight = 35;
            this.listBoxAssemblies.Location = new System.Drawing.Point(18, 26);
            this.listBoxAssemblies.Name = "listBoxAssemblies";
            this.listBoxAssemblies.Size = new System.Drawing.Size(202, 424);
            this.listBoxAssemblies.TabIndex = 45;
            this.listBoxAssemblies.TabStop = false;
            this.listBoxAssemblies.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxAssemblies_DrawItem);
            this.listBoxAssemblies.SelectedIndexChanged += new System.EventHandler(this.listBoxAssemblies_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(237, 299);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "State :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(237, 247);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(98, 13);
            this.label27.TabIndex = 2;
            this.label27.Text = "App.domain name :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(237, 195);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(109, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "App.domain address :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(312, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Permission set :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(237, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Assembly id :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(237, 93);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Clr name:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(599, 247);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(74, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "Creation time :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(599, 195);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 13);
            this.label26.TabIndex = 2;
            this.label26.Text = "Load time :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(599, 151);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "Modified date :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(398, 151);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Created date :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(319, 151);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "User defined :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(237, 151);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "User visible :";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(398, 352);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(40, 13);
            this.label33.TabIndex = 2;
            this.label33.Text = "Value :";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(328, 352);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(34, 13);
            this.label32.TabIndex = 2;
            this.label32.Text = "Cost :";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(626, 352);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(143, 13);
            this.label35.TabIndex = 2;
            this.label35.Text = "Total allocated memory ( kb )";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(480, 352);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(130, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "Total processor time ( ms )";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(237, 404);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(121, 13);
            this.label36.TabIndex = 2;
            this.label36.Text = "Survived memory ( kb ) :";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(237, 352);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(87, 13);
            this.label31.TabIndex = 2;
            this.label31.Text = "Weak ref.count :";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(599, 299);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(89, 13);
            this.label30.TabIndex = 2;
            this.label30.Text = "Strong ref.count :";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(308, 10);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(84, 13);
            this.label37.TabIndex = 2;
            this.label37.Text = "Principal Name :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(237, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Principal id :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Assemblies :";
            // 
            // btnGetHtml
            // 
            this.btnGetHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetHtml.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetHtml.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnGetHtml.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGetHtml.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGetHtml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetHtml.Location = new System.Drawing.Point(150, 528);
            this.btnGetHtml.Name = "btnGetHtml";
            this.btnGetHtml.Size = new System.Drawing.Size(219, 23);
            this.btnGetHtml.TabIndex = 4;
            this.btnGetHtml.TabStop = false;
            this.btnGetHtml.Text = "Get HTML";
            this.btnGetHtml.UseVisualStyleBackColor = false;
            this.btnGetHtml.Click += new System.EventHandler(this.btnGetIt_Click);
            // 
            // cms
            // 
            this.cms.Font = new System.Drawing.Font("Calibri", 9F);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuLocate,
            this.mnuClose});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(130, 70);
            this.cms.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Cms_ItemClicked);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(129, 22);
            this.mnuOpen.Text = "Open file";
            // 
            // mnuLocate
            // 
            this.mnuLocate.Name = "mnuLocate";
            this.mnuLocate.Size = new System.Drawing.Size(129, 22);
            this.mnuLocate.Text = "Locate file";
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(129, 22);
            this.mnuClose.Text = "Close";
            // 
            // btnGetTSql
            // 
            this.btnGetTSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetTSql.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetTSql.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnGetTSql.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGetTSql.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGetTSql.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetTSql.Location = new System.Drawing.Point(415, 528);
            this.btnGetTSql.Name = "btnGetTSql";
            this.btnGetTSql.Size = new System.Drawing.Size(219, 23);
            this.btnGetTSql.TabIndex = 4;
            this.btnGetTSql.TabStop = false;
            this.btnGetTSql.Text = "Get T-SQL";
            this.btnGetTSql.UseVisualStyleBackColor = false;
            this.btnGetTSql.Click += new System.EventHandler(this.btnGetTSQL_Click);
            // 
            // pn
            // 
            this.pn.ContentFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pn.ContentText = "The file is successfully formed. The file can be downloaded at this location. Cli" +
    "ck to open locations";
            this.pn.Image = null;
            this.pn.ImagePadding = new System.Windows.Forms.Padding(15);
            this.pn.ImageSize = new System.Drawing.Size(128, 128);
            this.pn.IsRightToLeft = false;
            this.pn.OptionsMenu = this.cms;
            this.pn.ShowOptionsButton = true;
            this.pn.Size = new System.Drawing.Size(400, 200);
            this.pn.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.pn.TitlePadding = new System.Windows.Forms.Padding(5);
            this.pn.TitleText = "Notification";
            this.pn.Click += new System.EventHandler(this.pn_Click);
            // 
            // labelConnectionInfo
            // 
            this.labelConnectionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelConnectionInfo.AutoSize = true;
            this.labelConnectionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConnectionInfo.Location = new System.Drawing.Point(12, 498);
            this.labelConnectionInfo.Name = "labelConnectionInfo";
            this.labelConnectionInfo.Size = new System.Drawing.Size(0, 13);
            this.labelConnectionInfo.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.labelConnectionInfo);
            this.Controls.Add(this.btnGetTSql);
            this.Controls.Add(this.btnGetHtml);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueryToHtml tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabResult.ResumeLayout(false);
            this.cmsBrowser.ResumeLayout(false);
            this.tabStyle.ResumeLayout(false);
            this.tabStyle.PerformLayout();
            this.tabTable.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRCO)).EndInit();
            this.tabConnect.ResumeLayout(false);
            this.tabConnect.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabQuery.ResumeLayout(false);
            this.tabQuery.PerformLayout();
            this.tbMonitor.ResumeLayout(false);
            this.tbMonitor.PerformLayout();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.TabPage tabStyle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCustomStyle;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown txtRCO;
        private System.Windows.Forms.ComboBox cmbRotate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabConnect;
        private System.Windows.Forms.ListBox listBoxConnection;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.ComboBox cmbAuth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabQuery;
        private System.Windows.Forms.TextBox txtParams;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnGetHtml;
        private System.Windows.Forms.CheckBox chkAppend;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ContextMenuStrip cmsBrowser;
        private System.Windows.Forms.ToolStripMenuItem itemCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem itemSaveAsHtml;
        private System.Windows.Forms.ToolStripMenuItem itemExcel;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tbMonitor;
        private System.Windows.Forms.ListBox listBoxAssemblies;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkIsUserDefined;
        private System.Windows.Forms.CheckBox chbUserVisible;
        private System.Windows.Forms.TextBox txtClrName;
        private System.Windows.Forms.TextBox txtPermissionSet;
        private System.Windows.Forms.TextBox txtModifiedDate;
        private System.Windows.Forms.TextBox txtCreatedDate;
        private System.Windows.Forms.TextBox txtAssemblyId;
        private System.Windows.Forms.TextBox txtPrincipalId;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAppDomainAddress;
        private System.Windows.Forms.TextBox txtLoadTime;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtAppDomainName;
        private System.Windows.Forms.TextBox txtCreationTime;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox totalAllocatedMemory;
        private System.Windows.Forms.TextBox txtSurvivedMemory;
        private System.Windows.Forms.TextBox totalProcesorTime;
        private System.Windows.Forms.TextBox txtWeakRefCount;
        private System.Windows.Forms.TextBox txtStrongRefCount;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnUnloadAppDomain;
        private System.Windows.Forms.Button btnLoadAppDomain;
        private Shared.Controls.PopupNotifier pn;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuLocate;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Button btnGetTSql;
        private System.Windows.Forms.TextBox txtPrincipalName;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label labelConnectionInfo;
    }
}

