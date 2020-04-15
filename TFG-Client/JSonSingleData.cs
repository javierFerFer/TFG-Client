using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFG_Client {
    class JSonSingleData {

        private string b_Content;
        private string a_Title;
        /// <summary>
        /// Constructor vacío
        /// 
        /// Empty constructor
        /// </summary>
        public JSonSingleData() {
        }

        public string A_Title { get => a_Title; set => a_Title = value; }
        public string B_Content { get => b_Content; set => b_Content = value; }
    }
}
