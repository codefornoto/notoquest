using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : SingletonMonoBehaviour<Game>
{

    private GameObject[] targetObjects = new GameObject[4];
    private BoxCollider[] boxColliders = new BoxCollider[4];
    private RawImage rawimage;

    public GameObject message;

    public GameObject quiz;

    public enum GameState
    {
        None,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Goal,
    }
    public GameState State { get; private set; } = GameState.None;

    void Start()
    {
        Debug.Log("InitializeGame");
        InitializeGame();
    }

    void Update()
    {

    }

    private void InitializeGame()
    {
        ChangeStatus("STAGE1");
        this.rawimage = GameObject.Find("Quiz").GetComponent<RawImage>();
        this.rawimage.texture = Resources.Load<Texture2D>("STAGE1");
        this.message = GameObject.Find("Message");
        this.message.SetActive(false);
    }
    public void InitBoxCollider()
    {
        for (int i = 0; i < targetObjects.Length; i++)
        {
            targetObjects[i] = GameObject.Find("Quiz" + (i + 1) + "_Target");
            if (targetObjects[i] == null)
            {
                Debug.LogWarning("Quiz" + (i + 1) + "_Target GameObject が見つかりませんでした。");
                continue;
            }
            boxColliders[i] = targetObjects[i].GetComponent<BoxCollider>();
            if (boxColliders[i] == null)
            {
                Debug.LogWarning("BoxCollider コンポーネントが見つかりませんでした。");
                continue;
            }
            ToggleCollider(targetObjects[i], false);
        }
    }
    public void ToggleCollider(GameObject obj, bool isEnabled)
    {
        BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            Debug.LogWarning("指定された GameObject に BoxCollider コンポーネントが見つかりませんでした。");
            return;
        }
        boxCollider.enabled = isEnabled;
    }

    public void NextQuiz(string stageName)
    {
        this.rawimage.texture = Resources.Load<Texture2D>(stageName);

    }
    // public void ShowClearMessage()
    // {
    //     Debug.Log("ShowClearMessage");
    //     var cardObj = Instantiate(Game.Instance.Message, transform);
    //     cardObj.sprite = Resources.Load<Sprite>("STAGE1");
    //     cardObj.transform.localPosition = new Vector3(0, 0, 1);
    // }
    public void ChangeStatus(string stage)
    {
        switch (stage)
        {
            case "STAGE1":
                State = GameState.Stage1;
                InitBoxCollider();
                ToggleCollider(targetObjects[0], true);
                break;
            case "STAGE2":
                State = GameState.Stage2;
                InitBoxCollider();
                ToggleCollider(targetObjects[1], true);
                break;
            case "STAGE3":
                State = GameState.Stage3;
                InitBoxCollider();
                ToggleCollider(targetObjects[2], true);
                break;
            case "STAGE4":
                State = GameState.Stage4;
                InitBoxCollider();
                ToggleCollider(targetObjects[3], true);
                break;
            default:
                break;
        }
    }

    public void ChangeVisibleModeforQuiz()
    {
        if (quiz != null)
        {
            quiz.SetActive(!quiz.activeSelf);
        }
    }
}
