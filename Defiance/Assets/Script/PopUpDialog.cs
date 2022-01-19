using TMPro;
using UnityEngine;

public class PopUpDialog : MonoBehaviour
{
    public TMP_Text popUpText;
    private bool isVisible = false;

    public PopUpDialog(string _text)
    {
        popUpText.text = _text;
        isVisible = true;
    }

    public void FixedUpdate()
    {
        if (!isVisible && Input.GetKey(KeyCode.F))
            Hide();
    }

    public void Hide()
    {
        Destroy(this);
    }
}
