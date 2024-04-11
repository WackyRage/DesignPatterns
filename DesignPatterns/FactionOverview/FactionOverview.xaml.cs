using System.Collections;

namespace DesignPatterns.FactionOverview
{
    public partial class FactionOverview : ContentPage
    {
        ArrayList Factions = new ArrayList();
        public FactionOverview(ArrayList Factions) 
        { 
            this.Factions = Factions;
            InitializeComponent();

            collectionViewFactions.ItemsSource = this.Factions;
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
