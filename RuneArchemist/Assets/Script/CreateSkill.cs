using UnityEngine;
using UnityEngine.UI;

public class CreateSkill : MonoBehaviour
{

    [SerializeField]MaterialDatabase materialdatabase;

    public int[] beforestatus = { 0, 0, 0, 0, 0 };
    public int[] afterstatus = { 0, 0, 0, 0, 0, 0 };

    [Header("基本魔法(属1,属2,攻,速)※千の位で属性種類を判別")]
    public Vector4[] basemagic =
        {
        new Vector4(0,0,0,0),

        };

    [Header("5属性の攻撃、速度のバフ情報")]
    public Vector2[] magicparsent =
        {
        new Vector2(1.6f,0.5f),
        new Vector2(0.9f,1.2f),
        new Vector2(0.5f,1.6f),
        new Vector2(1f,1.5f),
        new Vector2(1.6f,0.9f),
        };//0=火 1=水 2=風 3=岩 4=雷

    [Header("UI用")]
    [SerializeField] Text[] beforetexts;
    [SerializeField] Text[] aftertext;
    [SerializeField] GameObject ButtonPrefab;
    [SerializeField] Transform Canvaspos;

    [Space]
    //投入した素材
    public int material=0;
    public int max_material=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int button = 0;//生成したボタンの数
        for (int i = 0; i < PlayerData.Material_value.Length; i++)
        {
            if (PlayerData.Material_value[i] > 0)
            {
                GameObject a = Instantiate(ButtonPrefab,Canvaspos);
                a.transform.localPosition = new Vector3(130+button%4*220, 160-((button-button%4)/4)*280, 0);
                MatterialButtonManager b = a.GetComponent<MatterialButtonManager>();
                b.CreateSkill = gameObject.GetComponent<CreateSkill>();
                b.m_Rank = materialdatabase.materials[i].Rare;
                b.MatterialNo = i;
                b.m_Text.text = materialdatabase.materials[i].Name;
                button++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (beforetexts != null)
        {
            for (int i = 0; i < beforetexts.Length; i++)
            {
                beforetexts[i].text = beforestatus[i].ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            addmaterial(0);
        }
    }

    public void SkillBuild(int[] t, int[]s)
    {

    }
    
    public void addmaterial(int m)
    {
        int[] s = 
            { materialdatabase.materials[m].Fire, materialdatabase.materials[m].Water,
            materialdatabase.materials[m].Wind, materialdatabase.materials[m].Thunder,
            materialdatabase.materials[m].Rock, 
            materialdatabase.materials[m].Attack, materialdatabase.materials[m].Speed,
            materialdatabase.materials[m].MP, };
        for (int i = 0; i < s.Length; i++)
        {
            beforestatus[i] += s[i];
        }
        int[] types = 
            { beforestatus[0], beforestatus[1], beforestatus[2],
            beforestatus[3], beforestatus[4] };
        /*for (int i = 0; i < 100; i++)
        {
            int b = 0;
            if (types[i] < types[i + 1])
            {
                int a = types[i];
                types[i] = types[i + 1];
                types[i + 1] = a;
            }
            if (i < types.Length-1) i = 0;
            for (int j = 0; j < types.Length - 1; j++)
            {
                if (types[j] >= types[j + 1])
                {
                    b++;
                }
            }
            if (b == types.Length - 2)
            {
                Debug.Log("並び替え成功");
                Debug.Log("順番" + types[0] + "→" + types[1] + "→" + types[2] + "→" + types[3] + "→" + types[4]);
                aftertext[0].text = types[0].ToString();
                aftertext[1].text = types[1].ToString();
                break;
            }
        }
        */
        material++;
    }
}
