using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace M5P1CountriesFinal
{
    internal class DataBase
    {
        public string baseName = "countries.sqlite";
        SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");

        public DataBase()
        {
            SQLiteConnection.CreateFile(baseName);

            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"create table Countries
                    (Id integer not null constraint Coutries_pk primary key constraint Coutries_pk2 unique,
                    Name                TEXT    not null,
                    Capital             TEXT    not null,
                    NumberOfInhabitants integer not null,
                    Area                decimal not null,
                    PartOfTheWorld      TEXT    not null
                    );";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ConnectionToString()
        {


            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {
                    List<Country> countries = new List<Country>();
                    var country1 = new Country { Id = 1, Name = "Ukraine", Capital = "Kyiv", NumberOfInhabitants = 42300000, Area = 603628, PartOfTheWorld = "Europe" };
                    countries.Add(country1);
                    var country2 = new Country { Id = 2, Name = "Australia", Capital = "Canberra", NumberOfInhabitants = 24500000, Area = 7741220, PartOfTheWorld = "Australia and Oceania" };
                    countries.Add(country2);
                    var country3 = new Country { Id = 3, Name = "Argentina", Capital = "Buenos Aires", NumberOfInhabitants = 44300000, Area = 2780400, PartOfTheWorld = "America" };
                    countries.Add(country3);
                    var country4 = new Country { Id = 4, Name = "South Korea", Capital = "Seoul", NumberOfInhabitants = 51400000, Area = 99720, PartOfTheWorld = "Asia" };
                    countries.Add(country4);
                    var country5 = new Country { Id = 5, Name = "Nigeria", Capital = "Abuja", NumberOfInhabitants = 190900000, Area = 923768, PartOfTheWorld = "Africa" };
                    countries.Add(country5);
                    var country6 = new Country { Id = 6, Name = "Germany", Capital = "Berlin", NumberOfInhabitants = 83100000, Area = 357121, PartOfTheWorld = "Europe" };
                    countries.Add(country6);
                    var country7 = new Country { Id = 7, Name = "Japan", Capital = "Tokio", NumberOfInhabitants = 126700000, Area = 377915, PartOfTheWorld = "Asia" };
                    countries.Add(country7);
                    var country8 = new Country { Id = 8, Name = "South Africa", Capital = "Pretoria", NumberOfInhabitants = 56500000, Area = 1219090, PartOfTheWorld = "Africa" };
                    countries.Add(country8);
                    var country9 = new Country { Id = 9, Name = "Canada", Capital = "Ottawa", NumberOfInhabitants = 36700000, Area = 9984670, PartOfTheWorld = "America" };
                    countries.Add(country9);


                    db.GetTable<Country>().InsertAllOnSubmit(countries);
                    db.SubmitChanges();




                }
            }

        }

        public void PrintAllDataBase(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {
                    var table = db.GetTable<Country>();

                    dataGridView1.DataSource = table;
                }
            }
        }

        public void PrintAllNamesDataBase(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {
                    var table = db.GetTable<Country>().Select(c => new { c.Id, c.Name });


                    dataGridView1.DataSource = table;
                }
            }
        }

        public void PrintAllCapitalNamesDataBase(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {
                    var table = db.GetTable<Country>().Select(c => new { c.Id, c.Capital });


                    dataGridView1.DataSource = table;
                }
            }
        }

        public void PrintAllEuropeanDataBase(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {
                    var table = db.GetTable<Country>().Where(c => c.PartOfTheWorld == "Europe");

                    dataGridView1.DataSource = table;
                }
            }
        }

        public void PrintAllCountriesAreaMoreThan(DataGridView dataGridView1, int area)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {

                    var table = db.GetTable<Country>().Where(c => c.Area > area);



                    dataGridView1.DataSource = table;
                }
            }
        }

        public void PrintAllHaveUAndA(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {

                    var table = db.GetTable<Country>().Where(c => c.Name.Contains("a") && c.Name.Contains("u"));

                    dataGridView1.DataSource = table.ToList();
                }
            }
        }

        public void PrintAllHaveA(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {

                    var table = db.GetTable<Country>().Where(c => c.Name.Contains("a"));

                    dataGridView1.DataSource = table.ToList();
                }
            }
        }

        public void PrintAllCountriesAreaMoreThanAndLessThan(DataGridView dataGridView1, int areaMin, int areaMax)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {

                    var table = db.GetTable<Country>().Where(c => c.Area > areaMin && c.Area < areaMax);



                    dataGridView1.DataSource = table;
                }
            }
        }

        public void PrintAllCountriesNumberOfInhabitantsMoreThan(DataGridView dataGridView1, int NumberOfInhabitants)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {

                    var table = db.GetTable<Country>().Where(c => c.Area > NumberOfInhabitants);



                    dataGridView1.DataSource = table;
                }
            }
        }

        public void PrintTop5CountriesByArea(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {
                    var table = db.GetTable<Country>().OrderByDescending(c => c.Area).ToList().Take(5);

                    dataGridView1.DataSource = table.ToList();
                }
            }
        }

        public void PrintTop5CountriesByNumberOfInhabitants(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {
                    var table = db.GetTable<Country>().OrderByDescending(c => c.NumberOfInhabitants).ToList().Take(5);

                    dataGridView1.DataSource = table.ToList();
                }
            }
        }

        public void PrintCountryAreaMax(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {

                    var table = db.GetTable<Country>().OrderByDescending(c => c.Area).ToList().Take(1);


                    dataGridView1.DataSource = table.ToList();
                }
            }
        }

        public void PrintCountryNumberOfInhabitantsMax(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {

                    var table = db.GetTable<Country>().OrderByDescending(c => c.NumberOfInhabitants).ToList().Take(1);


                    dataGridView1.DataSource = table.ToList();
                }
            }
        }

        public void PrintCountryAreaMinAfrica(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var db = new DataContext(connection))
                {

                    var table = db.GetTable<Country>().Where(c => c.PartOfTheWorld == "Africa").OrderBy(c => c.Area).ToList().Take(1);


                    dataGridView1.DataSource = table.ToList();
                }
            }
        }

        public void PrintAverageAreaInAsia(DataGridView dataGridView1)
        {
            dataGridView1.Columns.Clear();

            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (DataContext db = new DataContext(connection))
                {
                    var averageArea = db.GetTable<Country>().Where(c => c.PartOfTheWorld == "Asia").Average(c => c.Area);

                    var result = new List<object> { new { AverageArea = averageArea } };
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = result;
                }
            }
        }



    }
}
