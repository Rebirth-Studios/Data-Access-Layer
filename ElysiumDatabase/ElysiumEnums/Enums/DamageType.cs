namespace RebirthStudios.Enums
{
    /*[CreateAssetMenu(fileName = "New Damage Type", menuName = "DamageType")]
    public class DamageType : ScriptableObject
    {
        [SerializeField] private new string name = "New Damage Type";
        [SerializeField] private Color color = new Color(1f, 1f, 1f, 1f);

        public string Name => name; 
        public Color Color => color;
        public ElementalTypes[] baseDmgTypes;
    }
    */
    public enum DamageType
    {
        Magic,
        Melee,
        Ranged,
    }
}