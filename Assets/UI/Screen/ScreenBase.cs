using UnityEngine;

public class ScreenBase : MonoBehaviour
{

    public void Exit()
    {
        UIManagement.Instance.CallPopup("Are you sure",() => Application.Quit());
        
    }
}
