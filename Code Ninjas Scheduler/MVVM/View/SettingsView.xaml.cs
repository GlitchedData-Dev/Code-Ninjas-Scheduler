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

namespace Code_Ninjas_Scheduler.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            //Make sure runtime settings are up to date
            userSettings.Default.Upgrade();
            UpdateTextbox();
        }

        //Set text in settings textboxes to stored settings
        public void UpdateTextbox()
        {
            emailField.Text = userSettings.Default.SenderEmail.ToString();
            passwordField.Text = userSettings.Default.SenderPassword.ToString();
            nameField.Text = userSettings.Default.SenderName.ToString();
            recipientEmailField.Text = userSettings.Default.RecipientEmail.ToString();
        }

        //Called when submit button in the settings view is pressed
        //Saves new settings based on text in textboxes
        public void ApplySettings(object sender, RoutedEventArgs e)
        {
            userSettings.Default.SenderEmail = emailField.Text;
            userSettings.Default.SenderName = nameField.Text;
            userSettings.Default.SenderPassword = passwordField.Text;
            userSettings.Default.RecipientEmail = recipientEmailField.Text;
            userSettings.Default.Save();
            userSettings.Default.Reload();
            userSettings.Default.Upgrade();
            UpdateTextbox();
        }

        //Called when cancel button in the settings view is pressed
        //Resets all settings
        public void ClearSettings(object sender, RoutedEventArgs e)
        {
            userSettings.Default.Reset();
            UpdateTextbox();
        }
    }
}
