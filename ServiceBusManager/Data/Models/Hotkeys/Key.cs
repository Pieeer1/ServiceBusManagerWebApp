namespace ServiceBusManager.Data.Models.Hotkeys
{
    public readonly struct Key : IPressable
    {
        private readonly string _value;
        public Key(string value)
        {
            _value = value;
        }
        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(Key key) => key._value;

        public static Key Control => new Key("Control");

        public static Key Alt => new Key("Alt");

        public static Key Shift => new Key("Shift");

        public static Key Meta => new Key("Meta");

        public static Key CapsLock => new Key("CapsLock");

        public static Key Tab => new Key("Tab");

        public static Key Escape => new Key("Escape");

        public static Key Delete => new Key("Delete");

        public static Key Backspace => new Key("Backspace");

        public static Key Insert => new Key("Insert");

        public static Key Enter => new Key("Enter");

        public static Key ArrowUp => new Key("ArrowUp");

        public static Key ArrowRight => new Key("ArrowRight");

        public static Key ArrowDown => new Key("ArrowDown");

        public static Key ArrowLeft => new Key("ArrowLeft");

        public static Key PageUp => new Key("PageUp");

        public static Key PageDown => new Key("PageDown");

        public static Key Home => new Key("Home");

        public static Key End => new Key("End");

        public static Key Space => new Key(" ");

        public static Key Num0 => new Key("0");

        public static Key Num1 => new Key("1");

        public static Key Num2 => new Key("2");

        public static Key Num3 => new Key("3");

        public static Key Num4 => new Key("4");

        public static Key Num5 => new Key("5");

        public static Key Num6 => new Key("6");

        public static Key Num7 => new Key("7");

        public static Key Num8 => new Key("8");

        public static Key Num9 => new Key("9");

        public static Key A => new Key("A");

        public static Key B => new Key("B");

        public static Key C => new Key("C");

        public static Key D => new Key("D");

        public static Key E => new Key("E");

        public static Key F => new Key("F");

        public static Key G => new Key("G");

        public static Key H => new Key("H");

        public static Key I => new Key("I");

        public static Key J => new Key("J");

        public static Key K => new Key("K");

        public static Key L => new Key("L");

        public static Key M => new Key("M");

        public static Key N => new Key("N");

        public static Key O => new Key("O");

        public static Key P => new Key("P");

        public static Key Q => new Key("Q");

        public static Key R => new Key("R");

        public static Key S => new Key("S");

        public static Key T => new Key("T");

        public static Key U => new Key("U");

        public static Key V => new Key("V");

        public static Key W => new Key("W");

        public static Key X => new Key("X");

        public static Key Y => new Key("Y");

        public static Key Z => new Key("Z");

        public static Key a => new Key("a");

        public static Key b => new Key("b");

        public static Key c => new Key("c");

        public static Key d => new Key("d");

        public static Key e => new Key("e");

        public static Key f => new Key("f");

        public static Key g => new Key("g");

        public static Key h => new Key("h");

        public static Key i => new Key("i");

        public static Key j => new Key("j");

        public static Key k => new Key("k");

        public static Key l => new Key("l");

        public static Key m => new Key("m");

        public static Key n => new Key("n");

        public static Key o => new Key("o");

        public static Key p => new Key("p");

        public static Key q => new Key("q");

        public static Key r => new Key("r");

        public static Key s => new Key("s");

        public static Key t => new Key("t");

        public static Key u => new Key("u");

        public static Key v => new Key("v");

        public static Key w => new Key("w");

        public static Key x => new Key("x");

        public static Key y => new Key("y");

        public static Key z => new Key("z");

        public static Key F1 => new Key("F1");

        public static Key F2 => new Key("F2");

        public static Key F3 => new Key("F3");

        public static Key F4 => new Key("F4");

        public static Key F5 => new Key("F5");

        public static Key F6 => new Key("F6");

        public static Key F7 => new Key("F7");

        public static Key F8 => new Key("F8");

        public static Key F9 => new Key("F9");

        public static Key F10 => new Key("F10");

        public static Key F11 => new Key("F11");

        public static Key F12 => new Key("F12");

        public static Key F13 => new Key("F13");

        public static Key F14 => new Key("F14");

        public static Key F15 => new Key("F15");

        public static Key F16 => new Key("F16");

        public static Key F17 => new Key("F17");

        public static Key F18 => new Key("F18");

        public static Key F19 => new Key("F19");

        public static Key F20 => new Key("F20");

        public static Key ContextMenu => new Key("ContextMenu");

        public static Key NumLock => new Key("NumLock");

        public static Key ScrollLock => new Key("ScrollLock");

        public static Key Equal => new Key("=");

        public static Key LessThan => new Key("<");

        public static Key GreaterThan => new Key(">");

        public static Key Asterisk => new Key("*");

        public static Key Plus => new Key("+");

        public static Key Minus => new Key("-");

        public static Key Slash => new Key("/");

        public static Key SemiColon => new Key(";");

        public static Key Colon => new Key(":");

        public static Key DoubleQuote => new Key("\"");

        public static Key Comma => new Key(",");

        public static Key Period => new Key(".");

        public static Key Backquote => new Key("`");

        public static Key Backslash => new Key("\\");

        public static Key BracketLeft => new Key("[");

        public static Key BracketRight => new Key("]");

        public static Key BraceLeft => new Key("{");

        public static Key BraceRight => new Key("}");

        public static Key ParenthesisLeft => new Key("(");

        public static Key ParenthesisRight => new Key(")");

        public static Key Underscore => new Key("_");

        public static Key Exclamation => new Key("!");

        public static Key Sharp => new Key("#");

        public static Key Dollar => new Key("$");

        public static Key Percent => new Key("%");

        public static Key Ampersand => new Key("&");

        public static Key Question => new Key("?");

        public static Key At => new Key("@");

        public static Key Caret => new Key("^");

        public static Key VerticalLine => new Key("|");

        public static Key Tilde => new Key("~");

        public static Key AudioVolumeMute => new Key("AudioVolumeMute ");

        public static Key AudioVolumeDown => new Key("AudioVolumeDown");

        public static Key AudioVolumeUp => new Key("AudioVolumeUp");

        public static Key MediaTrackNext => new Key("MediaTrackNext");

        public static Key MediaTrackPrevious => new Key("MediaTrackPrevious");

        public static Key MediaStop => new Key("MediaStop");

        public static Key MediaPlayPause => new Key("MediaPlayPause");

        public static Key LaunchMail => new Key("LaunchMail");

        public static Key LaunchMediaPlayer => new Key("LaunchMediaPlayer");

        public static Key LaunchCalculator => new Key("LaunchCalculator");

        public static Key LaunchCalendar => new Key("LaunchCalendar");

        public static Key LaunchContacts => new Key("LaunchContacts");

        public static Key LaunchMusicPlayer => new Key("LaunchMusicPlayer");

        public static Key LaunchMyComputer => new Key("LaunchMyComputer");

        public static Key LaunchPhone => new Key("LaunchPhone");

        public static Key LaunchScreenSaver => new Key("LaunchScreenSaver");

        public static Key LaunchSpreadsheet => new Key("LaunchSpreadsheet");

        public static Key LaunchWebBrowser => new Key("LaunchWebBrowser");

        public static Key LaunchWebCam => new Key("LaunchWebCam");

        public static Key LaunchWordProcessor => new Key("LaunchWordProcessor");

        public static Key LaunchApplication1 => new Key("LaunchApplication1");

        public static Key LaunchApplication2 => new Key("LaunchApplication2");

        public static Key LaunchApplication3 => new Key("LaunchApplication3");

        public static Key LaunchApplication4 => new Key("LaunchApplication4");

        public static Key LaunchApplication5 => new Key("LaunchApplication5");

        public static Key LaunchApplication6 => new Key("LaunchApplication6");

        public static Key LaunchApplication7 => new Key("LaunchApplication7");

        public static Key LaunchApplication8 => new Key("LaunchApplication8");

        public static Key LaunchApplication9 => new Key("LaunchApplication9");

        public static Key LaunchApplication10 => new Key("LaunchApplication10");

        public static Key LaunchApplication11 => new Key("LaunchApplication11");

        public static Key LaunchApplication12 => new Key("LaunchApplication12");

        public static Key LaunchApplication13 => new Key("LaunchApplication13");

        public static Key LaunchApplication14 => new Key("LaunchApplication14");

        public static Key LaunchApplication15 => new Key("LaunchApplication15");

        public static Key LaunchApplication16 => new Key("LaunchApplication16");

        public static Key LaunchApplication17 => new Key("LaunchApplication17");

        public static Key LaunchApplication18 => new Key("LaunchApplication18");

        public static Key LaunchApplication19 => new Key("LaunchApplication19");

        public static Key LaunchApplication20 => new Key("LaunchApplication20");
    }
}
