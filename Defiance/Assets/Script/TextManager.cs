using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    [SerializeField] static PopUpDialog dialogBox;

    public static void ShowDialog(string _text, Transform _transform)
    {
        Vector3 position = new Vector3(_transform.position.x, _transform.position.y + 10, _transform.position.z);
        Instantiate(dialogBox, position,_transform.localRotation);
    }

}
