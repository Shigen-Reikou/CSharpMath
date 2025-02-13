namespace CSharpMath.Atom.Atoms;

/// <summary>AMSMath class 4: Left/Opening delimiter, e.g. (, [, {, \langle</summary>
public sealed class Open(string nucleus) : MathAtom(nucleus) {
    public override bool ScriptsAllowed => true;
    public new Open Clone(bool finalize) => (Open)base.Clone(finalize);
    protected override MathAtom CloneInside(bool finalize) => new Open(Nucleus);
}