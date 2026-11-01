using UnityEngine;

public class CameraFollowSide : MonoBehaviour
{
    public Transform target; // 請把「飛機」拖進這個欄位
    
    // 相對於飛機的偏移量：X=35 (側邊距離), Y=4 (高度), Z=0 (與飛機同中心線，或可調 -5 稍微落後)
    public Vector3 offset = new Vector3(35f, 4f, 0f);

    void LateUpdate()
    {
        if (target == null) return;

        // 讓相機位置永遠等於「飛機的位置 + 側邊偏移量」
        // 這樣飛機從 Z = -50 移動到 Z = 150 時，相機會完美同步跟著走
        transform.position = target.position + offset;

        // 強制讓相機隨時盯著飛機看（確保側視角度不會跑掉）
        transform.LookAt(target);
    }
}
