using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPController : MonoBehaviour
{
    public static CPController instance;
    private Checkpoint[] checkpoints;
    public Vector3 spawnpoint;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DeactivateCp()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].Reset();
        }
    }


    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnpoint = newSpawnPoint;
    }
}