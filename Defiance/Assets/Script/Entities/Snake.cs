using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Snake : MonoBehaviour
{
    [SerializeField] private List<Transform> body;

    [SerializeField] private List<Vector3> pos = new List<Vector3>();

    public Player target;
    public float speed = 3f;

    [SerializeField]private float timeToSpawn;

    private Vector3 positionToAdd;
    private Vector3 destination;
    [SerializeField]
    NavMeshAgent agent;

    public void Start()
    {
        StartCoroutine(Spawn());
        //agent = GetComponent<NavMeshAgent>();
        pos = target.GetLastPosition();
    }

    void FixedUpdate()
    {
        //Enregistrement dans la liste
        if(pos.Count > body.Count)
        {
            target.RemoveLastPosition();
        }
        //Si la tête (index 0) s'arrête, on arrête tout

        Move();
    }

    public void Move()
    {
        for(int i = 0; i < pos.Count ; i++)
        {
            if(i == 0)
            {
                body[i].transform.LookAt(pos[i]);
                if (Vector3.Distance(body[i].transform.position, pos[i]) > 20f)
                {
                    //pos[i] += new Vector3(0, 0, speed * Time.deltaTime);
                    //pos[i] += new Vector3(0, 0, speed * Time.deltaTime);
                    agent.destination = pos[i];
                }
            }
            else
            {
                if (Vector3.Distance(body[i].transform.position, body[i - 1].transform.position) > 7f)
                {
                    body[i].transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                }
                body[i].transform.LookAt(body[i - 1]);
            }

            
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToSpawn);
    }
}
