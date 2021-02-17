using UnityEngine;

public class ElfSystem : MonoBehaviour
{
    void Update()
    {
        var elfs = EntitySet.Elfs;
        for (int i = 0; i < elfs.Length; i++)
        {
            var elf = elfs.Elements[i];

            if (elf.state == Elf.State.Idle)
                continue;

            if (elf.state == elf.lastState)
                continue;

            if (elf.state == Elf.State.WatchingTheSea)
            {
                elf.lastState = elf.state;

                elf.animator.SetTrigger("idleSad");
            }
        }
    }
}