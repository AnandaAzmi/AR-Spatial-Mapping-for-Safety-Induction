using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeMenu : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollRect;
    private float[] pos;
    private bool isDragging = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }

    void Update()
    {
        int itemCount = transform.childCount;
        if (itemCount < 2) return;

        pos = new float[itemCount];
        float distance = 1f / (itemCount - 1f);

        for (int i = 0; i < itemCount; i++)
        {
            pos[i] = 1f - (distance * i); // karena verticalNormalizedPosition: 1 = atas, 0 = bawah
        }

        // Ambil nilai posisi real-time
        float currentPos = scrollRect.verticalNormalizedPosition;

        // SNAP hanya saat tidak drag
        if (!isDragging)
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (currentPos < pos[i] + (distance / 2) && currentPos > pos[i] - (distance / 2))
                {
                    scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, pos[i], 0.1f);
                }
            }
        }

        // Zoom efek item aktif (ikut posisi real-time, bukan scroll_pos lama)
        for (int i = 0; i < itemCount; i++)
        {
            if (currentPos < pos[i] + (distance / 2) && currentPos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);

                for (int a = 0; a < itemCount; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

}
