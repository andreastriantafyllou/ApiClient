using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApiClient.Modules;
using ApiClient.Interafeces;
using ApiClient.Models;
using Newtonsoft.Json;

namespace WpfTester.pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        ICrud<ActorModel> actorManager;
        ICrud<DirectorModel> directorManager;
        ICrud<MovieModel> movieManager;

        public HomePage()
        {
            InitializeComponent();
            InitializeCrubObjects();
            try
            {
                DisplayItems(actorManager.ReadAll().ToList<object>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DisplayItems(List<object> items)
        {
            ListDataView.Items.Clear();
            foreach (var item in items)
            {
                ListDataView.Items.Add(JsonConvert.SerializeObject(item));
            }
        }

        private void InitializeCrubObjects()
        {
            actorManager = new ActorsController();
            directorManager = new DirectorsController();
            movieManager = new MoviesController();
        }

        private void ButtonGetAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((ComboBoxItem)ComboBoxTables.SelectedValue).Content.ToString())
                {
                    case "Actors":
                        DisplayItems(actorManager.ReadAll().ToList<object>());
                        break;
                    case "Directors":
                        DisplayItems(directorManager.ReadAll().ToList<object>());
                        break;
                    case "Movies":
                        DisplayItems(movieManager.ReadAll().ToList<object>());
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonGetById_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((ComboBoxItem)ComboBoxTables.SelectedValue).Content.ToString())
                {
                    case "Actors":
                        DisplayItems(new List<object>() {actorManager.ReadById(Convert.ToInt32(TextBoxId.Text))});
                        break;
                    case "Directors":
                        DisplayItems(new List<object>() { directorManager.ReadById(Convert.ToInt32(TextBoxId.Text)) });
                        break;
                    case "Movies":
                        DisplayItems(new List<object>() { movieManager.ReadById(Convert.ToInt32(TextBoxId.Text)) });
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((ComboBoxItem)ComboBoxTables.SelectedValue).Content.ToString())
                {
                    case "Actors":
                        MessageBox.Show(actorManager.Create(new ActorModel() { Name = TextBoxNameNewActor.Text, Birthday = TextBoxBirthdayNewActor.Text }));
                        DisplayItems(actorManager.ReadAll().ToList<object>());
                        break;
                    case "Directors":
                        MessageBox.Show(directorManager.Create(new DirectorModel() { Name = TextBoxNameNewDirector.Text, Birthday = TextBoxBirthdayNewDirector.Text }));
                        DisplayItems(directorManager.ReadAll().ToList<object>());
                        break;
                    case "Movies":
                        var actorIds = TextBoxActorsNewMovie.Text.Split(';');
                        List<int> actorsList = new List<int>();
                        foreach (var item in actorIds)
                        {
                            actorsList.Add(Convert.ToInt32(item));
                        }
                        MessageBox.Show(movieManager.Create(new MovieModel() { Name = TextBoxNameNewMovie.Text, ProductionYear = Convert.ToInt32(TextBoxYearNewMovie.Text), ActorIds = actorsList, DirectorIds=Convert.ToInt32(TextBoxDirectorNewMovie.Text) }));
                        DisplayItems(movieManager.ReadAll().ToList<object>());
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((ComboBoxItem)ComboBoxTables.SelectedValue).Content.ToString())
                {
                    case "Actors":
                        MessageBox.Show(actorManager.Update(Convert.ToInt32(TextBoxId.Text), new ActorModel() { Name = TextBoxNameNewActor.Text, Birthday = TextBoxBirthdayNewActor.Text }));
                        DisplayItems(actorManager.ReadAll().ToList<object>());
                        break;
                    case "Directors":
                        MessageBox.Show(directorManager.Update(Convert.ToInt32(TextBoxId.Text), new DirectorModel() { Name = TextBoxNameNewDirector.Text, Birthday = TextBoxBirthdayNewDirector.Text }));
                        DisplayItems(directorManager.ReadAll().ToList<object>());
                        break;
                    case "Movies":
                        var actorIds = TextBoxActorsNewMovie.Text.Split(';');
                        List<int> actorsList = new List<int>();
                        foreach (var item in actorIds)
                        {
                            actorsList.Add(Convert.ToInt32(item));
                        }
                        MessageBox.Show(movieManager.Update(Convert.ToInt32(TextBoxId.Text), new MovieModel() { Name = TextBoxNameNewMovie.Text, ProductionYear = Convert.ToInt32(TextBoxYearNewMovie.Text), ActorIds = actorsList, DirectorIds = Convert.ToInt32(TextBoxDirectorNewMovie.Text) }));
                        DisplayItems(movieManager.ReadAll().ToList<object>());
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((ComboBoxItem)ComboBoxTables.SelectedValue).Content.ToString())
                {
                    case "Actors":
                        MessageBox.Show(actorManager.Delete(Convert.ToInt32(TextBoxId.Text)));
                        DisplayItems(actorManager.ReadAll().ToList<object>());
                        break;
                    case "Directors":
                        MessageBox.Show(directorManager.Delete(Convert.ToInt32(TextBoxId.Text)));
                        DisplayItems(directorManager.ReadAll().ToList<object>());
                        break;
                    case "Movies":
                        MessageBox.Show(movieManager.Delete(Convert.ToInt32(TextBoxId.Text)));
                        DisplayItems(movieManager.ReadAll().ToList<object>());
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
