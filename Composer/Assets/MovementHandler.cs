using UnityEngine;
using System.Collections;

public class MovementHandler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0f, 0f, 0f);
        switch(Track)
        {
            case Tracks.Up:
                direction.y = -0.1f;
                break;
            case Tracks.Right:
                direction.x = 0.1f;
                break;
            case Tracks.Down:
                direction.y = 0.1f;
                break;
            case Tracks.Left:
                direction.x = -0.1f;
                break;
        }
        gameObject.transform.position += direction;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.ObjectDeath)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    public enum Tracks { Up, Right, Down, Left} 
    public Tracks Track { get; set; }
}
