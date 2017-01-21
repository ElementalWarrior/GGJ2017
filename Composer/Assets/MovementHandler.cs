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
        gameObject.transform.position += new Vector3(1, 0, 0);
    }

    public int Track { get; set; }
}
