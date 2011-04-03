// <auto-generated />
namespace IronJS.Tests.UnitTests.Sputnik.Conformance.NativeECMAScriptObjects.TheGlobalObject.FunctionPropertiesOfTheGlobalObject
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class EvalTests : SputnikTestFixture
    {
        public EvalTests()
            : base(@"Conformance\15_Native_ECMA_Script_Objects\15.1_The_Global_Object\15.1.2_Function_Properties_of_the_Global_Object\15.1.2.1_eval")
        {
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A1.1_T1.js", Description = "If x is not a string value, return x")]
        [TestCase("S15.1.2.1_A1.1_T2.js", Description = "If x is not a string value, return x")]
        public void IfXIsNotAStringValueReturnX(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A1.2_T1.js", Description = "If the eval function is called with some argument, then use a first argument")]
        public void IfTheEvalFunctionIsCalledWithSomeArgumentThenUseAFirstArgument(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.1.2.1")]
        [Category("ECMA 16")]
        [TestCase("S15.1.2.1_A2_T1.js", Description = "If the parse fails, throw a SyntaxError exception (but see also clause 16)")]
        [TestCase("S15.1.2.1_A2_T2.js", Description = "If the parse fails, throw a SyntaxError exception (but see also clause 16)", ExpectedException = typeof(Exception))]
        public void IfTheParseFailsThrowASyntaxErrorExceptionButSeeAlsoClause16(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.4")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A3.1_T1.js", Description = "If Result(3).type is normal and its completion value is a value V, then return the value V")]
        [TestCase("S15.1.2.1_A3.1_T2.js", Description = "If Result(3).type is normal and its completion value is a value V, then return the value V")]
        public void IfResult3TypeIsNormalAndItsCompletionValueIsAValueVThenReturnTheValueV(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.1")]
        [Category("ECMA 12.11")]
        [Category("ECMA 12.2")]
        [Category("ECMA 12.3")]
        [Category("ECMA 12.5")]
        [Category("ECMA 12.6.1")]
        [Category("ECMA 12.6.2")]
        [Category("ECMA 12.6.3")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A3.2_T1.js", Description = "If Result(3).type is normal and its completion value is empty, then return the value undefined")]
        [TestCase("S15.1.2.1_A3.2_T2.js", Description = "If Result(3).type is normal and its completion value is empty, then return the value undefined")]
        [TestCase("S15.1.2.1_A3.2_T3.js", Description = "If Result(3).type is normal and its completion value is empty, then return the value undefined")]
        [TestCase("S15.1.2.1_A3.2_T4.js", Description = "If Result(3).type is normal and its completion value is empty, then return the value undefined")]
        [TestCase("S15.1.2.1_A3.2_T5.js", Description = "If Result(3).type is normal and its completion value is empty, then return the value undefined")]
        [TestCase("S15.1.2.1_A3.2_T6.js", Description = "If Result(3).type is normal and its completion value is empty, then return the value undefined")]
        [TestCase("S15.1.2.1_A3.2_T7.js", Description = "If Result(3).type is normal and its completion value is empty, then return the value undefined")]
        [TestCase("S15.1.2.1_A3.2_T8.js", Description = "If Result(3).type is normal and its completion value is empty, then return the value undefined")]
        public void IfResult3TypeIsNormalAndItsCompletionValueIsEmptyThenReturnTheValueUndefined(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.13")]
        [Category("ECMA 12.7")]
        [Category("ECMA 12.8")]
        [Category("ECMA 12.9")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A3.3_T1.js", Description = "If Result(3).type is not normal, then Result(3).type must be throw. Throw Result(3).value as an exception")]
        [TestCase("S15.1.2.1_A3.3_T2.js", Description = "If Result(3).type is not normal, then Result(3).type must be throw. Throw Result(3).value as an exception")]
        [TestCase("S15.1.2.1_A3.3_T3.js", Description = "If Result(3).type is not normal, then Result(3).type must be throw. Throw Result(3).value as an exception")]
        [TestCase("S15.1.2.1_A3.3_T4.js", Description = "If Result(3).type is not normal, then Result(3).type must be throw. Throw Result(3).value as an exception")]
        public void IfResult3TypeIsNotNormalThenResult3TypeMustBeThrowThrowResult3ValueAsAnException(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.6.4")]
        [Category("ECMA 15.1.2.1")]
        [Category("ECMA 15.2.4.7")]
        [TestCase("S15.1.2.1_A4.1.js", Description = "The length property of eval has the attribute DontEnum")]
        public void TheLengthPropertyOfEvalHasTheAttributeDontEnum(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 11.4.1")]
        [Category("ECMA 15.1.2.1")]
        [Category("ECMA 15.2.4.5")]
        [TestCase("S15.1.2.1_A4.2.js", Description = "The length property of eval has the attribute DontDelete")]
        public void TheLengthPropertyOfEvalHasTheAttributeDontDelete(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A4.3.js", Description = "The length property of eval has the attribute ReadOnly")]
        public void TheLengthPropertyOfEvalHasTheAttributeReadOnly(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A4.4.js", Description = "The length property of eval is 1")]
        public void TheLengthPropertyOfEvalIs1(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.6.4")]
        [Category("ECMA 15.1.2.1")]
        [Category("ECMA 15.2.4.7")]
        [TestCase("S15.1.2.1_A4.5.js", Description = "The eval property has the attribute DontEnum")]
        public void TheEvalPropertyHasTheAttributeDontEnum(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A4.6.js", Description = "The eval property has not prototype property")]
        public void TheEvalPropertyHasNotPrototypeProperty(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 11.2.2")]
        [Category("ECMA 15.1.2.1")]
        [TestCase("S15.1.2.1_A4.7.js", Description = "The eval property can\'t be used as constructor")]
        public void TheEvalPropertyCanTBeUsedAsConstructor(string file)
        {
            RunFile(file);
        }
    }
}