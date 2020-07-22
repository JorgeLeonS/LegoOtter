/*
Particle System created by:
Alfredo Prado
Alonso Narro
Jorge León
Rosa Miranda
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Otter
{
    public class ParticleEmitter : MonoBehaviour
    {
        public GameObject particlePrefab;

        Otter.Particle[] particles = new Otter.Particle[15];

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            // CheckCollisions();
        }

        public void StartParticle()
        {
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i] = Instantiate(particlePrefab).GetComponent<Otter.Particle>();
                particles[i].transform.position = transform.position;
                particles[i].wind = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

                float randScale = Random.Range(0.1f, 0.2f);
                particles[i].transform.localScale = new Vector3(randScale, randScale, randScale);
                particles[i].radius = (randScale / 2);
            }
        }

        void CheckCollisions()
        {
            for (int p = 0; p < particles.Length; p++)
            {
                bool InCollision = false;
                for (int q = 0; q < particles.Length; q++)
                {
                    if (q != p)
                    {
                        if (particles[p].InCollision(particles[q]))
                        {
                            InCollision = true;
                            particles[p].GetComponent<Renderer>().material.color = Color.red;
                            particles[q].GetComponent<Renderer>().material.color = Color.red;
                        }
                    }

                }

                if (!InCollision)
                {
                    particles[p].GetComponent<Renderer>().material.color = particles[p].originalColor;
                }
            }
        }
    }
}