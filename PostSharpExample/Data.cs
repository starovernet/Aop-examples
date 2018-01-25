using PostSharpExample.Aspects;

namespace PostSharpExample
{
    [SetMaskedAspect]
    public class Data
    {
        public string CardNumber { get; set; }
        public string OtherCardNumber { get; set; }
    }
}