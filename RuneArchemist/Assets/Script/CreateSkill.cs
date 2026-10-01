using UnityEngine;
using UnityEngine.UI;

public class CreateSkill : MonoBehaviour
{

    [SerializeField]MaterialDatabase materialdatabase;

    public int[] beforestatus = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] afterstatus = { 0, 0, 0, 0, 0, 0 };
    public string[] magictypes = { "", "" };



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
    [SerializeField] Text[] beforetexts;//生成前のステータスText
    [SerializeField] Text[] aftertext;//生成後のステータスText
    [SerializeField] Text RankText;
    [SerializeField] GameObject[] Buttons;
    [SerializeField] GameObject ButtonPrefab;
    [SerializeField] Transform Canvaspos;
    [SerializeField] Transform Itempos;
    [SerializeField] bool SCROLL = false;
    [SerializeField] int scrolly = 0;
    [SerializeField] GameObject SliderObj_item;
    [SerializeField] Slider ItemSlider;//アイテム欄のスクロール用
    [SerializeField] int button = 0;//生成したボタンの数
    [SerializeField] Text MaxText;
    [SerializeField] Image MaxImg;
    [SerializeField] public int maxt_a = 0;
    [SerializeField] public int maxt_wait = 0;
    [SerializeField] Image[] InputImg;


    [Space]
    //投入した素材
    public int material_value = 0;
    public int[] material = { 0,0,0,0,0,0,0,0,0,0};
    public int max_material=0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        max_material = 5;
        material = new int[max_material];
        Buttons = new GameObject[PlayerData.Material_value.Length];
        CreateButton(0);
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
        if (MaxText != null)
        {
            MaxText.color = new Color(1,0,0,maxt_a/50f) ;
            MaxImg.color = new Color(0.5f, 0.5f, 0.5f, maxt_a / 50f);
        }

        if (maxt_wait != 0)
            maxt_wait--;
        else if (maxt_a != 0)
            maxt_a--;

        if (SCROLL)
        {
            Itempos.localPosition = new Vector3(0, ItemSlider.value * scrolly, 0);
            float wheel = Input.mouseScrollDelta.y;
            if (wheel > 0)
                ItemSlider.value -= (float)30 / scrolly;
            else if (wheel < 0)
                ItemSlider.value += (float)30 / scrolly;

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CreateButton(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            CreateButton(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            CreateButton(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            CreateButton(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            CreateButton(4);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            CreateButton(5);
    }

    public void SkillBuild(int[] t, int[]s)
    {

    }
    // a=並び替え方法
    // 偶数=昇順、奇数=降順
    public void CreateButton(int a)
    {
        // 既存ボタン削除
        for (int i = 0; i < button; i++)
        {
            Destroy(Buttons[i]);
        }

        button = 0;
        ItemSlider.value = 0f;

        // 昇順・降順
        bool descending = a % 2 != 0;

        // 表示順
        int start;
        int end;
        int step;

        if (descending)
        {
            start = PlayerData.Material_Get.Length - 1;
            end = -1;
            step = -1;
        }
        else
        {
            start = 0;
            end = PlayerData.Material_Get.Length;
            step = 1;
        }

        // レア度以外
        if (a >= 2)
        {
            int[] m = new int[materialdatabase.materials.Count];

            // 素材番号を入れる
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = i;
            }

            // 攻撃力 or 速度で並び替え
            for (int i = 0; i < m.Length - 1; i++)
            {
                for (int j = 0; j < m.Length - 1 - i; j++)
                {
                    bool swap = false;

                    if (a < 4)
                    {
                        swap = materialdatabase.materials[m[j]].Attack <
                               materialdatabase.materials[m[j + 1]].Attack;
                    }
                    else
                    {
                        swap = materialdatabase.materials[m[j]].Speed <
                               materialdatabase.materials[m[j + 1]].Speed;
                    }

                    if (swap)
                    {
                        int temp = m[j];
                        m[j] = m[j + 1];
                        m[j + 1] = temp;
                    }
                }
            }

            // 所持している素材
            for (int i = start; i != end; i += step)
            {
                int materialNo = m[i];

                if (PlayerData.Material_value[materialNo] > 0)
                {
                    CreateMaterialButton(materialNo);
                }
            }

            // 0個だが取得済みの素材
            for (int i = start; i != end; i += step)
            {
                int materialNo = m[i];

                if (PlayerData.Material_value[materialNo] == 0 &&
                    PlayerData.Material_Get[materialNo])
                {
                    CreateMaterialButton(materialNo);
                }
            }
        }
        else
        {
            // 所持している素材
            for (int i = start; i != end; i += step)
            {
                if (PlayerData.Material_value[i] > 0)
                {
                    CreateMaterialButton(i);
                }
            }

            // 0個だが取得済みの素材
            for (int i = start; i != end; i += step)
            {
                if (PlayerData.Material_value[i] == 0 &&
                    PlayerData.Material_Get[i])
                {
                    CreateMaterialButton(i);
                }
            }
        }
        if (button > 12)
        {
            SliderObj_item.SetActive(true);
            SCROLL = true;
            scrolly = -220 + (button - (button - 1) % 6) / 6 * 170;
        }
        else
        {
            SliderObj_item.SetActive(false);
            SCROLL = false;
        }
    }


    private void CreateMaterialButton(int materialNo)
    {
        Buttons[button] = Instantiate(ButtonPrefab, Itempos);

        Buttons[button].transform.localPosition =
            new Vector3(
                -375 + button % 6 * 145,
                115 - ((button - button % 6) / 6) * 170,
                0
            );

        MatterialButtonManager c =
            Buttons[button].GetComponent<MatterialButtonManager>();

        c.CreateSkill = gameObject.GetComponent<CreateSkill>();
        c.m_Rank = materialdatabase.materials[materialNo].Rare;
        c.MatterialNo = materialNo;
        c.m_Text.text = materialdatabase.materials[materialNo].Name;

        button++;
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
        string[] type = { "火","水","風","雷","岩",};
        for (int i = 0; i < types.Length - 1; i++)
        {
            for (int j = 0; j < types.Length - 1 - i; j++)
            {
                if (types[j] < types[j + 1])
                {
                    int temp = types[j];
                    string ii = type[j];
                    types[j] = types[j + 1];
                    types[j + 1] = temp;
                    type[j] = type[j + 1];
                    type[j + 1] = ii;
                }
            }
        }
        Debug.Log("1." + type[0] + ":" + types[0] +
            "→2." + type[1] + ":" + types[1] +
            "→3." + type[2] + ":" + types[2] +
            "→4." + type[3] + ":" + types[3] +
            "→5." + type[4] + ":" + types[4]);
        afterstatus[1] = types[0];
        afterstatus[2] = types[1];
        magictypes[0] = type[0];
        magictypes[1] = type[1];

        int a = afterstatus[1] + afterstatus[2] + beforestatus[5] + beforestatus[6];

        afterstatus[0] = (a - a % 500) / 500;

        Debug.Log("Rank:" + afterstatus[0]);

        if (afterstatus[0] > 5) afterstatus[0] = 5;
        if (afterstatus[0] == 0)
        {
            RankText.text = "E";
            RankText.color = Color.gray;
        }
        else if (afterstatus[0] == 1)
        {
            RankText.text = "D";
            RankText.color = new Color(0, 180f / 255f, 255f / 255f);
        }
        else if (afterstatus[0] == 2)
        {
            RankText.text = "C";
            RankText.color = Color.green;
        }
        else if (afterstatus[0] == 3)
        {
            RankText.text = "B";
            RankText.color = new Color(255f / 255f, 71f / 255f, 0);
        }
        else if (afterstatus[0] == 4)
        {
            RankText.text = "A";
            RankText.color = new Color(255f / 255f, 171f / 255f, 0);
        }
        else if (afterstatus[0] == 5)
        {
            RankText.text = "S";
            RankText.color = Color.yellow;
        }

        aftertext[0].text = afterstatus[1].ToString();
        aftertext[1].text = afterstatus[2].ToString();
        aftertext[2].text = beforestatus[5].ToString();
        aftertext[3].text = beforestatus[6].ToString();
        aftertext[4].text = afterstatus[5].ToString();
    }
}
