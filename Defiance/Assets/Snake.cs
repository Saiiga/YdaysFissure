using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private ArrayList body = new ArrayList();

    [SerializeField] private ArrayList pos = new ArrayList();

    public Transform target;
    public float speed = 3f;

    void Update()
    {
       /* //Calcul de la prochaine position à aller
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);


        if (Vector3.Distance(transform.position, target.position) > 2f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        //Enregistrement dans la liste
        pos.Add(posToAdd);
        if (posToAdd != null)
        {
            //Mouvement de chaque 'body' avec sa pos -1
            Move();
        }
        //Si la tête (index 0) s'arrête, on arrête tout*/
    }

    public void Move()
    {

    }
}
