using UnityEngine;
using System.Collections;

public class GalleryViewRecycler : MonoBehaviour
{
    private Gallery gallery;
    private GalleryViewHolder viewHolder;

    private bool ShouldRecycleLeft => gallery.Position > 1 && gallery.Position < gallery.ItemCount - 1;
    private bool ShouldRecycleRight => gallery.Position > 0 && gallery.Position < gallery.ItemCount - 2;

    private Vector3 shiftOffset;


    public void Initialize()
    {
        gallery = GetComponent<Gallery>();
        viewHolder = gallery.ViewHolder;
        shiftOffset = new Vector3(3f * gallery.Offset, 0f, 0f);
    }


    public void OnScrollLeft()
    {
        ShiftLeft();
        if (!ShouldRecycleLeft)
            return;

        viewHolder.Right.transform.position += shiftOffset;

        int recycledPosition = gallery.Position + 1;
        if (recycledPosition < gallery.ItemCount)
            gallery.OnViewRecycled(viewHolder.Right, recycledPosition);
    }

    public void OnScrollRight()
    {
        ShiftRight();
        if (!ShouldRecycleRight)
            return;

        viewHolder.Left.transform.position -= shiftOffset;

        int recycledPosition = gallery.Position - 1;
        if (recycledPosition >= 0)
            gallery.OnViewRecycled(viewHolder.Left, recycledPosition);
    }


    private void ShiftLeft()
    {
        var temp = viewHolder.Left;
        viewHolder.Left = viewHolder.Current;
        viewHolder.Current = viewHolder.Right;
        viewHolder.Right = temp;
    }

    private void ShiftRight()
    {
        var temp = viewHolder.Right;
        viewHolder.Right = viewHolder.Current;
        viewHolder.Current = viewHolder.Left;
        viewHolder.Left = temp;
    }
}
