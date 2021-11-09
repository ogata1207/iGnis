using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileMapTest : MonoBehaviour
{

    private Grid g;
    public Tilemap tile;
    public TileBase tb;
    public Sprite[] 燃えるタイル;
    public Sprite[] オイルタイル;
    public Sprite 森;
    public Sprite 水;
    public Sprite 岩;
    public Sprite 小岩;
    public Sprite オイル鉱山;
    public Sprite 火鉱山;

    public TilemapRenderer tileRender;
    public GameObject torch;
    public GameObject oil;
    public GameObject Forest;
    public GameObject Water;
    public GameObject Rock;
    public GameObject SmallRock;
    public GameObject OilMine;
    public GameObject FireMine;
    private Vector3Int CursorPosition = new Vector3Int(0, 0, 0);
    public int 読込み半径X = 100;
    public int 読込み半径Y = 100;
    //かり
    static public int Num = 0;
    static public int FireNum = 0;

    // Use this for initialization
    void Start()
    {
        Num = 0;
        FireNum = 0;

        g = GameObject.Find("Grid").GetComponent<Grid>();


        for (int x = -読込み半径X; x < 読込み半径X; x++)
        {
            for (int y = -読込み半径Y; y < 読込み半径Y; y++)
            {
                for (int i = 0; i < 燃えるタイル.Length; i++)
                {
                    if (tile.GetSprite(new Vector3Int(x, y, 0)) == 燃えるタイル[i])
                    {
                        Num++;
                        GameObject obj = Instantiate(torch, transform);
                        obj.transform.position = new Vector3(x + 1, y + 1, -1);
                        continue;
                    }
                }

                for (int i = 0; i < オイルタイル.Length; i++)
                {
                    if (tile.GetSprite(new Vector3Int(x, y, 0)) == オイルタイル[i])
                    {
                        Num++;
                        GameObject obj = Instantiate(oil, transform);
                        obj.transform.position = new Vector3(x + 1, y + 1, -1);
                        obj.GetComponent<SpriteRenderer>().sortingOrder = -2;
                        continue;
                    }
                }

                if (tile.GetSprite(new Vector3Int(x, y, 0)) == 森)
                {
                    GameObject obj = Instantiate(Forest, transform);
                    obj.transform.position = new Vector3(x + 1.5f, y + 1.5f, 1);
                    continue;
                }
                if (tile.GetSprite(new Vector3Int(x, y, 0)) == 岩)
                {
                    GameObject obj = Instantiate(Rock, transform);
                    obj.transform.position = new Vector3(x + 1.5f, y + 1.5f, 1);
                    continue;
                }

                if (tile.GetSprite(new Vector3Int(x, y, 0)) == 水)
                {
                    GameObject obj = Instantiate(Water, transform);
                    obj.transform.position = new Vector3(x + 1, y + 1, 1);
                    continue;
                }

                if (tile.GetSprite(new Vector3Int(x, y, 0)) == 小岩)
                {
                    GameObject obj = Instantiate(SmallRock, transform);
                    obj.transform.position = new Vector3(x + 1, y + 1, -1);
                    obj.GetComponent<SpriteRenderer>().sortingOrder = -2;
                    continue;
                }

                if (tile.GetSprite(new Vector3Int(x, y, 0)) == オイル鉱山)
                {
                    GameObject obj = Instantiate(OilMine, transform);
                    obj.transform.position = new Vector3(x + 1.5f, y + 1.5f, 1);
                    continue;
                }

                if (tile.GetSprite(new Vector3Int(x, y, 0)) == 火鉱山)
                {
                    GameObject obj = Instantiate(FireMine, transform);
                    obj.transform.position = new Vector3(x + 1.5f, y + 1.5f, 1);
                    continue;
                }

            }
        }


    }

    // Update is called once per frame


    GameObject Ray(Vector2 dir, float dist)
    {

        RaycastHit2D hit;
        Vector3 RayPos = transform.position + new Vector3(dir.x, dir.y, 0);
        hit = Physics2D.Raycast(RayPos, dir, dist);
        Debug.DrawRay(RayPos, dir * dist, Color.blue, .5f);

        if (hit) return hit.collider.gameObject;
        else return null;
        //else return ob;
    }

    //  同じ座標のオブジェクトを取得
    //  自分と同じ座標にあるオブジェクトを取得
    GameObject Ray()
    {
        return Ray(new Vector3(0, 0, 0), 0);
    }


    public void SetTile(TileBase tb, Vector3Int pos)
    {
        tile.SetTile(pos, tb);

    }




}
