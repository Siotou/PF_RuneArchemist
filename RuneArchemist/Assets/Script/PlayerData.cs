using UnityEngine;

public class PlayerData : MonoBehaviour
{

    [Header("素材用")]
    [SerializeField] MaterialDatabase material;
    static public int[] Material_value;//素材の所持数
    static public bool[] Material_Get;//一度手に入れたことがあるか判定

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Material_value = new int[material.materials.Count];
        Material_Get = new bool[material.materials.Count];
        //デバッグ用
        Material_value[0] = 3;
        Material_Get[0] = true;
        Material_value[1] = 3;
        Material_Get[1] = true;
        Material_value[7] = 3;
        Material_Get[7] = true;
        Material_value[17] = 3;
        Material_Get[17] = true;
        Material_value[24] = 3;
        Material_Get[24] = true;
        Material_value[32] = 3;
        Material_Get[32] = true;
        //----------

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}