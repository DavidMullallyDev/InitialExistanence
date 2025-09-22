using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class CameraTargetSetter : MonoBehaviour
{
    private CinemachineCamera vcam;

    void Awake()
    {
        vcam = GetComponent<CinemachineCamera>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            vcam.Follow = player.transform;
            Debug.Log("Camera following: " + player.name);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            vcam.Follow = player.transform;
        }
    }
}

