using UnityEngine;

public class LevelGrid : Singleton<LevelGrid>
{
    [SerializeField] private Vector2Int size;
    public Vector2Int GetSize() {return size;}
    
    private ObjectType[,] gridData;

    private bool[,] horizontalWallData;
    private bool[,] verticalWallData;

    private Vector2Int doorPosition;

    public const float cellSize = 1f;

    protected override void Awake()
    {
        base.Awake();

        // Initialize grid data
        gridData = new ObjectType[size.x, size.y];
        for(int gridX = 0; gridX < size.x; gridX++)
        {
            for(int gridY = 0; gridY < size.y; gridY++)
            {
                gridData[gridX, gridY] = ObjectType.None;
            }
        }

        // Initialize wall data
        horizontalWallData = new bool[size.x - 1, size.y - 1];
        for(int wallX = 0; wallX < size.x - 1; wallX++)
        {
            for (int wallY = 0; wallY < size.y - 1; wallY++)
            {
                horizontalWallData[wallX, wallY] = false;
            }
        }

        verticalWallData = new bool[size.x - 1, size.y - 1];
        for (int wallX = 0; wallX < size.x - 1; wallX++)
        {
            for (int wallY = 0; wallY < size.y - 1; wallY++)
            {
                verticalWallData[wallX, wallY] = false;
            }
        }
    }

    public bool IsValidGridPosition(in Vector2Int gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.x < size.x && gridPosition.y >= 0 && gridPosition.y < size.y;
    }

    public bool CanMoveDirection(in Vector2Int position, Direction direction)
    {
        Vector2Int wallPosition = new Vector2Int(-1, -1);
        Vector2Int newPosition = new Vector2Int(-1, -1);
        switch(direction)
        {
            case Direction.North:
                wallPosition = position;
                if (IsValidWallPosition(wallPosition) && horizontalWallData[wallPosition.x, wallPosition.y]) return false;
                newPosition = position + Vector2Int.up;
                break;
            case Direction.South:
                wallPosition = position + Vector2Int.down;
                if (IsValidWallPosition(wallPosition) && horizontalWallData[wallPosition.x, wallPosition.y]) return false;
                newPosition = wallPosition;
                break;
            case Direction.East:
                wallPosition = position;
                if (IsValidWallPosition(wallPosition) && verticalWallData[wallPosition.x, wallPosition.y]) return false;
                newPosition = position + Vector2Int.right;
                break;
            case Direction.West:
                wallPosition = position + Vector2Int.left;
                if (IsValidWallPosition(wallPosition) && verticalWallData[wallPosition.x, wallPosition.y]) return false;
                newPosition = wallPosition;
                break;
        }

        if(newPosition == doorPosition) return true;

        return IsValidGridPosition(newPosition) && gridData[newPosition.x, newPosition.y] == ObjectType.None;
        
    }

    public void MoveObject(LevelObject levelObject, in Vector2Int newPosition)
    {
        Vector2Int currentPosition = levelObject.GetGridCell();
        if(!IsValidGridPosition(currentPosition))
        {
            return;
        }

        ObjectType movingType = gridData[currentPosition.x, currentPosition.y];
        if (movingType != levelObject.GetObjectType())
        {
            Debug.LogError("Tried to move " + levelObject.name + " of type " + levelObject.GetObjectType().ToString() + 
                " from cell " + currentPosition.ToString() + " which is occupied by a(n) " + gridData[newPosition.x, newPosition.y].ToString());

            return;
        }
        else
        {
            if(newPosition == doorPosition)
            {
                levelObject.transform.position = GridToWorldLocation(newPosition, levelObject.transform.position.z);
                LevelManager.Get().OnPlayerMoveToDoor();
            }

            if (!IsValidGridPosition(newPosition))
            {
                return;
            }

            if (gridData[newPosition.x, newPosition.y] == ObjectType.None)
            {
                gridData[currentPosition.x, currentPosition.y] = ObjectType.None;
                gridData[newPosition.x, newPosition.y] = movingType;

                levelObject.transform.position = GridToWorldLocation(newPosition, levelObject.transform.position.z);
            }
            else
            {
                Debug.LogError("Tried to move " + levelObject.name + " from cell " + currentPosition.ToString() + " to cell " + newPosition.ToString() +
                    " which is occupied by a(n) " + gridData[newPosition.x, newPosition.y].ToString());
            }
        }
    }

