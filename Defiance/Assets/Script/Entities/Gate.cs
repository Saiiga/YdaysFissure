using UnityEngine;
public class Gate : Item
{
    private bool locked;
    private bool isOpenable;
    [SerializeField] private Animator animator;

    public override void Action(Player _player)
    {
        OpenTheGate();
    }

    public void OpenTheGate()
    {
        if(locked && !isOpenable)
        {
            animator.Play("open");
        }
    }

    public void UnlockDoor()
    {
        locked = false;
        OpenTheGate();
    }
}
