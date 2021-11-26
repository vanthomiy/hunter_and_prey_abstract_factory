using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripte
{
    public class CameraController : MonoBehaviour
    {
        public GameObject target;

        private Vector3 lookAt;

        public float camSpeed;
        public float camRotSpeed;
        public float value;

        public float minHeight;
        public float maxHeight;
        public float minDistance;
        public float maxDistance;

        private int pos = 0;
        private int lastTarget = 0;

        public Welt welt;

        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {

                value+= 0.01f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {

                value -= 0.01f;
            }

            if (value < 0)
            {
                value = 0;
            }
            else if (value > 10)
            {
                value = 10;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (++lastTarget >= welt.jägerObekte.Count)
                {
                    lastTarget = 0;
                }

                target = welt.jägerObekte[lastTarget].gameObject;
            }

            if (target != null)
            {
                var distanceRelation = maxDistance - minDistance;
                var distFactor = distanceRelation * (10 - value) + minDistance;

                var heightRelation = maxHeight - minHeight;
                var heightFactor = heightRelation * (10 - value) + minHeight;

                lookAt = target.transform.position + target.transform.forward * (maxDistance + minDistance - distFactor);
                var targetRotation = Quaternion.LookRotation(lookAt - transform.position);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, camRotSpeed * Time.deltaTime);
                
                gameObject.transform.LookAt(lookAt);

                var toPos = target.transform.position + target.transform.forward * -distFactor;
                toPos = new Vector3(toPos.x, heightFactor + target.transform.position.y, toPos.z);
                this.transform.position = Vector3.Lerp(this.transform.position, toPos, camSpeed * Time.deltaTime);
            }
        }
    }
}