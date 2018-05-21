using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamagePlayer : MonoBehaviour {
 
    public int damageToGive;
    public TextAsset file;

    void Start()
    {
        Load(file);


    }

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<PlayerHealth>().CurrentHealth -= damageToGive;
    }
    public class Row
    {
        public string id;
        public string health1;
        public string health2;
        public string maxspd;
        public string accel;
        public string jumpheight;
        public string jumpforce;
        public string atk1;
        public string atk2;
        public string atkrate1;
        public string atkrate2;
        public string numlives;
        public string playerno;
        public string mobno;
        public string addno;
        public string bossno;

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
            row.health1 = grid[i][1];
            row.health2 = grid[i][2];
            row.maxspd = grid[i][3];
            row.accel = grid[i][4];
            row.jumpheight = grid[i][5];
            row.jumpforce = grid[i][6];
            row.atk1 = grid[i][7];
            row.atk2 = grid[i][8];
            row.atkrate1 = grid[i][9];
            row.atkrate2 = grid[i][10];
            row.numlives = grid[i][11];
            row.playerno = grid[i][12];
            row.mobno = grid[i][13];
            row.addno = grid[i][14];
            row.bossno = grid[i][15];

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
    public Row Find_health1(string find)
    {
        return rowList.Find(x => x.health1 == find);
    }
    public List<Row> FindAll_health1(string find)
    {
        return rowList.FindAll(x => x.health1 == find);
    }
    public Row Find_health2(string find)
    {
        return rowList.Find(x => x.health2 == find);
    }
    public List<Row> FindAll_health2(string find)
    {
        return rowList.FindAll(x => x.health2 == find);
    }
    public Row Find_maxspd(string find)
    {
        return rowList.Find(x => x.maxspd == find);
    }
    public List<Row> FindAll_maxspd(string find)
    {
        return rowList.FindAll(x => x.maxspd == find);
    }
    public Row Find_accel(string find)
    {
        return rowList.Find(x => x.accel == find);
    }
    public List<Row> FindAll_accel(string find)
    {
        return rowList.FindAll(x => x.accel == find);
    }
    public Row Find_jumpheight(string find)
    {
        return rowList.Find(x => x.jumpheight == find);
    }
    public List<Row> FindAll_jumpheight(string find)
    {
        return rowList.FindAll(x => x.jumpheight == find);
    }
    public Row Find_jumpforce(string find)
    {
        return rowList.Find(x => x.jumpforce == find);
    }
    public List<Row> FindAll_jumpforce(string find)
    {
        return rowList.FindAll(x => x.jumpforce == find);
    }
    public Row Find_atk1(string find)
    {
        return rowList.Find(x => x.atk1 == find);
    }
    public List<Row> FindAll_atk1(string find)
    {
        return rowList.FindAll(x => x.atk1 == find);
    }
    public Row Find_atk2(string find)
    {
        return rowList.Find(x => x.atk2 == find);
    }
    public List<Row> FindAll_atk2(string find)
    {
        return rowList.FindAll(x => x.atk2 == find);
    }
    public Row Find_atkrate1(string find)
    {
        return rowList.Find(x => x.atkrate1 == find);
    }
    public List<Row> FindAll_atkrate1(string find)
    {
        return rowList.FindAll(x => x.atkrate1 == find);
    }
    public Row Find_atkrate2(string find)
    {
        return rowList.Find(x => x.atkrate2 == find);
    }
    public List<Row> FindAll_atkrate2(string find)
    {
        return rowList.FindAll(x => x.atkrate2 == find);
    }
    public Row Find_numlives(string find)
    {
        return rowList.Find(x => x.numlives == find);
    }
    public List<Row> FindAll_numlives(string find)
    {
        return rowList.FindAll(x => x.numlives == find);
    }
    public Row Find_playerno(string find)
    {
        return rowList.Find(x => x.playerno == find);
    }
    public List<Row> FindAll_playerno(string find)
    {
        return rowList.FindAll(x => x.playerno == find);
    }
    public Row Find_mobno(string find)
    {
        return rowList.Find(x => x.mobno == find);
    }
    public List<Row> FindAll_mobno(string find)
    {
        return rowList.FindAll(x => x.mobno == find);
    }
    public Row Find_addno(string find)
    {
        return rowList.Find(x => x.addno == find);
    }
    public List<Row> FindAll_addno(string find)
    {
        return rowList.FindAll(x => x.addno == find);
    }
    public Row Find_bossno(string find)
    {
        return rowList.Find(x => x.bossno == find);
    }
    public List<Row> FindAll_bossno(string find)
    {
        return rowList.FindAll(x => x.bossno == find);
    }
}
	
