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
                SceneManager.LoadScene("Scenes/Lose");
                
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

            GameObject duplicatedSounds = Instantiate(GameObject.Find("ComposerHit"));
            AudioSource aSource = duplicatedSounds.GetComponent<AudioSource>();
            aSource.Play();
            StartCoroutine(DestroyGameObject(duplicatedSounds));
        }
    }
    IEnumerator DestroyGameObject(GameObject obj) {
        yield return new WaitForSeconds(obj.GetComponent<AudioSource>().clip.length);
        GameObject.Destroy(obj);
    }
}
