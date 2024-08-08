using UnityEngine;

public class EvenlyDistributeObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDistribute;

    private void Start()
    {
        DistributeObjects();
    }

    private void DistributeObjects()
    {
        RectTransform parentRectTransform = GetComponent<RectTransform>();
        if (parentRectTransform == null || objectsToDistribute.Length == 0)
        {
            Debug.LogWarning("Parent RectTransform or objects to distribute are missing.");
            return;
        }

        Vector2 parentSize = parentRectTransform.rect.size;
        Vector2 cellSize = parentSize / 2f;

        for (int i = 0; i < objectsToDistribute.Length; i++)
        {
            int row = i / 2;
            int col = i % 2;
            Vector2 position = new Vector2(
                parentRectTransform.rect.min.x + (col + 0.5f) * cellSize.x,
                parentRectTransform.rect.min.y + (row + 0.5f) * cellSize.y
            );

            RectTransform objectRectTransform = objectsToDistribute[i].GetComponent<RectTransform>();
            if (objectRectTransform != null)
            {
                objectRectTransform.anchoredPosition = position;
            }
            else
            {
                Debug.LogWarning("No RectTransform found on object: " + objectsToDistribute[i].name);
            }
        }
    }
}
