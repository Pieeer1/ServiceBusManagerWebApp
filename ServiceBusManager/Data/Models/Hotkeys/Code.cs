namespace ServiceBusManager.Data.Models.Hotkeys
{
    public readonly struct Code : IPressable
    {
        private readonly string _value;

        public Code(string value)
        {
            _value = value;
        }

        public override string ToString() => _value;

        public static implicit operator string(Code code) => code._value;

        public static Code ControlLeft => new Code("ControlLeft");

        public static Code ControlRight => new Code("ControlRight");

        public static Code AltLeft => new Code("AltLeft");

        public static Code AltRight => new Code("AltRight");

        public static Code ShiftLeft => new Code("ShiftLeft");

        public static Code ShiftRight => new Code("ShiftRight");

        public static Code MetaLeft => new Code("MetaLeft");

        public static Code MetaRight => new Code("MetaRight");

        public static Code CapsLock => new Code("CapsLock");

        public static Code Tab => new Code("Tab");

        public static Code Escape => new Code("Escape");

        public static Code Delete => new Code("Delete");

        public static Code Backspace => new Code("Backspace");

        public static Code Insert => new Code("Insert");

        public static Code Enter => new Code("Enter");

        public static Code ArrowUp => new Code("ArrowUp");

        public static Code ArrowRight => new Code("ArrowRight");

        public static Code ArrowDown => new Code("ArrowDown");

        public static Code ArrowLeft => new Code("ArrowLeft");

        public static Code PageUp => new Code("PageUp");

        public static Code PageDown => new Code("PageDown");

        public static Code Home => new Code("Home");

        public static Code End => new Code("End");

        public static Code Space => new Code("Space");

        public static Code Num0 => new Code("Digit0");

        public static Code Num1 => new Code("Digit1");

        public static Code Num2 => new Code("Digit2");

        public static Code Num3 => new Code("Digit3");

        public static Code Num4 => new Code("Digit4");

        public static Code Num5 => new Code("Digit5");

        public static Code Num6 => new Code("Digit6");

        public static Code Num7 => new Code("Digit7");

        public static Code Num8 => new Code("Digit8");

        public static Code Num9 => new Code("Digit9");

        public static Code A => new Code("KeyA");

        public static Code B => new Code("KeyB");

        public static Code C => new Code("KeyC");

        public static Code D => new Code("KeyD");

        public static Code E => new Code("KeyE");

        public static Code F => new Code("KeyF");

        public static Code G => new Code("KeyG");

        public static Code H => new Code("KeyH");

        public static Code I => new Code("KeyI");

        public static Code J => new Code("KeyJ");

        public static Code K => new Code("KeyK");

        public static Code L => new Code("KeyL");

        public static Code M => new Code("KeyM");

        public static Code N => new Code("KeyN");

        public static Code O => new Code("KeyO");

        public static Code P => new Code("KeyP");

        public static Code Q => new Code("KeyQ");

        public static Code R => new Code("KeyR");

        public static Code S => new Code("KeyS");

        public static Code T => new Code("KeyT");

        public static Code U => new Code("KeyU");

        public static Code V => new Code("KeyV");

        public static Code W => new Code("KeyW");

        public static Code X => new Code("KeyX");

        public static Code Y => new Code("KeyY");

        public static Code Z => new Code("KeyZ");

        public static Code F1 => new Code("F1");

        public static Code F2 => new Code("F2");

        public static Code F3 => new Code("F3");

        public static Code F4 => new Code("F4");

        public static Code F5 => new Code("F5");

        public static Code F6 => new Code("F6");

        public static Code F7 => new Code("F7");

        public static Code F8 => new Code("F8");

        public static Code F9 => new Code("F9");

        public static Code F10 => new Code("F10");

        public static Code F11 => new Code("F11");

        public static Code F12 => new Code("F12");

        public static Code F13 => new Code("F13");

        public static Code F14 => new Code("F14");

        public static Code F15 => new Code("F15");

        public static Code F16 => new Code("F16");

        public static Code F17 => new Code("F17");

        public static Code F18 => new Code("F18");

        public static Code F19 => new Code("F19");

        public static Code F20 => new Code("F20");

        public static Code ContextMenu => new Code("ContextMenu");

        public static Code NumLock => new Code("NumLock");

        public static Code ScrollLock => new Code("ScrollLock");

        public static Code Equal => new Code("Equal");

        public static Code Minus => new Code("Minus");

        public static Code Slash => new Code("Slash");

        public static Code SemiColon => new Code("Semicolon");

        public static Code Quote => new Code("Quote");

        public static Code Comma => new Code("Comma");

        public static Code Period => new Code("Period");

        public static Code Backquote => new Code("Backquote");

        public static Code Backslash => new Code("Backslash");

        public static Code BracketLeft => new Code("BracketLeft");

        public static Code BracketRight => new Code("BracketRight");


    }
}
