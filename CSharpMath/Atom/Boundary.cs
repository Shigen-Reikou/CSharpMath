namespace CSharpMath.Atom;

/// <summary>
/// A left atom -- Left and Right in TeX.
/// We don't need two since we track boundaries separately.
/// </summary>
public readonly struct Boundary(string nucleus) : IMathObject, System.IEquatable<Boundary> {
    public static Boundary Empty => default;
    public string? Nucleus { get; } = nucleus;
    public string DebugString => Nucleus ?? "(null)";
    public bool EqualsBoundary(Boundary boundary) => Nucleus == boundary.Nucleus;
    bool System.IEquatable<Boundary>.Equals(Boundary other) => EqualsBoundary(other);
    public override bool Equals(object? obj) => obj is Boundary b && EqualsBoundary(b);
    public override int GetHashCode() => Nucleus?.GetHashCode() ?? 0;
    public static bool operator ==(Boundary left, Boundary right) => left.EqualsBoundary(right);
    public static bool operator !=(Boundary left, Boundary right) => !left.EqualsBoundary(right);
    public override string ToString() => Nucleus ?? "(null)";
}