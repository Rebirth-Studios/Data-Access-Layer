using System;
using System.Numerics;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CharacterModel
    {
        [JsonProperty] public int                         CharacterId          { get; private set; }
        [JsonProperty] public byte[]                      SpawnedWorldObjectId { get; private set; }
        [JsonProperty] public string                      CharacterName        { get; private set; }
        [JsonProperty] public int                         CharacterExperience  { get; private set; }
        [JsonProperty] public byte                        CharacterFactionId   { get; private set; }
        [JsonProperty] public (float x, float y, float z) Position             { get; private set; }
        [JsonProperty] public int                         Chunk                { get; private set; }
        [JsonProperty] public (float x, float y, float z) Rotation             { get; private set; }
        [JsonProperty] public (float x, float y, float z) Scale                { get; private set; }
        [JsonProperty] public byte                        Race                 { get; private set; }
        [JsonProperty] public byte                        Gender               { get; private set; }
        [JsonProperty] public byte                        Face                 { get; private set; }
        [JsonProperty] public byte                        Eyebrows             { get; private set; }
        [JsonProperty] public byte                        Hair                 { get; private set; }
        [JsonProperty] public byte                        FacialHair           { get; private set; }
        [JsonProperty] public (byte r, byte g, byte b)    SkinColor            { get; private set; }
        [JsonProperty] public (byte r, byte g, byte b)    EyeColor             { get; private set; }
        [JsonProperty] public (byte r, byte g, byte b)    HairColor            { get; private set; }
        [JsonProperty] public (byte r, byte g, byte b)    StubbleColor         { get; private set; }

        [JsonProperty]public uint   Gold { get; private set; }
        [JsonProperty]public byte   Silver { get; private set; }
        [JsonProperty]public byte   Copper { get; private set; }
        [JsonProperty]public ushort AdventuringTokens { get; private set; }
        [JsonProperty]public ushort CraftingTokens { get; private set; }
        [JsonProperty]public ushort GatheringTokens { get; private set; }
            
        [JsonProperty] public (float x, float y, float z)? SpawnLocation { get; private set; }

        public CharacterModel()
        {
            
        }

        public CharacterModel(int characterId, Guid spawnedWorldObjectId, string characterName, int characterExperience)
        {
            CharacterId          = characterId;
            SpawnedWorldObjectId = spawnedWorldObjectId.ToByteArray();
            CharacterName        = characterName;
            CharacterExperience  = characterExperience;
            CharacterFactionId        = 0;
            Position                  = (0,0,0);
            Chunk                     = 0;
            Rotation                  = (0,0,0);
            Scale                  = (0,0,0);
            Race                      = 0;
            Gender                    = 0;
            Face                      = 0;
            Eyebrows                  = 0;
            Hair                      = 0;
            FacialHair                = 0;
            SkinColor                 = HexColorModel.ToValueTuple("#FFFFFF");
            EyeColor                  = HexColorModel.ToValueTuple("#FFFFFF");
            HairColor                 = HexColorModel.ToValueTuple("#FFFFFF");
            StubbleColor              = HexColorModel.ToValueTuple("#FFFFFF");

            Gold              = 0;
            Silver            = 0;
            Copper            = 0;
            AdventuringTokens = 0;
            CraftingTokens    = 0;
            GatheringTokens   = 0;

            SpawnLocation = (0,0,0);
        }

        public CharacterModel(int characterId, Guid spawnedWorldObjectId, string characterName, int characterExperience,
            byte characterFactionId, (float x, float y, float z) position, int chunk, (float x, float y, float z) rotation,
            (float x, float y, float z) scale, byte race, byte gender, byte face, byte eyebrows, byte hair, byte facialHair, 
            string skinColor, string eyeColor, string hairColor, string stubbleColor, uint gold, byte silver, byte copper, 
            ushort adventuringTokens, ushort craftingTokens,
            ushort gatheringTokens)
        {
            CharacterId          = characterId;
            SpawnedWorldObjectId = spawnedWorldObjectId.ToByteArray();
            CharacterName        = characterName;
            CharacterExperience  = characterExperience;
            CharacterFactionId   = characterFactionId;
            Position             = position;
            Chunk                = chunk;
            Rotation             = rotation;
            Scale             = scale;
            Race                 = race;
            Gender               = gender;
            Face                 = face;
            Eyebrows             = eyebrows;
            Hair                 = hair;
            FacialHair           = facialHair;
            SkinColor            = HexColorModel.ToValueTuple(skinColor);
            EyeColor                  = HexColorModel.ToValueTuple(eyeColor);
            HairColor                 = HexColorModel.ToValueTuple(hairColor);
            StubbleColor              = HexColorModel.ToValueTuple(stubbleColor);
                
            Gold              = gold;
            Silver            = silver;
            Copper            = copper;
            AdventuringTokens = adventuringTokens;
            CraftingTokens    = craftingTokens;
            GatheringTokens   = gatheringTokens;

            SpawnLocation = (0,0,0);
        }
            
        public CharacterModel(int characterId, Guid spawnedObjectId, string characterName, (float x, float y, float z) position, 
            (float x, float y, float z) rotation, (float x, float y, float z) scale, int chunk, 
            (float x, float y, float z)? spawnLocation, int characterExperience, byte rank, byte level, 
            byte race, byte gender, byte face, byte eyebrows, byte hair, byte facialHair, HexColorModel skinColor, 
            HexColorModel eyeColor, HexColorModel hairColor, HexColorModel stubbleColor, uint gold, byte silver, byte copper, 
            ushort adventuringTokens, ushort craftingTokens, 
            ushort gatheringTokens)
        {
            CharacterId          = characterId;
            SpawnedWorldObjectId = spawnedObjectId.ToByteArray();
            CharacterName        = characterName;
            
            Position = position;
            Rotation = rotation;
            Scale    = scale;
            Chunk    = chunk;

                
            SpawnLocation = spawnLocation;

            CharacterExperience = characterExperience;
            //this.rank                = rank;
            //this.Level               = level;

            Race       = race;
            Gender     = gender;
            Face       = face;
            Eyebrows   = eyebrows;
            Hair       = hair;
            FacialHair = facialHair;
            
            SkinColor    = skinColor;
            EyeColor     = eyeColor;
            HairColor    = hairColor;
            StubbleColor = stubbleColor;
            
            Gold   = gold;
            Silver = silver;
            Copper = copper;
            
            AdventuringTokens = adventuringTokens;
            CraftingTokens    = craftingTokens;
            GatheringTokens   = gatheringTokens;
        }

    }

}
