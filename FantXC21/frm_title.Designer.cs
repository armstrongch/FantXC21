﻿namespace FantXC21
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_titleScreen = new System.Windows.Forms.Panel();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_gameTitle = new System.Windows.Forms.Label();
            this.lbl_presents = new System.Windows.Forms.Label();
            this.pnl_workout = new System.Windows.Forms.Panel();
            this.lbl_weekInfo = new System.Windows.Forms.Label();
            this.lbl_runnerInfo = new System.Windows.Forms.Button();
            this.lbl_exhaustionInfo = new System.Windows.Forms.Label();
            this.lbl_qualificationInfo = new System.Windows.Forms.Label();
            this.btn_viewWorkouts = new System.Windows.Forms.Button();
            this.btn_viewDeck = new System.Windows.Forms.Button();
            this.btn_selectWorkout = new System.Windows.Forms.Button();
            this.dg_workoutSelection = new System.Windows.Forms.DataGridView();
            this.cbl_topThreeFinishes = new System.Windows.Forms.CheckedListBox();
            this.bar_championshipPoints = new System.Windows.Forms.ProgressBar();
            this.pnl_seasonStandingInfo = new System.Windows.Forms.Panel();
            this.btn_seasonToWorkoutView = new System.Windows.Forms.Button();
            this.dg_seasonStandings = new System.Windows.Forms.DataGridView();
            this.lbl_seasonStandingsTitle = new System.Windows.Forms.Label();
            this.pnl_deckInfo = new System.Windows.Forms.Panel();
            this.btn_deckToWorkoutView = new System.Windows.Forms.Button();
            this.lbl_deckInfo = new System.Windows.Forms.Label();
            this.dg_deckInfo = new System.Windows.Forms.DataGridView();
            this.pnl_workoutInfo = new System.Windows.Forms.Panel();
            this.dg_workoutInfo = new System.Windows.Forms.DataGridView();
            this.lbl_workoutInfo = new System.Windows.Forms.Label();
            this.btn_workoutInfoToWorkoutsView = new System.Windows.Forms.Button();
            this.pnl_race = new System.Windows.Forms.Panel();
            this.pnl_titleScreen.SuspendLayout();
            this.pnl_workout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_workoutSelection)).BeginInit();
            this.pnl_seasonStandingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_seasonStandings)).BeginInit();
            this.pnl_deckInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_deckInfo)).BeginInit();
            this.pnl_workoutInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_workoutInfo)).BeginInit();
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
            this.btn_start.Size = new System.Drawing.Size(175, 30);
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
            this.pnl_workout.Controls.Add(this.lbl_weekInfo);
            this.pnl_workout.Controls.Add(this.lbl_runnerInfo);
            this.pnl_workout.Controls.Add(this.lbl_exhaustionInfo);
            this.pnl_workout.Controls.Add(this.lbl_qualificationInfo);
            this.pnl_workout.Controls.Add(this.btn_viewWorkouts);
            this.pnl_workout.Controls.Add(this.btn_viewDeck);
            this.pnl_workout.Controls.Add(this.btn_selectWorkout);
            this.pnl_workout.Controls.Add(this.dg_workoutSelection);
            this.pnl_workout.Controls.Add(this.cbl_topThreeFinishes);
            this.pnl_workout.Controls.Add(this.bar_championshipPoints);
            this.pnl_workout.Location = new System.Drawing.Point(12, 12);
            this.pnl_workout.Name = "pnl_workout";
            this.pnl_workout.Size = new System.Drawing.Size(775, 426);
            this.pnl_workout.TabIndex = 4;
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
            // lbl_runnerInfo
            // 
            this.lbl_runnerInfo.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_runnerInfo.Location = new System.Drawing.Point(-1, 293);
            this.lbl_runnerInfo.Name = "lbl_runnerInfo";
            this.lbl_runnerInfo.Size = new System.Drawing.Size(176, 30);
            this.lbl_runnerInfo.TabIndex = 11;
            this.lbl_runnerInfo.Text = "Season Info";
            this.lbl_runnerInfo.UseVisualStyleBackColor = true;
            this.lbl_runnerInfo.Click += new System.EventHandler(this.lbl_runnerInfo_Click);
            // 
            // lbl_exhaustionInfo
            // 
            this.lbl_exhaustionInfo.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_exhaustionInfo.Location = new System.Drawing.Point(-1, 327);
            this.lbl_exhaustionInfo.Name = "lbl_exhaustionInfo";
            this.lbl_exhaustionInfo.Size = new System.Drawing.Size(175, 69);
            this.lbl_exhaustionInfo.TabIndex = 10;
            this.lbl_exhaustionInfo.Text = "Exhaustion: 0\r\nThe energy cost of workouts during races will be multiplied by 1.0" +
    "\r\n";
            // 
            // lbl_qualificationInfo
            // 
            this.lbl_qualificationInfo.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_qualificationInfo.Location = new System.Drawing.Point(1, 27);
            this.lbl_qualificationInfo.Name = "lbl_qualificationInfo";
            this.lbl_qualificationInfo.Size = new System.Drawing.Size(175, 80);
            this.lbl_qualificationInfo.TabIndex = 9;
            this.lbl_qualificationInfo.Text = "To qualify for the championship, finish in 3rd place or better in 4 different rac" +
    "es or accumulate 140 total points to qualify.";
            // 
            // btn_viewWorkouts
            // 
            this.btn_viewWorkouts.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_viewWorkouts.Location = new System.Drawing.Point(0, 257);
            this.btn_viewWorkouts.Name = "btn_viewWorkouts";
            this.btn_viewWorkouts.Size = new System.Drawing.Size(176, 30);
            this.btn_viewWorkouts.TabIndex = 8;
            this.btn_viewWorkouts.Text = "View Workouts";
            this.btn_viewWorkouts.UseVisualStyleBackColor = true;
            this.btn_viewWorkouts.Click += new System.EventHandler(this.btn_viewWorkouts_Click);
            // 
            // btn_viewDeck
            // 
            this.btn_viewDeck.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_viewDeck.Location = new System.Drawing.Point(0, 221);
            this.btn_viewDeck.Name = "btn_viewDeck";
            this.btn_viewDeck.Size = new System.Drawing.Size(176, 30);
            this.btn_viewDeck.TabIndex = 7;
            this.btn_viewDeck.Text = "View Deck";
            this.btn_viewDeck.UseVisualStyleBackColor = true;
            this.btn_viewDeck.Click += new System.EventHandler(this.btn_viewDeck_Click);
            // 
            // btn_selectWorkout
            // 
            this.btn_selectWorkout.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_selectWorkout.Location = new System.Drawing.Point(186, 396);
            this.btn_selectWorkout.Name = "btn_selectWorkout";
            this.btn_selectWorkout.Size = new System.Drawing.Size(589, 30);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_workoutSelection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dg_workoutSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_workoutSelection.DefaultCellStyle = dataGridViewCellStyle10;
            this.dg_workoutSelection.Location = new System.Drawing.Point(187, 33);
            this.dg_workoutSelection.Name = "dg_workoutSelection";
            this.dg_workoutSelection.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_workoutSelection.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dg_workoutSelection.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_workoutSelection.RowTemplate.Height = 25;
            this.dg_workoutSelection.Size = new System.Drawing.Size(590, 357);
            this.dg_workoutSelection.TabIndex = 5;
            this.dg_workoutSelection.SelectionChanged += new System.EventHandler(this.dg_workoutSelection_Changed);
            // 
            // cbl_topThreeFinishes
            // 
            this.cbl_topThreeFinishes.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbl_topThreeFinishes.FormattingEnabled = true;
            this.cbl_topThreeFinishes.Items.AddRange(new object[] {
            "Top-3 Finish #1",
            "Top-3 Finish #2",
            "Top-3 Finish #3",
            "Top-3 Finish #4"});
            this.cbl_topThreeFinishes.Location = new System.Drawing.Point(0, 139);
            this.cbl_topThreeFinishes.Name = "cbl_topThreeFinishes";
            this.cbl_topThreeFinishes.Size = new System.Drawing.Size(176, 76);
            this.cbl_topThreeFinishes.TabIndex = 4;
            // 
            // bar_championshipPoints
            // 
            this.bar_championshipPoints.Location = new System.Drawing.Point(0, 110);
            this.bar_championshipPoints.Maximum = 160;
            this.bar_championshipPoints.Name = "bar_championshipPoints";
            this.bar_championshipPoints.Size = new System.Drawing.Size(176, 23);
            this.bar_championshipPoints.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bar_championshipPoints.TabIndex = 3;
            // 
            // pnl_seasonStandingInfo
            // 
            this.pnl_seasonStandingInfo.Controls.Add(this.btn_seasonToWorkoutView);
            this.pnl_seasonStandingInfo.Controls.Add(this.dg_seasonStandings);
            this.pnl_seasonStandingInfo.Controls.Add(this.lbl_seasonStandingsTitle);
            this.pnl_seasonStandingInfo.Location = new System.Drawing.Point(11, 12);
            this.pnl_seasonStandingInfo.Name = "pnl_seasonStandingInfo";
            this.pnl_seasonStandingInfo.Size = new System.Drawing.Size(775, 425);
            this.pnl_seasonStandingInfo.TabIndex = 12;
            // 
            // btn_seasonToWorkoutView
            // 
            this.btn_seasonToWorkoutView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_seasonToWorkoutView.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_seasonToWorkoutView.Location = new System.Drawing.Point(0, 395);
            this.btn_seasonToWorkoutView.Name = "btn_seasonToWorkoutView";
            this.btn_seasonToWorkoutView.Size = new System.Drawing.Size(775, 30);
            this.btn_seasonToWorkoutView.TabIndex = 2;
            this.btn_seasonToWorkoutView.Text = "Back";
            this.btn_seasonToWorkoutView.UseVisualStyleBackColor = true;
            this.btn_seasonToWorkoutView.Click += new System.EventHandler(this.btn_seasonToWorkoutView_Click);
            // 
            // dg_seasonStandings
            // 
            this.dg_seasonStandings.AllowUserToAddRows = false;
            this.dg_seasonStandings.AllowUserToDeleteRows = false;
            this.dg_seasonStandings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_seasonStandings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_seasonStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_seasonStandings.Location = new System.Drawing.Point(1, 32);
            this.dg_seasonStandings.Name = "dg_seasonStandings";
            this.dg_seasonStandings.ReadOnly = true;
            this.dg_seasonStandings.RowTemplate.Height = 25;
            this.dg_seasonStandings.Size = new System.Drawing.Size(775, 360);
            this.dg_seasonStandings.TabIndex = 1;
            // 
            // lbl_seasonStandingsTitle
            // 
            this.lbl_seasonStandingsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_seasonStandingsTitle.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_seasonStandingsTitle.Location = new System.Drawing.Point(0, 0);
            this.lbl_seasonStandingsTitle.Name = "lbl_seasonStandingsTitle";
            this.lbl_seasonStandingsTitle.Size = new System.Drawing.Size(775, 23);
            this.lbl_seasonStandingsTitle.TabIndex = 0;
            this.lbl_seasonStandingsTitle.Text = "Season Standings";
            // 
            // pnl_deckInfo
            // 
            this.pnl_deckInfo.Controls.Add(this.btn_deckToWorkoutView);
            this.pnl_deckInfo.Controls.Add(this.lbl_deckInfo);
            this.pnl_deckInfo.Controls.Add(this.dg_deckInfo);
            this.pnl_deckInfo.Location = new System.Drawing.Point(12, 12);
            this.pnl_deckInfo.Name = "pnl_deckInfo";
            this.pnl_deckInfo.Size = new System.Drawing.Size(775, 426);
            this.pnl_deckInfo.TabIndex = 4;
            // 
            // btn_deckToWorkoutView
            // 
            this.btn_deckToWorkoutView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_deckToWorkoutView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_deckToWorkoutView.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_deckToWorkoutView.Location = new System.Drawing.Point(1, 396);
            this.btn_deckToWorkoutView.Name = "btn_deckToWorkoutView";
            this.btn_deckToWorkoutView.Size = new System.Drawing.Size(777, 30);
            this.btn_deckToWorkoutView.TabIndex = 6;
            this.btn_deckToWorkoutView.Text = "Back";
            this.btn_deckToWorkoutView.UseVisualStyleBackColor = true;
            this.btn_deckToWorkoutView.Click += new System.EventHandler(this.btn_backFromDeckView_Click);
            // 
            // lbl_deckInfo
            // 
            this.lbl_deckInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_deckInfo.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_deckInfo.Location = new System.Drawing.Point(0, 0);
            this.lbl_deckInfo.Name = "lbl_deckInfo";
            this.lbl_deckInfo.Size = new System.Drawing.Size(775, 23);
            this.lbl_deckInfo.TabIndex = 1;
            this.lbl_deckInfo.Text = "Your Deck:";
            // 
            // dg_deckInfo
            // 
            this.dg_deckInfo.AllowUserToAddRows = false;
            this.dg_deckInfo.AllowUserToDeleteRows = false;
            this.dg_deckInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_deckInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dg_deckInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_deckInfo.Location = new System.Drawing.Point(0, 33);
            this.dg_deckInfo.Name = "dg_deckInfo";
            this.dg_deckInfo.ReadOnly = true;
            this.dg_deckInfo.RowTemplate.Height = 25;
            this.dg_deckInfo.Size = new System.Drawing.Size(775, 357);
            this.dg_deckInfo.TabIndex = 5;
            // 
            // pnl_workoutInfo
            // 
            this.pnl_workoutInfo.Controls.Add(this.dg_workoutInfo);
            this.pnl_workoutInfo.Controls.Add(this.lbl_workoutInfo);
            this.pnl_workoutInfo.Controls.Add(this.btn_workoutInfoToWorkoutsView);
            this.pnl_workoutInfo.Location = new System.Drawing.Point(12, 12);
            this.pnl_workoutInfo.Name = "pnl_workoutInfo";
            this.pnl_workoutInfo.Size = new System.Drawing.Size(777, 426);
            this.pnl_workoutInfo.TabIndex = 5;
            // 
            // dg_workoutInfo
            // 
            this.dg_workoutInfo.AllowUserToAddRows = false;
            this.dg_workoutInfo.AllowUserToDeleteRows = false;
            this.dg_workoutInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_workoutInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_workoutInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dg_workoutInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_workoutInfo.Location = new System.Drawing.Point(0, 27);
            this.dg_workoutInfo.Name = "dg_workoutInfo";
            this.dg_workoutInfo.RowTemplate.Height = 25;
            this.dg_workoutInfo.Size = new System.Drawing.Size(775, 366);
            this.dg_workoutInfo.TabIndex = 9;
            // 
            // lbl_workoutInfo
            // 
            this.lbl_workoutInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_workoutInfo.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_workoutInfo.Location = new System.Drawing.Point(0, 0);
            this.lbl_workoutInfo.Name = "lbl_workoutInfo";
            this.lbl_workoutInfo.Size = new System.Drawing.Size(777, 23);
            this.lbl_workoutInfo.TabIndex = 8;
            this.lbl_workoutInfo.Text = "Previous Workouts";
            // 
            // btn_workoutInfoToWorkoutsView
            // 
            this.btn_workoutInfoToWorkoutsView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_workoutInfoToWorkoutsView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_workoutInfoToWorkoutsView.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_workoutInfoToWorkoutsView.Location = new System.Drawing.Point(1, 399);
            this.btn_workoutInfoToWorkoutsView.Name = "btn_workoutInfoToWorkoutsView";
            this.btn_workoutInfoToWorkoutsView.Size = new System.Drawing.Size(777, 30);
            this.btn_workoutInfoToWorkoutsView.TabIndex = 7;
            this.btn_workoutInfoToWorkoutsView.Text = "Back";
            this.btn_workoutInfoToWorkoutsView.UseVisualStyleBackColor = true;
            this.btn_workoutInfoToWorkoutsView.Click += new System.EventHandler(this.btn_workoutInfoToWorkoutsView_Click);
            // 
            // pnl_race
            // 
            this.pnl_race.Location = new System.Drawing.Point(13, 12);
            this.pnl_race.Name = "pnl_race";
            this.pnl_race.Size = new System.Drawing.Size(776, 429);
            this.pnl_race.TabIndex = 3;
            // 
            // frm_title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_workout);
            this.Controls.Add(this.pnl_race);
            this.Controls.Add(this.pnl_seasonStandingInfo);
            this.Controls.Add(this.pnl_workoutInfo);
            this.Controls.Add(this.pnl_deckInfo);
            this.Controls.Add(this.pnl_titleScreen);
            this.Name = "frm_title";
            this.Text = " FantXC21";
            this.pnl_titleScreen.ResumeLayout(false);
            this.pnl_workout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_workoutSelection)).EndInit();
            this.pnl_seasonStandingInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_seasonStandings)).EndInit();
            this.pnl_deckInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_deckInfo)).EndInit();
            this.pnl_workoutInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_workoutInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titleScreen;
        private System.Windows.Forms.Label lbl_presents;
        private System.Windows.Forms.Label lbl_gameTitle;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Panel pnl_workout;
        private System.Windows.Forms.Label lbl_weekInfo;
        private System.Windows.Forms.ProgressBar bar_championshipPoints;
        private System.Windows.Forms.CheckedListBox cbl_topThreeFinishes;
        private System.Windows.Forms.DataGridView dg_workoutSelection;
        private System.Windows.Forms.Button btn_selectWorkout;
        private System.Windows.Forms.Button btn_viewDeck;
        private System.Windows.Forms.Panel pnl_deckInfo;
        private System.Windows.Forms.Label lbl_deckInfo;
        private System.Windows.Forms.DataGridView dg_deckInfo;
        private System.Windows.Forms.Button btn_backToWorkoutView;
        private System.Windows.Forms.Button btn_workoutInfoToWorkoutsView;
        private System.Windows.Forms.Button btn_viewWorkouts;
        private System.Windows.Forms.Panel pnl_workoutInfo;
        private System.Windows.Forms.Button btn_deckToWorkoutView;
        private System.Windows.Forms.Label lbl_workoutInfo;
        private System.Windows.Forms.DataGridView dg_workoutInfo;
        private System.Windows.Forms.Label lbl_qualificationInfo;
        private System.Windows.Forms.Label lbl_exhaustionInfo;
        private System.Windows.Forms.Button lbl_runnerInfo;
        private System.Windows.Forms.Panel pnl_seasonStandingInfo;
        private System.Windows.Forms.Label lbl_seasonStandingsTitle;
        private System.Windows.Forms.Button btn_seasonToWorkoutView;
        private System.Windows.Forms.DataGridView dg_seasonStandings;
        private System.Windows.Forms.Panel pnl_race;
    }
}

