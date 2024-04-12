using DesignPatterns.Classes.Faction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ArmyOverview
{
    public partial class ArmyScreen : ContentPage
    {
        private ArmyList army;
        private ArrayList Armies = new ArrayList();
        private ArrayList Units = new ArrayList();
        private ArrayList unitsInArmy = new ArrayList();
        int index;
        public ArmyScreen(ArrayList Armies, int selectedArmy, ArrayList Units)
        {
            this.index = selectedArmy;
            this.Armies = Armies;
            this.army = (ArmyList?)this.Armies[selectedArmy];
            this.Units = Units;
            InitializeComponent();

            /*List<AbstractUnit> units = army.units;
            foreach (AbstractUnit unit in units) 
            { 
                unitsInArmy.Add(unit);
            }*/

            armyNameLabel.Text = "Army name: " + army.armyName;
            armyOwnerLabel.Text = "Player name: " + army.playerName;

            unitPicker.ItemsSource = Units;
            collectionViewLogs.ItemsSource = unitsInArmy;
        }
        
        public void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public void EditArmyNameOnClick(object sender, EventArgs e) 
        {
            if (armyNameEdit.Text != null) 
            { 
                army.armyName = armyNameEdit.Text;
                Navigation.PushAsync(new ArmyScreen(Armies, index, Units));
            }
        } 

        public void editArmyOwnerOnClick(object sender, EventArgs e)
        {
            if (armyOwnerEdit.Text != null)
            {
                army.playerName = armyOwnerEdit.Text;
                Navigation.PushAsync(new ArmyScreen(Armies, index, Units));
            }
        }

        public void addUnitOnClick(object sender, EventArgs e)
        {
            if (unitPicker.SelectedIndex != -1) 
            {
                AbstractUnit unit = (AbstractUnit)Units[unitPicker.SelectedIndex];
                if (unit != null) 
                { 
                    army.addUnit(unit);
                    Navigation.PushAsync(new ArmyScreen(Armies, index, Units));
                }
            }
        }
    }
}
