using System.Collections;
using System.Reflection;

namespace DesignPatterns.TournamentOverview.TournamentScreen
{

    public partial class TournamentScreen : ContentPage
    {
        Tournament tournament;
        ArrayList Tournaments = new ArrayList();
        ArrayList Armies = new ArrayList();
        ArrayList Maps = new ArrayList();
        ArrayList Primary = new ArrayList();
        ArrayList Secondary = new ArrayList();
        int index;
        public TournamentScreen(ArrayList Tournaments, int SelectedTournament, ArrayList Armies, ArrayList Maps, ArrayList Primary, ArrayList Secondary)
        {
            this.index = SelectedTournament;
            this.Maps = Maps;
            this.Primary = Primary;
            this.Secondary = Secondary;
            this.Tournaments = Tournaments;
            this.Armies = Armies;
            this.tournament = (Tournament?)Tournaments[SelectedTournament];
            InitializeComponent();

            int tournamentpt = tournament.armyLimit;

            tournamentName.Text = tournament.name;
            tournamentPoints.Text = tournamentpt.ToString();
            tournamentMap.Text = tournament.map.name;

            List<Mission> missions = tournament.missions;

            foreach (Mission mission in missions)
            {
                if (mission.missionType == 1) 
                { 
                    tournamentPrimary.Text = mission.name;
                } 
                else if (mission.missionType == 2)
                {
                    tournamentSecondary.Text = mission.name;
                }
            }

            armyPicker.ItemsSource = this.Armies;
            collectionViewTournament.ItemsSource = this.tournament.armies;
            collectionViewLogs.ItemsSource = this.tournament.logs;
            tournamentPrimaryEntry.ItemsSource = this.Primary;
            tournamentSecondaryEntry.ItemsSource = this.Secondary;
            tournamentMapEntry.ItemsSource = this.Maps;
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public void addArmyOnClick(object sender, EventArgs e) 
        {
            if (armyPicker.SelectedIndex != -1)
            {
                ArmyList armyList = (ArmyList)armyPicker.ItemsSource[armyPicker.SelectedIndex];
                tournament.addArmy(armyList);
                TournamentsSave();
                refreshTournament();
            }
        }

        public void TournamentsSave()
        {
            List<string> LS = new();
            foreach (Tournament T in Tournaments)
            {
                LS.Add(T.ToJSON());
            }
            JSONObject.WriteJSONToFile(LS, "Tournaments.json");
        }

        public void nameClicked(object sender, EventArgs e) 
        {
            tournament.name = tournamentNameEntry.Text;
            refreshTournament();
        }

        public void pointValueClicked(object sender, EventArgs e)
        {
            if (tournamentPointsEntry.SelectedIndex != -1) 
            {
                String pointValue = tournamentPointsEntry.Items[tournamentPointsEntry.SelectedIndex];
                tournament.armyLimit = Int32.Parse(pointValue);
                refreshTournament();
            }
        }

        public void primaryClicked(object sender, EventArgs e)
        {
            if (tournamentPrimaryEntry.SelectedIndex != -1) 
            {
                int y = -1;
                int i = 0;
                foreach (Mission M in tournament.missions) 
                {
                    if (M.missionType == 1) 
                    {
                        y = i;
                    }
                    i++;
                }

                if (y != -1) 
                {
                    tournament.missions[y] = (Mission)tournamentPrimaryEntry.ItemsSource[tournamentPrimaryEntry.SelectedIndex];
                    refreshTournament();
                }
            }
        }

        public void secondaryClicked(object sender, EventArgs e)
        {
            if (tournamentSecondaryEntry.SelectedIndex != -1)
            {
                int y = -1;
                int i = 0;
                foreach (Mission M in tournament.missions)
                {
                    if (M.missionType == 2)
                    {
                        y = i;
                    }
                    i++;
                }
                if (y != -1)
                {
                    tournament.missions[y] = (Mission)tournamentSecondaryEntry.ItemsSource[tournamentSecondaryEntry.SelectedIndex];
                    refreshTournament();
                }
            }
        }

        public void mapClicked(object sender, EventArgs e)
        {

        }

        public void refreshTournament() 
        {
            Navigation.PushAsync(new TournamentScreen(Tournaments,
                    index, Armies, Maps, Primary, Secondary));
        }
    }
}
