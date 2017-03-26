using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private AudioSource m_Source;
        private bool playerTouch = false;
        private float ReloadCdw = 1f;

        void Awake()
        {
            m_Source = GetComponent<AudioSource>();
        } 

        void Update()
        {
            if (playerTouch)
            {
                ReloadCdw -= Time.deltaTime;
            }

            if (ReloadCdw < 0)
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                m_Source.Play();
                playerTouch = true;
            }
        }
    }
}