    public void RegisterLevelObject(LevelObject levelObject, out Vector2Int gridPosition)
    {
        gridPosition = WorldToGridLocation(new Vector2(levelObject.transform.position.x, levelObject.transform.position.y));

        if(IsValidGridPosition(gridPosition))
        {
            if(gridData[gridPosition.x, gridPosition.y] == ObjectType.None)
            {
                gridData[gridPosition.x, gridPosition.y] = levelObject.GetObjectType();
            }
            else
            {
                Debug.LogError("Tried to register " + levelObject.name + " to cell " + gridPosition.ToString() + 
                    " which is occupied by a(n) " + gridData[gridPosition.x, gridPosition.y].ToString());
            }
        }
    }

    public void RegisterWall(Wall wall)
    {
        int wallX = Mathf.RoundToInt((wall.transform.position.x - transform.position.x)/cellSize);
        int wallY = Mathf.RoundToInt((wall.transform.position.y - transform.position.y)/cellSize);

        float wallDotX = Vector2.Dot(wall.transform.up, Vector2.right);
        float wallDotY = Vector2.Dot(wall.transform.up, Vector2.up);
        Direction direction;

        if(wallDotX > .707f)
        {
            direction = Direction.East;
        }
        else if(wallDotX < -.707f)
        {
            direction = Direction.West;
        }
        else if (wallDotY > .707f)
        {
            direction = Direction.North;
        }
        else
        {
            direction = Direction.South;
        }

        int size = Mathf.RoundToInt(wall.transform.lossyScale.y);

        if(direction == Direction.East || direction == Direction.West)
        {
            --wallY;
            int minX = direction == Direction.West ? wallX - size : wallX;
            int maxX = direction == Direction.West ? wallX : wallX + size;

            if(IsValidWallPosition(new Vector2Int(minX, wallY)) && IsValidWallPosition(new Vector2Int(maxX, wallY)))
            {
                for (int x = minX; x < maxX; x++)
                {
                    horizontalWallData[x, wallY] = true;
                }
            }
        }
        else
        {
            --wallX;
            int minY = direction == Direction.South ? wallY - size : wallY;
            int maxY = direction == Direction.South ? wallY : wallY + size;

            if (IsValidWallPosition(new Vector2Int(wallX, minY)) && IsValidWallPosition(new Vector2Int(wallX, maxY)))
            {
                for (int y = minY; y < maxY; y++)
                {
                    verticalWallData[wallX, y] = true;
                }
            }
        }
    }

    public void RegisterDoor(Door door)
    {
        doorPosition = WorldToGridLocation(new Vector2(door.transform.position.x, door.transform.position.y));
    }

    bool IsValidWallPosition(in Vector2Int position)
    {
        return position.x >= 0 && position.x < size.x - 1 && position.y >= 0 && position.y < size.y - 1;
    }

    public Vector2Int WorldToGridLocation(in Vector2 worldLocation)
    {
        int x = Mathf.RoundToInt((worldLocation.x - transform.position.x)/cellSize);
        int y = Mathf.RoundToInt((worldLocation.y - transform.position.y) / cellSize);
        return new Vector2Int(x, y);
    }

    public Vector3 GridToWorldLocation(in Vector2Int gridLocation, float z = 0f)
    {
        float x = gridLocation.x * cellSize + transform.position.x;
        float y = gridLocation.y * cellSize + transform.position.y;
        return new Vector3(x, y, z);
    }
}

public enum Direction
{
    North = 0,
    South = 1,
    East = 2,
    West = 3
}