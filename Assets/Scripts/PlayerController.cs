using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Store an instance of a beat object
    [SerializeField]
    private GameObject theBeat;

    // Constants
    private int OFF_BEAT_COMBO;
    private int ON_BEAT_COMBO;

    // Glob variables
    public int score;

    private enum Move
    {
        U = 'U', D = 'D', L = 'L', R = 'R'
    };

    private Dictionary<string, string> combos = new Dictionary<string, string>();
    private string activeCombo = "";

    void Start()
    {
        combos.Add("Twirl", "LRLR");
        combos.Add("Wavedash Right", "RRD");
        combos.Add("Wavedash Left", "LLD");
        combos.Add("Split", "DD");

        // You get 5 points for landing a combo off-beat (subject to changes)
        // You get 10 points for landing a combo on-beat (subject to changes)
        OFF_BEAT_COMBO = 5;
        ON_BEAT_COMBO = 10;

        // Duh, count your current score
        score = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            activeCombo += Move.U;
        }
        if (Input.GetButtonDown("Down"))
        {
            activeCombo += Move.D;
        }
        if (Input.GetButtonDown("Left"))
        {
            activeCombo += Move.L;
        }
        if (Input.GetButtonDown("Right"))
        {
            activeCombo += Move.R;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            ClearCombo();
        }

        CheckForCombo();
    }

    private void CheckForCombo()
    {
        foreach (string combo in combos.Values)
        {
            // If this combo matches the active combo
            if (combo.Equals(activeCombo))
            {
                CompleteCombo(combo); // We made it boys
            }
        }
    }

    private void CompleteCombo(string combo)
    {
        Debug.Log(combo);

        if (theBeat.GetComponent<Beat>().comboTime)
        {
            score += ON_BEAT_COMBO;
        }
        else {
            score += OFF_BEAT_COMBO;
        }

        Debug.Log(score);

        ClearCombo();
    }

    private void ClearCombo()
    {
        activeCombo = "";
    }
}
