namespace fpv
{
    public struct FlightInput
    {
        public float throttle;
        public float yaw;
        public float pitch;
        public float roll;
        
        public FlightInput(float throttle, float yaw, float pitch, float roll)
        {
            this.throttle = throttle;
            this.yaw = yaw;
            this.pitch = pitch;
            this.roll = roll;
        }
        public static FlightInput Zero => new FlightInput(0, 0, 0, 0);
    }
}
