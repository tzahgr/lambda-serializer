using System;
using System.IO;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LambdaSerializer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Expression<Func<string, bool>> exp = s => s.Contains("a");

            var p1 = ((MethodCallExpression)exp.Body).Object;

            var gsdfgdsf = ReferenceEquals(exp.Parameters[0], p1);

            var serializer = new ExpressionSerializer();
            var deserializer = new ExpressionDeserializer();
            using (var stream = new MemoryStream(1000))
            {
                serializer.Serialize(exp, stream);
                stream.Position = 0;

                Expression<Func<string, bool>> exp2 = deserializer.Deserialize<Expression<Func<string, bool>>>(stream);
                var func = exp2.Compile();

                Assert.IsTrue(func("sab"));
                Assert.IsFalse(func("qqq"));
            }
        }
    }
}
