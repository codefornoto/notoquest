using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setParent : MonoBehaviour
{
    // 親オブジェクトのトランスフォームをアサインします。
    public Transform parentTran;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(parentTran, false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
