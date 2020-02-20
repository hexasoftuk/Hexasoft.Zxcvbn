Hexasoft.Zxcvbn
===============

.NET port of Dropbox's [zxcvbn](https://github.com/dropbox/zxcvbn) JavaScript library, utilising [Jint](https://github.com/sebastienros/jint) engine. Inspired by [zxcvbn.net](https://github.com/darcythomas/zxcvbn.net).


Download
--------
Hexasoft.Zxcvbn is available as a NuGet package at [https://www.nuget.org/packages/Hexasoft.Zxcvbn](https://www.nuget.org/packages/Hexasoft.Zxcvbn)


Usage
-----
    using Hexasoft.Zxcvbn;
    
    ...
    
    var estimator = new ZxcvbnEstimator();
    var result = estimator.EstimateStrength("hunter2");
    
    if (result.Score < 3)
    {
        Console.WriteLine("Password is not strong enough");
        Console.WriteLine(result.Feedback.Warning);
        Console.WriteLine(string.Join(Environment.NewLine, result.Feedback.Suggestions));
    }



Version history
---------------

- 1.1.0 Updated zxcvbn to 4.4.2, updated tests to match
- 1.0.2 Fixed bugs with passwords containing `'` and `\` characters. Requires Jint 2.10.3
- 1.0.0 Initial public release, using zxcvbn 4.2.0
