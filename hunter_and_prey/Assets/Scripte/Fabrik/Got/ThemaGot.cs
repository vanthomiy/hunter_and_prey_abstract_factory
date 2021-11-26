using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaGot : IThema
    {
        public IBeuteThema LiefereBeuteThema()
        {
            return new ThemaGotBeute();
        }

        public IJägerThema LiefereJägerThema()
        {
            return new ThemaGotJäger();
        }

        public GameObject LiefereUmweltThema()
        {
            return Resources.Load("Umwelt/GotUmwelt") as GameObject;
        }
    }
}
