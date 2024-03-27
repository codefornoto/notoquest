using UnityEngine;
using NRKernal;
using UnityEngine.EventSystems;
public class RotateImage : MonoBehaviour, IPointerClickHandler
{
    // 回転速度（初期値：20 deg/sec）
    public float speed = 20.0f;
    bool rotate = false;
    // 初期化で使用（今回は使わない）
    void Start() { }
    public void OnPointerClick(PointerEventData eventData)
    {
        rotate = !rotate;
    }

    // 毎フレーム更新
    void Update()
    {
        if (rotate)
        {
            // Rotate（x軸，y軸，z軸，回転基準）
            transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
        }
    }
}
