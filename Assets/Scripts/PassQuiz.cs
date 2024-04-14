using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PassQuiz : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ChangeScene");
        switch (Game.Instance.State)
        {
            case Game.GameState.Stage4:
                SceneManager.LoadScene("Goal");
                break;
            default:
                Game.Instance.message.SetActive(true);
                break;
        }
    }
}
