using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaWald : IThema
    {
        public IBeuteThema LiefereBeuteThema()
        {
            return new ThemaWaldBeute();
        }

        public IJägerThema LiefereJägerThema()
        {
            return new ThemaWaldJäger();
        }

        public GameObject LiefereUmweltThema()
        {
            return Resources.Load("Umwelt/WaldUmwelt") as GameObject;
        }
    }
}
