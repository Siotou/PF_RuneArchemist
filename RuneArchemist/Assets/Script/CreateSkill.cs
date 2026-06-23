using UnityEngine;
using UnityEngine.UI;

public class CreateSkill : MonoBehaviour
{

    [System.Serializable]
    public struct MaterialData
    {
        public int fire;
        public int water;
        public int wind;
        public int thunder;
        public int rock;

        public int attack;
        public int speed;
        public int mpCost;
    }

    public int[] typestatus = { 0, 0, 0, 0, 0 };
    public int[] status = { 0, 0, 0, 0, 0, 0 };

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
        };//0=火 1=風 2=水 3=雷 4=岩

    [Header("UI用")]
    [SerializeField] Text[] statustexts;

    [Space]
    //投入した素材
    public int material=0;
    public int max_material=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (statustexts != null)
        {
            for (int i = 0; i < statustexts.Length; i++)
            {
                if (i < 5)
                {
                    statustexts[i].text = typestatus[i].ToString();
                }
                else
                {
                    statustexts[i].text = status[i].ToString();
                }
            }
        }
    }

    public void SkillBuild(int[] t, int[]s)
    {

    }
    
    public void addmaterial(int[] s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (i < 5)
            {
                typestatus[i] = s[i];
            }
            else
            {
                status[i - 1] = s[i];
            }
        }
        int[] types = typestatus;
        for (int i = 0; i < 0; i++)
        {
            int b = 0;
            if (types[i] < types[i + 1])
            {
                int a = types[i];
                types[i] = types[i + 1];
                types[i + 1] = a;
            }
            if (i == types.Length) i = 0;
            for (int j = 0; j < types.Length - 1; j++)
            {
                if (types[j] == types[j + 1])
                {
                    b++;
                }
            }
            if (b == types.Length - 1)
            {
                Debug.Log("並び替え成功");
                Debug.Log("順番" + types[0] + "→" + types[1] + "→" + types[2] + "→" + types[3] + "→" + types[4]);
                break;
            }
        }
        material++;
    }
}
