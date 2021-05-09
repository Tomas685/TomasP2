using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moving_platform : MonoBehaviour

{
    public Transform[] waypoints;
    public float moveSpeed;
    public int currentPoint;
    public Transform platform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, waypoints[currentPoint].position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(platform.position, waypoints[currentPoint].position) < 0.5f)
        {
            currentPoint++;
            if (currentPoint >= waypoints.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
