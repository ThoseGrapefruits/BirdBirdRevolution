using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    private enum Move
    {
        U, D, L, R
    };

    private Dictionary<string, string> combos = new Dictionary<string, string>();
    private LinkedList<Move> activeCombo = new LinkedList<Move>();

    void Start()
    {
        combos.Add("Twirl", "LRLR");
        combos.Add("Wavedash Right", "RRD");
        combos.Add("Wavedash Left", "LLD");
        combos.Add("Split", "DD");
    }

    void Update()
    {
        Debug.Log(Input.GetKey("Up"));
    }
}
