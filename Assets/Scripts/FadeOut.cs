using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private RawImage image; // フェードアウトさせるImageオブジェクト
    private Color color;
    private GameObject message;
    private GameObject button;
    private float fadeSpeed = 0.5f; // フェードアウトの速度
    private void Start()
    {
        this.image = GameObject.Find("Image").GetComponent<RawImage>();
        this.message = GameObject.Find("Prologue").gameObject;
        this.button = GameObject.Find("PlayButton").gameObject;
        this.message.SetActive(false);
        this.button.SetActive(false);
        color = this.image.color;
        // color.r = 255.0f;
        // color.g = 255.0f;
        // color.b = 255.0f;
        color.a = 1.0f;
        this.image.color = color;

    }
    private void Update()
    {
        color.a -= fadeSpeed * Time.deltaTime;
        color.a = Mathf.Max(color.a, 0);

        this.image.color = color;

        // アルファ値が0になったらオブジェクトを非表示にする
        if (color.a <= 0)
        {
            gameObject.SetActive(false);
            this.message.SetActive(true);
            this.button.SetActive(true);
        }
    }
}
