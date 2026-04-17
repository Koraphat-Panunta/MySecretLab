using UnityEngine;

public class SkinMeshBoneAssign : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer newCloth;
    [SerializeField] private SkinnedMeshRenderer alreadyCharacterCloth;

    void Awake()
    {
        AssignBonesByIndex();
    }

    public void AssignBonesByIndex()
    {
        if (newCloth == null || alreadyCharacterCloth == null)
        {
            Debug.LogError("Missing SkinnedMeshRenderer reference!");
            return;
        }

        Transform[] sourceBones = alreadyCharacterCloth.bones;
        Transform[] targetBones = newCloth.bones;

        // Safety check
        if (sourceBones.Length != targetBones.Length)
        {
            Debug.LogError("Bone count mismatch! Cannot assign by index.");
            return;
        }

        Transform[] newBones = new Transform[targetBones.Length];

        for (int i = 0; i < newBones.Length; i++)
        {
            newBones[i] = sourceBones[i];
        }

        newCloth.bones = newBones;
        newCloth.rootBone = alreadyCharacterCloth.rootBone;

        Debug.Log("Bone assignment (by index) complete!");
    }
}
