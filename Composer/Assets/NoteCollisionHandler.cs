using UnityEngine;
using System.Collections;

public class NoteCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.ObjectDeath)
        {
            GameObject.Destroy(this.gameObject);
            GameManager.Instance().NumNotes--;
        }
    }
}
