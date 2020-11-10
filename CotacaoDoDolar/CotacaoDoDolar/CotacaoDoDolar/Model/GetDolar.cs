using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoDoDolar.Model {
    class GetDolar {
        public double High { get; set; }
        public double Low { get; set; }
        public double VarBid { get; set; }
        public double Bid { get; set; }
        public string Create_Date { get; set; }

        public class root {
            public GetDolar USD { get; set; }
        }
    }
}
