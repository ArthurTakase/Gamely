using UnityEngine;
using UnityEngine.UI;

public class AutoGrid : MonoBehaviour
{
    private int nbColumns;
    private GridLayoutGroup gridLayoutGroup;
    private float defaultCellWidth = 0;
    private float defaultCellHeight = 0;

    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        nbColumns = gridLayoutGroup.constraintCount;
        defaultCellWidth = gridLayoutGroup.cellSize.x;
        defaultCellHeight = gridLayoutGroup.cellSize.y;
        UpdateCellSize();
    }

    public void UpdateCellSize()
    {
        float width = (gridLayoutGroup.transform as RectTransform).rect.width - gridLayoutGroup.padding.left - gridLayoutGroup.padding.right - gridLayoutGroup.spacing.x * (nbColumns - 1);
        float cellWidth = width / nbColumns;
        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellWidth);

        float cellHeight = defaultCellHeight * (cellWidth / defaultCellWidth);
        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }

    public void UpdateCellSize(int nbColumns)
    {
        this.nbColumns = nbColumns;
        UpdateCellSize();
    }
}
