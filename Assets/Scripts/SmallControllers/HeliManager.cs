using System.Collections;
using UnityEngine;

public class HeliManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    public IEnumerator DestroyHelicopter()
    {
        yield return new WaitForSeconds(2f);
        GameObject player = Instantiate(playerSprite, new Vector2(-14.8f, 4.64f), Quaternion.identity);

        GameManager.Instance.PlayerSetCam(player);

        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
