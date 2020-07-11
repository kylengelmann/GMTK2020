using UnityEngine;

public abstract class LevelObject : MonoBehaviour
{
    public abstract ObjectType GetObjectType();

    protected LevelGrid currentGrid;
    private Vector2Int gridCell;
    public Vector2Int GetGridCell() { return gridCell; }

    protected virtual void Start()
    {
        currentGrid = LevelGrid.Get();
        currentGrid.RegisterLevelObject(this, out gridCell);
    }

    public bool MoveGrid(Direction direction)
    {
        if(!currentGrid.CanMoveDirection(gridCell, direction))
        {
            return false;
        }

        Vector2Int newGridCell = gridCell;
        switch(direction)
        {
            case Direction.North:
                newGridCell = newGridCell + Vector2Int.up;
                break;
            case Direction.South:
                newGridCell = newGridCell + Vector2Int.down;
                break;
            case Direction.East:
                newGridCell = newGridCell + Vector2Int.right;
                break;
            case Direction.West:
                newGridCell = newGridCell + Vector2Int.left;
                break;
        }

        currentGrid.MoveObject(this, newGridCell);
        gridCell = newGridCell;

        return true;
    }
}

public enum ObjectType
{
    None = 0,
    Player = 1,
    Enemy = 2,
    Loot = 3,
}