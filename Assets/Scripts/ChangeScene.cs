using NRKernal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, IPointerClickHandler
{
    public string targetSceneName; // クリックした画像に対応するシーンの名前

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ChangeScene");
        SceneManager.LoadScene(targetSceneName); // クリックした画像に対応するシーンをロード
    }
}