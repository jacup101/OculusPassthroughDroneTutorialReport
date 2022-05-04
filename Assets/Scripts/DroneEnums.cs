public enum DroneCommand
{
    // These enums are super useful for standardizing the way we communicate with the drone, instead of using strings or things like that
    command,
    takeoff,
    land,
    streamon, 
    streamoff,
    emergency,
    up,
    down,
    left,
    right,
    forward,
    back,
    cw,
    ccw,
    rc,

    // get commands
    battery,
    speed,
    time,
    height,
    temp,
    attitude,
    baro,
    acceleration,
    tof,
    wifi

}

public enum DroneControllerType
{ 
    Standalone,
    Controllers,
    Hands
}

public enum DroneAction
{
    // move actions
    Left,
    Right,
    Forward,
    Backward,
    Up,
    Down,
    RotateRight,
    RotateLeft,
    // core actions
    Connect,
    InitializeSDK,
    TakeOff,
    Landing,
    Emergency
}

public enum DroneSpeedType
{ 
    Positive,
    Negative
}

public enum RequestType
{
    ControlCommand,
    ReadCommand,
}

public enum DroneStatsAttribute
{
    bat,
    pitch,
    roll,
    yaw,
    h,
    time,
    tof,
    baro,
    templ,
    temph,
    agx,
    agy,
    agz
}

public enum ResponseType
{ 
    ok,
    error
}
