using System.Reflection;

[assembly: AssemblyDescription("WCF support for Stugo.Glue DI")]
[assembly: AssemblyCompany("Stugo Ltd")]
[assembly: AssemblyProduct("Stugo.Glue.Wcf")]
[assembly: AssemblyCopyright("Copyright Stugo Ltd ©  2016")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
