using System.Collections;

namespace DesignPatterns.TournamentOverview
{
    public partial class TournamentOverview : ContentPage
    {
        ArrayList Tournaments = new ArrayList();

        public TournamentOverview(ArrayList Tournaments)
        {
            this.Tournaments = Tournaments;
            InitializeComponent();

            collectionViewTournaments.ItemsSource = this.Tournaments;
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
