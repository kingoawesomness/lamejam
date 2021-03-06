using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{
    Left = 0,
    TopLeft = 1,
    TopRight = 2,
    Right = 3,
    BottomRight = 4,
    BottomLeft = 5
}

public enum TileType
{
    NormalTile,
    None,
    WallTile,
    AcidTile
}

[System.Serializable]
public struct TileInfo
{
    public TileType type;
    public int x;
    public int y;
    public string specialInfo;
}

public enum EnemyType
{
    None,
    Exploder
}

[System.Serializable]
public struct EnemyInfo
{
    public EnemyType type;
    public int x;
    public int y;
    public Direction facingDirection;
}

public enum WeaponType
{
    GrenadeLauncher,
    PaintGun
}

[System.Serializable]
public struct AllyInfo
{
    public WeaponType[] weaponTypes;
    public int[] ammoAmt;
    public int movementPoints;
    public int x;
    public int y;
    public Direction facingDirection;
}

[System.Serializable]
public struct CameraInfo{
    public Vector3 location;
    public Vector3 rotation;
}

public class Level : MonoBehaviour
{
    public CameraInfo cameraInfo;

    public TileInfo[] tiles;
    public EnemyInfo[] enemies;
    public AllyInfo[] allies;

    private LevelBuilder LevelBuilder = null;

    public int tileShift;

    public void buildLevel()
    {
        if(LevelBuilder != null) { return; }
        LevelBuilder = (LevelBuilder)((new GameObject()).AddComponent<LevelBuilder>());
        LevelBuilder.name = "Level Builder";
        LevelBuilder.transform.parent = this.transform;
        LevelBuilder.setTileShift(tileShift);
        LevelBuilder.SetLevel(this);
        LevelBuilder.buildLevel();
    }

    void OnDestroy(){
        Destroy(this.gameObject);
    }

    public Tile[][] GetTiles(){
        if(LevelBuilder == null) { return null; }
        return LevelBuilder.GetTiles();
    }

    public Enemy[] GetEnemies(){
        if (LevelBuilder == null) { return null; }
        return LevelBuilder.GetEnemies();
    }

    public Player[] GetPlayers(){
        print("levelbuilder");
        print(LevelBuilder);
        if (LevelBuilder == null) { return null; }
        return LevelBuilder.GetPlayers();
    }

    // Start is called before the first frame update
    void Start()
    {
        buildLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
