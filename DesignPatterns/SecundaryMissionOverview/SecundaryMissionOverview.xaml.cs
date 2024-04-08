using System.Collections;

namespace DesignPatterns.SecundaryMissionOverview
{

    public partial class SecundaryMissionOverview : ContentPage
    {
        ArrayList SecondaryMissions = new ArrayList();

        public SecundaryMissionOverview(ArrayList SecondaryMissions) 
        {
            this.SecondaryMissions = SecondaryMissions;
            InitializeComponent();

            collectionViewSecondaryMissions.ItemsSource = this.SecondaryMissions;
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
