using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject player;
    public float awakeTime = 5;
    public Transform position;

    // Start is called before the first frame update
    void Awake()
    {
        //GameManager.playerWaypoints.Add(gameObject);
        player = GameManager.player;
        Destroy(gameObject, awakeTime);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
