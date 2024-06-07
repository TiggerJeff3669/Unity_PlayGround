using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class MonitorCamSwitch : MonoBehaviour
{
    public GameObject PlayerArmature;
    // GameObject PlayerCapsule;
    public GameObject PlayerCam, DynamicCamera;

    public GameObject PlayerFollowCameraTPS, PlayerFollowCameraFPS;

    public int cameraState = 0;

    void Start()
    {
        PlayerArmature = GameObject.Find("PlayerArmature"); // WhiteMan Reference
        // PlayerCapsule = GameObject.Find("PlayerCapsule"); // FreeFly Reference 
        PlayerCam = GameObject.Find("PlayerCam"); // Common Camera Reference
        DynamicCamera = GameObject.Find("DynamicCamera");
        PlayerFollowCameraTPS = GameObject.Find("PlayerFollowCameraTPS");
        PlayerFollowCameraFPS = GameObject.Find("PlayerFollowCameraFPS");
        CameraStateCallback(2); // Initial state
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            cameraState = (cameraState + 1) % 3;
            CameraStateCallback(cameraState);
        }
    }

    void CameraStateCallback(int state)
    {
        switch (state)
        {
            case 0:
                // 狀態 0：啟用監視器鏡頭，停用其他對象
                PlayerArmature.GetComponent<PlayerInput>().enabled = false;
                // PlayerCapsule.GetComponent<PlayerInput>().enabled = false;
                PlayerCam.SetActive(false);
                PlayerFollowCameraTPS.SetActive(false);
                PlayerFollowCameraFPS.SetActive(false);
                DynamicCamera.SetActive(true);
                break;
            case 1:
                StartCoroutine(SwitchToState1());
                break;
            case 2:
                // 狀態 2：啟用 PlayerArmature 和 PlayerCam，停用其他對象
                StartCoroutine(SwitchToState2());
                break;
        }
    }
    IEnumerator SwitchToState1()
    {
        // 先停用狀態1的組件
        // PlayerArmature.GetComponent<ThirdPersonController>().enabled = false;
        // PlayerCapsule.GetComponent<FirstPersonController>().enabled = false;
        PlayerArmature.GetComponent<PlayerInput>().enabled = false;
        DynamicCamera.SetActive(false);
        PlayerFollowCameraTPS.SetActive(false);
        // PlayerCapsule.GetComponent<PlayerInput>().enabled = false;
        PlayerCam.SetActive(true);
        PlayerFollowCameraFPS.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        // 啟用狀態2的組件
        PlayerArmature.GetComponent<PlayerInput>().enabled = true;

    }
    IEnumerator SwitchToState2()
    {
        // 先停用狀態1的組件
        // PlayerArmature.GetComponent<ThirdPersonController>().enabled = false;
        // PlayerCapsule.GetComponent<FirstPersonController>().enabled = false;
        PlayerArmature.GetComponent<PlayerInput>().enabled = false;
        DynamicCamera.SetActive(false);
        PlayerFollowCameraFPS.SetActive(!true);
        // PlayerCapsule.GetComponent<PlayerInput>().enabled = false;
        PlayerCam.SetActive(true);
        PlayerFollowCameraTPS.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        // 啟用狀態2的組件
        PlayerArmature.GetComponent<PlayerInput>().enabled = true;

    }


}
