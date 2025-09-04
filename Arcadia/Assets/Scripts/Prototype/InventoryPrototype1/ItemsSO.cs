using UnityEngine;

namespace Arcadia.Prototype.InventoryPrototype1
{
    [CreateAssetMenu]
    public class ItemsSO : ScriptableObject
    {
        [field : SerializeField] public bool IsStackable { get; set; }
        public int ID => GetInstanceID();
        [field: SerializeField] public int MaxStackSize { get; set; } = 1;
        [field : SerializeField] public string Name { get; set; }
        [field : TextArea]
        [field : SerializeField] public string Description { get; set; }
        [field : SerializeField] public Sprite ItemImage { get; set; }
    }
}