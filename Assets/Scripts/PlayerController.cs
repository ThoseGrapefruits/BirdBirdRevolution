using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Store an instance of a beat object
    [SerializeField]
    private GameObject theBeat;

    // Constants
    private const float POINTS_PER_MOVE = 3f;
    private const float ON_BEAT_MULT = 2f;
    private const int MAX_COMBO_SIZE = 4;

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
        combos.Add("Jump Split", "UUD");
        combos.Add("Flip Right", "UURD");
        combos.Add("Flip Left", "UULD");

        // Duh, count your current score
        score = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            AddMove(Move.U);
        }
        if (Input.GetButtonDown("Down"))
        {
            AddMove(Move.D);
        }
        if (Input.GetButtonDown("Left"))
        {
            AddMove(Move.L);
        }
        if (Input.GetButtonDown("Right"))
        {
            AddMove(Move.R);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            ClearCombo();
        }

        CheckForCombo();
    }

    private void AddMove(Move move)
    {
        activeCombo += move;
        if (!CheckForCombo() && activeCombo.Length >= MAX_COMBO_SIZE)
        {
            ClearCombo();
        }
    }

    private bool CheckForCombo()
    {
        foreach (string combo in combos.Values)
        {
            // If this combo matches the active combo
            if (combo.Equals(activeCombo))
            {
                CompleteCombo(combo); // We made it boys
                return true;
            }
        }
        return false;
    }

    private void CompleteCombo(string combo)
    {
        Debug.Log(combo);
        AddScoreFor(combo);
        ClearCombo();
        Debug.Log(score);
    }

    private void AddScoreFor(string combo)
    {
        float scoreIncr = combo.Length * POINTS_PER_MOVE;
        if(theBeat.GetComponent<Beat>().comboTime)
        {
            scoreIncr *= ON_BEAT_MULT;
        }
        score += (int)scoreIncr;
    }

    private void ClearCombo()
    {
        activeCombo = "";
        Debug.Log("Clearing combo");
    }

    public string GetActiveCombo()
    {
        return activeCombo;
    }
}
