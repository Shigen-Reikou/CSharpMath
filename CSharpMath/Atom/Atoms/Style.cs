namespace CSharpMath.Atom.Atoms;

///<summary>Style changes during rendering</summary>
public sealed class Style(LineStyle style) : MathAtom(string.Empty) {
    public LineStyle LineStyle { get; } = style;
    public override bool ScriptsAllowed => false;
    public new Style Clone(bool finalize) => (Style)base.Clone(finalize);
    protected override MathAtom CloneInside(bool finalize) => new Style(LineStyle);
    public override string DebugString =>
#pragma warning disable CA1308 // Normalize strings to uppercase
        @"\" + LineStyle.ToString().ToLowerInvariant() + "style";
#pragma warning restore CA1308 // Normalize strings to uppercase
    public bool EqualsStyle(Style otherStyle) =>
        EqualsAtom(otherStyle) && LineStyle == otherStyle.LineStyle;
    public override bool Equals(object? obj) => obj is Style s && EqualsStyle(s);
    public override int GetHashCode() =>
        unchecked(base.GetHashCode() + 107 * LineStyle.GetHashCode());
}