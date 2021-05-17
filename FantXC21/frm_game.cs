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
    public partial class frm_game : Form
    {
        private Season season;
        private Workout selectedWorkout;
        private Card selectedCard;
        private List<Workout> workoutList;
        private int workoutNum;

        public frm_game()
        {
            season = new Season();
            season.AddWeekToSeason();
            InitializeComponent();
            showPanel(pnl_titleScreen.Name);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            setupWorkoutPanel(season.weeks.Last().WorkoutSelection_One);
            workoutNum = 1;
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
            this.workoutList = workoutList;

            lbl_weekInfo.Text = "Week #" + season.weekNum.ToString() + " - " + (13 - season.weekNum).ToString() + " races until the championship";

            bar_championshipProgress.Value = season.player.getTotalPoints();

            int numTopThrees = season.player.getNumTopThreeFinishes();
            if (numTopThrees > 4) { numTopThrees = 4; }

            for (int i = 0; i < numTopThrees; i += 1)
            {
                cbl_topThreeFinishes.SetItemChecked(i, true);
            }

            dg_workoutSelection.DataSource = getWorkoutList_DT(workoutList);
            dg_workoutSelection.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            selectedWorkout = workoutList[0];
            dg_workoutSelection.Rows[0].Selected = true;

            double exhaustionDecimal = 1 + season.player.exhaustion * 0.1;
            string exhaustionString = exhaustionDecimal.ToString();

            lbl_exhaustionInfo.Text = "Exhaustion: " + season.player.exhaustion.ToString() + "\n"
                + "The energy cost of workouts during races will be multiplied by " + exhaustionString + ".";
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
            List<Workout> playerWorkouts = new List<Workout>();
            foreach(workoutType type in season.player.workouts)
            {
                playerWorkouts.Add(new Workout(type));
            }
            dg_workoutInfo.DataSource = getWorkoutList_DT(playerWorkouts);
            dg_workoutSelection.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void setupSeasonStandingInfoPanel()
        {
            DataTable runners_DT = new DataTable();
            runners_DT.Columns.Add("Name");
            runners_DT.Columns.Add("Points", typeof(int));
            runners_DT.Columns.Add("Top-3 Finishes", typeof(int));
            runners_DT.Columns.Add("Personal Best Time", typeof(TimeSpan));
            runners_DT.Columns.Add("Qualified?");

            foreach(Runner runner in season.runners)
            {
                string nameString = runner.name;

                if (runner.isPlayer) { nameString += " (You)"; }
                runners_DT.Rows.Add(
                    nameString,
                    runner.getTotalPoints(),
                    runner.getNumTopThreeFinishes(),
                    runner.personalBest,
                    runner.qualified ? "Yes" : "No");
            }

            dg_seasonStandings.DataSource = runners_DT;
        }

        private void setupDeckInfoPanel()
        {
            DataTable deckData = new DataTable();
            deckData.Columns.Add("Card Name");
            deckData.Columns.Add("Distance", typeof(int));
            deckData.Columns.Add("Description");
            deckData.Columns.Add("Energy", typeof(int));
            deckData.Columns.Add("Number of Copies", typeof(int));

            Dictionary<cardType, int> playerCardCount = new Dictionary<cardType, int>();
            List<cardType> allPlayerCards = season.player.deck.Concat(season.player.discard).Concat(season.player.hand).ToList();
            
            foreach (cardType type in season.player.deck)
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
                Card playerCard = season.player.getModifiedCard(playerCardCount.ElementAt(i).Key);
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

        private void dg_playerHand_Changed(object sender, EventArgs e)
        {
            if (dg_playerHand.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dg_playerHand.SelectedCells[0];
                DataGridViewRow selectedCellRow = selectedCell.OwningRow;
                selectedCellRow.Selected = true;
                selectedCard = selectedCard = selectedCellRow.Cells[4].Value as Card;
                btn_selectCardFromHand.Text = "Play Card: \"" + selectedCellRow.Cells["Name"].Value;
                btn_selectCardFromHand.Enabled = season.isCardValid(selectedCard.cardType, season.player.name);
            }
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
            season.player.doWorkout(selectedWorkout);
            if (workoutNum == 1)
            {
                workoutNum = 2;
                setupWorkoutPanel(season.weeks.Last().WorkoutSelection_Two);
            }
            else
            {
                season.SelectAndPerformWorkoutsForAllCPURunners();
                
                Race displayRace = season.playerRace;
                ri_raceImage.SetCourse(displayRace.course);
                ri_raceImage.SetRunnerPositionList(season.runnersInPlayerRace);
                
                lbl_raceInfo.Text = "Race #" + season.weekNum + " at " + displayRace.course.name;
                
                season.setupRace(displayRace);
                startNewRaceTurn();

                showPanel(pnl_race.Name);
            }
        }

        private void startNewRaceTurn()
        {
            season.startNewRaceTurn(season.playerRace);
            DataTable handContents = new DataTable();
            handContents.Columns.Add("Name");
            handContents.Columns.Add("Distance (meters)", typeof(int));
            handContents.Columns.Add("Cost (% energy)", typeof(int));
            handContents.Columns.Add("Description");
            handContents.Columns.Add("Card", typeof(Card));


            foreach(cardType type in season.player.hand)
            {
                Card handCard = season.player.getModifiedCard(type);

                handContents.Rows.Add(
                    handCard.name,
                    handCard.distance,
                    handCard.energy,
                    handCard.specialText,
                    handCard
                    );
            }

            dg_playerHand.DataSource = handContents;
            dg_playerHand.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dg_playerHand.Rows[0].Selected = true;
            dg_playerHand.Columns["Card"].Visible = false;
            selectedCard = dg_playerHand.Rows[0].Cells[4].Value as Card;
            lbl_racePlayerStatus.Text = season.getRacePlayerStatus();
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

        private void btn_workoutInfoToWorkoutsView_Click(object sender, EventArgs e)
        {
            showPanel(pnl_workout.Name);
        }

        private void lbl_runnerInfo_Click(object sender, EventArgs e)
        {
            setupSeasonStandingInfoPanel();
            showPanel(pnl_seasonStandingInfo.Name);
        }

        private void btn_seasonToWorkoutView_Click(object sender, EventArgs e)
        {
            showPanel(pnl_workout.Name);
        }

        private void btn_selectCardFromHand_Click(object sender, EventArgs e)
        {
            season.player.playCard(selectedCard);
            if (season.player.turnEndPosition < 10000)
            {
                season.SelectAndPlayCardsForAllCPURunnersInRace(season.playerRace);
                season.endRaceTurn(season.playerRace);
                startNewRaceTurn();
                ri_raceImage.SetRunnerPositionList(season.runnersInPlayerRace);
                this.Refresh();
            }
            else
            {
                while (season.playerRace.finisherList.Count < season.playerRace.runnerNames.Count)
                {
                    season.SelectAndPlayCardsForAllCPURunnersInRace(season.playerRace);
                    season.endRaceTurn(season.playerRace);
                    startNewRaceTurn();
                    ri_raceImage.SetRunnerPositionList(season.runnersInPlayerRace);
                }
                foreach(Race race in season.weeks.Last().races.Where(r => !r.runnerNames.Contains(season.player.name)))
                {
                    season.simulateFullRace(race);
                }
                setupRaceResultPanel();
                showPanel(pnl_raceResults.Name);
            }
        }

        private string getLbl_playerRaceResultsText()
        {
            Course currentCourse = season.courses.Find(c => c.name == cb_racePicker.SelectedItem.ToString());
            return "You finished the race with " + season.player.currentEnergy.ToString()
                + " energy, accumulating " + Runner.exhaustionAccumulated(season.player.currentEnergy).ToString() + " exhaustion."
                + "\n" + currentCourse.name + " course record: " + currentCourse.courseRecord.ToString();
        }

        private void setupRaceResultPanel()
        {
            lbl_raceResults.Text = "Week " + season.weekNum.ToString() + " Race Results";
            
            cb_racePicker.Items.Clear();
            foreach(Course course in season.courses)
            {

                cb_racePicker.Items.Add(course.name);
            }
            cb_racePicker.SelectedIndex = cb_racePicker.Items.IndexOf(season.playerRace.course.name);
            
            lbl_playerRaceResults.Text = getLbl_playerRaceResultsText();
            dg_raceResults.DataSource = getRaceResultsDataTable(
                season.weeks.Last().races.Find(r => r.course.name == cb_racePicker.SelectedItem.ToString()));
        }

        private void cb_racePicker_OnValueChanged(object sender, EventArgs e)
        {
            dg_raceResults.DataSource = getRaceResultsDataTable(
                            season.weeks.Last().races.Find(r => r.course.name == cb_racePicker.SelectedItem.ToString()));
            lbl_playerRaceResults.Text = getLbl_playerRaceResultsText();
        }

        private DataTable getRaceResultsDataTable(Race race)
        {
            DataTable raceResultsDataTable = new DataTable();
            raceResultsDataTable.Columns.Add("Name");
            raceResultsDataTable.Columns.Add("Position", typeof(int));
            raceResultsDataTable.Columns.Add("Time", typeof(TimeSpan));

            for (int i = 0; i < race.sortedFinisherList.Count; i += 1)
            {
                string finisherName = race.sortedFinisherList.ElementAt(i);
                raceResultsDataTable.Rows.Add(
                    finisherName == season.player.name ? finisherName + " (You)" : finisherName,
                    i+1,
                    race.sortedFinisherList.ElementAt(i));
            }

            return raceResultsDataTable;
        }
    }
}
