using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class NoteCollisionHandler : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.ObjectDeath)
        {
            GameObject particles = Resources.Load<GameObject>("DeathParticleSpawner");
            
            Instantiate(particles, this.transform.position, new Quaternion());
            //collision.GetComponent<ParticleSystem>().Play();
            GameObject.Destroy(this.gameObject);
            GameManager.Instance().NumNotes--;
            GameManager.NumHearts -= 1;
            
            if (GameManager.NumHearts == 0)
            {
                SceneManager.LoadScene("Lose");
                
            }
            if (GameManager.NumHearts == 2)
            {
                GameObject.Destroy(GameManager.Instance().heart0);
            }
            if (GameManager.NumHearts == 1)
            {
                GameObject.Destroy(GameManager.Instance().heart1);
            }

            if (GameManager.NumHearts == 0)
            {
                GameObject.Destroy(GameManager.Instance().heart2);
            }

        }
    }
}
