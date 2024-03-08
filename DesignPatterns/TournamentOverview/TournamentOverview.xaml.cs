namespace DesignPatterns.TournamentOverview
{
    public partial class TournamentOverview : ContentPage
    {

        public TournamentOverview()
        {
            InitializeComponent();
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
