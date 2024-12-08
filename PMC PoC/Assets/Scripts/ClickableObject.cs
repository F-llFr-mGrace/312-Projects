using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public GUIController controller;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        controller.TownClicked(gameObject);
    }
}
