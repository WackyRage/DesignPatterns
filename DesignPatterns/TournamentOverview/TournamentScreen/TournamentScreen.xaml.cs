namespace DesignPatterns.TournamentOverview.TournamentScreen
{

    public partial class TournamentScreen : ContentPage
    {
        public TournamentScreen()
        {
            InitializeComponent();
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
