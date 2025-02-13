using System.Collections.Generic;
using System.Linq;

namespace CSharpMath.Display;

public class AttributedString<TFont, TGlyph> where TFont: FrontEnd.IFont<TGlyph> {
    private readonly List<AttributedGlyphRun<TFont, TGlyph>> _runs;
    public AttributedString(IEnumerable<AttributedGlyphRun<TFont, TGlyph>>? runs = null) {
        _runs = runs?.ToList() ?? [];
        FuseMatchingRuns();
    }
    public void SetFont(TFont font) { foreach (var r in _runs) r.Font = font; }
    private string Text => string.Concat(Runs.Select(r => r.Text));
    public int Length => _runs.Sum(r => r.Length);
    public IEnumerable<AttributedGlyphRun<TFont, TGlyph>> Runs => _runs;

    private void FuseMatchingRuns() {
        for (int i = _runs.Count - 1; i > 0; i--)
            TryFuseRunAt(i);
    }

    private void TryFuseRunAt(int index) {
        if (index <= 0 || !_runs[index].AttributesMatch(_runs[index - 1])) return;
        _runs[index - 1].GlyphInfos.AddRange(_runs[index].GlyphInfos);
        _runs[index - 1].Text.Append(_runs[index].Text);
        _runs.RemoveAt(index);
    }
    public void AppendAttributedString(AttributedString<TFont, TGlyph> other) {
        _runs.AddRange(other.Runs);
        FuseMatchingRuns();
    }
    internal void AppendGlyphRun(AttributedGlyphRun<TFont, TGlyph> run) {
        _runs.Add(run);
        TryFuseRunAt(_runs.Count - 1);
    }
    public void Clear() => _runs.Clear();
    public override string ToString() => "AttributedString " + Text;
}