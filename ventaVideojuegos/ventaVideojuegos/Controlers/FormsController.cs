using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos;

namespace ventaVideojuegos
{
    internal class FormsController
    {

        public static Form1 Form1
        {
            get
            {
                if(_form1 == null)
                {
                    _form1 = new Form1();
                }
                return _form1;
            }
        }

        public static Login login1
        {
            get
            {
                if (_login1 == null)
                {
                    _login1 = new Login();
                }
                return _login1;
            }
        }

        private static Login _login1;

        private static Form1 _form1;

    }
}
