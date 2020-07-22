using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Otter
{
    public class Particle : MonoBehaviour
    {
        Vector3 grav = new Vector3(0, -9.81f, 0);
        public Vector3 wind = new Vector3(0, 0, 0);
        Vector3 bounce;
        Vector3 bounceWithRC;
        Vector3 accel = new Vector3(0, 0, 0);
        Vector3 forces;
        float dt = 1.0f / 60.0f;
        public float mass = 10;
        public float radius;
        Vector3 prevPos;
        Vector3 currPos;
        bool first = true;
        public Color originalColor;

        // Start is called before the first frame update
        void Start()
        {
            float red = Random.Range(0.0f, 0.1f);
            float blue = Random.Range(0.3f, 0.7f);
            float green = Random.Range(0.5f, 0.9f);
            Color c = new Color(red, blue, green);
            originalColor = c;
            gameObject.GetComponent<Renderer>().material.color = c;

            bounceWithRC = new Vector3(0, 40f, 0);
            accel = grav;
            forces = new Vector3(accel.x + wind.x, accel.y + wind.y, accel.z + wind.z);
            prevPos = transform.localPosition;
            currPos = prevPos;
            transform.localPosition = prevPos;
            Destroy(gameObject, 7);
        }

        // Update is called once per frame
        void Update()
        {

            //Reduce acceleration
            if (accel.y > -9.81f)
            {
                //Reduce 
                //bounceWithFriction = bounceWithFriction + grav;
                accel = accel + grav;

                //Validate that accel.y is always equal to gravity
                if (accel.y <= grav.y)
                {
                    accel = grav;
                }

            }

            forces = new Vector3(accel.x + wind.x, accel.y + wind.y, accel.z + wind.z);
            Vector3 newPos;

            newPos = 2 * currPos - prevPos + forces * dt;

            transform.localPosition = newPos;

            prevPos = currPos;
            currPos = newPos;

            //Bounce();

            if (transform.localPosition.y <= 0f)
            {
                prevPos = new Vector3(0, 3f, -15);
                currPos = new Vector3(0, 4.25f, -15);
                transform.localPosition = currPos;
                bounceWithRC = new Vector3(0, 40f, 0);
                wind = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            }
        }

        void Bounce()
        {
            if (transform.localPosition.y <= 2f && transform.localPosition.x > -1.6f && transform.localPosition.x < 1.6f
                && transform.localPosition.z > -19f && transform.localPosition.z < -10f)
            {
                prevPos = new Vector3(transform.localPosition.x, 0.2f, transform.localPosition.z);
                currPos = new Vector3(transform.localPosition.x, 0.21f, transform.localPosition.z);
                transform.localPosition = currPos;

                Vector3 RC = new Vector3(0, 0.95f, 0);

                bounceWithRC.y = bounceWithRC.y * RC.y;

                //Set the new accel
                accel = bounceWithRC;
                //Debug.Log("bounce accel: " + accel);
            }
        }

        public bool InCollision(Particle other)
        {
            float r1 = radius;
            float r2 = other.radius;
            float sumR = r1 + r2;

            Vector3 c1 = currPos;
            Vector3 c2 = other.currPos;

            if (Vector3.Distance(c1, c2) < sumR)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}