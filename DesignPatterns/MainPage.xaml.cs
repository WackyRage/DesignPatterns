namespace DesignPatterns
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public void Button_Clicked_Tournament(object sender, EventArgs e) 
        {
            Navigation.PushAsync(new TournamentOverview.TournamentOverview());
        }

        public void Button_Clicked_Main(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMissionOverview.MainMissionOverview());
        }

        public void Button_Clicked_Secundary(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecundaryMissionOverview.SecundaryMissionOverview());
        }

        public void Button_Clicked_Faction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FactionOverview.FactionOverview());
        }

        public void Button_Clicked_Map(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapOverview.MapOverview());
        }
    }

}
