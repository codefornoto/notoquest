using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMenu : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        Game.Instance.ChangeVisibleModeforQuiz();

    }
}
