using UnityEngine;
using System.Collections;

public class WaveCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == this.tag && collision.name.IndexOf("Note") > -1)
        {
            GameObject.Destroy(collision.gameObject);
            GameManager.Instance().NumNotes--;
        }
        if (collision.name.IndexOf("Note") > -1)
        {
            DestroySelf();
        }
        //if (this.GetComponent<Collider2D>().bounds.Intersects(Camera.main.GetComponent<Collider2D>().bounds))
        //{
        //    Debug.Log("Outside");
        //}
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Main Camera")
        {
            DestroySelf();
        }
    }
    private void DestroySelf()
    {
        GameObject.Destroy(this.gameObject);
        GameManager.Instance().NumWaves--;
    }
}
