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
            return new ThemaSchneeHase();
        }

        public IJägerThema LiefereJägerThema()
        {
            return new ThemaEisFuchs();
        }

        public GameObject LiefereUmweltThema()
        {
            return Resources.Load("Umwelt/ArktikUmwelt") as GameObject;
        }
    }
}
