using System;

class DiskPhone
{
    public string PhoneNumber { get; set; }
    public char[] AvailableSymbols { get; set; }

    public DiskPhone(string phoneNumber, char[] availableSymbols)
    {
        PhoneNumber = phoneNumber;
        AvailableSymbols = availableSymbols;
    }

    public void MakeCall(string number)
    {
        Console.WriteLine($"Dialing {number}...");
    }

    public void ReceiveCall(string number)
    {
        Console.WriteLine($"Incoming call from {number}.");
    }
}

class ButtonPhone : DiskPhone
{
    public ButtonPhone(string phoneNumber, char[] availableSymbols) : base(phoneNumber, availableSymbols)
    {
        AvailableSymbols = new char[availableSymbols.Length + 2];
        Array.Copy(availableSymbols, AvailableSymbols, availableSymbols.Length);
        AvailableSymbols[availableSymbols.Length] = '*';
        AvailableSymbols[availableSymbols.Length + 1] = '#';
    }

    public new void ReceiveCall(string number)
    {
        base.ReceiveCall(number);
        Console.WriteLine($"Caller ID: {number}");
    }
}

class MonochromePhone : ButtonPhone
{
    public int Resolution { get; set; }
    public double ScreenSize { get; set; }
    public string Color { get; set; }

    public MonochromePhone(string phoneNumber, char[] availableSymbols, int resolution, double screenSize, string color) : base(phoneNumber, availableSymbols)
    {
        Resolution = resolution;
        ScreenSize = screenSize;
        Color = color;
    }

    public void SendSMS(string recipient, string message)
    {
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
    }

    public void ReceiveSMS(string sender, string message)
    {
        Console.WriteLine($"Received SMS from {sender}: {message}");
    }
}

class ColorPhone : MonochromePhone
{
    public int NumColors { get; set; }
    public bool HasSecondSim { get; set; }
    public string SecondNumber { get; set; }

    public ColorPhone(string phoneNumber, char[] availableSymbols, int resolution, double screenSize, string color, int numColors, bool hasSecondSim, string secondNumber) : base(phoneNumber, availableSymbols, resolution, screenSize, color)
    {
        NumColors = numColors;
        HasSecondSim = hasSecondSim;
        SecondNumber = secondNumber;
    }

    public void SendMMS(string recipient, string media)
    {
        Console.WriteLine($"Sending MMS to {recipient} with media: {media}");
    }

    public void ReceiveMMS(string sender, string media)
    {
        Console.WriteLine($"Received MMS from {sender} with media: {media}");
    }
}

class Smartphone : ColorPhone
{
    public bool TouchControl { get; set; }
    public int MaxTouches { get; set; }
    public int NumCameras { get; set; }

    public Smartphone(string phoneNumber, char[] availableSymbols, int resolution, double screenSize, string color, int numColors, bool hasSecondSim, string secondNumber, bool touchControl, int maxTouches, int numCameras) : base(phoneNumber, availableSymbols, resolution, screenSize, color, numColors, hasSecondSim, secondNumber)
    {
        TouchControl = touchControl;
        MaxTouches = maxTouches;
        NumCameras = numCameras;
    }

    public void TakePhoto()
    {
        Console.WriteLine("Taking a photo...");
    }

    public void RecordVideo()
    {
        Console.WriteLine("Recording a video...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        DiskPhone diskPhone = new DiskPhone("1234567890", new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        diskPhone.MakeCall("9876543210");
        diskPhone.ReceiveCall("9876543210");

        ButtonPhone buttonPhone = new ButtonPhone("1234567890", new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        buttonPhone.MakeCall("9876543210");
        buttonPhone.ReceiveCall("9876543210");

        MonochromePhone monochromePhone = new MonochromePhone("1234567890", new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, 480, 4.5, "Black");
        monochromePhone.SendSMS("9876543210", "Hello!");
        monochromePhone.ReceiveSMS("9876543210", "Hi!");

        ColorPhone colorPhone = new ColorPhone("1234567890", new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, 1080, 5.0, "Red", 16, true, "9876543210");
        colorPhone.SendMMS("9876543210", "image.jpg");
        colorPhone.ReceiveMMS("9876543210", "video.mp4");

        Smartphone smartphone = new Smartphone("1234567890", new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, 1440, 6.0, "Blue", 32, true, "9876543210", true, 5, 3);
        smartphone.TakePhoto();
        smartphone.RecordVideo();
    }
}
