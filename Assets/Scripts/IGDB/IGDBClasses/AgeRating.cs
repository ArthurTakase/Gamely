using UnityEngine;

public enum category
{
    ESRB = 1,
    PEGI = 2,
    CERO = 3,
    USK = 4,
    GRAC = 5,
    CLASS_IND = 6,
    ACB = 7,
}

public class AgeRating
{
    public category category { get; set; }
    public string checksum { get; set; }
}