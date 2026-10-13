using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    [Header("素材用")]
    [SerializeField] MaterialDatabase material;
    static public int[] Material_value;//素材の所持数
    static public bool[] Material_Get;//一度手に入れたことがあるか判定
    public int Material_count;


    [SerializeField]private List<MagicData> magicDatas;

    public static List<MagicData> MagicList = new List<MagicData>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Material_value = new int[material.materials.Count];
        Material_Get = new bool[material.materials.Count];
        //デバッグ用
        for (int i = 0; i < Material_count; i++)
        {
            Material_value[i] = 5;
            Material_Get[i] = true;
        }
        for (int i = 0; i < 5; i++)
        {
            Material_value[i] = 0;
            Material_Get[i] = true;
        }
    }

    void Start()
    {

    }
    void Update()
    {
        magicDatas = MagicList;
    }
    static public void CreateMagic(string magicname ,int[] afterstatus,int[] magictypes)
    {
        MagicData magic = new MagicData();

        magic.Name = magicname;
        magic.Rank = afterstatus[0];
        magic.Magic_value[0] = afterstatus[1];
        magic.Magic_value[1] = afterstatus[2];
        magic.Attack = afterstatus[3];
        magic.Speed = afterstatus[4];
        magic.MP = afterstatus[5];
        for (int i = 0; i < magictypes.Length; i++)
        {
            if (magic.Magic_value[i] > 0)
                magic.Magic[i] = magictypes[i]+1;
            else
                magic.Magic[i] = 0;
        }

        PlayerData.MagicList.Add(magic);
    }
}