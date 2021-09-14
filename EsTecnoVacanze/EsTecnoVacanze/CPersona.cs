using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace EsTecnoVacanze
{
    public class CPersona
    {
        private string nome;
        private string cognome;
        private string CodiceFiscale;
        private string DatadiNascita;
        private string percorsoQRpersona;
        private string ndosericevuta;
        private string tipovaccino;
        private BitmapImage I;

        public CPersona(string nome, string cognome, string codiceFiscale, string datadiNascita, string percorsoQRpersona, string ndosericevuta, string tipovaccino, BitmapImage i)
        {
            this.nome = nome;
            this.cognome = cognome;
            CodiceFiscale = codiceFiscale;
            DatadiNascita = datadiNascita;
            this.percorsoQRpersona = percorsoQRpersona;
            this.ndosericevuta = ndosericevuta;
            this.tipovaccino = tipovaccino;
            I = i;
        }

        public CPersona()
        {
            nome = null;
            cognome = null;
            CodiceFiscale = null;
            DatadiNascita = null;
            tipovaccino = null;
            ndosericevuta = null;
        }

        public string getnome()
        {
            return nome;
        }

        public string getcognome()
        {
            return cognome;
        }
        public string getcodicefiscale()
        {
            return CodiceFiscale;
        }
        public string getnascita()
        {
            return DatadiNascita;
        }
        public string gettipovaccino()
        {
            return tipovaccino;
        }
        public string getndose()
        {
            return ndosericevuta;
        }
        public string stringone()
        {
            string v;
            v = nome + " " + cognome + " " + DatadiNascita + " " + CodiceFiscale + " " + I+tipovaccino+" "+ndosericevuta;
            return v;
        }


        public BitmapImage getQR()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(Directory.GetCurrentDirectory() + "//" + getnome() + ".bmp"+getcognome()+ ".bmp"+getcodicefiscale()+ ".bmp"+getnascita()+ ".bmp");
            I = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "//" + getnome() + ".bmp" + getcognome() + ".bmp" + getcodicefiscale() + ".bmp" + getnascita() + ".bmp"));
            return I;
        }
        public string toCSV()
        {
            return this.stringone() + percorsoQRpersona + ";" + "\n";
        }



    }
}
