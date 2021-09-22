using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            byte[] bytes;
            using (WebClient myWebClient = new WebClient())
            {
                // Download the Web resource and save it into a data buffer.
                bytes = myWebClient.DownloadData("https://www.ivsoftware.com/proto-21/high-def.docx");
            }
            RichEditDocumentServer wordProcessor = new RichEditDocumentServer();
            { }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
