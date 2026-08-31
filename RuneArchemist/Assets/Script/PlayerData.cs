using UnityEngine;

public class PlayerData : MonoBehaviour
{

    [Header("‘fŞ—p")]
    [SerializeField] MaterialDatabase material;
    public int[] Material_value;//‘fŞ‚ÌŠ”
    public bool[] Material_Get;//ˆê“xè‚É“ü‚ê‚½‚±‚Æ‚ª‚ ‚é‚©”»’è

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Material_value = new int[Material_value.Length];
        Material_Get = new bool[Material_value.Length];

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
