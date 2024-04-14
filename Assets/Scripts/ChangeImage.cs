using NRKernal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeImage : MonoBehaviour, IPointerClickHandler
{
    public Sprite newSprite;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ChangeScene");
    }
}