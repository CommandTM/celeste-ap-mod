using Celeste;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monocle;
using System;
using System.Collections.Generic;

namespace Celeste.Mod.APCeleste;

// Written by beesnation
public class MessageDisplay : DrawableGameComponent
{
    public static MessageDisplay instance { get; private set; }

    public static readonly Vector2 TextCenter = new(960, 1000);
    public const float MessageTime = 3f;
    public const float FadeIn = 0.2f;
    public const float FadeOut = 0.5f;
    private readonly Queue<string> messageQueue = new();
    private string _text;
    private float _timeRemaining;

    public MessageDisplay(Game game) : base(game)
    {
        instance = this;
    }

    public void AddMessage(string text) => messageQueue.Enqueue(text);

    public override void Update(GameTime gameTime)
    {
        if (_timeRemaining <= 0)
        {
            if (messageQueue.Count == 0)
                return;
            _text = messageQueue.Dequeue();
            _timeRemaining = MessageTime;
        }

        _timeRemaining -= Engine.DeltaTime;
        if (_timeRemaining > 0)
            return;
        _text = "";
        _timeRemaining = 0f;
    }

    public override void Draw(GameTime gameTime)
    {
        if (string.IsNullOrEmpty(_text))
            return;

        // I took these settings from celestenet code, they're probably fine
        Monocle.Draw.SpriteBatch.Begin(
            SpriteSortMode.Deferred,
            BlendState.AlphaBlend,
            SamplerState.LinearClamp,
            DepthStencilState.None,
            RasterizerState.CullNone,
            null,
            Engine.ScreenMatrix);

        // [-1, 0) in fade in, (0, 1] in fade out
        float fadeValue = Math.Max(1 - _timeRemaining / FadeOut, 0)
                          + Math.Min((MessageTime - _timeRemaining) / FadeIn - 1, 0);
        float opacity = 1f - Math.Abs(fadeValue);

        ActiveFont.DrawOutline(
            _text,
            TextCenter + fadeValue * new Vector2(0.0f, -40f),
            new Vector2(0.5f, 0.5f),
            Vector2.One,
            Color.White * opacity,
            3f,
            Color.Black * opacity);
        Monocle.Draw.SpriteBatch.End();
    }
}
