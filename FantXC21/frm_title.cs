using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantXC21
{
    public partial class frm_title : Form
    {
        private Season season;
        private Workout selectedWorkout;
        private List<Workout> workoutList;
        private int workoutNum;

        public frm_title()
        {
            season = new Season();
            season.AddWeekToSeason();
            InitializeComponent();
            showPanel(pnl_titleScreen.Name);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            setupWorkoutPanel(season.weeks.Last().WorkoutSelection_One);
            showPanel(pnl_workout.Name);
        }

        private void showPanel(string panelName)
        {
            foreach(Control c in Controls)
            {
                if (c is Panel)
                {
                    if (c.Name == panelName) { c.Show(); }
                    else { c.Hide(); }
                }
            }
        }

        private void setupWorkoutPanel(List<Workout> workoutList)
        {
            this.workoutNum = 1;
            this.workoutList = workoutList;

            lbl_weekInfo.Text = "Week #" + season.weekNum.ToString() + ", " + (13 - season.weekNum).ToString() + " races until the championship";

            Runner player = season.runners.Where(r => r.isPlayer).FirstOrDefault();
            bar_championshipPoints.Value = player.getTotalPoints();
            
            int numTopThrees = player.getNumTopThreeFinishes();
            if (numTopThrees > 4) { numTopThrees = 4; }
            
            for (int i = 0; i < numTopThrees; i += 1)
            {
                cbl_topThreeFinishes.SetItemChecked(i, true);
            }

            dg_workoutSelection.DataSource = getWorkoutList_DT(workoutList);
            dg_workoutSelection.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            selectedWorkout = workoutList[0];
            dg_workoutSelection.Rows[0].Selected = true;
        }

        private DataTable getWorkoutList_DT(List<Workout> workoutList)
        {
            DataTable workoutList_dt = new DataTable();
            workoutList_dt.Columns.Add("Workout Name");
            workoutList_dt.Columns.Add("Type"); //Not actually workout type, this is based on the cost.
            workoutList_dt.Columns.Add("Description");
            workoutList_dt.Columns.Add("Cost (exhaustion)", typeof(int));

            foreach (Workout workout in workoutList)
            {
                string workoutStyle = "";
                switch (workout.cost)
                {
                    case 0:
                        workoutStyle = "Recovery";
                        break;
                    case 1:
                        workoutStyle = "Speed";
                        break;
                    case 2:
                        workoutStyle = "Pace";
                        break;
                    case 3:
                        workoutStyle = "Endurance";
                        break;
                }
                workoutList_dt.Rows.Add(
                    workout.name,
                    workoutStyle,
                    workout.text,
                    workout.cost
                );
            }

            return workoutList_dt;
        }

        private void setupWorkoutInfoPanel()
        {
            Runner player = season.runners.Where(p => p.isPlayer).FirstOrDefault();
            List<Workout> playerWorkouts = new List<Workout>();
            foreach(workoutType type in player.workouts)
            {
                playerWorkouts.Add(new Workout(type));
            }
            dg_workoutInfo.DataSource = getWorkoutList_DT(playerWorkouts);
            dg_workoutSelection.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void setupDeckInfoPanel()
        {
            DataTable deckData = new DataTable();
            deckData.Columns.Add("Card Name");
            deckData.Columns.Add("Distance", typeof(int));
            deckData.Columns.Add("Description");
            deckData.Columns.Add("Energy", typeof(int));
            deckData.Columns.Add("Number of Copies", typeof(int));

            Runner player = season.runners.Where(p => p.isPlayer).FirstOrDefault();
            Dictionary<cardType, int> playerCardCount = new Dictionary<cardType, int>();
            List<cardType> allPlayerCards = player.deck.Concat(player.discard).Concat(player.hand).ToList();
            
            foreach (cardType type in player.deck)
            {
                if (playerCardCount.ContainsKey(type))
                {
                    playerCardCount[type] += 1;
                }
                else
                {
                    playerCardCount.Add(type, 1);
                }
            }

            for (int i = 0; i < playerCardCount.Count; i += 1)
            {
                Card playerCard = player.getModifiedCard(playerCardCount.ElementAt(i).Key);
                deckData.Rows.Add(
                    playerCard.name,
                    playerCard.distance,
                    playerCard.specialText,
                    playerCard.energy,
                    playerCardCount.ElementAt(i).Value);
            }

            dg_deckInfo.DataSource = deckData;
            dg_deckInfo.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void btn_qualificationInfo_Click(object sender, EventArgs e)
        {
            string championshipStatus = 
                "To qualify, you must meet 1 of the following benchmarks:\n"
                + "Finish in the top 3 in " + Season.numTopThreeFinishesToQualify.ToString() + " different races\n"
                + "Accumulate a total of " + Season.pointsToQualify.ToString() + " points";
            MessageBox.Show(championshipStatus);
        }

        private void dg_workoutSelection_Changed(object sender, EventArgs e)
        {
            if (dg_workoutSelection.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dg_workoutSelection.SelectedCells[0];
                DataGridViewRow selectedCellRow = selectedCell.OwningRow;
                selectedCellRow.Selected = true;
                selectedWorkout = workoutList.Where(w => w.name == selectedCellRow.Cells[0].Value.ToString()).FirstOrDefault();
                btn_selectWorkout.Text = "Select Workout: \"" + selectedWorkout.name + "\" (" + workoutNum.ToString() + " of 2)";
            }
        }

        private void btn_selectWorkout_Click(object sender, EventArgs e)
        {
            season.runners.Where(r => r.isPlayer).FirstOrDefault().doWorkout(selectedWorkout);
            if (workoutNum == 1)
            {
                workoutNum = 2;
                setupWorkoutPanel(season.weeks.Last().WorkoutSelection_Two);
            }
            else
            {
                season.SelectAndPerformWorkoutsForAllCPURunners();
                //Go to race phase
            }
        }

        private void btn_backFromDeckView_Click(object sender, EventArgs e)
        {
            showPanel(pnl_workout.Name);
        }

        private void btn_viewDeck_Click(object sender, EventArgs e)
        {
            setupDeckInfoPanel();
            showPanel(pnl_deckInfo.Name);
        }

        private void btn_viewWorkouts_Click(object sender, EventArgs e)
        {
            setupWorkoutInfoPanel();
            showPanel(pnl_workoutInfo.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showPanel(pnl_workout.Name);
        }
    }
}
