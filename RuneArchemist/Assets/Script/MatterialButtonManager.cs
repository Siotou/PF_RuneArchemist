using UnityEngine;
using UnityEngine.UI;

public class MatterialButtonManager : MonoBehaviour
{

    public CreateSkill CreateSkill;
    public int MatterialNo;//素材の登録No

    [SerializeField] public Text m_Text;//素材名
    [SerializeField] public int m_Rank;//素材のレア度
    [SerializeField] Button m_Button;
    [SerializeField] Sprite[] ButtonSprite;
    [SerializeField] Image ButtonImg;
    [SerializeField] Sprite[] m_sprites;
    [SerializeField]Image m_Img;
    [SerializeField] Text m_valueText;//素材の所持数

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Img.sprite = m_sprites[MatterialNo];
        ButtonImg.sprite = ButtonSprite[m_Rank];
        if (PlayerData.Material_value[MatterialNo] == 0)
        {
            ButtonImg.color = Color.gray;
            m_Img.color = Color.gray;
            // 既存の登録をすべてクリアする場合（必要に応じて）
            m_Button.onClick.RemoveAllListeners();
        }
        else
        {
            ButtonImg.color = Color.white;
            m_Img.color = Color.white;
            // 既存の登録をすべてクリアする場合（必要に応じて）
            m_Button.onClick.RemoveAllListeners();
            // クリック時に実行したいメソッドを登録
            m_Button.onClick.AddListener(addmaterial);
        }
    }

    // Update is called once per frame
    void Update()
    {

        m_valueText.text = "×" + PlayerData.Material_value[MatterialNo];
    }

    public void addmaterial()
    {
        CreateSkill.addmaterial(MatterialNo);

        PlayerData.Material_value[MatterialNo]--;
        if (PlayerData.Material_value[MatterialNo]<=0)
            PlayerData.Material_value[MatterialNo] = 0;

        //所持数でボタンの状態を変化
        if (PlayerData.Material_value[MatterialNo] == 0)
        {
            ButtonImg.color = Color.gray;
            m_Img.color = Color.gray;
            // 既存の登録をすべてクリアする場合（必要に応じて）
            m_Button.onClick.RemoveAllListeners();
        }
        else
        {
            ButtonImg.color = Color.white;
            m_Img.color = Color.white;
            // 既存の登録をすべてクリアする場合（必要に応じて）
            m_Button.onClick.RemoveAllListeners();
            // クリック時に実行したいメソッドを登録
            m_Button.onClick.AddListener(addmaterial);
        }
    }

}
