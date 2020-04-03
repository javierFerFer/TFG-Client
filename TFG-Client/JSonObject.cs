using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFG_Client {
    public class JSonObject {
        private string title;
        private string[] content;

        public JSonObject() {
        }

        public string Title { get => title; set => title = value; }
        public string[] Content { get => content; set => content = value; }
    }
}
