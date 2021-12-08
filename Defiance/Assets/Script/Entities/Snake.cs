using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private List<Transform> body;

    [SerializeField] private ArrayList pos = new ArrayList();

    public Transform target;
    public float speed = 3f;

    [SerializeField]private float timeToSpawn;

    private Vector3 rotationToAdd;
    private Vector3 positionToAdd;
    public Transform transformToAdd;

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
        Debug.Log(positionToAdd);


        transformToAdd.position = positionToAdd;
        transformToAdd.rotation = quaternion;
        //Enregistrement dans la liste
        pos.Add(transformToAdd);
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
            //body[i].transform.LookAt(pos[i], Vector3.forward);
            body[i].transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            if (Vector3.Distance(body[i].transform.position, target.position) > 2f)
            {
                body[i].transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            
        }




        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > 2f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToSpawn);
    }
}
