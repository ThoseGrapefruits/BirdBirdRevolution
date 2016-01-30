using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Store an instance of a beat object
    [SerializeField]
    private GameObject theBeat;

    [SerializeField]
    private GameObject flyText;

    [SerializeField]
    private GameObject ladyBirdComp;
    private LadyBirdController ladyBird;

    // Constants
    private const int POINTS_PER_COMBO = 9;
    private const int COMBO_SIZE = 3;

    // Glob variables
    public static int score;

    public enum Move
    {
        U = 'U', D = 'D', L = 'L', R = 'R'
    };

    private enum ComboState
    {
        sat, unsat, failed
    };

    public SortedDictionary<string, string> combos = new SortedDictionary<string, string>();
    private string activeCombo = "";

    void Start()
    {
        combos.Add("Twirl", "LRL");
        combos.Add("Wavedash Right", "RRD");
        combos.Add("Wavedash Left", "LLD");
        combos.Add("Split", "DDD");
        combos.Add("Jump Split", "UUD");
        combos.Add("Flip Right", "URD");
        combos.Add("Flip Left", "ULD");

        // Duh, count your current score
        score = 0;

        ladyBird = ladyBirdComp.GetComponent<LadyBirdController>();
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
    }

    private void AddMove(Move move)
    {
        activeCombo += move;
        if (activeCombo.Length >= COMBO_SIZE)
        {
            CompleteCombo(activeCombo);
        }
    }

    private bool ValidCombo()
    {
        foreach (string combo in combos.Values)
        {
            // If this combo matches the active combo
            if (combo.Equals(activeCombo))
            {
                return true; // We made it boys
            }
        }
        return false;
    }

    private void CompleteCombo(string combo)
    {
        bool realCombo = ValidCombo();
        bool ladyHappy = ladyBird.CompleteCombo(combo);
        bool onBeat = theBeat.GetComponent<Beat>().comboTime;
        if (realCombo && ladyHappy && onBeat)
        {
            AddScoreFor(combo);
            InstantiateComboText(true, combo); // Make combo text
        }
        else
        {
            SubScoreFor(combo);
            InstantiateComboText(false, activeCombo); // Make combo text
        }
        ClearCombo();
    }

    private void AddScoreFor(string combo)
    {
        score += POINTS_PER_COMBO;
    }

    private void SubScoreFor(string combo)
    {
        score -= POINTS_PER_COMBO;
    }

    private void InstantiateComboText(bool success, string combo)
    {
        Color toPass = success ? Color.green : Color.red;
        FlyingText text = Instantiate(flyText).GetComponent<FlyingText>();
        text.init();
        text.setText(combo, toPass);
    }

    private void ClearCombo()
    {
        activeCombo = "";
    }

    public string GetActiveCombo()
    {
        return activeCombo;
    }
}
