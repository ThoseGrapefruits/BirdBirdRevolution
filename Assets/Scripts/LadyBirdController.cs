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

    void Start()
    {
        player = playerComp.GetComponent<PlayerController>();
        hearts = heartsComp.GetComponent<Hearts>();
    }

    void Update()
    {
        if(desiredCombo == null)
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
        int randIndex = (int)Random.value * player.combos.Count;
        desiredCombo = (string)new ArrayList(player.combos.Values)[randIndex];
    }

    public string GetDesiredCombo()
    {
        return desiredCombo;
    }
}
