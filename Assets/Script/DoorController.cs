using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject interactUI;

    private bool isPlayerNear = false;

    void Update()
    {
        if (!isPlayerNear) return;

        if (GameState.Instance.HasKey)
        {
            interactUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameState.Instance.TryUseKey())
                {
                    OpenDoor();
                    GameState.Instance.ClearGame();
                }
            }
        }
        else
        {
            interactUI.SetActive(true);
        }
    }

    void OpenDoor()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            interactUI.SetActive(false);
        }
    }
}