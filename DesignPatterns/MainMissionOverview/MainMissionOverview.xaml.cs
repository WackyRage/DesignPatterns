namespace DesignPatterns.MainMissionOverview
{

    public partial class MainMissionOverview : ContentPage
    {
        public MainMissionOverview() 
        {
            InitializeComponent();
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
