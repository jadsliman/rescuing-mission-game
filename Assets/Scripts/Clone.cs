using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public Block currentBlock, targetBlock;
    public float JumpDuration = 0.3f;
    Wizard w;
    void Start()
    {
        w = FindObjectOfType<Wizard>();
    }

    public void MoveTo(Block TargetBlock)
    {
        var path = Path_Finding.FindPath(currentBlock, TargetBlock);
        if (path == null)
        {
            w.CanMove = true; return;
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(JumpAlongPath(path));
        }
    }

    private IEnumerator JumpAlongPath(List<Block> path)
    {
        for (int i = 1; i < path.Count; i++)
        {
            Block block = path[i];
            Vector3 StartPos = transform.position;
            Vector3 EndPos = block.transform.position; EndPos.y = 0.85f;
            Vector3 direction = (block.GridPosition - currentBlock.GridPosition);
            float elapsed = 0;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction * 90);
            }

            while (elapsed < JumpDuration)
            {
                float t = elapsed / JumpDuration;
                transform.position = Vector3.Lerp(StartPos, EndPos, t) + Vector3.up * Mathf.Sin(t * Mathf.PI);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = EndPos;
            currentBlock = block;
        }
        w.CanMove = true;
    }
}
