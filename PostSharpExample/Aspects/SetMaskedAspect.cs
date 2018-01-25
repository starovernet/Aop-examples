using PostSharp.Aspects;
using PostSharp.Serialization;

namespace PostSharpExample.Aspects
{
    [PSerializable]
    public class SetMaskedAspect : LocationInterceptionAspect
    {
        public override void OnSetValue(LocationInterceptionArgs args)
        {
            var stringValue = args.Value as string;
            if (stringValue != null && stringValue.Length == 16)
            {
                args.Value = stringValue.Remove(4, 8).Insert(4, "********");
            }

            base.OnSetValue(args);
        }
    }
}