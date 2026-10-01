using NUnit.Framework;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    [Header("素材用")]
    [SerializeField] MaterialDatabase material;
    static public int[] Material_value;//素材の所持数
    static public bool[] Material_Get;//一度手に入れたことがあるか判定
    public int Material_count;

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
}