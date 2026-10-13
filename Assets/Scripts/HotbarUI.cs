using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    public Hotbar hotbar;
    public TMP_Text[] slotTexts = new TMP_Text[5];
    public Image[] slotBackgrounds = new Image[5];

    public Color normalColor = new Color(0.2f, 0.2f, 0.2f, 0.9f);
    public Color selectedColor = new Color(0.85f, 0.75f, 0.35f, 1f);

    private int selectedSlot = 0;

    private void Start()
    {
        Refresh();
        UpdateSelection();
    }

    private void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                selectedSlot = i;
                UpdateSelection();
            }
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < slotTexts.Length; i++)
        {
            HotbarItem item = hotbar.slots[i];

            if (item != null && !string.IsNullOrEmpty(item.itemName))
            {
                slotTexts[i].text = item.itemName + " x" + item.quantity;
            }
            else
            {
                slotTexts[i].text = "Empty";
            }
        }
    }

    private void UpdateSelection()
    {
        for (int i = 0; i < slotBackgrounds.Length; i++)
        {
            slotBackgrounds[i].color =
                (i == selectedSlot) ? selectedColor : normalColor;
        }
    }
}