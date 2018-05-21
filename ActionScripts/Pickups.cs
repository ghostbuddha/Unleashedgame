using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickups : MonoBehaviour {

    public TextAsset file;
    
    private Animator anim;
    private SpriteRenderer sprite;

    public float amount, cd;
    protected string nameof;


    public virtual void Start () {

        Load(file);

        amount = float.Parse(Find_id(nameof).amount);
        cd = float.Parse(Find_id(nameof).cooldown);

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 


    public class Row
    {
        public string id;
        public string amount;
        public string cooldown;

    }

    List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.id = grid[i][0];
            row.amount = grid[i][1];
            row.cooldown = grid[i][2];

            rowList.Add(row);
        }
        isLoaded = true;
    }

    public int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public Row Find_id(string find)
    {
        return rowList.Find(x => x.id == find);
    }
    public List<Row> FindAll_id(string find)
    {
        return rowList.FindAll(x => x.id == find);
    }
    public Row Find_amount(string find)
    {
        return rowList.Find(x => x.amount == find);
    }
    public List<Row> FindAll_amount(string find)
    {
        return rowList.FindAll(x => x.amount == find);
    }
    public Row Find_cooldown(string find)
    {
        return rowList.Find(x => x.cooldown == find);
    }
    public List<Row> FindAll_cooldown(string find)
    {
        return rowList.FindAll(x => x.cooldown == find);
    }
}
