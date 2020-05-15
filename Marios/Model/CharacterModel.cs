using System;
using System.Collections.Generic;
using System.Text;

namespace Marios.Model
{
    //son genericas
        public class Characters//hace uno
        {
            public Character[] amiibo { get; set; }
        }

        public class Character//sus datos de uno
        {
            public string key { get; set; }
            public string name { get; set; }
        }

    
}
