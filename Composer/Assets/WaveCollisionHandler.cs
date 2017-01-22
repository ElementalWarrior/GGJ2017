using UnityEngine;
using System.Collections;

public class WaveCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == this.tag && collision.name.IndexOf("Note") > -1)
        {
            GameObject.Destroy(collision.gameObject);
        }
        if (collision.name.IndexOf("Note") > -1)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
