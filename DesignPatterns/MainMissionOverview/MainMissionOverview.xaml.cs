using System.Collections;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace DesignPatterns.MainMissionOverview
{

    public partial class MainMissionOverview : ContentPage
    {
        ArrayList PrimaryMissions = new ArrayList();
        ArrayList Missions = new ArrayList();
        public MainMissionOverview(ArrayList PrimaryMissions, ArrayList Missions) 
        {
            this.Missions = Missions;
            this.PrimaryMissions = PrimaryMissions;
            InitializeComponent();

            collectionViewPrimaryMissions.ItemsSource = PrimaryMissions;
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public void Button_Clicked_New_Primary(object sender, EventArgs e)
        {
            
            if (primaryMissionNameEntry.Text != null && 
                primaryMissionDescriptionEntry.Text != null && 
                primaryMissionPointsEntry.Text != null) 
            {
                int value = 0;
                try { 
                    value = Int32.Parse(primaryMissionPointsEntry.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Mission mission = new Mission(primaryMissionNameEntry.Text, primaryMissionDescriptionEntry.Text, value, 1);
                Missions.Add(mission);
                PrimaryMissions.Add(mission);
                MissionSave();  
            }
            Navigation.PushAsync(new MainMissionOverview(PrimaryMissions, Missions));
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
