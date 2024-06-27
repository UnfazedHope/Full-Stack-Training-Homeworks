namespace Assignment3;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;
    
    //Constructor
    public Color(int red, int green, int blue, int alpha)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }
    
    // Constructor with alpha defaulting to 255 (opaque)
    public Color(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = 255;
    }
    
    // get and set red
    public int GetRed() { return red; }
    public void SetRed(int red) { this.red = red; }

    // get and set green
    public int GetGreen() { return green; }
    public void SetGreen(int green) { this.green = green; }

    // get and set blue
    public int GetBlue() { return blue; }
    public void SetBlue(int blue) { this.blue = blue; }

    // get and set alpha
    public int GetAlpha() { return alpha; }
    public void SetAlpha(int alpha) { this.alpha = alpha; }
    
    // To get the grayscale value for the color(way given in problem)
    public int GetGrayscale()
    {
        return (red + green + blue) / 3;
    }
}