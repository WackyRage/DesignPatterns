namespace DesignPatterns.MapOverview
{
    public partial class MapOverview : ContentPage
    {
        public MapOverview()    
        {
            InitializeComponent();
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
