using UnityEngine;

public class HintSystem : MonoBehaviour
{
    public Transform player;
    public KeySpawner keySpawner;
    public GameObject arrowUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameState.Instance.TryUseHint())
            {
                ShowDirection();
            }
        }
    }

    void ShowDirection()
    {
        Transform key = keySpawner.GetKeyTransform();
        if (key == null) return;

        Vector2 dir = (key.position - player.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        arrowUI.transform.rotation = Quaternion.Euler(0, 0, angle);

        arrowUI.SetActive(true);
        Invoke(nameof(HideArrow), 2f);
    }

    void HideArrow()
    {
        arrowUI.SetActive(false);
    }
}