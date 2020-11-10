using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CotacaoDoDolar {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new View.PaginaCotacao();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
