using System.Collections;

namespace DesignPatterns.TournamentOverview
{
    public partial class TournamentOverview : ContentPage
    {
        ArrayList Tournaments = new ArrayList();
        ArrayList Maps = new ArrayList();
        ArrayList PrimaryMissions = new ArrayList();
        ArrayList SecondaryMissions = new ArrayList();

        public TournamentOverview(ArrayList Tournaments, ArrayList Maps, ArrayList PrimaryMissions, ArrayList SecondaryMissions)
        {
            this.Tournaments = Tournaments;
            this.Maps = Maps;   
            this.PrimaryMissions = PrimaryMissions;
            this.SecondaryMissions = SecondaryMissions;
            InitializeComponent();

            primaryMissionPicker.ItemsSource = this.PrimaryMissions;
            secondaryMissionPicker.ItemsSource = this.SecondaryMissions; 
            mapPicker.ItemsSource = this.Maps;
            collectionViewTournaments.ItemsSource = this.Tournaments;
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public void Button_Clicked_NewTournament(object sender, EventArgs e)
        {
            Map map;
            Mission primary;
            Mission secondary;
            String pointValue;
            String name;
            if (mapPicker.SelectedIndex != -1 &&
                primaryMissionPicker.SelectedIndex != -1 &&
                secondaryMissionPicker.SelectedIndex != -1 &&
                pointPicker.SelectedIndex != -1 &&
                namePicker.GetValue != null)
            {
                map = (Map)mapPicker.ItemsSource[mapPicker.SelectedIndex];
                primary = (Mission)primaryMissionPicker.ItemsSource[primaryMissionPicker.SelectedIndex];
                secondary = (Mission)secondaryMissionPicker.ItemsSource[secondaryMissionPicker.SelectedIndex];
                pointValue = pointPicker.Items[pointPicker.SelectedIndex];
                name = namePicker.Text;
                Console.WriteLine(map);
                Console.WriteLine(primary);
                Console.WriteLine(secondary);
                Console.WriteLine(pointValue);
                Console.WriteLine(name);

                GameType game = new GameType("Warhammer");
                List<Mission> Missions = new List<Mission>();
                Missions.Add(primary);
                Missions.Add(secondary);
                List<Log> Logs = new List<Log>();
                List<ArmyList> Armylists = new List<ArmyList>();

                Tournament tournament = new Tournament(name, map, game, Int32.Parse(pointValue), Missions, Logs, Armylists);
                Tournaments.Add(tournament);

                TournamentsSave();
            }
            //Navigation.PushAsync(new TournamentScreen.TournamentScreen());
            Navigation.PushAsync(new TournamentOverview(Tournaments, Maps, PrimaryMissions, SecondaryMissions));
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
    }
}
