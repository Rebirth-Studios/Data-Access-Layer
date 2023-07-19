namespace RebirthStudios.Enums
{
    public enum PlayerMovementInputs: ushort
    {
        IS_GROUNDED = 1 << 0,
        BTN_FORWARD = 1 << 1,
        BTN_BACKWARD = 1 << 2,
        BTN_LEFT = 1 << 3,
        BTN_RIGHT = 1 << 4,
        BTN_JUMP = 1 << 5,
        BTN_SPRINT = 1 << 6,
        BTN_CROUCH = 1 << 7,
        BTN_INTERACT = 1 << 8,
        BTN_ROLL_FORWARD = 1 << 9,
        BTN_ROLL_BACKWARD = 1 << 10,
        BTN_ROLL_LEFT = 1 << 11,
        BTN_ROLL_RIGHT = 1 << 12
    }
}