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
        CreateNewCombo();
    }

    void Update()
    {

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
        desiredCombo = (string)new ArrayList(player.combos.Values)[(int)(Random.value * player.combos.Count)];
    }

    public string GetDesiredCombo()
    {
        return desiredCombo;
    }
}
