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

    }
    public void CreateMagic(int[] afterstatus)
    {
        MagicData magic = new MagicData();

        magic.Rank = afterstatus[0];
        magic.Magic1_value = afterstatus[1];
        magic.Magic2_value = afterstatus[2];
        magic.Attack = afterstatus[3];
        magic.Speed = afterstatus[4];
        magic.MP = afterstatus[5];

        PlayerData.MagicList.Add(magic);
    }
}