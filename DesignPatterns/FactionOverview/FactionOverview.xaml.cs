using System.Collections;
using static Microsoft.Maui.ApplicationModel.Permissions;

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

        public void Button_Clicked_Create_Faction(object sender, EventArgs e)
        {
            if (factionNameEntry.Text != null)
            {
                Faction faction = new Faction(factionNameEntry.Text);
                Factions.Add(faction);
            }
            FactionSave();
            Navigation.PushAsync(new FactionOverview(Factions));
        }

        public void FactionSave()
        {
            List<string> LS = new();
            foreach (Faction T in Factions)
            {
                LS.Add(T.ToJSON());
            }
            JSONObject.WriteJSONToFile(LS, "Factions.json");
        }
    }
}
