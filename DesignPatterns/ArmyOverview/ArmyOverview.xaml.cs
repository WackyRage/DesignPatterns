using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ArmyOverview
{
    public partial class ArmyOverview : ContentPage
    {
        ArrayList Armies = new ArrayList();
        ArrayList Units = new ArrayList();
        public ArmyOverview(ArrayList Armies, ArrayList Units) 
        {
            this.Units = Units;
            this.Armies = Armies;
            InitializeComponent();

            collectionViewArmies.ItemsSource = this.Armies;
            armyPicker.ItemsSource = this.Armies;
        }

        public void Button_Clicked_EditArmy(object sender, EventArgs e) 
        {
            if (armyPicker.SelectedIndex != -1) 
            {
                Navigation.PushAsync(new ArmyScreen(Armies, armyPicker.SelectedIndex, Units));
            }
        }

        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public void Button_Clicked_New_Army(object sender, EventArgs e) 
        {
            if (ownerNameEntry.Text != null && armyNameEntry.Text != null) 
            {
                ArmyList army = new ArmyList(ownerNameEntry.Text, armyNameEntry.Text);
                Armies.Add(army);
                ArmiesSave();
                Navigation.PushAsync(new ArmyOverview(Armies, Units));
            }
        }

        public void ArmiesSave()
        {
            List<string> LS = new();
            foreach (ArmyList T in Armies)
            {
                LS.Add(T.ToJSON());
            }
            JSONObject.WriteJSONToFile(LS, "Armies.json");
        }
    }
}
