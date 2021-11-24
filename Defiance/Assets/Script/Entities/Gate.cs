
public class Gate : Item
{
    private bool locked;
    private bool isOpen;

    public override void Action(Player _player)
    {
        OpenTheGate();
    }

    public void OpenTheGate()
    {
        if(locked && !isOpen)
        {

        }
    }

    public void UnlockDoor(Player _player)
    {
        if (_player.CanUnlockDoor())
            locked = false;
    }
}
