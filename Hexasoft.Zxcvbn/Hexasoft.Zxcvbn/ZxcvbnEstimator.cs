using Jint;
using System;
using System.IO;
using System.Reflection;

namespace Hexasoft.Zxcvbn
{
    public class ZxcvbnEstimator : IZxcvbnEstimator
    {
        private static Engine _engine = null;

        public ZxcvbnEstimator()
        {
            if (_engine == null)
            {
                _engine = new Engine(cfg => cfg.TimeoutInterval(new TimeSpan(0, 1, 0)));
                var assembly = Assembly.GetAssembly(typeof(ZxcvbnEstimator));

                using (var resource = assembly.GetManifestResourceStream(assembly.GetName().Name + ".js.zxcvbn.js"))
                using (var streamReader = new StreamReader(resource))
                {
                    string script = streamReader.ReadToEnd();
                    _engine.Execute(script);
                }
            }
        }

        public EstimationResult EstimateStrength(string password)
        {
            // Protection against overloading the CPU with long passwords
            if (password.Length > 128)
            {
                throw new ArgumentException("Password can't be longer than 128 characters");
            }

            password = password.Replace("\\","\\\\").Replace("'", "\\'");

            var result = _engine.Execute(string.Format("zxcvbn('{0}')", password)).GetCompletionValue().ToObject();
            var zxcvbnResult = EstimationResult.FromDynamic(result);
            return zxcvbnResult;
        }
    }
}
