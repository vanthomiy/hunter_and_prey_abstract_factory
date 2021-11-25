using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    public interface IWesenThema
    {
        AudioStrategie HoleAudioStrategie();
        IBewegungsStrategie HoleBewegungsStrategie();
        GameObject HoleAussehen();
    }
}
