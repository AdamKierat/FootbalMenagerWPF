using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;



namespace FootbalMenager
{
    public partial class MainWindow : Window
    {
        private List<Player> playerList = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 15; i < 45; i++)
            {
                age_cb.Items.Add(i);
            }
        }

        private bool ChceckIfPlayerExist(Player p)
        {
            if (playerList.Contains(p))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PlayersToListBox()
        {
            playersList_lb.Items.Clear();
            foreach (var item in playerList)
            {
                playersList_lb.Items.Add(item);
            }
        }

        private void ClearFirstName()
        {
            firstName_tbx.Text = "";
            firstName_tbx.BorderThickness = default;
            firstName_tbx.BorderThickness = default;
        }
        private Player PlayerFromForsm()
        {
            string firstName = firstName_tbx.Text;
            string lastName = lastName_tbx.Text;
            string tmp = age_cb.SelectedItem.ToString();
            int age = Int32.Parse(tmp);
            tmp = weight_slider.Value.ToString();
            double weight = Double.Parse(tmp);
            Player player = new Player(firstName, lastName, age, weight);
            return player;
        }

        private void ClearLastName()
        {
            lastName_tbx.Text = "";
            lastName_tbx.BorderThickness = default;
            lastName_tbx.BorderThickness = default;
        }

        private void ClearAllFields()
        {
            ClearFirstName();
            ClearLastName();
            weight_slider.Value = 50.0;
            age_cb.SelectedIndex = 0;
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {

            if (ErrorsCheck())
            {
                Player player = PlayerFromForsm();
                if (!ChceckIfPlayerExist(player))
                {
                    playerList.Add(player);
                    PlayersToListBox();
                    ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Record allready exist");
                }

            }
            else
            {
                MessageBox.Show("Incorrect input");
            }
        }

        private void Modify_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are u sure?", "Modification", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (ErrorsCheck() && playersList_lb.SelectedItem != null)
                    {
                        Player player = PlayerFromForsm();
                        if (!ChceckIfPlayerExist(player))
                        {
                            playerList.Remove((Player)playersList_lb.SelectedItem);
                            playerList.Add(player);
                            PlayersToListBox();
                            ClearAllFields();
                        }
                        else
                        {
                            MessageBox.Show("Record allready exist");
                        }
                    }
                    else if (playersList_lb.SelectedItem == null)
                    {
                        MessageBox.Show("Chose record to edit");
                    }

                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (playersList_lb.SelectedItem != null)
            {
                Player player = (Player)playersList_lb.SelectedItem;
                playerList.Remove(player);
                PlayersToListBox();
                ClearAllFields();
            }

        }
        private void SelectionChanged_lb(object sender, RoutedEventArgs e)
        {
            Player player = (Player)playersList_lb.SelectedItem;
            try
            {
                lastName_tbx.Foreground = Brushes.Black;
                firstName_tbx.Foreground = Brushes.Black;
                firstName_tbx.Text = player.firstName;
                lastName_tbx.Text = player.lastName;
                age_cb.SelectedItem = player.age;
                weight_slider.Value = player.weight;
            }
            catch { }
        }

        private void MouseDown_firstName_tbx(object sender, MouseButtonEventArgs e)
        {
            if (firstName_tbx.Text == "Input_Name")
            {
                ClearFirstName();
            }
        }

        private void MouseDown_lastName_tbx(object sender, MouseButtonEventArgs e)
        {
            if (lastName_tbx.Text == "Input surname")
            {
                ClearLastName();
            }
        }

        private void weight_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        private Boolean ErrorsCheck()
        {
            bool firstNameCorrect = firstName_tbx.Text.Length != 0 ? true : false;
            bool lastNameCorrect = lastName_tbx.Text.Length != 0 ? true : false;

            return firstNameCorrect && lastNameCorrect;
        }
    }
}
