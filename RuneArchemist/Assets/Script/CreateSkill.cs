using UnityEngine;

public class CreateSkill : MonoBehaviour
{
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
        
    }

    public void SkillBuild(int[] t, int[]s)
    {

    }

}
