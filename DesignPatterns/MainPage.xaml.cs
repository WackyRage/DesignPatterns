using Microsoft.Maui.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DesignPatterns
{
    public partial class MainPage : ContentPage
    {
        ArrayList Factions = new ArrayList();
        ArrayList Tournaments = new ArrayList();
        ArrayList Maps = new ArrayList();
        ArrayList PrimaryMissions = new ArrayList();
        ArrayList SecondaryMissions = new ArrayList();

        public MainPage()
        {
            refreshJsons();
            InitializeComponent();
        }

        public void Button_Clicked_Faction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FactionOverview.FactionOverview(Factions));
        }

        public void Button_Clicked_Tournament(object sender, EventArgs e) 
        {
            Navigation.PushAsync(new TournamentOverview.TournamentOverview(Tournaments, Maps, PrimaryMissions, SecondaryMissions));
        }
        public void Button_Clicked_Map(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapOverview.MapOverview(Maps));
        }

        public void Button_Clicked_Main(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMissionOverview.MainMissionOverview(PrimaryMissions));
        }

        public void Button_Clicked_Secundary(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecundaryMissionOverview.SecundaryMissionOverview(SecondaryMissions));
        }

        public void refreshJsons() 
        {
            FromJSON("Tournaments.json", "Tournament");
            FromJSON("Factions.json", "Faction");
            FromJSON("Maps.json", "Map");
            FromJSON("Missions.json", "Mission");
        }

        public void FromJSON(String jsonString, String fileType)
        {
            List<string> jsonList = JSONObject.ReadJSONFile(jsonString);
            if (fileType == "Tournament")
            {
                Tournaments.Clear();
                foreach (String item in jsonList)
                {
                    Tournament temp = Tournament.FromJSON(item);
                    Tournaments.Add(temp);
                }
            }
            else if (fileType == "Faction")
            {
                Factions.Clear();
                foreach (String item in jsonList)
                {
                    Faction temp = Faction.FromJSON(item);
                    Factions.Add(temp);
                }
            }
            else if (fileType == "Map")
            {
                Maps.Clear();
                foreach (String item in jsonList)
                {
                    Map temp = Map.FromJSON(item);
                    Maps.Add(temp);
                }
            }
            else if (fileType == "Mission")
            {
                PrimaryMissions.Clear();
                SecondaryMissions.Clear();
                foreach (String item in jsonList)
                {
                    Mission temp = Mission.FromJSON(item);
                    if (temp.missionType == 1) 
                    {
                        PrimaryMissions.Add(temp);
                    }
                    else if (temp.missionType == 2)
                    {
                        SecondaryMissions.Add(temp);
                    }
                }
            }
        }

        public void ExampleSave()
        {
            List<string> LS = new();
            foreach (Tournament T in Tournaments) 
            {
                LS.Add(T.ToJSON());
            }
            JSONObject.WriteJSONToFile(LS, "Tournament.json");
        }
    }
}
