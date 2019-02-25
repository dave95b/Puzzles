using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Gallery : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField]
    private Interpolator interpolator;

    [SerializeField]
    private NativeEvent onImageSelected;

    [SerializeField]
    private SpriteList gameSprites;

    [Header("Shared data")]
    public float Offset = 4.5f;

    public GalleryViewHolder ViewHolder;

    [Space, SerializeField]
    private GalleryDataList dataList;

    private GalleryItemView[] items;

    public int Position;
    public int ItemCount => dataList.Count;

    private GalleryAnimator animator;
    private GalleryViewRecycler recycler;


    private void Awake()
    {
        animator = GetComponent<GalleryAnimator>();
        recycler = GetComponent<GalleryViewRecycler>();
        recycler.Initialize();

        InitializeItems();

        onImageSelected.AddListener(SelectImage);
    }

    private void InitializeItems()
    {
        items = GetComponentsInChildren<GalleryItemView>();
        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i];
            item.Image = dataList[i].Image;
            item.Interpolator = interpolator;
            item.transform.localPosition = new Vector3(i * Offset, 0f, 0f);
        }

        ViewHolder.Left = items[2];
        ViewHolder.Current = items[0];
        ViewHolder.Right = items[1];

        ScrollToLastChosenImage();
    }

    private void ScrollToLastChosenImage()
    {
        ViewHolder.Current.Hide();

        for (int i = 0; i < gameSprites.ListIndex; i++)
        {
            Position++;
            recycler.OnScrollLeft();
        }
        transform.GetChild(0).localPosition = GetSlidePosition();

        ViewHolder.Current.Show();
    }

    public Vector3 GetSlidePosition()
    {
        float x = Offset * Position;
        return new Vector3(-x, 0f, 0f);
    }

    private void SlideLeft()
    {
        if (Position < ItemCount - 1)
        {
            Position++;
            recycler.OnScrollLeft();
            animator.SlideLeft();
        }
    }

    private void SlideRight()
    {
        if (Position > 0)
        {
            Position--;
            recycler.OnScrollRight();
            animator.SlideRight();
        }
    }

    public void OnViewRecycled(GalleryItemView view, int position)
    {
        view.Image = dataList[position].Image;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;
        if (delta.x > 0)
            SlideRight();
        else
            SlideLeft();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Bez tego OnBeginDrag nie jest wywoływany
    }


    private void SelectImage()
    {
        gameSprites.List = dataList[Position].Tiles;
        gameSprites.ListIndex = Position;
    }

    private void OnDestroy()
    {
        onImageSelected.RemoveListener(SelectImage);
    }
}
