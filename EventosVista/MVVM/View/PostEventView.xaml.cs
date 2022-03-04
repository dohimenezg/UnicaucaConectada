using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using EventosVista.MVVM.Model;
using System.IO;

namespace EventosVista.MVVM.View
{
    /// <summary>
    /// Interaction logic for PostEventView.xaml
    /// </summary>
    public partial class PostEventView : UserControl
    {
        string titulo = "";
        DateTime fechaInicio = new DateTime();
        DateTime fechaFin = new DateTime();
        string lugar = "";
        string descrip = "";
        string imageName = "";

        private EventRepository EventRepository;
        public PostEventView()
        {
            InitializeComponent();
            EventRepository = new EventRepository();

        }

        private void PostEventButton_Click(object sender, RoutedEventArgs e)
        {
            if (titleField.Text == null)
            {
                MessageBox.Show("El evento debe tener un título");
                return;
            }
            if (initDateField.Text == null)
            {
                MessageBox.Show("El evento debe tener una fecha de inicio");
                return;
            }
            if (endDateField.Text == null)
            {
                MessageBox.Show("El evento debe tener una fecha de finalización");
                return;
            }
            if (endDateField.Text == null)
            {
                MessageBox.Show("El evento debe tener un lugar");
                return;
            }
            if (descriptField.Text == null)
            {
                MessageBox.Show("El evento debe tener una descripción");
                return;
            }
            titulo = titleField.Text;
            fechaInicio = initDateField.DisplayDate.Date;
            fechaFin = DateTime.Parse(endDateField.Text);
            lugar = placeField.Text;
            descrip = descriptField.Text;
            Event evento = new Event(titulo, descrip, fechaInicio, fechaFin)
            {
                lugar = lugar,
                banner = getImageData()
            };
            titulo = "";
            lugar = "";
            descrip = "";

            titleField.Text = "";
            initDateField.Text = "";
            endDateField.Text = "";
            placeField.Text = "";
            descriptField.Text = "";
            if (EventRepository.saveEvent(evento))
            {
                MessageBox.Show("Evento agregado!");
            }
        }

        private void SearchImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private byte[] getImageData()
        {
            byte[] imgByteArr = {0};
            try
            {
                if (imageName != "")
                {
                    //Initialize a file stream to read the image file
                    FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                    //Initialize a byte array with size of stream
                    imgByteArr = new byte[fs.Length];

                    //Read data from the file stream and put into the byte array
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

                    //Close a file stream
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return imgByteArr;
        }
    }
}
