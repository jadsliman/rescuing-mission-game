using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Wizard : MonoBehaviour
{
    public Block CurrentBlock; public List<Block> ClosedBlocks = new List<Block>(), 
        OpenedBlocks = new List<Block>(), RTP = new List<Block>(2), BTP = new List<Block>(2), 
        GTP = new List<Block>(2), YTP = new List<Block>(2), FBs = new List<Block>();
    public float JumpDuration = 0.3f;
    public bool CanMove = true, Won = false, Lost = false, Paused = false;
    Star s;
    Gadget g;
    GadgetToken Gt;
    bool Goal1Achieved = false, Goal2Achieved = false, TPUsedThisMove = false;
    public TextMeshProUGUI Goal1, Goal2;
    public TextMeshProUGUI Moves, gems, gt;
    public TextMeshProUGUI GadgetCollected;
    public int TotalMoves; private int RemainingMoves, cloneN = 0;
    public int allEnemies; private int killedEnemies;
    public Fight_Trigger[] fts;
    Gear_Manager gm;
    Transform t;
    Rigidbody rb;
    public Animator animator;
    public Fighter[] Monsters;
    public Image[] Keys;
    private int gts;
    public Door[] doors;
    public GameObject[] keys;
    public TP[] tps;
    public Clone clone;
    GameObject canva, gadget;
    Transform wint, loset, fadeoutt, fadeint, battleReturnt, battleGot, Gemst, GTst, Geart, UGott, git;
    public GameObject win, lose, fadeout, fadein, battleReturn, battleGo, Gems, GTs, UGot, gi, Gear, Au;
    public AudioSource au; public AudioClip step, star, lvlwin, lvllose, augadget, trigger, gtA, keyA, doorA, cloneA, TPA, FSong;

    private void Start() {
        canva = GameObject.Find("Canvas");
        g = FindObjectOfType<Gadget>();
        wint = canva.transform.Find("Win");
        loset = canva.transform.Find("Lose");
        fadeoutt = canva.transform.Find("Fade out");
        fadeint = canva.transform.Find("Fade in");
        battleReturnt = canva.transform.Find("Battle Return");
        battleGot = canva.transform.Find("Battle Go");
        Au = GameObject.Find("SFX Player");
        win = wint.gameObject;
        lose = loset.gameObject;
        fadeout = fadeoutt.gameObject;
        fadein = fadeint.gameObject;
        battleReturn = battleReturnt.gameObject;
        battleGo = battleGot.gameObject;
        Gemst = win.transform.Find("Gems");
        GTst = win.transform.Find("GTs");
        Geart = win.transform.Find("Gear");
        UGott = win.transform.Find("U Got");
        UGot = UGott.gameObject;
        Gems = Gemst.gameObject;
        GTs = GTst.gameObject;
        Gear = Geart.gameObject;
        gems = Gems.GetComponentInChildren<TextMeshProUGUI>();
        gt = GTs.GetComponentInChildren<TextMeshProUGUI>();
        RemainingMoves = TotalMoves;
        killedEnemies = 0;
        au = Au.GetComponent<AudioSource>();
        s = FindObjectOfType<Star>();
        Gt = FindObjectOfType<GadgetToken>();
        t = GetComponentInParent<Transform>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        au.volume = DataCrosser.sfx;
        MusicPlayer.instance.ChangeVolume();
        DataCrosser.WonThisLevelBefore = false;
        if(!DataCrosser.IsClockwise)
        {
            if (DataCrosser.WonLevels > DataCrosser.Levelindex + 1)
            {
                DataCrosser.WonThisLevelBefore = true;
                if(g != null) g.gameObject.SetActive(false);
                if(Gt != null) Gt.gameObject.SetActive(false);
            }
            else
                DataCrosser.WonThisLevelBefore = false;
        }
        else
        {
            if (DataCrosser.WonLevels > (77 - DataCrosser.Levelindex) + 3)
            {
                DataCrosser.WonThisLevelBefore = true;
                Gt.gameObject.SetActive(false);
                g.gameObject.SetActive(false);
            }
            else
                DataCrosser.WonThisLevelBefore = false;
        }
        if (DataCrosser.isReturningFromBattle)
        {
            battleReturn.SetActive(true);
            if (DataCrosser.EnvIndex == 5) { clone.gameObject.SetActive(true); }
            if (DataCrosser.Star)
            {
                s.gameObject.SetActive(false); Goal1.text = "1/1"; Goal1Achieved = true;
            }
            if (DataCrosser.GT) { Gt.gameObject.SetActive(false); gts++; }
            if (DataCrosser.Gadget) { g.gameObject.SetActive(false); GadgetCollected.text = "You got a new gadget!"; }
            killedEnemies = DataCrosser.enemies + 1;
            if (killedEnemies == allEnemies) Goal2Achieved = true;
            RemainingMoves = DataCrosser.moves;
            t.position = DataCrosser.WizardReturningPos;
            if (DataCrosser.EnvIndex == 5) { clone.transform.position = DataCrosser.CloneReturningPos; }
            if (DataCrosser.Enemy1) { Monsters[0].gameObject.SetActive(false); fts[0].blocks = null; Monsters[0].block.isWalkable = true; }
            if (DataCrosser.Enemy2) { Monsters[1].gameObject.SetActive(false); fts[1].blocks = null; Monsters[1].block.isWalkable = true; }
            if (DataCrosser.Enemy3) { Monsters[2].gameObject.SetActive(false); fts[2].blocks = null; Monsters[2].block.isWalkable = true; }
            if (DataCrosser.Enemy4) { Monsters[3].gameObject.SetActive(false); fts[3].blocks = null; Monsters[3].block.isWalkable = true; }
            if (DataCrosser.Enemy5) { Monsters[4].gameObject.SetActive(false); fts[4].blocks = null; Monsters[4].block.isWalkable = true; }
            if (DataCrosser.Enemy6) { Monsters[5].gameObject.SetActive(false); fts[5].blocks = null; Monsters[5].block.isWalkable = true; }
            List<Block> allblocks = FindObjectsOfType<Block>().ToList();
            foreach(Block b in allblocks)
            {
                if(b.GridPosition == DataCrosser.current)
                {
                    CurrentBlock = b;
                    break;
                }
            }
            if (DataCrosser.EnvIndex == 5)
            {
                foreach (Block b in allblocks)
                {
                    if (b.GridPosition == DataCrosser.cloneCurrent)
                    {
                        clone.currentBlock = b;
                        break;
                    }
                }
            }
            for (int i = 0; i < doors.Length; i++)
            {
                if (DataCrosser.GotKeys[i])
                {
                    keys[i % 4].SetActive(false);
                    if (DataCrosser.doorOpened[i])
                    {
                        Keys[i % 4].gameObject.SetActive(false);
                        doors[i].gameObject.SetActive(false);
                        doors[i].PlacedBlock.isWalkable = true;
                    }
                    else
                    {
                        Keys[i % 4].gameObject.SetActive(true);
                        doors[i].gameObject.SetActive(true);
                    }
                }
            }
            StartCoroutine(LavaAndCaveBlocks());
            DataCrosser.isReturningFromBattle = false;
            if (Goal1Achieved && Goal2Achieved)
            {
                Won = true;
                StartCoroutine(Win());
            }
            if ((RemainingMoves == 0 && (!Goal1Achieved || !Goal2Achieved)) || DataCrosser.LostBattle)
            {
                Lost = true;
                StartCoroutine(Lose());
            }
        }
        else
        {
            fadeout.SetActive(true);
            for (int i = 0; i < 8; i++) DataCrosser.GotKeys[i] = false;
            for (int i = 0; i < 8; i++) DataCrosser.doorOpened[i] = false;
            for (int i = 0; i < 10; i++) DataCrosser.FallenBlocks[i] = false;
            DataCrosser.Lava = 0; gts = 0; DataCrosser.GemsPerLevel = 0;
            DataCrosser.Gadget = false; DataCrosser.GT = false; DataCrosser.EnvCompleted = false;
            DataCrosser.Star = false; DataCrosser.Enemy1 = false; DataCrosser.Enemy2 = false;
            DataCrosser.Enemy3 = false; DataCrosser.Enemy4 = false; DataCrosser.Enemy5 = false;
            DataCrosser.Enemy6 = false;
        }
    }

    public void MoveTo(Block TargetBlock)
    {
        if (!CanMove || RemainingMoves == 0) return;
        var path = Path_Finding.FindPath(CurrentBlock, TargetBlock);
        if (path != null)
        {
            RemainingMoves--;
            StopAllCoroutines();
            StartCoroutine(JumpAlongPath(path));
        }
    }

    private IEnumerator JumpAlongPath(List<Block> path)
    {
        CanMove = false;
        if (DataCrosser.EnvIndex == 5 && !TPUsedThisMove) { clone.targetBlock = CurrentBlock; }
        for (int i = 1; i < path.Count; i++)
        {
            Block block = path[i];
            Vector3 StartPos = transform.position;
            Vector3 EndPos = block.transform.position; EndPos.y = 0.85f;
            Vector3 direction = (block.GridPosition - CurrentBlock.GridPosition);
            float elapsed = 0;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction * 90);
            }

            while(elapsed < JumpDuration)
            {
                float t = elapsed / JumpDuration;
                transform.position = Vector3.Lerp(StartPos, EndPos, t) + Vector3.up * Mathf.Sin(t * Mathf.PI);
                elapsed += Time.deltaTime;
                yield return null;
            }
            au.PlayOneShot(step);
            transform.position = EndPos;
            CurrentBlock = block;
            if(DataCrosser.EnvIndex == 5)
            {
                if (RemainingMoves == TotalMoves - 1)
                {
                    clone.gameObject.SetActive(true);
                    if (cloneN == 0) { au.PlayOneShot(cloneA); cloneN = 1; }
                    CanMove = true; 
                }
                else
                {
                    clone.MoveTo(clone.targetBlock);
                }
            }
        }
        if (DataCrosser.EnvIndex != 5) { CanMove = true; }
        for (int i = 0; i < doors.Length; i++)
        {
            if (CurrentBlock == doors[i].UnlockBlock && DataCrosser.GotKeys[i])
            {
                doors[i].anim.SetBool("Opened", true);
                au.PlayOneShot(doorA);
                doors[i].PlacedBlock.isWalkable = true;
                Keys[i % 4].gameObject.SetActive(false);
                DataCrosser.doorOpened[i] = true;
                if (i >= 4) DataCrosser.GotKeys[i - 4] = false;
                else DataCrosser.GotKeys[i + 4] = false;
            }
        }
        SwitchLavaBlocks();
        if (RTP.Count > 0) { TPUsedThisMove = false; StartCoroutine(TP()); }
        if (fts[0].blocks != null)
        {
            foreach (Block b in fts[0].blocks)
            {
                if (b == CurrentBlock)
                {
                    au.PlayOneShot(trigger);
                    DataCrosser.EnemyNumber = 0; DataCrosser.Enemy1 = true;
                    DataCrosser.enemies = killedEnemies;
                    DataCrosser.moves = RemainingMoves;
                    DataCrosser.WizardReturningPos = t.position;
                    DataCrosser.isReturningFromBattle = true;
                    DataCrosser.current = CurrentBlock.GridPosition;
                    if (DataCrosser.EnvIndex == 5)
                    {
                        DataCrosser.CloneReturningPos = clone.transform.position;
                        DataCrosser.cloneCurrent = clone.currentBlock.GridPosition;
                    }
                    battleGo.SetActive(true);
                    yield return new WaitForSeconds(1.5f);
                    MusicPlayer.instance.ChangeMusic(FSong);
                    SceneManager.LoadScene("Fight scene");
                }
            }
        }
        if (fts[1].blocks != null)
        {
            foreach (Block b in fts[1].blocks)
            {
                if (b == CurrentBlock)
                {
                    au.PlayOneShot(trigger);
                    DataCrosser.EnemyNumber = 1; DataCrosser.Enemy2 = true;
                    DataCrosser.enemies = killedEnemies;
                    DataCrosser.moves = RemainingMoves;
                    DataCrosser.WizardReturningPos = t.position;
                    DataCrosser.isReturningFromBattle = true;
                    DataCrosser.current = CurrentBlock.GridPosition;
                    if (DataCrosser.EnvIndex == 5)
                    {
                        DataCrosser.CloneReturningPos = clone.transform.position;
                        DataCrosser.cloneCurrent = clone.currentBlock.GridPosition;
                    }
                    battleGo.SetActive(true);
                    yield return new WaitForSeconds(1.5f);
                    MusicPlayer.instance.ChangeMusic(FSong);
                    SceneManager.LoadScene("Fight scene");
                }
            }
        }
        if (fts[2].blocks != null)
        {
            foreach (Block b in fts[2].blocks)
            {
                if (b == CurrentBlock)
                {
                    au.PlayOneShot(trigger);
                    DataCrosser.EnemyNumber = 2; DataCrosser.Enemy3 = true;
                    DataCrosser.enemies = killedEnemies;
                    DataCrosser.moves = RemainingMoves;
                    DataCrosser.WizardReturningPos = t.position;
                    DataCrosser.isReturningFromBattle = true;
                    DataCrosser.current = CurrentBlock.GridPosition;
                    if (DataCrosser.EnvIndex == 5)
                    {
                        DataCrosser.CloneReturningPos = clone.transform.position;
                        DataCrosser.cloneCurrent = clone.currentBlock.GridPosition;
                    }
                    battleGo.SetActive(true);
                    yield return new WaitForSeconds(1.5f);
                    MusicPlayer.instance.ChangeMusic(FSong);
                    SceneManager.LoadScene("Fight scene");
                }
            }
        }
        if (fts[3].blocks != null)
        {
            foreach (Block b in fts[3].blocks)
            {
                if (b == CurrentBlock)
                {
                    au.PlayOneShot(trigger);
                    DataCrosser.EnemyNumber = 3; DataCrosser.Enemy4 = true;
                    DataCrosser.enemies = killedEnemies;
                    DataCrosser.moves = RemainingMoves;
                    DataCrosser.WizardReturningPos = t.position;
                    DataCrosser.isReturningFromBattle = true;
                    DataCrosser.current = CurrentBlock.GridPosition;
                    if (DataCrosser.EnvIndex == 5)
                    {
                        DataCrosser.CloneReturningPos = clone.transform.position;
                        DataCrosser.cloneCurrent = clone.currentBlock.GridPosition;
                    }
                    battleGo.SetActive(true);
                    yield return new WaitForSeconds(1.5f);
                    MusicPlayer.instance.ChangeMusic(FSong);
                    SceneManager.LoadScene("Fight scene");
                }
            }
        }
        if (fts[4].blocks != null)
        {
            foreach (Block b in fts[4].blocks)
            {
                if (b == CurrentBlock)
                {
                    au.PlayOneShot(trigger);
                    DataCrosser.EnemyNumber = 4; DataCrosser.Enemy5 = true;
                    DataCrosser.enemies = killedEnemies;
                    DataCrosser.moves = RemainingMoves;
                    DataCrosser.WizardReturningPos = t.position;
                    DataCrosser.isReturningFromBattle = true;
                    DataCrosser.current = CurrentBlock.GridPosition;
                    if (DataCrosser.EnvIndex == 5)
                    {
                        DataCrosser.CloneReturningPos = clone.transform.position;
                        DataCrosser.cloneCurrent = clone.currentBlock.GridPosition;
                    }
                    battleGo.SetActive(true);
                    yield return new WaitForSeconds(1.5f);
                    MusicPlayer.instance.ChangeMusic(FSong);
                    SceneManager.LoadScene("Fight scene");
                }
            }
        }
        if (fts[5].blocks != null)
        {
            foreach (Block b in fts[5].blocks)
            {
                if (b == CurrentBlock)
                {
                    au.PlayOneShot(trigger);
                    DataCrosser.EnemyNumber = 5; DataCrosser.Enemy6 = true;
                    DataCrosser.enemies = killedEnemies;
                    DataCrosser.moves = RemainingMoves;
                    DataCrosser.WizardReturningPos = t.position;
                    DataCrosser.isReturningFromBattle = true;
                    DataCrosser.current = CurrentBlock.GridPosition;
                    if (DataCrosser.EnvIndex == 5)
                    {
                        DataCrosser.CloneReturningPos = clone.transform.position;
                        DataCrosser.cloneCurrent = clone.currentBlock.GridPosition;
                    }
                    battleGo.SetActive(true);
                    yield return new WaitForSeconds(1.5f);
                    MusicPlayer.instance.ChangeMusic(FSong);
                    SceneManager.LoadScene("Fight scene");
                }
            }
        }
        if (killedEnemies == allEnemies) Goal2Achieved = true;
        if (Goal1Achieved && Goal2Achieved) 
        {
            StartCoroutine(Win());
            Won = true;
        }
        if(RemainingMoves == 0 && (!Goal1Achieved || !Goal2Achieved))
        {
            StartCoroutine(Lose());
            Lost = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Star"))
        {
            s.anim.SetBool("IsCollected", true);
            au.PlayOneShot(star);
            Destroy(collision);
            Goal1.text = "1/1";
            Goal1Achieved = true;
            DataCrosser.Star = true;
        }
        else if (collision.CompareTag("Gadget"))
        {
            g.anim.SetBool("IsCollected", true);
            au.PlayOneShot(augadget);
            Destroy(collision);
            GadgetCollected.text = "You got a new gadget!";
            DataCrosser.Gadget = true;
        }
        else if(collision.CompareTag("RedKey"))
        {
            au.PlayOneShot(keyA);
            DataCrosser.GotKeys[0] = true; DataCrosser.GotKeys[4] = true;
            Keys[0].gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("BlueKey"))
        {
            au.PlayOneShot(keyA);
            DataCrosser.GotKeys[1] = true; DataCrosser.GotKeys[5] = true;
            Keys[1].gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("GreenKey"))
        {
            au.PlayOneShot(keyA);
            DataCrosser.GotKeys[2] = true; DataCrosser.GotKeys[6] = true;
            Keys[2].gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("YellowKey"))
        {
            au.PlayOneShot(keyA);
            DataCrosser.GotKeys[3] = true; DataCrosser.GotKeys[7] = true;
            Keys[3].gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("GT"))
        {
            GadgetToken gt = collision.GetComponent<GadgetToken>();
            gt.a.SetBool("IsCollected", true);
            au.PlayOneShot(gtA);
            Destroy(collision);
            gts++;
            DataCrosser.GT = true;
        }
        else if(collision.CompareTag("FallingBlock"))
        {
            Animator a = collision.GetComponent<Animator>();
            Block b = collision.GetComponent<Block>();
            StartCoroutine(fall(a, b));
        }
        else if (collision.CompareTag("Clone"))
        {
            Lost = true;
            StartCoroutine(Lose());
        }
    }

    private IEnumerator fall(Animator a, Block b)
    {
        yield return new WaitForSeconds(0.01f);
        a.SetTrigger("Fall");
        DataCrosser.FallenBlocks[b.id] = true;
        b.isWalkable = false;
        yield return new WaitForSeconds(0.5f);
    }

    public void SwitchLavaBlocks()
    {
        DataCrosser.Lava++; List<Block> bs = new List<Block>(ClosedBlocks.Count);
        foreach(Block b in ClosedBlocks)
        {
            b.ab.SetBool("Open", true);
            b.ab.SetBool("Close", false);
            bs.Add(b);
            b.isWalkable = true;
        }
        ClosedBlocks.Clear();
        foreach(Block b in OpenedBlocks)
        {
            b.ab.SetBool("Close", true);
            b.ab.SetBool("Open", false);
            ClosedBlocks.Add(b);
            b.isWalkable = false;
        }
        OpenedBlocks.Clear();
        foreach(Block b in bs)
        {
            OpenedBlocks.Add(b);
        }
        bs.Clear();
        Debug.Log(DataCrosser.Lava);
    }

    private IEnumerator LavaAndCaveBlocks()
    {
        yield return null;

        List<Block> allblocks = FindObjectsOfType<Block>().ToList();
        OpenedBlocks = allblocks.Where(b => b.gameObject.CompareTag("Open")).ToList();
        ClosedBlocks = allblocks.Where(b => b.gameObject.CompareTag("Close")).ToList();
        if (DataCrosser.Lava % 2 == 1)
        {
            DataCrosser.Lava--;
            SwitchLavaBlocks();
        }
        //FBs = allblocks.Where(b => b.gameObject.CompareTag("FallingBlock")).ToList();
        for (int i = 0; i < FBs.Count; i++)
        {
            if (DataCrosser.FallenBlocks[i])
            {
                FBs[i].isWalkable = false;
                FBs[i].gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator TP()
    {
        if (!TPUsedThisMove)
        {
            if (CurrentBlock == RTP[0])
            {
                tps[0].a.SetTrigger("TP"); tps[1].a.SetTrigger("TP");
                TPUsedThisMove = true;
                yield return new WaitForSeconds(0.5f);
                au.PlayOneShot(TPA);
                yield return new WaitForSeconds(0.5f);
                if (DataCrosser.EnvIndex == 5) clone.targetBlock = RTP[0];
                CurrentBlock = RTP[1];
                t.position = new Vector3(RTP[1].transform.position.x, 0.358f, RTP[1].transform.position.z);
            }
            else if (CurrentBlock == RTP[1])
            {
                tps[0].a.SetTrigger("TP"); tps[1].a.SetTrigger("TP");
                TPUsedThisMove = true;
                yield return new WaitForSeconds(0.5f);
                au.PlayOneShot(TPA);
                yield return new WaitForSeconds(0.5f);
                if (DataCrosser.EnvIndex == 5) clone.targetBlock = RTP[1];
                CurrentBlock = RTP[0];
                t.position = new Vector3(RTP[0].transform.position.x, 0.358f, RTP[0].transform.position.z);
            }
            else if (CurrentBlock == BTP[0])
            {
                tps[2].a.SetTrigger("TP"); tps[3].a.SetTrigger("TP");
                TPUsedThisMove = true;
                yield return new WaitForSeconds(0.5f);
                au.PlayOneShot(TPA);
                yield return new WaitForSeconds(0.5f);
                CurrentBlock = BTP[1];
                t.position = new Vector3(BTP[1].transform.position.x, 0.358f, BTP[1].transform.position.z);
            }
            else if (CurrentBlock == BTP[1])
            {
                tps[2].a.SetTrigger("TP"); tps[3].a.SetTrigger("TP");
                TPUsedThisMove = true;
                yield return new WaitForSeconds(0.5f);
                au.PlayOneShot(TPA);
                yield return new WaitForSeconds(0.5f);
                CurrentBlock = BTP[0];
                t.position = new Vector3(BTP[0].transform.position.x, 0.358f, BTP[0].transform.position.z);
            }
            else if (CurrentBlock == GTP[0])
            {
                tps[4].a.SetTrigger("TP"); tps[5].a.SetTrigger("TP");
                TPUsedThisMove = true;
                yield return new WaitForSeconds(0.5f);
                au.PlayOneShot(TPA);
                yield return new WaitForSeconds(0.5f);
                CurrentBlock = GTP[1];
                t.position = new Vector3(GTP[1].transform.position.x, 0.358f, GTP[1].transform.position.z);
            }
            else if (CurrentBlock == GTP[1])
            {
                tps[4].a.SetTrigger("TP"); tps[5].a.SetTrigger("TP");
                TPUsedThisMove = true;
                yield return new WaitForSeconds(0.5f);
                au.PlayOneShot(TPA);
                yield return new WaitForSeconds(0.5f);
                CurrentBlock = GTP[0];
                t.position = new Vector3(GTP[0].transform.position.x, 0.358f, GTP[0].transform.position.z);
            }
            else if (CurrentBlock == YTP[0])
            {
                tps[6].a.SetTrigger("TP"); tps[7].a.SetTrigger("TP");
                TPUsedThisMove = true;
                yield return new WaitForSeconds(0.5f);
                au.PlayOneShot(TPA);
                yield return new WaitForSeconds(0.5f);
                CurrentBlock = YTP[1];
                t.position = new Vector3(YTP[1].transform.position.x, 0.358f, YTP[1].transform.position.z);
            }
            else if (CurrentBlock == YTP[1])
            {
                tps[6].a.SetTrigger("TP"); tps[7].a.SetTrigger("TP");
                TPUsedThisMove = true;
                yield return new WaitForSeconds(0.5f);
                au.PlayOneShot(TPA);
                yield return new WaitForSeconds(0.5f);
                CurrentBlock = YTP[0];
                t.position = new Vector3(YTP[0].transform.position.x, 0.358f, YTP[0].transform.position.z);
            }
        }
    }

    public void Update()
    {
        if(DataCrosser.Levelindex > 0)
        {
            Moves.text = RemainingMoves.ToString();
        }
        if (DataCrosser.Levelindex > 1)
        {
            Goal2.text = killedEnemies.ToString() + "/" + allEnemies.ToString();
        }
    }

    private IEnumerator Win()
    {
        if(!DataCrosser.WonThisLevelBefore)
        {
            if(DataCrosser.Enemy1) DataCrosser.GemsPerLevel += 50;
            if (DataCrosser.Enemy2) DataCrosser.GemsPerLevel += 50;
            if (DataCrosser.Enemy3) DataCrosser.GemsPerLevel += 100;
            if (DataCrosser.Enemy4) DataCrosser.GemsPerLevel += 100;
            if (DataCrosser.Enemy5) DataCrosser.GemsPerLevel += 200;
            if (DataCrosser.Enemy6) DataCrosser.GemsPerLevel += 400;
            if (DataCrosser.Levelindex == 17) { DataCrosser.GemsPerLevel += 1000; }
            DataCrosser.WonLevels++;
            DataCrosser.GTs += gts;
            DataCrosser.Gems += DataCrosser.GemsPerLevel;
            if(DataCrosser.Gadget)
            {
                DataCrosser.Gadgets[g.id - 2] = 1;
                Gear.SetActive(true);
            }
            else { Gear.SetActive(false); }
            if (DataCrosser.GemsPerLevel == 0) Gems.SetActive(false);
            else
            {
                gems.text = "x" + DataCrosser.GemsPerLevel;
            }
            if (gts == 0) GTs.SetActive(false);
            else
            {
                gt.text = "x" + gts;
            }
            if (DataCrosser.Levelindex == 1) { DataCrosser.Weapons[0] = 1; DataCrosser.FTF = true; }
            else if (DataCrosser.Levelindex == 2) { DataCrosser.RC = true; DataCrosser.WonLevels--; }
            else if (DataCrosser.Levelindex == 17) { DataCrosser.EnvCompleted = true; }
            else if (DataCrosser.Levelindex == 32) { DataCrosser.Weapons[1] = 1; DataCrosser.EnvCompleted = true; }
            else if (DataCrosser.Levelindex == 47) { DataCrosser.Weapons[3] = 1; DataCrosser.EnvCompleted = true; }
            else if (DataCrosser.Levelindex == 62) { DataCrosser.Weapons[4] = 1; DataCrosser.EnvCompleted = true; }
            else if (DataCrosser.Levelindex == 77) { DataCrosser.Weapons[2] = 1; DataCrosser.EnvCompleted = true; }
            else if (DataCrosser.Levelindex == 92) { DataCrosser.EnvCompleted = true; }
        }
        else
        {
            UGot.SetActive(false);
            Gems.SetActive(false);
            GTs.SetActive(false);
            Gear.SetActive(false);
        }
        yield return new WaitForSeconds(2f);
        au.PlayOneShot(lvlwin);
        win.SetActive(true);
        SaveManager.SaveGame();
    }
    private IEnumerator Lose()
    {
        DataCrosser.LostBattle = false;
        yield return new WaitForSeconds(2f);
        au.PlayOneShot(lvllose);
        lose.SetActive(true);
    }
}