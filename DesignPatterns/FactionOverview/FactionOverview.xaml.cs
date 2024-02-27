namespace DesignPatterns.FactionOverview
{

    public partial class FactionOverview : ContentPage
    {
        public FactionOverview() 
        { 
            InitializeComponent();
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
