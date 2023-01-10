namespace FlightManagement.Base.Position
{
    public class PositionToStringMapper
    {
        private static string _pilot = "Pilot";
        private static string _controller = "Kontroler";
        private static string _steward = "Steward";
        private static string _admin = "Admin";
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

        public static string Translate(string position)
        {
            if (position == PositionEnum.Pilot.ToString())
                return _pilot;
            if (position == PositionEnum.Controller.ToString())
                return _controller;
            if (position == PositionEnum.Steward.ToString())
                return _steward;
            if (position == PositionEnum.Admin.ToString())
                return _admin;
            throw new ArgumentException();
        }
    }
}
