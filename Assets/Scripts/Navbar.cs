using System.Collections.Generic;
using UnityEngine;

public class Navbar : MonoBehaviour
{
    [SerializeField] private List<NavItem> navItems = new();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<NavItem>(out var item))
                navItems.Add(item);
        }
    }

    public void ActivateAll()
    {
        foreach (NavItem item in navItems)
            item.Deactivate();
    }

    public void DeactivateAll()
    {
        foreach (NavItem item in navItems)
            item.Deactivate();
    }
}
