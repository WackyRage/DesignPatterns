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
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
