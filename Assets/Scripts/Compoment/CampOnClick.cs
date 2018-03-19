using UnityEngine;

public class CampOnClick : MonoBehaviour
{
    public BaseCamp Camp { get; set; }

    public void OnMouseUpAsButton()
    {
        GameFacade.Instance.CampInfoUI.ShowCampInfo(Camp);
    }
}