using System;
using System.Windows;
using System.Windows.Controls;
using EventosVista.Source.Core;
using EventosVista.Source.ViewModel;

namespace EventosVista.Source.View
{
    /// <summary>
    /// Interaction logic for PostEventView.xaml
    /// </summary>
    public partial class PostEventView : UserControl
    {
        string imageName = "";

        public PostEventView()
        {
            InitializeComponent();
        }

        private void PostEventButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (Utilities.AnyFieldEmpty(PostEventFormGrid) || String.IsNullOrEmpty(imageName))
            {
                MessageBox.Show("Hay campos que deben ser llenados");
                return;
            }

            ((PostEventViewModel)this.DataContext).PostEvent(titleField.Text, DateTime.Parse(initDateField.Text),
                DateTime.Parse(endDateField.Text), placeField.Text, descriptField.Text, imageName);

            titleField.Text = "";
            initDateField.Text = "";
            endDateField.Text = "";
            placeField.Text = "";
            descriptField.Text = "";
        }

        private void SearchImageButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            imageName = Utilities.getImageName();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
