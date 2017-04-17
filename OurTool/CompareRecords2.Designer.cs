namespace OurCRMTool
{
    partial class CompareRecords2
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
            this.butFrom2To1 = new System.Windows.Forms.Button();
            this.butFrom1To2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAllRecords = new System.Windows.Forms.TabPage();
            this.ldFilterBy = new System.Windows.Forms.Label();
            this.gridEnviroment2 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbRecords2 = new System.Windows.Forms.Label();
            this.lbEnviroment2 = new System.Windows.Forms.Label();
            this.comboFilterBy = new System.Windows.Forms.ComboBox();
            this.lbEnviroment1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRecords1 = new System.Windows.Forms.Label();
            this.gridEnviroment1 = new System.Windows.Forms.DataGridView();
            this.Differences = new System.Windows.Forms.TabPage();
            this.lbEnviroment2b = new System.Windows.Forms.Label();
            this.lbEnviroment1b = new System.Windows.Forms.Label();
            this.gridDiff2 = new System.Windows.Forms.DataGridView();
            this.gridDiff1 = new System.Windows.Forms.DataGridView();
            this.OnlyInOneEnviroment = new System.Windows.Forms.TabPage();
            this.butClearAllOnlyIn2 = new System.Windows.Forms.Button();
            this.butClearAllOnlyIn1 = new System.Windows.Forms.Button();
            this.butSelAllOnlyIn2 = new System.Windows.Forms.Button();
            this.butSelAllOnlyIn1 = new System.Windows.Forms.Button();
            this.lbEnviroment2c = new System.Windows.Forms.Label();
            this.lbEnviroment1c = new System.Windows.Forms.Label();
            this.gridOnlyIn2 = new System.Windows.Forms.DataGridView();
            this.gridOnlyIn1 = new System.Windows.Forms.DataGridView();
            this.butRefresh = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabAllRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEnviroment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEnviroment1)).BeginInit();
            this.Differences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiff2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiff1)).BeginInit();
            this.OnlyInOneEnviroment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOnlyIn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOnlyIn1)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // butFrom2To1
            // 
            this.butFrom2To1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butFrom2To1.Location = new System.Drawing.Point(1116, 250);
            this.butFrom2To1.Name = "butFrom2To1";
            this.butFrom2To1.Size = new System.Drawing.Size(103, 53);
            this.butFrom2To1.TabIndex = 81;
            this.butFrom2To1.Text = "Copy/Create in 1st enviroment <<<";
            this.butFrom2To1.UseVisualStyleBackColor = true;
            this.butFrom2To1.Click += new System.EventHandler(this.butFrom2To1_Click);
            // 
            // butFrom1To2
            // 
            this.butFrom1To2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butFrom1To2.Location = new System.Drawing.Point(1114, 177);
            this.butFrom1To2.Name = "butFrom1To2";
            this.butFrom1To2.Size = new System.Drawing.Size(105, 55);
            this.butFrom1To2.TabIndex = 80;
            this.butFrom1To2.Text = "Copy/Create in 2nd enviroment >>>";
            this.butFrom1To2.UseVisualStyleBackColor = true;
            this.butFrom1To2.Click += new System.EventHandler(this.butFrom1To2_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAllRecords);
            this.tabControl1.Controls.Add(this.Differences);
            this.tabControl1.Controls.Add(this.OnlyInOneEnviroment);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1102, 514);
            this.tabControl1.TabIndex = 79;
            // 
            // tabAllRecords
            // 
            this.tabAllRecords.Controls.Add(this.ldFilterBy);
            this.tabAllRecords.Controls.Add(this.gridEnviroment2);
            this.tabAllRecords.Controls.Add(this.txtSearch);
            this.tabAllRecords.Controls.Add(this.lbRecords2);
            this.tabAllRecords.Controls.Add(this.lbEnviroment2);
            this.tabAllRecords.Controls.Add(this.comboFilterBy);
            this.tabAllRecords.Controls.Add(this.lbEnviroment1);
            this.tabAllRecords.Controls.Add(this.label2);
            this.tabAllRecords.Controls.Add(this.lbRecords1);
            this.tabAllRecords.Controls.Add(this.gridEnviroment1);
            this.tabAllRecords.Location = new System.Drawing.Point(4, 22);
            this.tabAllRecords.Name = "tabAllRecords";
            this.tabAllRecords.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllRecords.Size = new System.Drawing.Size(1094, 488);
            this.tabAllRecords.TabIndex = 0;
            this.tabAllRecords.Text = "All records";
            this.tabAllRecords.UseVisualStyleBackColor = true;
            // 
            // ldFilterBy
            // 
            this.ldFilterBy.AutoSize = true;
            this.ldFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ldFilterBy.Location = new System.Drawing.Point(570, 54);
            this.ldFilterBy.Name = "ldFilterBy";
            this.ldFilterBy.Size = new System.Drawing.Size(84, 17);
            this.ldFilterBy.TabIndex = 67;
            this.ldFilterBy.Text = "FieldName";
            // 
            // gridEnviroment2
            // 
            this.gridEnviroment2.AllowUserToAddRows = false;
            this.gridEnviroment2.AllowUserToDeleteRows = false;
            this.gridEnviroment2.AllowUserToResizeRows = false;
            this.gridEnviroment2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEnviroment2.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridEnviroment2.Location = new System.Drawing.Point(549, 85);
            this.gridEnviroment2.MultiSelect = false;
            this.gridEnviroment2.Name = "gridEnviroment2";
            this.gridEnviroment2.RowHeadersVisible = false;
            this.gridEnviroment2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEnviroment2.Size = new System.Drawing.Size(534, 369);
            this.gridEnviroment2.TabIndex = 66;
            this.gridEnviroment2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEnviroment2_CellClick);
            this.gridEnviroment2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick2);
            this.gridEnviroment2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridEnviroment2_Scroll);
            this.gridEnviroment2.SelectionChanged += new System.EventHandler(this.gridEnviroment2_SelectionChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(660, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(397, 20);
            this.txtSearch.TabIndex = 70;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbRecords2
            // 
            this.lbRecords2.AutoSize = true;
            this.lbRecords2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbRecords2.Location = new System.Drawing.Point(546, 457);
            this.lbRecords2.Name = "lbRecords2";
            this.lbRecords2.Size = new System.Drawing.Size(114, 17);
            this.lbRecords2.TabIndex = 72;
            this.lbRecords2.Text = "Nr of Records:";
            // 
            // lbEnviroment2
            // 
            this.lbEnviroment2.AutoSize = true;
            this.lbEnviroment2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbEnviroment2.Location = new System.Drawing.Point(563, 3);
            this.lbEnviroment2.Name = "lbEnviroment2";
            this.lbEnviroment2.Size = new System.Drawing.Size(77, 13);
            this.lbEnviroment2.TabIndex = 69;
            this.lbEnviroment2.Text = "Enviroment2";
            // 
            // comboFilterBy
            // 
            this.comboFilterBy.FormattingEnabled = true;
            this.comboFilterBy.Location = new System.Drawing.Point(360, 54);
            this.comboFilterBy.Name = "comboFilterBy";
            this.comboFilterBy.Size = new System.Drawing.Size(193, 21);
            this.comboFilterBy.TabIndex = 73;
            this.comboFilterBy.SelectedIndexChanged += new System.EventHandler(this.comboFilterBy_SelectedIndexChanged);
            // 
            // lbEnviroment1
            // 
            this.lbEnviroment1.AutoSize = true;
            this.lbEnviroment1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbEnviroment1.Location = new System.Drawing.Point(5, 4);
            this.lbEnviroment1.Name = "lbEnviroment1";
            this.lbEnviroment1.Size = new System.Drawing.Size(77, 13);
            this.lbEnviroment1.TabIndex = 68;
            this.lbEnviroment1.Text = "Enviroment1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(287, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "Filter by";
            // 
            // lbRecords1
            // 
            this.lbRecords1.AutoSize = true;
            this.lbRecords1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbRecords1.Location = new System.Drawing.Point(6, 457);
            this.lbRecords1.Name = "lbRecords1";
            this.lbRecords1.Size = new System.Drawing.Size(114, 17);
            this.lbRecords1.TabIndex = 71;
            this.lbRecords1.Text = "Nr of Records:";
            // 
            // gridEnviroment1
            // 
            this.gridEnviroment1.AllowUserToAddRows = false;
            this.gridEnviroment1.AllowUserToDeleteRows = false;
            this.gridEnviroment1.AllowUserToResizeRows = false;
            this.gridEnviroment1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEnviroment1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridEnviroment1.Location = new System.Drawing.Point(9, 85);
            this.gridEnviroment1.MultiSelect = false;
            this.gridEnviroment1.Name = "gridEnviroment1";
            this.gridEnviroment1.RowHeadersVisible = false;
            this.gridEnviroment1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEnviroment1.Size = new System.Drawing.Size(534, 369);
            this.gridEnviroment1.TabIndex = 65;
            this.gridEnviroment1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEnviroment1_CellClick);
            this.gridEnviroment1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick1);
            this.gridEnviroment1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridEnviroment1_Scroll);
            this.gridEnviroment1.SelectionChanged += new System.EventHandler(this.gridEnviroment1_SelectionChanged);
            // 
            // Differences
            // 
            this.Differences.Controls.Add(this.lbEnviroment2b);
            this.Differences.Controls.Add(this.lbEnviroment1b);
            this.Differences.Controls.Add(this.gridDiff2);
            this.Differences.Controls.Add(this.gridDiff1);
            this.Differences.Location = new System.Drawing.Point(4, 22);
            this.Differences.Name = "Differences";
            this.Differences.Padding = new System.Windows.Forms.Padding(3);
            this.Differences.Size = new System.Drawing.Size(1094, 488);
            this.Differences.TabIndex = 1;
            this.Differences.Text = "Differences";
            this.Differences.UseVisualStyleBackColor = true;
            // 
            // lbEnviroment2b
            // 
            this.lbEnviroment2b.AutoSize = true;
            this.lbEnviroment2b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbEnviroment2b.Location = new System.Drawing.Point(549, 10);
            this.lbEnviroment2b.Name = "lbEnviroment2b";
            this.lbEnviroment2b.Size = new System.Drawing.Size(98, 17);
            this.lbEnviroment2b.TabIndex = 71;
            this.lbEnviroment2b.Text = "Enviroment2";
            // 
            // lbEnviroment1b
            // 
            this.lbEnviroment1b.AutoSize = true;
            this.lbEnviroment1b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbEnviroment1b.Location = new System.Drawing.Point(3, 10);
            this.lbEnviroment1b.Name = "lbEnviroment1b";
            this.lbEnviroment1b.Size = new System.Drawing.Size(98, 17);
            this.lbEnviroment1b.TabIndex = 70;
            this.lbEnviroment1b.Text = "Enviroment1";
            // 
            // gridDiff2
            // 
            this.gridDiff2.AllowUserToAddRows = false;
            this.gridDiff2.AllowUserToDeleteRows = false;
            this.gridDiff2.AllowUserToResizeRows = false;
            this.gridDiff2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDiff2.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridDiff2.Location = new System.Drawing.Point(543, 30);
            this.gridDiff2.MultiSelect = false;
            this.gridDiff2.Name = "gridDiff2";
            this.gridDiff2.RowHeadersVisible = false;
            this.gridDiff2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDiff2.Size = new System.Drawing.Size(534, 422);
            this.gridDiff2.TabIndex = 68;
            this.gridDiff2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDiff2_CellClick);
            this.gridDiff2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick2);
            this.gridDiff2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridDiff2_Scroll);
            this.gridDiff2.SelectionChanged += new System.EventHandler(this.gridDiff2_SelectionChanged);
            // 
            // gridDiff1
            // 
            this.gridDiff1.AllowUserToAddRows = false;
            this.gridDiff1.AllowUserToDeleteRows = false;
            this.gridDiff1.AllowUserToResizeRows = false;
            this.gridDiff1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDiff1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridDiff1.Location = new System.Drawing.Point(3, 30);
            this.gridDiff1.MultiSelect = false;
            this.gridDiff1.Name = "gridDiff1";
            this.gridDiff1.RowHeadersVisible = false;
            this.gridDiff1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDiff1.Size = new System.Drawing.Size(534, 422);
            this.gridDiff1.TabIndex = 67;
            this.gridDiff1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDiff1_CellClick);
            this.gridDiff1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick1);
            this.gridDiff1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridDiff1_Scroll);
            this.gridDiff1.SelectionChanged += new System.EventHandler(this.gridDiff2_SelectionChanged);
            // 
            // OnlyInOneEnviroment
            // 
            this.OnlyInOneEnviroment.Controls.Add(this.butClearAllOnlyIn2);
            this.OnlyInOneEnviroment.Controls.Add(this.butClearAllOnlyIn1);
            this.OnlyInOneEnviroment.Controls.Add(this.butSelAllOnlyIn2);
            this.OnlyInOneEnviroment.Controls.Add(this.butSelAllOnlyIn1);
            this.OnlyInOneEnviroment.Controls.Add(this.lbEnviroment2c);
            this.OnlyInOneEnviroment.Controls.Add(this.lbEnviroment1c);
            this.OnlyInOneEnviroment.Controls.Add(this.gridOnlyIn2);
            this.OnlyInOneEnviroment.Controls.Add(this.gridOnlyIn1);
            this.OnlyInOneEnviroment.Location = new System.Drawing.Point(4, 22);
            this.OnlyInOneEnviroment.Name = "OnlyInOneEnviroment";
            this.OnlyInOneEnviroment.Size = new System.Drawing.Size(1094, 488);
            this.OnlyInOneEnviroment.TabIndex = 2;
            this.OnlyInOneEnviroment.Text = "Only In One Enviroment";
            this.OnlyInOneEnviroment.UseVisualStyleBackColor = true;
            // 
            // butClearAllOnlyIn2
            // 
            this.butClearAllOnlyIn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearAllOnlyIn2.Location = new System.Drawing.Point(865, 450);
            this.butClearAllOnlyIn2.Name = "butClearAllOnlyIn2";
            this.butClearAllOnlyIn2.Size = new System.Drawing.Size(103, 29);
            this.butClearAllOnlyIn2.TabIndex = 79;
            this.butClearAllOnlyIn2.Text = "Clear All";
            this.butClearAllOnlyIn2.UseVisualStyleBackColor = true;
            this.butClearAllOnlyIn2.Click += new System.EventHandler(this.butClearAllOnlyIn2_Click);
            // 
            // butClearAllOnlyIn1
            // 
            this.butClearAllOnlyIn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearAllOnlyIn1.Location = new System.Drawing.Point(325, 450);
            this.butClearAllOnlyIn1.Name = "butClearAllOnlyIn1";
            this.butClearAllOnlyIn1.Size = new System.Drawing.Size(103, 29);
            this.butClearAllOnlyIn1.TabIndex = 78;
            this.butClearAllOnlyIn1.Text = "Clear All";
            this.butClearAllOnlyIn1.UseVisualStyleBackColor = true;
            this.butClearAllOnlyIn1.Click += new System.EventHandler(this.butClearAllOnlyIn1_Click);
            // 
            // butSelAllOnlyIn2
            // 
            this.butSelAllOnlyIn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSelAllOnlyIn2.Location = new System.Drawing.Point(974, 450);
            this.butSelAllOnlyIn2.Name = "butSelAllOnlyIn2";
            this.butSelAllOnlyIn2.Size = new System.Drawing.Size(103, 29);
            this.butSelAllOnlyIn2.TabIndex = 77;
            this.butSelAllOnlyIn2.Text = "Select All";
            this.butSelAllOnlyIn2.UseVisualStyleBackColor = true;
            this.butSelAllOnlyIn2.Click += new System.EventHandler(this.butSelAllOnlyIn2_Click);
            // 
            // butSelAllOnlyIn1
            // 
            this.butSelAllOnlyIn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSelAllOnlyIn1.Location = new System.Drawing.Point(434, 450);
            this.butSelAllOnlyIn1.Name = "butSelAllOnlyIn1";
            this.butSelAllOnlyIn1.Size = new System.Drawing.Size(103, 29);
            this.butSelAllOnlyIn1.TabIndex = 76;
            this.butSelAllOnlyIn1.Text = "Select All";
            this.butSelAllOnlyIn1.UseVisualStyleBackColor = true;
            this.butSelAllOnlyIn1.Click += new System.EventHandler(this.butSelAllOnlyIn1_Click);
            // 
            // lbEnviroment2c
            // 
            this.lbEnviroment2c.AutoSize = true;
            this.lbEnviroment2c.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbEnviroment2c.Location = new System.Drawing.Point(549, 10);
            this.lbEnviroment2c.Name = "lbEnviroment2c";
            this.lbEnviroment2c.Size = new System.Drawing.Size(98, 17);
            this.lbEnviroment2c.TabIndex = 75;
            this.lbEnviroment2c.Text = "Enviroment2";
            // 
            // lbEnviroment1c
            // 
            this.lbEnviroment1c.AutoSize = true;
            this.lbEnviroment1c.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbEnviroment1c.Location = new System.Drawing.Point(3, 10);
            this.lbEnviroment1c.Name = "lbEnviroment1c";
            this.lbEnviroment1c.Size = new System.Drawing.Size(98, 17);
            this.lbEnviroment1c.TabIndex = 74;
            this.lbEnviroment1c.Text = "Enviroment1";
            // 
            // gridOnlyIn2
            // 
            this.gridOnlyIn2.AllowUserToAddRows = false;
            this.gridOnlyIn2.AllowUserToDeleteRows = false;
            this.gridOnlyIn2.AllowUserToResizeRows = false;
            this.gridOnlyIn2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOnlyIn2.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridOnlyIn2.Location = new System.Drawing.Point(543, 30);
            this.gridOnlyIn2.MultiSelect = false;
            this.gridOnlyIn2.Name = "gridOnlyIn2";
            this.gridOnlyIn2.RowHeadersVisible = false;
            this.gridOnlyIn2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOnlyIn2.Size = new System.Drawing.Size(534, 414);
            this.gridOnlyIn2.TabIndex = 73;
            this.gridOnlyIn2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOnlyIn2_CellClick);
            this.gridOnlyIn2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick2);
            // 
            // gridOnlyIn1
            // 
            this.gridOnlyIn1.AllowUserToAddRows = false;
            this.gridOnlyIn1.AllowUserToDeleteRows = false;
            this.gridOnlyIn1.AllowUserToResizeRows = false;
            this.gridOnlyIn1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOnlyIn1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridOnlyIn1.Location = new System.Drawing.Point(3, 30);
            this.gridOnlyIn1.MultiSelect = false;
            this.gridOnlyIn1.Name = "gridOnlyIn1";
            this.gridOnlyIn1.RowHeadersVisible = false;
            this.gridOnlyIn1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOnlyIn1.Size = new System.Drawing.Size(534, 414);
            this.gridOnlyIn1.TabIndex = 72;
            this.gridOnlyIn1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOnlyIn1_CellClick);
            this.gridOnlyIn1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick1);
            // 
            // butRefresh
            // 
            this.butRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butRefresh.Location = new System.Drawing.Point(1116, 504);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(103, 29);
            this.butRefresh.TabIndex = 64;
            this.butRefresh.Text = "Refresh";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.butFrom2To1);
            this.groupBox.Controls.Add(this.butFrom1To2);
            this.groupBox.Controls.Add(this.tabControl1);
            this.groupBox.Controls.Add(this.butRefresh);
            this.groupBox.Enabled = false;
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1224, 547);
            this.groupBox.TabIndex = 76;
            this.groupBox.TabStop = false;
            // 
            // CompareRecords2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 562);
            this.Controls.Add(this.groupBox);
            this.MaximizeBox = false;
            this.Name = "CompareRecords2";
            this.Text = "CompareRecords2";
            this.tabControl1.ResumeLayout(false);
            this.tabAllRecords.ResumeLayout(false);
            this.tabAllRecords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEnviroment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEnviroment1)).EndInit();
            this.Differences.ResumeLayout(false);
            this.Differences.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiff2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiff1)).EndInit();
            this.OnlyInOneEnviroment.ResumeLayout(false);
            this.OnlyInOneEnviroment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOnlyIn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOnlyIn1)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butFrom2To1;
        private System.Windows.Forms.Button butFrom1To2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAllRecords;
        private System.Windows.Forms.Label ldFilterBy;
        private System.Windows.Forms.DataGridView gridEnviroment2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbRecords2;
        private System.Windows.Forms.Label lbEnviroment2;
        private System.Windows.Forms.ComboBox comboFilterBy;
        private System.Windows.Forms.Label lbEnviroment1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecords1;
        private System.Windows.Forms.DataGridView gridEnviroment1;
        private System.Windows.Forms.TabPage Differences;
        private System.Windows.Forms.Label lbEnviroment2b;
        private System.Windows.Forms.Label lbEnviroment1b;
        private System.Windows.Forms.DataGridView gridDiff2;
        private System.Windows.Forms.DataGridView gridDiff1;
        private System.Windows.Forms.TabPage OnlyInOneEnviroment;
        private System.Windows.Forms.Label lbEnviroment2c;
        private System.Windows.Forms.Label lbEnviroment1c;
        private System.Windows.Forms.DataGridView gridOnlyIn2;
        private System.Windows.Forms.DataGridView gridOnlyIn1;
        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button butClearAllOnlyIn2;
        private System.Windows.Forms.Button butClearAllOnlyIn1;
        private System.Windows.Forms.Button butSelAllOnlyIn2;
        private System.Windows.Forms.Button butSelAllOnlyIn1;
    }
}