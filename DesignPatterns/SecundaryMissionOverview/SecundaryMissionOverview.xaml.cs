namespace DesignPatterns.SecundaryMissionOverview
{

    public partial class SecundaryMissionOverview : ContentPage
    {
        public SecundaryMissionOverview() 
        { 
            InitializeComponent();
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
