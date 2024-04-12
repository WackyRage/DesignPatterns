using System.Collections;

namespace DesignPatterns.MapOverview
{
    public partial class MapOverview : ContentPage
    {
        ArrayList Maps = new ArrayList();
        public MapOverview(ArrayList Maps)    
        {
            this.Maps = Maps;
            InitializeComponent();

            collectionViewMap.ItemsSource = this.Maps;
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public void Button_Clicked_New_Map(object sender, EventArgs e) 
        {
            if (mapNameEntry.Text != null)
            {
                Map map = new Map(mapNameEntry.Text);
                Maps.Add(map);
            }
            MapSave();
            Navigation.PushAsync(new MapOverview(Maps));
        }

        public void MapSave()
        {
            List<string> LS = new();
            foreach (Map T in Maps)
            {
                LS.Add(T.ToJSON());
            }
            JSONObject.WriteJSONToFile(LS, "Maps.json");
        }
    }
}
