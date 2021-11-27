using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaArktis : IThema
    {
        public IBeuteThema LiefereBeuteThema()
        {
            return new ThemaArktisBeute();
        }

        public IJägerThema LiefereJägerThema()
        {
            return new ThemaArktisJäger();
        }

        public GameObject LiefereUmweltThema()
        {
            return Resources.Load("Umwelt/ArktisUmwelt") as GameObject;
        }
    }
}
