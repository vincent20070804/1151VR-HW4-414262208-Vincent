using UnityEngine;

public class AircraftController : MonoBehaviour
{
    // 固定往前飛的速度（你可以自己調整大小，例如 0.2 或 0.5）
    public float forwardSpeed = 0.3f; 
    
    // 記錄滑鼠按下的起始位置
    Vector2 startTouchPos;
    float startPlaneY;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // 1. 讓飛機持續不斷地朝 Z 軸正向移動
        transform.Translate(0, 0, forwardSpeed, Space.World);

        // 2. 滑鼠拖曳控制上下（Y 軸）移動
        if (Input.GetMouseButtonDown(0))
        {
            this.startTouchPos = Input.mousePosition;
            this.startPlaneY = transform.position.y;
        }
        else if (Input.GetMouseButton(0)) // 當滑鼠按著拖曳時
        {
            Vector2 currentTouchPos = Input.mousePosition;
            
            // 計算滑鼠上下移動的距離差
            float ySwipeLength = currentTouchPos.y - this.startTouchPos.y;
            
            // 根據滑鼠移動量來改變飛機的 Y 座標（除以 100 可以調整靈敏度）
            float targetY = this.startPlaneY + (ySwipeLength / 100.0f);
            
            // 更新飛機的 Position，保持 X 和 Z 不變，只改變 Y
            transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
        }
        // 檢查是否飛過 Z = 150
        if (transform.position.z >= 150f)
        {
            Debug.Log("遊戲通關！");
            
            // 如果是在 Unity 編輯器中測試，這行可以停止 Play 模式
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            // 如果是打包後的遊戲，可以關閉程式
            Application.Quit();
            #endif
        }
    }
}