using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Project_Z_Creator
{
    public partial class Mainscreen : Form
    {
        public Mainscreen()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Character character = new Character();
            tbCost.Text = character.Cost.ToString();

            CharacterContainer CharContainer = new CharacterContainer(new CharacterDAL());

            TraitsContainer posContainer = new TraitsContainer(new TraitsDAL());
            TraitsContainer negContainer = new TraitsContainer(new TraitsDAL());

            OccupationContainer occupationContainer = new OccupationContainer(new OccupationDAL());

            foreach (Trait traits in posContainer.GetTraits())
            {
                if (traits.PosNeg == true)
                {
                    cbPosTraits.Items.Add(traits);
                }
            }

            foreach (Trait traits in negContainer.GetTraits())
            {
                if (traits.PosNeg == false)
                {
                    cbNegTraits.Items.Add(traits);
                }
            }

            foreach (Occupations occupations in occupationContainer.GetOccupations())
            {
                cbOccupations.Items.Add(occupations);
            }

            foreach (Character characters in CharContainer.GetCharacters())
            {

                cbCharacters.Items.Add(characters);
            }
        }

        private void cbPosTraits_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbPosTraits.Items.Add(cbPosTraits.SelectedItem);
            Trait character = (Trait)cbPosTraits.SelectedItem;
            tbCost.Text = (Convert.ToInt32(tbCost.Text) - character.Cost).ToString();
            cbPosTraits.Items.Remove(cbPosTraits.SelectedItem);

            if (cbPosTraits.SelectedIndex == -1)
            {
                lbPosTraits.Items.Remove(cbPosTraits.SelectedItem);
            }
        }

        private void cbNegTraits_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNegTraits.Items.Add(cbNegTraits.SelectedItem);
            Trait character = (Trait)cbNegTraits.SelectedItem;
            tbCost.Text = (Convert.ToInt32(tbCost.Text) + character.Cost).ToString();
            cbNegTraits.Items.Remove(cbNegTraits.SelectedItem);

            if (cbNegTraits.SelectedIndex == -1)
            {
                lbNegTraits.Items.Remove(cbNegTraits.SelectedItem);
            }
        }

        private void cbOccupations_SelectedIndexChanged(object sender, EventArgs e)
        {
            Occupations occupations = (Occupations)cbOccupations.SelectedItem;
            lblOccupation.Text = Convert.ToString(occupations);
        }

        private void lbChosenTraits_DoubleClick(object sender, EventArgs e)
        {
            cbPosTraits.Items.Add(lbPosTraits.SelectedItem);
            lbPosTraits.Items.Remove(lbPosTraits.SelectedItem);
        }

        private void lbNegTraits_DoubleClick(object sender, EventArgs e)
        {
            cbNegTraits.Items.Add(lbNegTraits.SelectedItem);
            lbNegTraits.Items.Remove(lbNegTraits.SelectedItem);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Occupations occupations = (Occupations)cbOccupations.SelectedItem;

            var list = new List<Trait>();
            foreach (Trait trait in lbNegTraits.Items)
            {
                list.Add(trait);
            }
            foreach (Trait trait in lbPosTraits.Items)
            {
                list.Add(trait);
            }

            Character character = new Character(tbCharacterName.Text, Convert.ToInt32(tbCost.Text), occupations.ID, list, new CharacterDAL());
            character.SaveChar();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            Character character1 = (Character)cbCharacters.SelectedItem;

            Character character = new Character(character1.CharacterID, new CharacterDAL());
            character.DeleteChar();
        }

        private void cbCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCharacterName.Text = Convert.ToString(cbCharacters.SelectedItem);
            Character character = (Character)cbCharacters.SelectedItem;
            tbCost.Text = character.Cost.ToString();
            lblOccupation.Text = character.OccupationName.ToString();
        }

        private void cbCharacter_DropDown(object sender, EventArgs e)
        {
            CharacterContainer characterContainer = new CharacterContainer(new CharacterDAL());
            cbCharacters.Items.Clear();
            foreach (Character characters in characterContainer.GetCharacters())
            {
                cbCharacters.Items.Add(characters);
            }
        }
    }
}
