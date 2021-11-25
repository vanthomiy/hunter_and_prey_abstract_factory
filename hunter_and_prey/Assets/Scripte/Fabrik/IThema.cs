using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripte.Fabrik
{
    internal interface IThema
    {
        IJägerThema LiefereJägerThema();
        IBeuteThema LiefereBeuteThema();
    }
}
