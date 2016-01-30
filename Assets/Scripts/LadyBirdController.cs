using UnityEngine;
using System.Collections;

public class LadyBirdController : MonoBehaviour
{

    [SerializeField]
    private GameObject playerComp;
    private PlayerController player;

    [SerializeField]
    private GameObject heartsComp;
    private Hearts hearts;

    private string desiredCombo;
    private int lastDesiredComboIndex = -1;

    void Start()
    {
        player = playerComp.GetComponent<PlayerController>();
        hearts = heartsComp.GetComponent<Hearts>();
    }

    void Update()
    {
        if (desiredCombo == null)
        {
            CreateNewCombo();
        }
    }

    public void CompleteCombo(string combo)
    {
        if (!combo.Equals(desiredCombo))
        {
            hearts.loseOneLife();
        }
        CreateNewCombo();
    }

    private void CreateNewCombo()
    {
        int randIndex;

        // This makes sure it doesn't pick the same combo as last time
        while ((randIndex = (int)(Random.value * player.combos.Count)) == lastDesiredComboIndex) ;
        lastDesiredComboIndex = randIndex;

        desiredCombo = (string)new ArrayList(player.combos.Values)[randIndex];
    }

    public string GetDesiredCombo()
    {
        return desiredCombo;
    }
}
