using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaWald : IThema
    {
        public IBeuteThema LiefereBeuteThema()
        {
            return new ThemaWaldHase();
        }

        public IJägerThema LiefereJägerThema()
        {
            return new ThemaWaldFuchs();
        }
    }
}
