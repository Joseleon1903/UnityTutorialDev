using UnityEngine;

public class ItemLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        var item = GetComponent<Item>();
        if (item == null) { return; }

        item.DisplayText();
    }

}
