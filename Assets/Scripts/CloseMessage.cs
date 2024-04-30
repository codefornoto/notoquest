using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CloseMessage : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (Game.Instance.State)
        {
            case Game.GameState.None:
            case Game.GameState.Stage1:
                ChangeStage("STAGE2");
                break;
            case Game.GameState.Stage2:
                ChangeStage("STAGE3");
                break;
            case Game.GameState.Stage3:
                ChangeStage("STAGE4");
                break;
            default:
                break;
        }
    }

    public void ChangeStage(string StageName)
    {
        Game.Instance.message.SetActive(false);
        Game.Instance.NextQuiz(StageName);
        Game.Instance.ChangeStatus(StageName);
        Game.Instance.quiz.SetActive(true);
    }
}
