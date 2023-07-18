using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool playerInstantiated;

    [SerializeField]
    private CinemachineVirtualCamera cinemachineCam;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerSetCam(GameObject Player)
    {
        playerInstantiated = true;

        cinemachineCam.LookAt = Player.transform;
        cinemachineCam.Follow = Player.transform;  
    }
}
