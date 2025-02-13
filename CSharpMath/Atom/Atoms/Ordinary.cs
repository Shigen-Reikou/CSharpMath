namespace CSharpMath.Atom.Atoms;

/// <summary>AMSMath class 0: Simple/Ordinary (noun), e.g. \infty</summary>
public sealed class Ordinary(string nucleus) : MathAtom(nucleus) {
    public override bool ScriptsAllowed => true;
    public new Ordinary Clone(bool finalize) => (Ordinary)base.Clone(finalize);
    protected override MathAtom CloneInside(bool finalize) => new Ordinary(Nucleus);
}