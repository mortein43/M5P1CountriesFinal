using System.Windows.Forms;

namespace M5P1CountriesFinal
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
            this.dataBase.ConnectionToString();
            this.AllInfo.Checked = true;
        }

        private void AllInfo_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllDataBase(this.dataGridView1);
        }

        private void AllNames_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllNamesDataBase(this.dataGridView1);
        }

        private void CapitalNames_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllCapitalNamesDataBase(this.dataGridView1);
        }

        private void EuropeanCountries_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllEuropeanDataBase(this.dataGridView1);
        }

        private void CoutriesAndArea_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllCountriesAreaMoreThan(this.dataGridView1, (int)this.numericUpDown1.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
        {
            if (this.CoutriesAndArea.Checked) this.dataBase.PrintAllCountriesAreaMoreThan(this.dataGridView1, (int)this.numericUpDown1.Value);
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllHaveUAndA(this.dataGridView1);
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllHaveA(this.dataGridView1);
        }

        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllCountriesAreaMoreThanAndLessThan(this.dataGridView1, (int)this.numericUpDown2.Value, (int)this.numericUpDown3.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, System.EventArgs e)
        {
            if (this.radioButton3.Checked) this.dataBase.PrintAllCountriesAreaMoreThanAndLessThan(this.dataGridView1, (int)this.numericUpDown2.Value, (int)this.numericUpDown3.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, System.EventArgs e)
        {
            if (this.radioButton3.Checked) this.dataBase.PrintAllCountriesAreaMoreThanAndLessThan(this.dataGridView1, (int)this.numericUpDown2.Value, (int)this.numericUpDown3.Value);
        }

        private void radioButton4_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAllCountriesNumberOfInhabitantsMoreThan(this.dataGridView1, (int)this.numericUpDown4.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, System.EventArgs e)
        {
            if (this.radioButton4.Checked) this.dataBase.PrintAllCountriesNumberOfInhabitantsMoreThan(this.dataGridView1, (int)this.numericUpDown4.Value);
        }

        private void radioButton5_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintTop5CountriesByArea(this.dataGridView1);
        }

        private void radioButton6_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintTop5CountriesByNumberOfInhabitants(this.dataGridView1);
        }

        private void radioButton7_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintCountryAreaMax(this.dataGridView1);
        }

        private void radioButton8_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintCountryNumberOfInhabitantsMax(this.dataGridView1);
        }

        private void radioButton9_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintCountryAreaMinAfrica(this.dataGridView1);
        }

        private void radioButton10_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dataBase.PrintAverageAreaInAsia(this.dataGridView1);
        }
    }
}
