namespace FlightManagement.Base.Position
{
    public class PositionToStringMapper
    {
        private static string _pilot = "Pilot";
        private static string _controller = "Kontroler";
        private static string _steward = "Steward";
        public static PositionEnum MapTo(string position)
        {
            if (position == _pilot)
                return PositionEnum.Pilot;
            if (position == _controller)
                return PositionEnum.Controller;
            if (position == _steward)
                return PositionEnum.Steward;
            throw new ArgumentException();
        }

        public static string MapTo(PositionEnum position)
        {
            return position switch
            {
                PositionEnum.Pilot => _pilot,
                PositionEnum.Controller => _controller,
                PositionEnum.Steward => _steward,
                _ => throw new ArgumentException()
            };
        }
    }
}
