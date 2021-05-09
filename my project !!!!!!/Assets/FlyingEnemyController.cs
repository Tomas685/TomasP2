using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed;
    public int currentPoint;
    public SpriteRenderer sr;
    public float attackDistance;
    public float attackSpeed;
    private Vector3 target;
    public float waitAfterAttack;
    private float attackCounter;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCounter > 0.01f)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, PlayerScript.instance.transform.position) > attackDistance)
            {

                target = Vector3.zero;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentPoint].position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, waypoints[currentPoint].position) < 0.5f)
                {
                    currentPoint++;
                    if (currentPoint >= waypoints.Length)
                    {
                        currentPoint = 0;
                    }
                }

                if (transform.position.x < waypoints[currentPoint].position.x)
                {
                    sr.flipX = true;
                }

                else if (transform.position.x > waypoints[currentPoint].position.x)
                {
                    sr.flipX = false;
                }
            }
            else
            {
                Debug.Log("toimib");

                if (target == Vector3.zero)
                {
                    target = PlayerScript.instance.transform.position;
                }
                transform.position = Vector3.MoveTowards(transform.position, target, attackSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target) <= 0.3f)
                {
                    attackCounter = waitAfterAttack;
                    target = Vector3.zero;
                }
            }
        }

    }
}