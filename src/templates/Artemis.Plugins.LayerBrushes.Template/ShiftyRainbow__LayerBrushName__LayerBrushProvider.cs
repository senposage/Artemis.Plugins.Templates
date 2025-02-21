using Artemis.Core;
using Artemis.Core.LayerBrushes;
using SkiaSharp;

public class ColorWavesBrush : LayerBrush<LayerBrushProperties>
{
    private float waveOffset;

    public ColorWavesBrush()
    {
        Properties.Speed.DefaultValue = 1.0f;
        Properties.Direction.DefaultValue = 1;
        Properties.Reactive.DefaultValue = false;
    }

    public override void Render(SKCanvas canvas, SKRect bounds, SKPaint paint)
    {
        float width = bounds.Width;
        float height = bounds.Height;

        for (int x = 0; x < width; x++)
        {
            float hue = ((x + waveOffset) * 10) % 360;
            paint.Color = SKColor.FromHsv(hue, 100, 100);
            canvas.DrawRect(x, 0, 1, height, paint);
        }
    }

    public override void Update(double deltaTime)
    {
        waveOffset += Properties.Speed * Properties.Direction * (float)deltaTime;
    }

    public override void OnKeyPressed(string key)
    {
        if (Properties.Reactive)
            waveOffset += 5;
    }
}
