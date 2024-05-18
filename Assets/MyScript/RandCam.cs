using UnityEngine;

public class RandCam : MonoBehaviour
{
    public Transform targetObject;  // 物體
    public float switchIntervalMin = 3f;  // 切換鏡頭的最小間隔
    public float switchIntervalMax = 5f;  // 切換鏡頭的最大間隔
    
    public float maxOffsetDistance = 5f;  // 鏡頭最大偏移距離
    public float yp=20,yn=5;
    public Camera mainCamera;
    private float switchTimer;

    void Start()
    {
        mainCamera = Camera.main;
        switchTimer = Random.Range(switchIntervalMin, switchIntervalMax);
    }

    void Update()
    {
        switchTimer -= Time.deltaTime;

        if (switchTimer <= 0f)
        {
            SwitchCamera();
            switchTimer = Random.Range(switchIntervalMin, switchIntervalMax);
        }
    }

    void SwitchCamera()
    {
        // 以目標物體為基準，生成隨機偏移
        Vector3 randomOffset = new Vector3(Random.Range(-maxOffsetDistance, maxOffsetDistance),
                                           Random.Range(yn, yp),
                                           Random.Range(-maxOffsetDistance, maxOffsetDistance));

        // 設定攝影機位置，參考目標物體位置加上隨機偏移
        mainCamera.transform.position = targetObject.position + randomOffset;

        // 讓攝影機看向物體
        mainCamera.transform.LookAt(targetObject);
    }
}
