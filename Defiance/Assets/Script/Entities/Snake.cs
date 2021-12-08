using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private List<Transform> body;

    [SerializeField] private List<Tuple<Vector3, Quaternion>> pos = new List<Tuple<Vector3, Quaternion>>();

    public Transform target;
    public float speed = 3f;

    [SerializeField]private float timeToSpawn;

    private Vector3 rotationToAdd;
    private Vector3 positionToAdd;
    public Tuple<Vector3, Quaternion> transformToAdd;

    public void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {

        //Calcul de la prochaine rotation à faire face
        rotationToAdd = target.position;
        rotationToAdd += new Vector3(0, -90, 0);
        Quaternion quaternion = Quaternion.Euler(rotationToAdd.x, rotationToAdd.y, rotationToAdd.z);

        //Calcul de la prochaine position à rejoindre
        positionToAdd = new Vector3(speed * Time.deltaTime, 0, 0);
        //Debug.Log(positionToAdd);


        transformToAdd = new Tuple<Vector3, Quaternion> (positionToAdd, quaternion);

        //Enregistrement dans la liste
        pos.Insert(0, transformToAdd);
        if(pos.Count >= body.Count)
        {
            pos.RemoveAt(body.Count);
        }



        if (transformToAdd != null)
        {
            //Mouvement de chaque 'body' avec sa pos -1
            Move();
        }
        //Si la tête (index 0) s'arrête, on arrête tout
    }

    public void Move()
    {
        for(int i = 0; pos[i] != null ; i++)
        {
            if(i == 0)
            {
                body[i].transform.LookAt(target);
            }
            else
            {
                body[i].transform.LookAt(body[i - 1]);
            }
            body[i].transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            if (Vector3.Distance(body[i].transform.position, target.position) > 20f)
            {
                body[i].transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToSpawn);
    }
}
