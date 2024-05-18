using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class MonitorCamSwitch : MonoBehaviour
{
    GameObject MonitorCam;
    GameObject PlayerArmature;
    GameObject PlayerCapsule;
    GameObject PlayerCam;
    GameObject PlayerFollowCameraFPS;

    GameObject PlayerFollowCameraTPS;

    private int cameraState = 0;

    void Start()
    {
        MonitorCam = GameObject.Find("MonitorCam"); // FreeFlyCam Reference
        PlayerArmature = GameObject.Find("PlayerArmature"); // WhiteMan Reference
        PlayerCapsule = GameObject.Find("PlayerCapsule"); // FreeFly Reference 
        PlayerCam = GameObject.Find("PlayerCam"); // Common Camera Reference
        PlayerFollowCameraFPS = GameObject.Find("PlayerFollowCameraFPS");
        PlayerFollowCameraTPS = GameObject.Find("PlayerFollowCameraTPS");
        CameraStateCallback(0); // Initial state
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
                // 状态 0：启用监视器镜头，停用其他对象
                MonitorCam.SetActive(true);
                PlayerArmature.GetComponent<PlayerInput>().enabled = false;
                PlayerCapsule.GetComponent<PlayerInput>().enabled = false;
                PlayerCam.SetActive(false);
                PlayerFollowCameraFPS.SetActive(false);
                PlayerFollowCameraTPS.SetActive(false);
                break;
            case 1:
                // 状态 1：启用 PlayerCapsule 和 PlayerCam，停用其他对象
                MonitorCam.SetActive(false);
                PlayerArmature.GetComponent<PlayerInput>().enabled = false;
                PlayerCapsule.GetComponent<PlayerInput>().enabled = true;
                PlayerCam.SetActive(true);
                PlayerFollowCameraFPS.SetActive(true);
                PlayerFollowCameraTPS.SetActive(false);
                break;
            case 2:
                // 状态 2：启用 PlayerArmature 和 PlayerCam，停用其他对象
                StartCoroutine(SwitchToState2());
                break;
        }
    }

    IEnumerator SwitchToState2()
    {
        // 先停用状态1的组件
        MonitorCam.SetActive(false);
        // PlayerArmature.GetComponent<ThirdPersonController>().enabled = false;
        // PlayerCapsule.GetComponent<FirstPersonController>().enabled = false;
        PlayerArmature.GetComponent<PlayerInput>().enabled = false;
        PlayerCapsule.GetComponent<PlayerInput>().enabled = false;
        PlayerCam.SetActive(true);
        PlayerFollowCameraFPS.SetActive(false);
        PlayerFollowCameraTPS.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        // 启用状态2的组件
        PlayerArmature.GetComponent<PlayerInput>().enabled = true;

    }


}
