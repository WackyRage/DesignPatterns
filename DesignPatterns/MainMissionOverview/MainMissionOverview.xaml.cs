using System.Collections;

namespace DesignPatterns.MainMissionOverview
{

    public partial class MainMissionOverview : ContentPage
    {
        ArrayList PrimaryMissions = new ArrayList();
        public MainMissionOverview(ArrayList PrimaryMissions) 
        {
            this.PrimaryMissions = PrimaryMissions;
            InitializeComponent();

            collectionViewPrimaryMissions.ItemsSource = PrimaryMissions;
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
