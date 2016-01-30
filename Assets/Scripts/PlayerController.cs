using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    private enum Move
    {
        U = 'U', D = 'D', L = 'L', R = 'R'
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
        if (Input.GetButtonDown("Up"))
        {
            activeCombo.AddLast(Move.U);
        }
        if (Input.GetButtonDown("Down"))
        {
            activeCombo.AddLast(Move.D);
        }
        if (Input.GetButtonDown("Left"))
        {
            activeCombo.AddLast(Move.L);
        }
        if (Input.GetButtonDown("Right"))
        {
            activeCombo.AddLast(Move.R);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            ClearCombo();
        }

        CheckForCombo();
    }

    private LinkedList<Move> ComboStringToList(string combo)
    {
        LinkedList<Move> toReturn = new LinkedList<Move>();
        foreach (char c in combo.ToCharArray())
        {
            toReturn.AddLast((Move)c); // Get move corresponding to the character c
        }
        return toReturn;
    }

    private string ComboListToString(LinkedList<Move> combo)
    {
        string s = "";
        foreach (Move move in combo)
        {
            s += (char)move;
        }
        return s;
    }

    private void CheckForCombo()
    {
        foreach (string combo in combos.Values)
        {
            // If this combo matches the active combo
            if (combo.Length == activeCombo.Count && combo.Equals(ComboListToString(activeCombo)))
            {
                CompleteCombo(combo); // We made it boys
            }
        }
    }

    private void CompleteCombo(string combo)
    {
        Debug.Log(combo);
        ClearCombo();
    }

    private void ClearCombo()
    {
        activeCombo.Clear();
    }
}
