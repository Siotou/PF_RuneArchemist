using UnityEngine;
using UnityEngine.UI;

public class MatterialButtonManager : MonoBehaviour
{

    public int MatterialNo;//‘fŞ‚Ì“o˜^No

    [SerializeField] public Text m_Text;//‘fŞ–¼
    [SerializeField] public int m_Rank;//‘fŞ‚ÌƒŒƒA“x
    [SerializeField] Sprite[] ButtonSprite;
    [SerializeField] Image ButtonImg;
    [SerializeField] Sprite[] m_sprites;
    [SerializeField]Image m_Img;
    [SerializeField] Text m_valueText;//‘fŞ‚ÌŠ”
    [SerializeField] PlayerData playerData;//ƒvƒŒƒCƒ„[ƒf[ƒ^

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerData = GameObject.FindAnyObjectByType<PlayerData>();
        m_Img.sprite = m_sprites[MatterialNo];
        ButtonImg.sprite = ButtonSprite[m_Rank];
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData != null) m_valueText.text = "~" + playerData.Material_value[MatterialNo];
    }
}
