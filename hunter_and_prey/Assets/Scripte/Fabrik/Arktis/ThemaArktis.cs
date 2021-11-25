using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
