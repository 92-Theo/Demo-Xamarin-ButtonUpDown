using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ButtonUpDownApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
            TapCommand = new Command(() =>
            {
                Debug.WriteLine("TapCommand");
            });

            BindingContext = this;
        }

        public ICommand TapCommand { get; private set; }

        private void Button_Pressed(object sender, EventArgs e)
        {
            Debug.WriteLine("Button_Pressed");
        }

        private void Button_Released(object sender, EventArgs e)
        {
            Debug.WriteLine("Button_Released");
        }
    }
}
