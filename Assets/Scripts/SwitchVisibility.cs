using UnityEngine;
using UnityEngine.EventSystems;

public class SwithVisibility : MonoBehaviour, IPointerClickHandler
{
    public GameObject quiz;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (quiz != null)
        {
            quiz.SetActive(!quiz.activeSelf);
        }
    }
}
