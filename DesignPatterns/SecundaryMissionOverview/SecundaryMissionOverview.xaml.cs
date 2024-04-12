using System.Collections;

namespace DesignPatterns.SecundaryMissionOverview
{

    public partial class SecundaryMissionOverview : ContentPage
    {
        ArrayList Missions = new ArrayList();
        ArrayList SecondaryMissions = new ArrayList();
        public SecundaryMissionOverview(ArrayList SecondaryMissions, ArrayList Missions) 
        { 
            this.Missions = Missions;
            this.SecondaryMissions = SecondaryMissions;
            InitializeComponent();

            collectionViewSecondaryMissions.ItemsSource = SecondaryMissions;
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public void Button_Clicked_New_Secondary(object sender, EventArgs e)
        {
            if (secondaryMissionNameEntry.Text != null &&
                secondaryMissionDescriptionEntry.Text != null &&
                secondaryMissionPointsEntry.Text != null)
            {
                int value = 0;
                try
                {
                    value = Int32.Parse(secondaryMissionPointsEntry.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Mission mission = new Mission(secondaryMissionNameEntry.Text, secondaryMissionDescriptionEntry.Text, value, 2);
                Missions.Add(mission);
                SecondaryMissions.Add(mission);
                MissionSave();
            }
            Navigation.PushAsync(new SecundaryMissionOverview(SecondaryMissions, Missions));
        }

        public void MissionSave()
        {
            List<string> LS = new();
            foreach (Mission T in Missions)
            {
                LS.Add(T.ToJSON());
            }
            JSONObject.WriteJSONToFile(LS, "Missions.json");
        }
    }
}
