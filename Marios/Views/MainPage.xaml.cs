using Marios.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Marios
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        
           // this.BindingContext = new MainPageViewModel();
        }


        //testear un servicio rest con un metodo virtual

        public MainPageViewModel ViewModel { get; set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new MainPageViewModel();//nueva instancia
            await ViewModel.LoadCharacter();
            this.BindingContext = ViewModel;
            
        }
        //eveto del frame
        private async void ViewCell_Appearing(object sender, EventArgs e)
        {
            //siempre se convierte el sender a lo que estoy trabajando
            var cell = sender as ViewCell;
            //ocupamos la propiedad view
            var view = cell.View;
            view.TranslationX = -100;
            view.Opacity = 0;
            await Task.WhenAny<bool>
                (
                    view.TranslateTo(0, 0, 250, Easing.SinIn),
                    view.FadeTo(1,500,Easing.CubicInOut)
                );
            
        }

       
    }
}
