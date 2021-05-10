namespace FantXC21
{
    partial class frm_title
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_titleScreen = new System.Windows.Forms.Panel();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_gameTitle = new System.Windows.Forms.Label();
            this.lbl_presents = new System.Windows.Forms.Label();
            this.pnl_workout = new System.Windows.Forms.Panel();
            this.btn_selectWorkout = new System.Windows.Forms.Button();
            this.dg_workoutSelection = new System.Windows.Forms.DataGridView();
            this.cbl_topThreeFinishes = new System.Windows.Forms.CheckedListBox();
            this.bar_championshipPoints = new System.Windows.Forms.ProgressBar();
            this.btn_qualificationInfo = new System.Windows.Forms.Button();
            this.lbl_championshipInfo = new System.Windows.Forms.Label();
            this.lbl_weekInfo = new System.Windows.Forms.Label();
            this.pnl_titleScreen.SuspendLayout();
            this.pnl_workout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_workoutSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_titleScreen
            // 
            this.pnl_titleScreen.Controls.Add(this.btn_start);
            this.pnl_titleScreen.Controls.Add(this.lbl_gameTitle);
            this.pnl_titleScreen.Controls.Add(this.lbl_presents);
            this.pnl_titleScreen.Location = new System.Drawing.Point(13, 12);
            this.pnl_titleScreen.Name = "pnl_titleScreen";
            this.pnl_titleScreen.Size = new System.Drawing.Size(775, 426);
            this.pnl_titleScreen.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_start.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_start.Location = new System.Drawing.Point(312, 117);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(175, 46);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "Start New Season";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lbl_gameTitle
            // 
            this.lbl_gameTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_gameTitle.Font = new System.Drawing.Font("HP Simplified", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_gameTitle.Location = new System.Drawing.Point(0, 30);
            this.lbl_gameTitle.Name = "lbl_gameTitle";
            this.lbl_gameTitle.Size = new System.Drawing.Size(775, 30);
            this.lbl_gameTitle.TabIndex = 2;
            this.lbl_gameTitle.Text = "Fantasy Cross Country 2021";
            this.lbl_gameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_presents
            // 
            this.lbl_presents.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_presents.Font = new System.Drawing.Font("HP Simplified", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_presents.Location = new System.Drawing.Point(0, 0);
            this.lbl_presents.Name = "lbl_presents";
            this.lbl_presents.Size = new System.Drawing.Size(775, 30);
            this.lbl_presents.TabIndex = 1;
            this.lbl_presents.Text = "Chris \'Turd Boomerang\' Armstrong presents:\r\n";
            this.lbl_presents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_workout
            // 
            this.pnl_workout.Controls.Add(this.btn_selectWorkout);
            this.pnl_workout.Controls.Add(this.dg_workoutSelection);
            this.pnl_workout.Controls.Add(this.cbl_topThreeFinishes);
            this.pnl_workout.Controls.Add(this.bar_championshipPoints);
            this.pnl_workout.Controls.Add(this.btn_qualificationInfo);
            this.pnl_workout.Controls.Add(this.lbl_championshipInfo);
            this.pnl_workout.Controls.Add(this.lbl_weekInfo);
            this.pnl_workout.Location = new System.Drawing.Point(12, 12);
            this.pnl_workout.Name = "pnl_workout";
            this.pnl_workout.Size = new System.Drawing.Size(775, 426);
            this.pnl_workout.TabIndex = 4;
            // 
            // btn_selectWorkout
            // 
            this.btn_selectWorkout.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_selectWorkout.Location = new System.Drawing.Point(187, 380);
            this.btn_selectWorkout.Name = "btn_selectWorkout";
            this.btn_selectWorkout.Size = new System.Drawing.Size(589, 46);
            this.btn_selectWorkout.TabIndex = 6;
            this.btn_selectWorkout.Text = "Select Workout";
            this.btn_selectWorkout.UseVisualStyleBackColor = true;
            this.btn_selectWorkout.Click += new System.EventHandler(this.btn_selectWorkout_Click);
            // 
            // dg_workoutSelection
            // 
            this.dg_workoutSelection.AllowUserToAddRows = false;
            this.dg_workoutSelection.AllowUserToDeleteRows = false;
            this.dg_workoutSelection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_workoutSelection.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_workoutSelection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_workoutSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_workoutSelection.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_workoutSelection.Location = new System.Drawing.Point(186, 56);
            this.dg_workoutSelection.Name = "dg_workoutSelection";
            this.dg_workoutSelection.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_workoutSelection.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_workoutSelection.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_workoutSelection.RowTemplate.Height = 25;
            this.dg_workoutSelection.Size = new System.Drawing.Size(590, 318);
            this.dg_workoutSelection.TabIndex = 5;
            this.dg_workoutSelection.SelectionChanged += new System.EventHandler(this.dg_workoutSelection_Changed);
            // 
            // cbl_topThreeFinishes
            // 
            this.cbl_topThreeFinishes.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbl_topThreeFinishes.FormattingEnabled = true;
            this.cbl_topThreeFinishes.Items.AddRange(new object[] {
            "Top-3 Finish #1",
            "Top-3 Finish #2",
            "Top-3 Finish #3",
            "Top-3 Finish #4"});
            this.cbl_topThreeFinishes.Location = new System.Drawing.Point(1, 138);
            this.cbl_topThreeFinishes.Name = "cbl_topThreeFinishes";
            this.cbl_topThreeFinishes.Size = new System.Drawing.Size(176, 104);
            this.cbl_topThreeFinishes.TabIndex = 4;
            // 
            // bar_championshipPoints
            // 
            this.bar_championshipPoints.Location = new System.Drawing.Point(1, 109);
            this.bar_championshipPoints.Maximum = 160;
            this.bar_championshipPoints.Name = "bar_championshipPoints";
            this.bar_championshipPoints.Size = new System.Drawing.Size(176, 23);
            this.bar_championshipPoints.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bar_championshipPoints.TabIndex = 3;
            // 
            // btn_qualificationInfo
            // 
            this.btn_qualificationInfo.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_qualificationInfo.Location = new System.Drawing.Point(0, 56);
            this.btn_qualificationInfo.Name = "btn_qualificationInfo";
            this.btn_qualificationInfo.Size = new System.Drawing.Size(177, 46);
            this.btn_qualificationInfo.TabIndex = 2;
            this.btn_qualificationInfo.Text = "Qualification Info";
            this.btn_qualificationInfo.UseVisualStyleBackColor = true;
            this.btn_qualificationInfo.Click += new System.EventHandler(this.btn_qualificationInfo_Click);
            // 
            // lbl_championshipInfo
            // 
            this.lbl_championshipInfo.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_championshipInfo.Location = new System.Drawing.Point(1, 30);
            this.lbl_championshipInfo.Name = "lbl_championshipInfo";
            this.lbl_championshipInfo.Size = new System.Drawing.Size(774, 23);
            this.lbl_championshipInfo.TabIndex = 1;
            this.lbl_championshipInfo.Text = "champ_info_string";
            // 
            // lbl_weekInfo
            // 
            this.lbl_weekInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_weekInfo.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_weekInfo.Location = new System.Drawing.Point(1, 1);
            this.lbl_weekInfo.Name = "lbl_weekInfo";
            this.lbl_weekInfo.Size = new System.Drawing.Size(774, 29);
            this.lbl_weekInfo.TabIndex = 0;
            this.lbl_weekInfo.Text = "season_info_string";
            // 
            // frm_title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_workout);
            this.Controls.Add(this.pnl_titleScreen);
            this.Name = "frm_title";
            this.Text = " FantXC21";
            this.pnl_titleScreen.ResumeLayout(false);
            this.pnl_workout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_workoutSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titleScreen;
        private System.Windows.Forms.Label lbl_presents;
        private System.Windows.Forms.Label lbl_gameTitle;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Panel pnl_workout;
        private System.Windows.Forms.Label lbl_weekInfo;
        private System.Windows.Forms.Label lbl_championshipInfo;
        private System.Windows.Forms.Button btn_qualificationInfo;
        private System.Windows.Forms.ProgressBar bar_championshipPoints;
        private System.Windows.Forms.CheckedListBox cbl_topThreeFinishes;
        private System.Windows.Forms.DataGridView dg_workoutSelection;
        private System.Windows.Forms.Button btn_selectWorkout;
    }
}

