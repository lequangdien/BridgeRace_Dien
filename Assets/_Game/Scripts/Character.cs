using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask stairLayer;

    [SerializeField] private Transform skin;

    public List<PlayerBrick> playerBricks = new List<PlayerBrick>();
    [SerializeField] private PlayerBrick playerBrickPrefab;
    [SerializeField] private Transform brickHolder;
    public Stage stage;
    public bool CanMove(Vector3 nextPoint)
    {

        bool isCanMove = true;
        RaycastHit hit;
        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 0.5f, stairLayer))
        {

            Stair stair = hit.collider.GetComponent<Stair>();
            if (stair.colorType != colorType && playerBricks.Count > 0)
            {
                stair.ChangeColor(colorType);
                RemoveBrick();
                stage.NewBrick(colorType);
            }
            if (stair.colorType != colorType && playerBricks.Count == 0 && skin.forward.z > 0)
            {
                isCanMove = false;
            }
        }
        return isCanMove;
    }
    public void AddBrick()
    {
        PlayerBrick playerBrick = Instantiate(playerBrickPrefab, brickHolder);
        playerBrick.ChangeColor(colorType);
        playerBrick.transform.localPosition = Vector3.up * 0.25f * playerBricks.Count;
        playerBricks.Add(playerBrick);
    }
    public void RemoveBrick()
    {
        if (playerBricks.Count > 0)
        {
            PlayerBrick playerBrick = playerBricks[playerBricks.Count - 1];
            playerBricks.RemoveAt(playerBricks.Count - 1);
            Destroy(playerBrick.gameObject);
        }
    }
    public void ClearBrick()
    {
        for (int i = 0; i < playerBricks.Count; i++)
        {
            Destroy(playerBricks[i]);
        }
        playerBricks.Clear();
    }
}
