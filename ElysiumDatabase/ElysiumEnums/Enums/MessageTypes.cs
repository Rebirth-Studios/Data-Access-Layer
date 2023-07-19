namespace RebirthStudios.Player.Messaging
{
    public enum MessageTypes : byte
    {
        None = 0,
        General = 1,
        Server = 2,
        Error = 3,
        Whisper = 4,
        Combat = 5,
        Looting = 6,
        Party = 7
    }  
    public enum SpawnedObjectTypes
    {
        None = 0,
        Interactable = 1,
        Entity = 2,
        Item = 3,
        Weapon = 4,
        Sheath = 4,
    }
}

