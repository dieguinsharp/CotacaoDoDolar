using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CotacaoDoDolar.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaCotacao : ContentPage {
        public PaginaCotacao() {
            InitializeComponent();

            BindingContext = new ViewModel.PaginaCotacaoVM();
        }
    }
}