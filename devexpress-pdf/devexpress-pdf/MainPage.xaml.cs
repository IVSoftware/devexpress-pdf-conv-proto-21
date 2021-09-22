using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace devexpress_pdf
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
    class BindingContext : INotifyPropertyChanged
    {
        public BindingContext()
        {          
            DocxToPdfCommand = new Command(OnDocxToPdf);
        }
        public ICommand DocxToPdfCommand { get; }
        private void OnDocxToPdf(object o)
        {
            var assembly = GetType().Assembly;

            Stream stream = assembly.GetManifestResourceStream("devexpress_pdf.res.high-def.docx");
            Byte[] bytes;
            using (var reader = new BinaryReader(stream))
            {
                bytes = reader.ReadBytes((int)stream.Length);
            }
            RichEditDocumentServer conversionServer = new RichEditDocumentServer();

            //Specify export options:
            PdfExportOptions options = new PdfExportOptions();
            options.DocumentOptions.Author = "Anonymous";
            options.Compressed = false;
            options.ImageQuality = PdfJpegImageQuality.Highest;

            //Export the document to the stream:
            using (MemoryStream pdfFileStream = new MemoryStream(bytes))
            {
                conversionServer.ExportToPdf(pdfFileStream, options);
            }
            { }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
