using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public TextAsset file;

    protected string nameof;
        
    public float health1, health2;

    protected float moveSpeed, moveForce;

    protected float damage1, damage2;

    protected float fireRate1, fireRate2, nextFire;

    [SerializeField] protected bool facingRight, movingRight;

    public bool isGrounded;

    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckRadius;
    [SerializeField] protected LayerMask whatIsGround;

    protected Rigidbody2D rb2d;
    protected Animator anim;
    public AudioSource sound;
    public AudioClip shoot, hit, death;

    public GameObject projectileRight, projectileLeft;
    protected Vector2 projPos, aim, aimLow;

    public virtual void Start()
    {
        Load(file);
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();

        PlayerPrefs.GetFloat("SliderVolumeLevel", sound.volume);

        Debug.Log(Find_id(nameof).id);

        

        health1 = float.Parse(Find_id(nameof).health1);
        health2 = float.Parse(Find_id(nameof).health2);
        moveSpeed = float.Parse(Find_id(nameof).maxspd);
        damage1 = float.Parse(Find_id(nameof).atk1);
        damage2 = float.Parse(Find_id(nameof).atk2);
        moveForce = float.Parse(Find_id(nameof).accel);
        fireRate1 = float.Parse(Find_id(nameof).atkrate1);
        fireRate2 = float.Parse(Find_id(nameof).atkrate2);

    }

    protected void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    protected void Fire(Vector2 aim)
    {
        
        projPos = transform.position;

        
        if (facingRight)
        {
            projPos += aim;
            Instantiate(projectileRight, projPos, Quaternion.identity);
        }
        else
        {
            projPos += new Vector2(aim.x * -1, aim.y);
            Instantiate(projectileLeft, projPos, Quaternion.identity);
        }
            
        
    }

    

    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// 
    ///  /// CSV SECTION
    /// 
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    
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
