using UnityEngine;
using System.Collections;
    

public class MovementHandler : MonoBehaviour
{
    public Vector3 direction;
    public float Speed = 0.05f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //switch(Track)
        //{
        //    case Tracks.Up:
        //        direction.y = -0.1f;
        //        break;
        //    case Tracks.Right:
        //        direction.x = 0.1f;
        //        break;
        //    case Tracks.Down:
        //        direction.y = 0.1f;
        //        break;
        //    case Tracks.Left:
        //        direction.x = -0.1f;
        //        break;
        //}
        if (!GameManager.Instance().IsPaused)
        {
            gameObject.transform.position += direction * Speed;
        }

    }
    //public enum Tracks { Up, Right, Down, Left} 
    //public Tracks Track { get; set; }
}