using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private TeamColorLookup teamColorLookup;
    [SerializeField] private TankPlayer player;
    [SerializeField] private SpriteRenderer[] playerSprites;

    [SerializeField] private int colorIndex;

    private void Start()
    {
        HandlePlayerColorChanged(0, player.PlayerColorIndex.Value);
        player.PlayerColorIndex.OnValueChanged += HandlePlayerColorChanged;
    }

    private void HandlePlayerColorChanged(int oldIndex, int newIndex)
    {
        colorIndex = newIndex;
        foreach (SpriteRenderer sprite in playerSprites)
        {
            if (teamColorLookup.GetTeamColor(colorIndex) != null)
            {
                sprite.color = (Color)teamColorLookup.GetTeamColor(colorIndex);
            }

        }
    }

    private void OnDestroy()
    {
        player.PlayerColorIndex.OnValueChanged -= HandlePlayerColorChanged;
    }
}