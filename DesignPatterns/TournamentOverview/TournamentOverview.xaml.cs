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
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public void Button_Clicked_NewTournament(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TournamentScreen.TournamentScreen());
        }
    }
}
