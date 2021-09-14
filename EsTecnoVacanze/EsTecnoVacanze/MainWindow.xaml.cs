using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EsTecnoVacanze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }
        string nome;
        string cognome;
        string CodiceFiscale;
        string DatadiNascita;
        string ndosericevuta;
        string tipovaccino;
        CPersone p;
        private void btnsalvapersona_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"\Schedine elenco.txt") && File.ReadAllText(@"\Elenco persone.txt") == "")
            {
                File.AppendAllText(Directory.GetCurrentDirectory() + @"\Elenco persone.txt", nome + "-" + cognome + "-" + DatadiNascita+"-"+CodiceFiscale+"-"+ ndosericevuta+"-"+tipovaccino);

            }
            else
            {
                File.AppendAllText(Directory.GetCurrentDirectory() + @"\Elenco persone.txt", "\n" + nome + "-" + cognome + "-" + DatadiNascita+"-"+CodiceFiscale+"-"+ndosericevuta+"-"+ tipovaccino);
            }
        }

        private void btnqr_Click(object sender, RoutedEventArgs e)
        {
            list_scelta .ItemsSource= CaricaLista();
        }
        private String[] CaricaLista()
        {
            string nomeFile = Directory.GetCurrentDirectory() + @"\Elenco persone.txt";
            string tutto = File.ReadAllText(nomeFile);
            String[] linee = tutto.Split('\n');
            return linee;
        }

        private void list_scelta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String[] lista = CaricaLista();
            string stringaDaConvertire = lista.ElementAt(list_scelta.SelectedIndex);


            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(stringaDaConvertire, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\ImgQr.bmp"))
            {
                img_qr.Source = new BitmapImage();
                File.Delete(Directory.GetCurrentDirectory() + "\\ImgQr.bmp");
                qrCodeImage.Save(Directory.GetCurrentDirectory() + "\\ImgQr.bmp");
                qrCodeImage.Dispose();
            }
            else
            {
                qrCodeImage.Save(Directory.GetCurrentDirectory() + "\\ImgQr.bmp");
                qrCodeImage.Dispose();
            }
            img_qr.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\ImgQr.bmp"));

        }

     
    }
}
