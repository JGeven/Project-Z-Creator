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
using Project_Z_Creator.LogicLayer;

namespace Project_Z_Creator
{
    public partial class Form1 : Form
    {
        List<Character> Characters = new List<Character>();

        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Character character = new Character();
            tbCost.Text = character.Cost.ToString();

            TraitsContainer posContainer = new TraitsContainer();
            TraitsContainer negContainer = new TraitsContainer();

            OccupationContainer occupationContainer = new OccupationContainer();

            foreach (Traits traits in posContainer.GetAllPosTraits())
            {
                cbPosTraits.Items.Add(traits.Name);
            }

            foreach (Traits traits in negContainer.GetAllNegTraits())
            {
                cbNegTraits.Items.Add(traits.Name);
            }

            foreach (Occupations occupations in occupationContainer.GetOccupations())
            {
                cbOccupations.Items.Add(occupations.Name);
            }
        }
        
        private void cbPosTraits_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbChosenTraits.Items.Add(cbPosTraits.SelectedItem);

            if (cbPosTraits.SelectedIndex == 0)
            {
                lbChosenTraits.Items.Remove(cbPosTraits.SelectedItem);
            }
        }

        private void cbNegTraits_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbChosenTraits.Items.Add(cbNegTraits.SelectedItem);
            
            if (cbNegTraits.SelectedIndex == 0)
            {
                lbChosenTraits.Items.Remove(cbNegTraits.SelectedItem);
            }
        }

        private void cbOccupations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOccupation.Text = Convert.ToString(cbOccupations.SelectedItem);
        }

        private void lbChosenTraits_DoubleClick(object sender, EventArgs e)
        {
            lbChosenTraits.Items.Remove(lbChosenTraits.SelectedItem);
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }
    }   
}
  