using UnityEngine;
using System.Collections.Generic;

public class FiltersManager : MonoBehaviour
{
    public GameObject filterParent;
    public Color selectedColor;
    public Color deselectedColor;

    private readonly List<Filter> filters = new();

    void Start()
    {
        foreach (Transform child in filterParent.transform)
        {
            Filter filter = child.GetComponent<Filter>();
            filter.Init(this);
            filters.Add(filter);
        }
    }

    public void DisableAllFilters()
    {
        foreach (Filter filter in filters)
            filter.Disable();
    }
}