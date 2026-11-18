using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;
    public int towerCost = 100;

    private GameObject ghost;
    private bool isPlacing;

    void Update()
    {
        if (!isPlacing || ghost == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        ghost.transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            if (IsValidPosition(mousePos) && GameManager.Instance != null && GameManager.Instance.SpendMoney(towerCost))
            {
                Instantiate(towerPrefab, mousePos, Quaternion.identity);
                CancelPlacement();
            }
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
            CancelPlacement();
    }

    public void StartPlacement()
    {
        if (isPlacing) CancelPlacement();

        if (towerPrefab == null) return;

        isPlacing = true;
        ghost = Instantiate(towerPrefab, Vector3.zero, Quaternion.identity);

        // Make ghost semi-transparent and disable logic
        SpriteRenderer sr = ghost.GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            c.a = 0.5f;
            sr.color = c;
        }

        Tower tower = ghost.GetComponent<Tower>();
        if (tower != null) tower.enabled = false;

        Collider2D col = ghost.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
    }

    void CancelPlacement()
    {
        isPlacing = false;
        if (ghost != null)
            Destroy(ghost);
        ghost = null;
    }

    bool IsValidPosition(Vector3 pos)
    {
        // Simple check: nothing else nearby
        Collider2D hit = Physics2D.OverlapCircle(pos, 0.4f);
        return hit == null;
    }
}
