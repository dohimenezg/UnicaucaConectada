using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using EventosVista.MVVM.Model;
using System.IO;
using EventosVista.MVVM.ICommand;
using EventosVista.MVVM.Model.Repository;
using System.Threading.Tasks;

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
        FireBaseUploader fbu;

        private EventRepository EventRepository;
        public PostEventView()
        {
            InitializeComponent();
            EventRepository = new EventRepository();
            fbu = new FireBaseUploader();

        }

        private async void PostEventButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (string.IsNullOrEmpty(titleField.Text))
            {
                MessageBox.Show("El evento debe tener un título");
                return;
            }
            if (string.IsNullOrEmpty(initDateField.Text))
            {
                MessageBox.Show("El evento debe tener una fecha de inicio");
                return;
            }
            if (string.IsNullOrEmpty(endDateField.Text))
            {
                MessageBox.Show("El evento debe tener una fecha de finalización");
                return;
            }
            if (string.IsNullOrEmpty(endDateField.Text))
            {
                MessageBox.Show("El evento debe tener un lugar");
                return;
            }
            if (string.IsNullOrEmpty(descriptField.Text))
            {
                MessageBox.Show("El evento debe tener una descripción");
                return;
            }
            titulo = titleField.Text;
            fechaInicio = initDateField.DisplayDate.Date;
            fechaFin = DateTime.Parse(endDateField.Text);
            lugar = placeField.Text;
            descrip = descriptField.Text;
            await fbu.UploadFile(imageName);

            Event evento = new Event(titulo, descrip, fechaInicio, fechaFin, Session.GetInstance().user)
            {
                lugar = lugar,
                banner = fbu.latestUpload
            };
            titulo = "";
            lugar = "";
            descrip = "";

            titleField.Text = "";
            initDateField.Text = "";
            endDateField.Text = "";
            placeField.Text = "";
            descriptField.Text = "";
            fbu.latestUpload = "";

            SaveCommand saveEvent = new SaveCommand(evento);
            Invoker.getInstance().setCommand(saveEvent);
            Invoker.getInstance().execute();
            if (saveEvent.response)
            {
                MessageBox.Show("Evento agregado!");
            }
            e.Handled = false;
        }

        private void SearchImageButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png";
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

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
