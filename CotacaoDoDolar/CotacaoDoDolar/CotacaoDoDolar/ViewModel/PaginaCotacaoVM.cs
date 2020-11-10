using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace CotacaoDoDolar.ViewModel {
    class PaginaCotacaoVM : INotifyPropertyChanged {

        private string GetApi = "https://economia.awesomeapi.com.br/json/all/USD-BRL";
        private double Dolar;

        private string _Atualizacao;
        public string Atualizacao { get { return _Atualizacao; } set { _Atualizacao = value; OnPropertyChanged("Atualizacao"); } }

        private string _ValorDolar;
        public string ValorDolar { get { return _ValorDolar; } set { _ValorDolar = value; OnPropertyChanged("ValorDolar"); } }

        private string _ValorMenor;
        public string ValorMenor { get { return _ValorMenor; } set { _ValorMenor = value; OnPropertyChanged("ValorMenor"); } }

        private string _ValorVariacao;
        public string ValorVariacao { get { return _ValorVariacao; } set { _ValorVariacao = value; OnPropertyChanged("ValorVariacao"); } }

        private string _ValorMaior;
        public string ValorMaior { get { return _ValorMaior; } set { _ValorMaior = value; OnPropertyChanged("ValorMaior"); } }

        private string _TextoParaBRL;
        public string TextoParaBRL { get { return _TextoParaBRL; } set { _TextoParaBRL = value; OnPropertyChanged("TextoParaBRL"); } }

        private string _TextoParaUSD;
        public string TextoParaUSD { get { return _TextoParaUSD; } set { _TextoParaUSD = value; OnPropertyChanged("TextoParaUSD"); } }

        private string _ResultParaBRL;
        public string ResultParaBRL { get { return _ResultParaBRL; } set { _ResultParaBRL = value; OnPropertyChanged("ResultParaBRL"); } }

        private string _ResultParaUSD;
        public string ResultParaUSD { get { return _ResultParaUSD; } set { _ResultParaUSD = value; OnPropertyChanged("ResultParaUSD"); } }

        public Command ConverterParaUSD { get; set; }
        public Command ConverterParaBRL { get; set; }

        public PaginaCotacaoVM() {

            ConverterParaBRL = new Command(ConvertBRL);
            ConverterParaUSD = new Command(ConvertUSD);


            using(WebClient web = new WebClient()) {
                try {
                    var down = web.DownloadString(GetApi);

                    var json = JsonConvert.DeserializeObject<Model.GetDolar.root>(down);

                    Atualizacao = "Atualizado hoje, as " + json.USD.Create_Date.Substring(10, 9);
                    ValorDolar = "R$ " + json.USD.Bid.ToString("0.00");
                    ValorMenor = Convert.ToString(json.USD.Low);
                    ValorVariacao = Convert.ToString(json.USD.VarBid);
                    ValorMaior = Convert.ToString(json.USD.High);

                    Dolar = Convert.ToDouble(json.USD.Bid.ToString("0.00"));

                } catch(System.Net.WebException) {
                    Application.Current.MainPage.DisplayAlert("Error", "Conexão inexistente com a internet", "Ok");
                }
            }
        }

        public void ConvertBRL() {
            ResultParaBRL = "R$ " + (Convert.ToDouble(TextoParaBRL) * Dolar).ToString("0.00");
        }

        public void ConvertUSD() {
            ResultParaUSD = "$ " + (Convert.ToDouble(TextoParaUSD) / Dolar).ToString("0.00");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomeProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(nomeProperty));
            }
        }
    }
}
