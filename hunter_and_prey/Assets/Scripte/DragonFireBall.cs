using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripte
{
    internal class DragonFireBall : MonoBehaviour
    {

        public GameObject fireball;

        public void StartAnimation()
        {
            fireball.SetActive(true);
            fireball.GetComponent<ParticleSystem>().Play();
        }

        public void EndAnimation()
        {
            fireball.SetActive(false);
            fireball.GetComponent<ParticleSystem>().Clear();
            fireball.GetComponent<ParticleSystem>().Pause();
        }

    }
}
